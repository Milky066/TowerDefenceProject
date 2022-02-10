using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 100;
    public int coinGain = 10;
    private AudioSource audioSource;
    [Header("Optional Effect")]
    public GameObject deathEffect;
    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        PlayerStats.coin += coinGain;
        if(deathEffect!=null)
        {
            GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1f);
        }
    }
}
