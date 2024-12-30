using Microsoft.Rest;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALQ2GenerateCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var service = new CrmServiceClient(connectionString);
            if (!service.IsReady)
            {
                Console.WriteLine("Service not ready");
                Console.ReadKey();
                return;
            }

            //var appointment = new Entity("appointment")
            //{
            //    ["subject"] = "Customer Meeting",
            //    ["scheduledstart"] = DateTime.Now.AddHours(1),
            //    ["scheduledend"] = DateTime.Now.AddHours(2),
            //    ["location"] = "Online",
            //    ["description"] = "Discuss customer requirements and project details."
            //};

            //var createRequest = new CreateRequest { Target = appointment };
            //var createResponse = (CreateResponse)service.Execute(createRequest);

            //Console.WriteLine("Done! Message: {0}", createResponse.ToString());


            QueryExpression query = new QueryExpression("knowledgearticle")
            {
                ColumnSet = new ColumnSet("title", "articlepublicnumber", "createdon")
            };

            EntityCollection result = service.RetrieveMultiple(query);

            foreach (Entity article in result.Entities)
            {
                Console.WriteLine($"Title: {article["title"]}, Article Number: {article["articlepublicnumber"]}, Created On: {article["createdon"]}");
            }

            Console.ReadKey();
        }
    }
}
