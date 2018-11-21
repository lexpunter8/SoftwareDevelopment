using Assets;
using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        responseHandler = new WebsocketResponseHandler();
        myWebsocketClient = new WebsocketClient("ws://141.252.216.175:8887", responseHandler);
        List<TrafficLight> objects = new List<TrafficLight>(FindObjectsOfType<TrafficLight>());
        objects.ForEach(o =>
        {
            JsonTrafficLight newLight = new JsonTrafficLight
            {
                light = o.id,
                status = o.status,
                timer = o.timer
            };
            MainController.Instance.TrafficLights.Add(newLight);
        });

	}
	private WebsocketClient myWebsocketClient { get; set; }
	private IWebsocketResponseHandler responseHandler { get; set; }
	// Update is called once per frame
	void Update () {
		
	}
}
