using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Cloud" || collider2D.tag == "Deadly")
        {
            collider2D.gameObject.SetActive(false);
        }//Ends Collider If

    }//Ends OnTriggerEnter

}//Ends Calss
