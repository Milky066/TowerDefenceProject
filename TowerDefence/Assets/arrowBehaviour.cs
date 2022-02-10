using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBehaviour : MonoBehaviour
{
    //Projectile behaviour,damage,velocity and explosion radius
    private Transform target;
    public float velocity = 25f;
    public int bulletDamage = 1000;
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float frameDistance = velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
        if (dir.magnitude <= frameDistance)
        {
            //Hit
            DamageEnemy(target);
            OnHit();
            return;
        }
        transform.Translate(dir.normalized * frameDistance, Space.World);

    }
    public void Seek(Transform _target)
    {
        target = _target;

    }
    public void OnHit()
    {
        DamageEnemy(target);
        return;
    }

    private void DamageEnemy(Transform enemyGO)
    {
        EnemyHealth enemy = enemyGO.GetComponent<EnemyHealth>();
        enemy.TakeDamage(bulletDamage);
    }

}
