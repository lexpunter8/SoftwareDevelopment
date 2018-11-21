using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathObject : MonoBehaviour {

    public FollowPathScript pathToFollow;

    public int currentWaypointId = 1;
    public float speed;
    private float reachDistance = 1.0f;
    public float totationspeed = 5.0f;
    public string pathName;

    Vector2 lastPosition;
    Vector2 currentPosition;
    
    

    // Use this for initialization
    void Start () {
        pathToFollow = GameObject.Find(pathName).GetComponent<FollowPathScript>();
        transform.position = pathToFollow.wayPoints[0].position;
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 nextPath = pathToFollow.wayPoints[currentWaypointId].position;
        float distance = Vector2.Distance(nextPath, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, nextPath, Time.deltaTime * speed);

        //Quaternion rotation = Quaternion.LookRotation(nextPath - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * totationspeed);

        if (distance <= reachDistance)
        {
            currentWaypointId++;
            if (currentWaypointId >= pathToFollow.wayPoints.Count)
                Destroy(gameObject);
        }
	}


}
