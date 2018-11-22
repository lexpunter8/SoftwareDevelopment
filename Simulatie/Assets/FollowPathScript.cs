using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScript : MonoBehaviour {

    public List<Transform> wayPoints = new List<Transform>();
    Transform[] theArray;
    public Color rayColor = Color.white;

    void OnDrawGizmos()
    {
        Debug.Log("gismos");
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        wayPoints.Clear();

        foreach (Transform waypoint in theArray)
        {

            if (waypoint != this.transform)
            {
                wayPoints.Add(waypoint);
            }
        }

        for (int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 position = wayPoints[i].position;
            if (i > 0)
            {
                Vector3 previous = wayPoints[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }

    }
}
