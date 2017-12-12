using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

    private GameObject[] backgrounds;
    private float lastBackgroundY;

	// Use this for initialization
	void Start () {
        GetBackground();
	}

    void GetBackground()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background"); //Obtenemos todos los background en juego

        lastBackgroundY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastBackgroundY > backgrounds[i].transform.position.y)
            {
                lastBackgroundY = backgrounds[i].transform.position.y;
            }//Ends If

        }//Ends For

    }//Ends Getbackground

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Background")
        {
            if(collision.transform.position.y == lastBackgroundY)
            {
                Vector3 collisionPosition = collision.transform.position; //Obtiene la posición de la colisión
                BoxCollider2D collisionCollider = collision.GetComponent<BoxCollider2D>();//Obtiene su Collider
                float backgroundHeight = collisionCollider.size.y;//Obtiene su tamaño en Y.

                foreach (var background in backgrounds.Where(b => !b.activeInHierarchy)) //Revisamos por cada background que no este activo
                {
                    collisionPosition.y -= backgroundHeight; //Se le resta el tamaño en Y.
                    lastBackgroundY = collisionPosition.y; //Se ubica el nuevo background al final.
                    background.transform.position = collisionPosition;//Se cambia la posición.
                    background.SetActive(true);//Se activa

                }//Ends For

            }//Ends If Position Check

        }//Ends If Tag Check 

    }//Ends On Trigger

}//Ends Class
