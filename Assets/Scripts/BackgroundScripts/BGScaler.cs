using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	void Start () {
        SpriteRenderer sprinteRenderer = GetComponent<SpriteRenderer>(); //Obtiene el componente Sprite Renderer
        Vector3 tempScale = transform.localScale; // Vector 3 temporal basado en el scale local.

        
        float spriteWidth = sprinteRenderer.sprite.bounds.size.x; //El tamaño de x del sprite.

     
        float worldHeight = Camera.main.orthographicSize * 2f; // Se obtiene la altura de la camara real
        float worldWidth = worldHeight / Screen.height * Screen.width; //El ancho de la camara se calcula con el alto de la camara y el de la pantalla.

        tempScale.x = worldWidth / spriteWidth; //Los cambios en x del sprite se calculan con el ancho global y del sprite.

        transform.localScale = tempScale; //Se le dan los cambios al sprite.
	}//Ends Start

}//Ends Class
