using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount, lifeCount, cointCount;

    public void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }//Ends Awake

    // Use this for initialization
    void Start () {
        previousPosition = transform.position;
        countScore = true;
	}//Ends Start
	
	// Update is called once per frame
	void Update () {
        CountScore();
	}//Ends Update

    void CountScore()
    {
        switch (countScore)
        {
            case true:
                if (transform.position.y < previousPosition.y) scoreCount++;
                previousPosition = transform.position;
                Gameplay.instance.SetScore(scoreCount);
                break;
            case false:
                Debug.Log("Count Score is false");
                break;
            default:
                break;
        }//Ends Switch

    }//Ends CountScore

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                ScorePoint(cointCount,100,coinClip, collision);
                break;
            case "Life":
                ScorePoint(lifeCount,150, lifeClip,collision);
                break;
            case "Bounds":
                KillPlayer();
                break;
            case "Deadly":
                KillPlayer();
                Gameplay.instance.GameOverShowPanel(scoreCount, cointCount);
                break;

            default:
                break;
        }//Ends Switch

    }//Ends On Trigger

    private void KillPlayer()
    {
        cameraScript.moveCamera = false;
        countScore = false;

        transform.position = new Vector3(500, 500, 0);
        lifeCount--;
    }//Ends Kill Player

    private void ScorePoint(int scoreType, int scoreAmount, AudioClip audioClip, Collider2D collision)
    {
        scoreType++;
        scoreCount += scoreAmount;
        Gameplay.instance.SetScore(scoreCount);
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        collision.gameObject.SetActive(false);
        
    }//Ends Score Point

}//Ends Class
