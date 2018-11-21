using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Linq;
using System;

public class TrafficLight : MonoBehaviour {

    public int timer;
    public Enums.LightStatus status = Enums.LightStatus.none;
    public string id;
    private Renderer render;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
        UpdateColor();
	}

    private Color GetColor(Enums.LightStatus status)
    {
        if (status == Enums.LightStatus.green)
            return Color.green;
        if (status == Enums.LightStatus.red)
            return Color.red;
        if (status == Enums.LightStatus.orange)
            return Color.yellow;

        return Color.white;

    }

    private void UpdateColor()
    {
        Color col = GetColor(status);
        var test1 = render.material.color;
        render.material.color = GetColor(status);
        var test = render.material.color;
    }

    // Update is called once per frameD:\SoftwareDevelopment1\SoftwareDevelopment\Assets\MainController.cs
    void Update () {
        JsonTrafficLight bject = null;
        foreach (var light in MainController.Instance.TrafficLights)
        {
            string lId = light.light;
            bool right = lId == id;
            if (right)
                bject = light;
        }
        Enums.LightStatus newStatus = bject.status;
        if (newStatus != status)
        {
            status = newStatus;
            UpdateColor();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MainController.Instance.WebsocketClient.Send(this);
    }
}
