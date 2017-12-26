using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void StartGame()
    {
        GameManager.instance.gameStartedMain = true;
        SceneManager.LoadScene("Gameplay");
    }

    public void Highscore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Music()
    {

    }
}
