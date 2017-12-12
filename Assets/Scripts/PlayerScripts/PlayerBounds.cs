using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    private float minX, maxX;

	void Start () {
        SetMinAndMaxX();
    }//Ends Start 
	
	void Update () {
        CheckPlayerX();	
	}//Ends Update

    void CheckPlayerX()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        transform.position = playerPosition;
    }//Ends CheckPlayer

    void SetMinAndMaxX()
    {
        //Convierte las coordenadas de la pantalla del cliente a coordenadas de Unity para determinar el max y min correcto para cada pantalla.
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }//Ends SetMinMax

}//Ends Class
