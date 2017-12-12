using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds, collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX, lastCloudYPosition;
    private int controlX;

    void Awake() {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

    }//Ends Awake

    void Start()
    {
        PositionThePlayer();
    }//Ends Start

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

            temp = ChangeXPosition(temp);

            lastCloudYPosition = positionY; //Se guarda la ultima Y de la ultima nube.

            clouds[i].transform.position = temp; //Se cambia el temp.

            positionY -= distanceBetweenClouds; //Se le resta la distancia deseada entre cada nube.

        }//Ends For

    }//Ends Create Clouds

    private Vector3 ChangeXPosition(Vector3 temp)
    {
        switch (controlX)
        {
            case 0:
                temp = ChangeXPosition(temp, 0.0f, maxX);
                controlX = 1;
                break;
            case 1:
                temp = ChangeXPosition(temp, 0.0f, minX);
                controlX = 2;
                break;
            case 2:
                temp = ChangeXPosition(temp, 1.0f, maxX);
                controlX = 3;
                break;
            case 3:
                temp = ChangeXPosition(temp, 0.0f, minX);
                controlX = 0;
                break;
            default:
                break;
        }

        return temp;
    }

    private Vector3 ChangeXPosition(Vector3 temp, float xPos, float MinMax)
    {
        temp.x = Random.Range(xPos, MinMax);
        return temp;
    }//Ends ChangeXPosition

    void PositionThePlayer()
    {
        GameObject[] normalClouds = GameObject.FindGameObjectsWithTag("Cloud"); //Buscamos las nubes no letales.

        Vector3 firstCloudPosition = clouds[0].transform.position; //Almacenamos la posicion de la primera nube.

        if (clouds[0].tag == "Deadly") //Revisamos si es letal.
        {
            Vector3 deadlyPosition = clouds[0].transform.position; //Le asignamos la posición de la primera nube no letal.
            clouds[0].transform.position = normalClouds[0].transform.position; //Cambiamos de posición.
            normalClouds[0].transform.position = deadlyPosition; 
        }//Ends If

        firstCloudPosition.y += 1f; // Ligero epacio entre nube y jugador.

        player.transform.position = firstCloudPosition; ///Se coloca al jugador arriba de la nube.
         

    }// Ends Position The Player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cloud" || collision.tag == "Deadly") //Revisamos si es una nube
        {
            if (collision.transform.position.y == lastCloudYPosition) //Revisamos si es la última nube
            {
                Shuffle(clouds); //Shuffle de nuevo
                Shuffle(collectables);
                Vector3 cloudPosition = collision.transform.position;//Se obtiene la posición de la nube que colisiona

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy) //Se recorre el arreglo de nubes para ver si están activas
                    {
                        cloudPosition = ChangeXPosition(cloudPosition); //Se cambia la posició´n
                        cloudPosition.y -= distanceBetweenClouds; //Distancia para evitar choques
                        lastCloudYPosition = cloudPosition.y; //Ultima nube

                        clouds[i].transform.position = cloudPosition; //Se le da la posición a la nube
                        clouds[i].SetActive(true); //Se activan para recrearlas.
                    }//Ends If

                }//Ends For


            }//Ends Inner If

        }//Ends If

    }//Ends OnTriggerEnter

}//Ends Class




