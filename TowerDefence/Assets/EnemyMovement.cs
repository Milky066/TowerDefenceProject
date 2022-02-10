using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMovement : MonoBehaviour
{
    //Enemy AI
    public float speed = 5f;
    private Transform target;
    private int waypointIndex = 0;
    public float targetBound = 0.05f;
    void Start()
    {
        target = EnemyWaypoint.Waypoints[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if(Vector3.Distance(transform.position, target.position)<targetBound)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {

        if(waypointIndex<EnemyWaypoint.Waypoints.Length)
        {
            target = EnemyWaypoint.Waypoints[waypointIndex];
            waypointIndex++;
        }
        else
        {
            EndPath();
        }

    }
    private void EndPath()
    {
        PlayerStats playerStat = FindObjectOfType<PlayerStats>();
        playerStat.health -= 10;
        playerStat.healthSlider.value = playerStat.health;
        Destroy(gameObject);
    }


}
