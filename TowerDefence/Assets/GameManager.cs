using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnd=false;
    private PlayerStats playerStats;
    public GameObject gameOverUI;

    public static int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
        gameEnd = false;
        playerStats=GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd == true)
        {
            return;
        }
        if (playerStats.health <= 0)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        gameEnd = true;
        gameOverUI.SetActive(true);
    }

}
