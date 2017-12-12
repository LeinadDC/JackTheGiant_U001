using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            collision.gameObject.SetActive(false);
        }//Ends If

    }//Ends On Trigger Enter

}//Ends Class
