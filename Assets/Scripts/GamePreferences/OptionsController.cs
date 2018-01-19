using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	void Start () {
        GamePreferences.SetMusicState(1);
        SetTheDifficulty();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                easySign.SetActive(true);
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "medium":
                mediumSign.SetActive(true);
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;
            case "hard":
                hardSign.SetActive(true);
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
    }
   
    void SetTheDifficulty()
    {
        if (GamePreferences.GetEasy() == 1)
        {
            SetInitialDifficulty("easy");
        }

        if (GamePreferences.GetMedium() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (GamePreferences.GetHard() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDiff()
    {
        DifficultySetter(1, 0, 0, true, false, false);
    }

    public void MediumDiff()
    {
        DifficultySetter(0, 1, 0,false, true, false);
    }

    public void HardDiff()
    {
        DifficultySetter(0, 0, 1, false, false, true);
    }

    void DifficultySetter(int easy, int medium, int hard, bool easyS, bool mediumS, bool hardS)
    {
        GamePreferences.SetEasy(easy);
        GamePreferences.SetMedium(medium);
        GamePreferences.SetHard(hard);

        easySign.SetActive(easyS);
        mediumSign.SetActive(mediumS);
        hardSign.SetActive(hardS);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
