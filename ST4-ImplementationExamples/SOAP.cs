using System;
using System.Threading.Tasks;
using WarehouseService;

namespace ST4_ImplementationExamples
{
    public class SOAP
    {
        public SOAP()
        {
        }

        //runner
        public async Task RunExample()
        {
            //instatiate web service from 'Connected Services' reference through Visual Studio tool
            var service = new EmulatorServiceClient();

            //print response of GetInventoryAsync()
            var response = await service.GetInventoryAsync();
            Console.WriteLine(response);
        }
        
    }
}
