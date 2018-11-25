<<<<<<< HEAD
﻿using Assets.Interfaces;
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
        public WebsocketClient(string url)
        {
            myWebSocket = new WebSocket(url);
            myWebSocket.Opened += MyWebSocket_Opened;
            myWebSocket.Closed += MyWebSocket_Closed;
            myWebSocket.DataReceived += MyWebSocket_DataReceived;
            myWebSocket.Error += MyWebSocket_Error;
            myWebSocket.MessageReceived += MyWebSocket_MessageReceived;

            myWebSocket.Open();
            IsOpen = true;
            
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
            IsOpen = false;
        }

        private void MyWebSocket_Opened(object sender, EventArgs e)
        {
            IsOpen = true;
        }

        public void Send(TrafficLight trafficLight)
        {
            List<string> lights = new List<string>();
            lights.Add(trafficLight.id);
            string json = JsonConvert.SerializeObject(lights);
            Send(json);
        }

        internal void Close()
        {
            myWebSocket.Close();
        }

        public void Send(IEnumerable<TrafficLight> trafficLight)
        {
            string json = JsonConvert.SerializeObject(trafficLight);
            Send(json);
        }
        public void Send(string message)
        {
            myWebSocket.Send(message);
        }
    }
}
=======
﻿using Assets.Interfaces;
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
        public WebsocketClient(string url)
        {
            myWebSocket = new WebSocket(url);
            myWebSocket.Opened += MyWebSocket_Opened;
            myWebSocket.Closed += MyWebSocket_Closed;
            myWebSocket.DataReceived += MyWebSocket_DataReceived;
            myWebSocket.Error += MyWebSocket_Error;
            myWebSocket.MessageReceived += MyWebSocket_MessageReceived;

            myWebSocket.Open();
            IsOpen = true;
            
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
            IsOpen = false;
        }

        private void MyWebSocket_Opened(object sender, EventArgs e)
        {
            IsOpen = true;
        }

        public void Send(TrafficLight trafficLight)
        {
            List<string> lights = new List<string>();
            lights.Add(trafficLight.id);
            string json = JsonConvert.SerializeObject(lights);
            Send(json);
        }

        internal void Close()
        {
            myWebSocket.Close();
        }

        public void Send(IEnumerable<TrafficLight> trafficLight)
        {
            string json = JsonConvert.SerializeObject(trafficLight);
            Send(json);
        }
        public void Send(string message)
        {
            myWebSocket.Send(message);
        }
    }
}
>>>>>>> 04b101eca450f9fc4a90d2653ee78f5b943cbd5e
