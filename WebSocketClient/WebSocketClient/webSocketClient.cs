using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebSocket4Net;
using System.Linq;

namespace WebSocketClient
{
    public class WebSocketClient
    {
        public WebSocketClient(string url)
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

        private void MyWebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            myData = e.Message.ToString();
            //if (!myData.StartsWith("{"))
            //    return;
            //TrafficLight trafficLight = JsonConvert.DeserializeObject<TrafficLight>(myData);
            //TrafficLight lightToChange = myLights.FirstOrDefault(l => l.Light.Equals(trafficLight.Light, StringComparison.CurrentCultureIgnoreCase));
            //lightToChange.Status = trafficLight?.Status;
        }

        public bool IsOpen { get; set; }
        private string myData { get; set; }
        private WebSocket myWebSocket { get; set; }
        private List<TrafficLight> myLights { get; } = new List<TrafficLight>
        {
            new TrafficLight{Light = "A1", Status = "Green", Timer = 0},
            new TrafficLight{Light = "B1", Status = "Red", Timer = 0},
        };
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
            myData = "Open!";
            IsOpen = true;
        }

        private void ShowLights()
        {
            foreach (TrafficLight light in myLights)
            {
                Console.WriteLine($"Light: {light.Light}{Environment.NewLine}Staus: {light.Status}{Environment.NewLine}");
            }
        }

        public void Start()
        {
            ShowLights();
            while(IsOpen)
            {
                if (!string.IsNullOrEmpty(myData))
                {
                    Console.WriteLine(myData);

                    if (myData.Equals("close"))
                    {
                        myWebSocket.Close();
                        break;
                    }

                    string response = Console.ReadLine();
                    if (response.Equals("json"))
                    {
                        TrafficLight tl = new TrafficLight {
                            Light = "A8",
                            Status = "Red",
                            Timer = 0
                        };
                        response = JsonConvert.SerializeObject(tl);
                    }
                    if (response.Equals("show"))
                    {
                        ShowLights();
                        continue;
                    }
                    myWebSocket.Send(response);
                    myData = string.Empty;


                }
            }
        }

    }
}
