using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ST4_ImplementationExamples
{
    public class REST
    {
        //construct
        public REST() 
        {
        }

        //runner
        public async Task RunExample()
        {
            //connect
            RestClient client = new RestClient("http://localhost:8082");

            //request
            RestRequest request = new RestRequest("v1/status/");

            //result
            RestResponse response = await client.GetAsync(request); 
            
            //printout
            Console.WriteLine("REST GET request response: " + response.Content);
        }
    }
}
