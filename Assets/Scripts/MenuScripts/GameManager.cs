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

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
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
}
