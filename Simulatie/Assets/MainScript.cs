using Assets;
using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
        
        //Texture2D SpriteTexture = new Texture2D(100, 100);
        //var currentDir = System.Environment.CurrentDirectory; 
        //SpriteTexture = LoadTexture(Path.Combine(currentDir, "Assets/Square.png"));
        //Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), 100);
        
        //GameObject go = new GameObject("Test");
        //SpriteRenderer render = go.AddComponent<SpriteRenderer>();
        //render.sprite = Resources.Load<Sprite>("Square");
        //go.transform.position = new Vector2(0, 0);
        //
        //FollowPathObject path = go.AddComponent<FollowPathObject>();
        //path.speed = 5;
        //path.pathName = "A9path";
        //path.totationspeed = 5;
        //go.AddComponent<BoxCollider2D>();
        //go.AddComponent<TrafficLightInteractable>();
    }
	private IWebsocketResponseHandler responseHandler { get; set; }
	// Update is called once per frame
	void Update () {
		
	}

    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    private void OnApplicationQuit()
    {
        MainController.Instance.WebsocketClient.Close();
    }
}
