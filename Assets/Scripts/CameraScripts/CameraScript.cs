using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float speed = 1f, acceleration = 0.2f, maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;

    void Start()
    {
        moveCamera = true;
    }//Ends Start

    void Update()
    {
        if (moveCamera) MoveCamera();
    }//Ends Update

    private void MoveCamera()
    {
        Vector3 cameraPosition = transform.position; //Obtenemos la posición actual de la camara

        cameraPosition = GenerateCameraPosition(cameraPosition);

        transform.position = cameraPosition; //Asignamos nueva posición

        speed += acceleration * Time.deltaTime; //Definimos la velocidad y aceleración

        if (speed > maxSpeed) speed = maxSpeed; //Se revisa la velocidad para que no exceda el limite.
    }//Ends Move Camera

    private Vector3 GenerateCameraPosition(Vector3 cameraPosition)
    {
        float oldY = cameraPosition.y;//Obtenemos la Y actual
        float newY = cameraPosition.y - (speed * Time.deltaTime); //Obtenemos la Y "futura"

        cameraPosition.y = Mathf.Clamp(cameraPosition.y, oldY, newY); //Matenemos la posición Y entre la actual y la futura
        return cameraPosition;
    }//Ends GenerateCameraPosition

}//Ends Class
