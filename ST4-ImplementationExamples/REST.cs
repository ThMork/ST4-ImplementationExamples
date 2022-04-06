using Newtonsoft.Json;
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

        //init REST
        private RestClient client = new RestClient("http://localhost:8082");
        private RestRequest request = new RestRequest("v1/status/");

        //runner
        public async Task RunExample()
        {
            GetStatus();
            PutOperation();
        }

        //test PUT request
        public async void PutOperation()
        {
            //build json content string
            var msg = new OperationMessage();
            msg.State = 1;
            msg.Programname = "MoveToAssemblyOperation";
            var json = JsonConvert.SerializeObject(msg);

            //new request obj
            RestRequest putRequest = request;

            //add body
            putRequest.AddJsonBody(msg);
            
            //define content format
            putRequest.RequestFormat = DataFormat.Json;
            

            var response = await client.PutAsync(putRequest);
            Console.WriteLine("PUT request response" + response.Content);

            
        }
        //test status method
        public async void GetStatus()
        {
            //GET request
            RestResponse response = await client.GetAsync(request);

            Console.WriteLine("GET request response: " + response.Content);        
        }


    }

    //class for json serialization
    public class OperationMessage
    {
        [JsonProperty(PropertyName = "Program name")]
        public string Programname { get; set; }
        public int State { get; set; }
    }
}
