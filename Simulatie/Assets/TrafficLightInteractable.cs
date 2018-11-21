using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class TrafficLightInteractable : MonoBehaviour
    {
        private TrafficLight trafficLight = null;
        private FollowPathObject followPathObject;
        private float speed;

        void Start()
        {
            followPathObject = GetComponent<FollowPathObject>();
            speed = followPathObject.speed;
        }


        void Update()
        {
            if (trafficLight != null)
            {
                if (trafficLight.status != Enums.LightStatus.green)
                {
                    followPathObject.speed = 0;
                }
                else
                    followPathObject.speed = speed;
            }
            
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            trafficLight = collision.gameObject.GetComponent<TrafficLight>();
        }


    }
}
