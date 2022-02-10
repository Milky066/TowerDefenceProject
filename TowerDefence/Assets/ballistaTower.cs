using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballistaTower : MonoBehaviour
{
    public AudioClip fireSound;
    private AudioSource audioSource;
    public Transform target;
    public float range = 25f;
    private GameObject nearestEnemy = null;
    public Animation fireArrow;
    public Transform rotatingObject;

    public float fireRate = 0.5f;
    private float fireCountdown = 0.0f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    public string enemyTag = "Enemy";

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        fireArrow = gameObject.GetComponent<Animation>();
        InvokeRepeating("FindTarget",0f,2f);
    }

    // Update is called once per frame
    void Update()
    {

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
    private void FindTarget()
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
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            rotatingObject.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            fireArrow.Play();
            audioSource.PlayOneShot(fireSound, 0.3f);
        }

    }
    void Fire()
    {
        GameObject projectileRef = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, firePoint);
        arrowBehaviour bullet = projectileRef.GetComponent<arrowBehaviour>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
}
