using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

    // Use this for initialization
    void Start()
    {
        CheckMusic();
    }

    void CheckMusic()
    {
        if(GamePreferences.GetMusicState() == 1)
        {
            ChangeMusic(true, 1);
        }
        else
        {
            ChangeMusic(false, 0);
        }
    }

    private void ChangeMusic(bool playMusic, int icon)
    {
        MusicController.instance.PlayMusic(playMusic);
        musicButton.image.sprite = musicIcons[icon];
    }

    public void StartGame()
    {
        GameManager.instance.gameStartedMain = true;
        //SceneManager.LoadScene("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
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

    public void MusicButton()
    {
        if(GamePreferences.GetMusicState() == 0)
        {
            PlayMusic(1, true, 1);
        }
        else
        {
            PlayMusic(0, false, 0);
        }
    }

    private void PlayMusic(int musicState, bool playMusic, int musicSprite)
    {
        GamePreferences.SetMusicState(musicState);
        MusicController.instance.PlayMusic(playMusic);
        musicButton.image.sprite = musicIcons[musicSprite];
    }
}
