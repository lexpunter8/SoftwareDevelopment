<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class MainController
    {
        private MainController()
        {
            TrafficLights = new List<JsonTrafficLight>();
            WebsocketClient = new WebsocketClient("ws://127.0.0.1:9090");
        }

        private static MainController myInstance;
        public WebsocketClient WebsocketClient { get; set; }

        public static MainController Instance
        {
            get
            {
                if (myInstance == null)
                    myInstance = new MainController();
                return myInstance;
            }
        }

        public List<JsonTrafficLight> TrafficLights { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class MainController
    {
        private MainController()
        {
            TrafficLights = new List<JsonTrafficLight>();
            WebsocketClient = new WebsocketClient("ws://127.0.0.1:9090");
        }

        private static MainController myInstance;
        public WebsocketClient WebsocketClient { get; set; }

        public static MainController Instance
        {
            get
            {
                if (myInstance == null)
                    myInstance = new MainController();
                return myInstance;
            }
        }

        public List<JsonTrafficLight> TrafficLights { get; set; }
    }
}
>>>>>>> 04b101eca450f9fc4a90d2653ee78f5b943cbd5e
