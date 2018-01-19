using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedMain, gameRestarted;

    [HideInInspector]
    public int score, coinScore, lifeScore;


	void Awake () {
        MakeSingleton();
  
	}

    void Start()
    {
        InitializeVariables();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneFinishedLoading;
    }

    private void OnDisable()
    {
        
    }

    private void SceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            if (gameRestarted)
            {
                Gameplay.instance.SetScore(score);
                Gameplay.instance.SetCointScore(coinScore);
                Gameplay.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.cointCount = coinScore;
                PlayerScore.lifeCount = lifeScore;

            }else if (gameStartedMain)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.cointCount = 0;
                PlayerScore.lifeCount = 2;

                Gameplay.instance.SetScore(0);
                Gameplay.instance.SetCointScore(0);
                Gameplay.instance.SetLifeScore(2);
            }
        }
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("GameInitialized"))
        {
            GamePreferences.SetEasy(0);
            GamePreferences.SetEasyCoins(0);
            GamePreferences.SetEasyScore(0);

            GamePreferences.SetMedium(1);
            GamePreferences.SetMediumCoins(0);
            GamePreferences.SetMediumScore(0);

            GamePreferences.SetHard(0);
            GamePreferences.SetHardCoins(0);
            GamePreferences.SetHardScore(0);

            //TODO: MusicState(0);

            PlayerPrefs.SetInt("GameInitialized", 1);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
            int highScore;
            int coingHighScore;

            if (GamePreferences.GetEasy() == 1)
            {
                highScore = GamePreferences.GetEasyScore();
                coingHighScore = GamePreferences.GetEasyCoins();

                CheckEasyScore(score, coinScore, highScore, coingHighScore);

            }

            if (GamePreferences.GetMedium() == 1)
            {
                highScore = GamePreferences.GetMediumScore();
                coingHighScore = GamePreferences.GetMediumCoins();

                CheckMediumScore(score, coinScore, highScore, coingHighScore);
            }

            if (GamePreferences.GetHard() == 1)
            {
                highScore = GamePreferences.GetHardScore();
                coingHighScore = GamePreferences.GetHardCoins();

                CheckHardScore(score, coinScore, highScore, coingHighScore);
            }

            gameRestarted = false;
            gameStartedMain = false;

            Gameplay.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            Gameplay.instance.SetScore(score);
            Gameplay.instance.SetCointScore(coinScore);
            Gameplay.instance.SetLifeScore(lifeScore);

            gameStartedMain = false;
            gameRestarted = true;

            Gameplay.instance.RestartGame();
        }
    }

    private static void CheckHardScore(int score, int coinScore, int highScore, int coingHighScore)
    {
        if (highScore < score)
        {
            GamePreferences.SetHardScore(score);
        }

        if (coingHighScore < coinScore)
        {
            GamePreferences.SetHardCoins(coinScore);
        }
    }

    private static void CheckMediumScore(int score, int coinScore, int highScore, int coingHighScore)
    {
        if (highScore < score)
        {
            GamePreferences.SetMediumScore(score);
        }

        if (coingHighScore < coinScore)
        {
            GamePreferences.SetMediumCoins(coinScore);
        }
    }

    private static void CheckEasyScore(int score, int coinScore, int highScore, int coingHighScore)
    {
        if (highScore < score)
        {
            GamePreferences.SetEasyScore(score);
        }

        if (coingHighScore < coinScore)
        {
            GamePreferences.SetEasyCoins(coinScore);
        }
    }
}
