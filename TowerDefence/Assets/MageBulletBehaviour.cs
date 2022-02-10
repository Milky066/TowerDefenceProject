using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBulletBehaviour : MonoBehaviour
{
    private Transform target;
    public float velocity=10f;
    public float destroyDistance;
    public float explodeRadius=2f;
    public GameObject explosion;
    public int bulletDamage = 50;
    // Update is called once per frame

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float frameDistance = velocity * Time.deltaTime;
        Quaternion.LookRotation(dir);
        if (dir.magnitude <= frameDistance)
        {
            //Hit
            OnHit();
            return;
        }
        transform.Translate(dir.normalized * frameDistance,Space.World);
    }
    public void Seek(Transform _target)
    {
        target = _target;

    }
    public void OnHit()
    {
        Explode();
        GameObject exInst =(GameObject) Instantiate(explosion, transform.position, transform.rotation);
        Destroy(exInst, 1f);
        Destroy(gameObject);
        return;
    }

    private void DamageEnemy(Transform enemyGO)
    {
        EnemyHealth enemy = enemyGO.GetComponent<EnemyHealth>();
        enemy.TakeDamage(bulletDamage);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag =="Enemy")
            {
                DamageEnemy(collider.transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}
