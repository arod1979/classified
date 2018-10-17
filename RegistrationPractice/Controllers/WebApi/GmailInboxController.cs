using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistrationPractice.Classes;
using RegistrationPractice.Classes.Loggers;

namespace RegistrationPractice.Controllers.WebApi
{

    public class GmailServiceHandler
    {
        static GmailServiceHandler _instance;
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "awolr.com";
        private LoggerWrapper loggerwrapper = new LoggerWrapper();

        public static GmailServiceHandler Instance
        {
            get { return _instance ?? (_instance = new GmailServiceHandler()); }
        }
        private GmailServiceHandler()
        {
            UserCredential credential = null;

            try
            {

                using (var stream =
                    new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/credentials.json"), FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Web.HttpContext.Current.Server.MapPath("~/token.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging(e.ToString());
            }
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            this.service = service;
        }

        public string Message { get; set; }

        public GmailService service { get; set; }
    }


    public class GmailInboxController : ApiController
    {
        LoggerWrapper loggerWrapper = new LoggerWrapper();
        public HttpResponseMessage Post([FromBody] Message email)
        {
            
            if (email != null)
            {
                var data = Encoding.UTF8.GetString(Convert.FromBase64String(email.message.data));
                JObject historyidobj = JObject.Parse(data);
                string historyid = (string)historyidobj["historyId"];
                string emailaddress = (string)historyidobj["emailAddress"];
                //Logger.Write(Encoding.UTF8.GetString(Convert.FromBase64String(email.message.data)));
                loggerWrapper.PickAndExecuteLogging(emailaddress);
            }

            var gmailservicehandler = GmailServiceHandler.Instance;
            var gmailservice = gmailservicehandler.service;

            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        public class Message
        {
            public MessageInside message { get; set; }
            public string subscription { get; set; }
        }

        public class MessageInside
        {
            public string data { get; set; }
            public string messageId { get; set; }
            public string message_id { get; set; }
            public string publishTime { get; set; }
            public string publish_time { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
