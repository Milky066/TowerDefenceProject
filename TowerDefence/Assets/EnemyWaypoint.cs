using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{
    public static Transform[] Waypoints;

    void Start()
    {
        Waypoints = new Transform[transform.childCount];
        for (int i=0;i<transform.childCount;i++)
        {
            Waypoints[i] = transform.GetChild(i);
        }
    }
}
