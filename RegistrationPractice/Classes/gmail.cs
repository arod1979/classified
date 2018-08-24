using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using RegistrationPractice.Classes.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RegistrationPractice.Classes;


namespace RegistrationPractice.Classes
{
    public static class gmail
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json

        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        public static void RegisterWatch()
        {
            Logger.Write("apple");
            return;

            UserCredential credential;
            try
            {
                string path = Path.Combine(System.Web.HttpContext.Current.Server.
             MapPath(
             "credentials.json"
             )
             );

                string token = Path.Combine(System.Web.HttpContext.Current.Server.
             MapPath(
             "token.json"
             )
             );


                using (var stream =
                    new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "admin@awolr.com",
                        CancellationToken.None,
                        new FileDataStore(token, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                WatchRequest body = new WatchRequest()
                {
                    //TopicName = "projects/awolr-213414/topics/awolr",
                    TopicName = "projects/my-project-1534261658850/topics/awolr",
                    LabelIds = new[] { "INBOX" }
                };
                string userId = "admin@awolr.com";
                UsersResource.WatchRequest watchRequest = service.Users.Watch(body, userId);
                WatchResponse test = watchRequest.Execute();










            }
            catch (Exception e)
            {

            }
        }
    }
}