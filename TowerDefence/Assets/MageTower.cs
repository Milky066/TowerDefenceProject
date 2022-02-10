using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : MonoBehaviour
{
    public AudioClip fireSound;
    private AudioSource audioSource;
    public Transform target;
    public float range = 10f;
    private GameObject nearestEnemy = null;

    public float fireRate = 1.0f;
    private float fireCountdown = 0.0f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    public string enemyTag = "Enemy";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("FindTarget", 0f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCountdown<=0.0f)
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
        if(nearestEnemy != null)
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
            if(enemyDistance<shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy!=null&&shortestDistance<=range)
        {
            target = nearestEnemy.transform;
            audioSource.PlayOneShot(fireSound, 0.3f);
        }

    }
    void Fire()
    {
        GameObject projectileRef = (GameObject)Instantiate(projectilePrefab, firePoint.position,firePoint.rotation,firePoint);
        MageBulletBehaviour bullet = projectileRef.GetComponent<MageBulletBehaviour>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }
}
