using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTower : MonoBehaviour
{
    public Transform target;
    public float range = 10f;
    private GameObject nearestEnemy = null;

    public float fireRate = 10.0f;
    private float fireCountdown = 0.0f;
    public int fireDamge = 10;
    public float turnSpeed = 8f;

    public GameObject flameObject;

    public string enemyTag = "Enemy";

    void Start()
    {
        //InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        if (target == null)
        {
            flameObject.SetActive(false);
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0.0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (nearestEnemy != null)
        {
            Gizmos.DrawLine(transform.position, nearestEnemy.transform.position);
        }

    }
    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    void Fire()
    {
        DamageEnemy(target);
        flameObject.SetActive(true);

    }
    private void DamageEnemy(Transform enemyGO)
    {
        EnemyHealth enemy = enemyGO.GetComponent<EnemyHealth>();
        enemy.TakeDamage(fireDamge);
    }
}
