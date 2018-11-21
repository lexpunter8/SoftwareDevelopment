using System;
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
        }

        private static MainController myInstance;

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
