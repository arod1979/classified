using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Services.Description;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RegistrationPractice.Classes;
using RegistrationPractice.Classes.Loggers;
using RegistrationPractice.ViewModels;

namespace RegistrationPractice.Controllers.WebApi
{

    public class GmailServiceHandler
    {
        static GmailServiceHandler _instance;
        static string[] Scopes = {"https://mail.google.com/",
    "https://www.googleapis.com/auth/pubsub"};
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

                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                this.service = service;
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging(e.ToString());
            }
        }

        public string Message { get; set; }

        public GmailService service { get; set; }
    }


    public class GmailInboxController : ApiController
    {
        LoggerWrapper loggerWrapper = new LoggerWrapper();
        public HttpResponseMessage Post([FromBody] Message email)
        {
            try
            {
                loggerWrapper.PickAndExecuteLogging("here");
                string historyid = null;
                string emailaddress = null;
                if (email != null)
                {
                    var data = Encoding.UTF8.GetString(Convert.FromBase64String(email.message.data));
                    JObject historyidobj = JObject.Parse(data);
                    historyid = (string)historyidobj["historyId"];
                    emailaddress = (string)historyidobj["emailAddress"];

                    loggerWrapper.PickAndExecuteLogging(historyid);
                }

                //var gmailservicehandler = GmailServiceHandler.Instance;
                //var gmailservice = gmailservicehandler.service;
                //Google.Apis.Gmail.v1.Data.Message message = await gmailservice.Users.Messages.Get("admin@awolr.com", email.message.messageId).ExecuteAsync();
                //if (email != null)
                //{
                //    String from = "";
                //    String date = "";
                //    String subject = "";
                //    String body = "";
                //    //loop through the headers and get the fields we need...
                //    foreach (var mParts in message.Payload.Headers)
                //    {
                //        if (mParts.Name == "Date")
                //        {
                //            date = mParts.Value;
                //        }
                //        else if (mParts.Name == "From")
                //        {
                //            from = mParts.Value;
                //        }
                //        else if (mParts.Name == "Subject")
                //        {
                //            subject = mParts.Value;
                //        }
                //        if (date != "" && from != "")
                //        {
                //            if (message.Payload.Parts == null && message.Payload.Body != null)
                //                body = DecodeBase64String(message.Payload.Body.Data);
                //            //else
                //            //body = GetNestedBodyParts(message.Payload.Parts, "");
                //            //now you have the data you want....
                //        }
                //    }
                //    //Console.Write(body);
                //    Console.WriteLine("{0}  --  {1}  -- {2}", subject, date, message.Id);
                //    Console.ReadKey();
                //}
                //List<History> historylist = null;
                //ulong historyid_start_conversionresult;
                //try
                //{
                //    historyid_start_conversionresult = Convert.ToUInt64(historyid);
                //    historylist = ListHistory(gmailservice, "admin@awolr.com", historyid_start_conversionresult);
                //}
                //catch (OverflowException)
                //{
                //    Console.WriteLine("{0} is outside the range of the UInt64 type.", historyid);
                //}
                //if (historylist != null)
                //{
                //    loggerWrapper.PickAndExecuteLogging("Was able to retrieve history" + historylist.ToString());
                //}
            }
            catch (Exception e)
            {
                loggerWrapper.PickAndExecuteLogging("general error" + e.ToString());
            }
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            loggerWrapper.PickAndExecuteLogging("got here");
            return response;
        }

        /// <summary>
        /// List History of all changes to the user's mailbox.
        /// </summary>
        /// <param name="service">Gmail API service instance.</param>
        /// <param name="userId">User's email address. The special value "me"
        /// can be used to indicate the authenticated user.</param>
        /// <param name="startHistoryId">Only return changes at or after startHistoryId.</param>
        public static List<History> ListHistory(GmailService service, String userId, ulong startHistoryId)
        {
            List<History> result = new List<History>();
            UsersResource.HistoryResource.ListRequest request = service.Users.History.List(userId);
            request.StartHistoryId = startHistoryId;

            do
            {
                try
                {
                    ListHistoryResponse response = request.Execute();
                    if (response.History != null)
                    {
                        result.AddRange(response.History);
                    }
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return result;
        }


        static String DecodeBase64String(string s)
        {
            var ts = s.Replace("-", "+");
            ts = ts.Replace("_", "/");
            var bc = Convert.FromBase64String(ts);
            var tts = Encoding.UTF8.GetString(bc);

            return tts;
        }

        //static String GetNestedBodyParts(IList<MessagePart> part, string curr)
        //{
        //    string str = curr;
        //    if (part == null)
        //    {
        //        return str;
        //    }
        //    else
        //    {
        //        foreach (var parts in part)
        //        {
        //            if (parts.Parts == null)
        //            {
        //                if (parts.Body != null && parts.Body.Data != null)
        //                {
        //                    var ts = DecodeBase64String(parts.Body.Data);
        //                    str += ts;
        //                }
        //            }
        //            else
        //            {
        //                return GetNestedBodyParts(parts.Parts, str);
        //            }
        //        }

        //        return str;
        //    }
        //}







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
