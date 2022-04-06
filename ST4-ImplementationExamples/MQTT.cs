using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST4_ImplementationExamples
{
    public class MQTT
    {
        //construct
        public MQTT()
        {
        }

        //MQTT vars
        MqttFactory factory;
        IMqttClient client;
        IMqttClientOptions options;

        private async Task Connect()
        {
            //init vars
            factory = new MqttFactory();
            client = factory.CreateMqttClient();
            options = new MqttClientOptionsBuilder()
                .WithClientId("")
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(true)
                .Build();

            //on established connection
            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("Connected.");
                SubscribeToTopic("emulator/status");
                SubscribeToTopic("emulator/echo");
            });

            //on lost connection
            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconnected.");
            });

            //on receive message on subscribed topic
            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine($"MQTT Subscribed message: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} on topic: {e.ApplicationMessage.Topic}");
            });

            //connect
            await client.ConnectAsync(options);
        }

        //subscribe method
        public async void SubscribeToTopic(string input)
        {
            //printout
            Console.WriteLine("Subscribing to : " + input);

            //define topics
            var topic = new MqttTopicFilterBuilder()
                .WithTopic(input)
                .Build();

            //subscribe
            await client.SubscribeAsync(topic);
        }

        //publish method
        public async Task PublishOnTopic(string msg, string topic)
        {
            await client.PublishAsync(msg, topic);
        }

        //runner
        public async Task RunExample()
        {
            await Connect();

            var msg = new MQTTMessage();
            msg.ProcessID = 9999;

            Console.WriteLine("Jsonconvert: " + JsonConvert.SerializeObject(msg));
            await PublishOnTopic("emulator/operation", JsonConvert.SerializeObject(msg));
        }
    }
    public class MQTTMessage
    {
        public int ProcessID { get; set; }
    }
}

