using Assets.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;

namespace Assets
{
    public class WebsocketClient
    {
        public WebsocketClient(string url, IWebsocketResponseHandler responseHandler)
        {
            Console.WriteLine("WebsocketClient");
            myWebSocket = new WebSocket(url);
            myWebSocket.Opened += MyWebSocket_Opened;
            myWebSocket.Closed += MyWebSocket_Closed;
            myWebSocket.DataReceived += MyWebSocket_DataReceived;
            myWebSocket.Error += MyWebSocket_Error;
            myWebSocket.MessageReceived += MyWebSocket_MessageReceived;

            myWebSocket.Open();
            IsOpen = true;

            myResponseHandler = responseHandler;
        }

        private IWebsocketResponseHandler myResponseHandler {get;set;}
        private void MyWebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                List<JsonTrafficLight> trafficLights = new List<JsonTrafficLight>(JsonConvert.DeserializeObject<JsonTrafficLight[]>(e.Message));
                trafficLights.ForEach(tl =>
                {
                    JsonTrafficLight current = MainController.Instance.TrafficLights.FirstOrDefault(l => l.light.Equals(tl.light));
                    current.status = tl.status;
                });
            } catch (Exception excep)
            {
                Console.WriteLine(excep);

            }
            
        }

        public bool IsOpen { get; set; }
        private string myData { get; set; }
        private WebSocket myWebSocket { get; set; }
        
        private void MyWebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }

        private void MyWebSocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            myData = e.Data.ToString();
        }

        private void MyWebSocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Closed!");
            IsOpen = false;
        }

        private void MyWebSocket_Opened(object sender, EventArgs e)
        {
            IsOpen = true;
        }
    }
}
