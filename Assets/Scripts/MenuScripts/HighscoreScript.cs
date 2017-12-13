using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
