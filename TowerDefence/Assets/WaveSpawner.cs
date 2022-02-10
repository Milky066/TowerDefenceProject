using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    //Responsible from controlling enemy waves
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;

    public Transform instantiateParent;
    public TextMeshProUGUI timerText;

    public Transform spawnPoint;//Spawn point
    public float timeBetweenSpawn=0.6f;//Time between each enemy spawn

    public float timeBetweenWaves = 10f;//in sec
    public float prepTime = 0f;//Time before 1st wave
    private int waveCount;
    
    private void Update()
    {
        if(prepTime<=0)
        {
            StartCoroutine(SpawnWave());
            prepTime = timeBetweenWaves;
            waveCount++;
            GameManager.rounds++;

        }
        prepTime -= Time.deltaTime;
        prepTime = Mathf.Clamp(prepTime, 0f, Mathf.Infinity);
        timerText.SetText("Incoming : "+string.Format("{0:00.00}", Mathf.Clamp(prepTime, 0f, Mathf.Infinity)));
    }
    IEnumerator SpawnWave()
    {
        //Debug.Log("Spawn wave: "+ waveCount );
        int randomIndex = Random.Range(1,4);
        for (int i=0; i<waveCount;i++)
        {

            if (randomIndex==1)
            {
                Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation, instantiateParent);
            }
            else if(randomIndex==2)
            {
                Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation, instantiateParent);
            }
            else if(randomIndex==3)
            {
                Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation, instantiateParent);
            }


            yield return new WaitForSeconds(timeBetweenSpawn);
        }


    }

}
