using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using IntegrationApp.Models;

namespace IntegrationApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");

            ContentModel contentModel = new ContentModel
            {
                content = "ye wut .net test"
            };
            
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["content"] = contentModel.content;

                var response = wb.UploadValues(Configs.discordWebHook, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                Console.WriteLine(responseInString);
            }
            
            Console.WriteLine("Finished!");
        }
    }
}