using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;
	// Use this for initialization
	void Awake () {
        MakeSingleton();
	}
	
	// Update is called once per frame
	void Update () {
		
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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        //Entra y hacemos fade in,
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        //Esperamos
        yield return StartCoroutine(CustomCoroutine.WaitForSeconds(1f));
        //Cargadmos y hacemos FadeOut
        SceneManager.LoadScene(level);
        fadeAnim.Play("FadeOut");

        yield return StartCoroutine(CustomCoroutine.WaitForSeconds(0.7f));
        fadePanel.SetActive(false);
    }
}
