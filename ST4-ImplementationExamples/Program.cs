using System;

namespace ST4_ImplementationExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            //REST
            REST rest = new REST();
            _ = rest.RunExample();

            //MQTT
            MQTT mqtt = new MQTT();
            _ = mqtt.RunExample();

            //SOAP
            SOAP soap = new SOAP();
            _ = soap.RunExample();

            Console.ReadKey();
        }
    }
}
