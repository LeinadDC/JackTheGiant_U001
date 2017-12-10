using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds, collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX, lastCloudYPosition, controlX;

    void Awake() {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();

    }//Ends Awake

    void SetMinAndMaxX()
    {
        //Convierte las coordenadas de la pantalla del cliente a coordenadas de Unity para determinar el max y min correcto para cada pantalla.
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }//Ends SetMinMax

    void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject temp = array[i]; //Obtiene un objeto en la posición de I.
            int randomIndex = Random.Range(i, array.Length); //Crear un indice al azar entre i y el tamaño del arreglo.
            array[i] = array[randomIndex]; //El objeto en la posición i se convierte el objeto en la posición de indice aleatorio.
            array[randomIndex] = temp;//Se cambian las posiciones de los objetos

            /***
             * Primero se toma el objeto[0] y luego se crea un indice aleatorio(digamos 3)
             * El objeto que está en objeto[0] se convierte en objeto[3]
             * Y el objeto[3] se mueve a la posición del objeto[0]
             ***/
        }

    }//Ends Shuffle

    void CreateClouds()
    {
        Shuffle(clouds);

        //La primera nube va a empezar en Y = 0
        float positionY = 0;

        for (int i = 0; i < clouds.Length; i++)
        {
            //Posición de spawn de la nube.
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            temp.x = Random.Range(minX, maxX); //Posición X aleatoria en el rango min y max.

            if (controlX == 0)//Verificamos la posicion X de la ultima nube para darle un efecto de "zig-zag" al spawn.
            {
                temp = ChangeXPosition(temp,0.0f,maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp = ChangeXPosition(temp, 0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp = ChangeXPosition(temp, 1.0f, maxX);
                controlX = 3;

            }
            else if (controlX == 3)
            {
                temp = ChangeXPosition(temp, 0.0f, minX);
                controlX = 3;
            }

            lastCloudYPosition = positionY; //Se guarda la ultima Y de la ultima nube.

            clouds[i].transform.position = temp; //Se cambia el temp.

            positionY -= distanceBetweenClouds; //Se le resta la distancia deseada entre cada nube.
                
        }//Ends For

    }//Ends Create Clouds

    private Vector3 ChangeXPosition(Vector3 temp, float xPos, float MinMax)
    {
        temp.x = Random.Range(xPos, MinMax);
        return temp;
    }//Ends ChangeXPosition

}//Ends Class


