using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour {

    public static Gameplay instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText,gameOverScore,gameOverCoins;
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

	void Awake () {
        MakeInstance();
	}

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScore.text = "x" + finalScore.ToString();
        gameOverCoins.text = "x" + finalCoinScore.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        StartCoroutine(PlayerDied());
    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Gameplay");
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCointScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

	
}
