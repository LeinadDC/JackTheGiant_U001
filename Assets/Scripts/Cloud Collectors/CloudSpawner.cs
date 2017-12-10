using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds, collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX, lastCloudYPosition, controlX;

    void Start() {

    }

    void SetMinAndMaxX()
    {
        //Convierte las coordenadsa de la pantalla del cliente a coordenadas de Unity para determinar el max y min correcto para cada pantalla.
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }//Ends SetMinMax

    void Shuffle(GameObject[] array)
    {

    }//Ends Shuffle

    void CreateClouds()
    {

    }//Ends Create Clouds
}//Ends Class


