using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {


    [SerializeField]
    private Text scoreText, coinText;

	// Use this for initialization
	void Start () {
        SetScoreDif();

    }
	

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }


    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SetScoreDif()
    {
        if(GamePreferences.GetEasy () == 1)
        {
            SetScore(GamePreferences.GetEasyScore(), GamePreferences.GetEasyCoins());

        }

        if (GamePreferences.GetMedium() == 1)
        {
            SetScore(GamePreferences.GetMediumScore(), GamePreferences.GetMediumCoins());

        }

        if (GamePreferences.GetHard() == 1)
        {
            SetScore(GamePreferences.GetHardScore(), GamePreferences.GetHardCoins());

        }
    }



}
