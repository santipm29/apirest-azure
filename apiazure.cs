using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;


namespace Company.Function
{
 
    public static class apiazure
    {
        [FunctionName("apiazure")]
        public static Object Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
           
            string URL = "https://jsonplaceholder.typicode.com/photos?_limit=5";
            var json = new WebClient().DownloadString(URL);
            dynamic data = JsonConvert.DeserializeObject(json);
        

            return data != null
                ? (ActionResult)new OkObjectResult(data)
                : new BadRequestObjectResult("error al obtener resultado");
        }
    }
}
