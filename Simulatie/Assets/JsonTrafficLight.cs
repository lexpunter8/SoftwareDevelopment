using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class JsonTrafficLight
    {
        public string light { get; set; }
        public Enums.LightStatus status { get; set; }
        public int timer { get; set; }
    }
}
