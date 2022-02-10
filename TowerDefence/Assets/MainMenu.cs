using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loading different scenes
    public void PlayScene1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayScene2()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
