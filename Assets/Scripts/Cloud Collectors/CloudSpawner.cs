using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds, collectables;
    private GameObject player;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX, lastCloudYPosition;
    private int controlX;

    void Awake()
    {
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");
        ActivateCoins();

    }//Ends Awake

    private void ActivateCoins()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }//Ends For
    }//Ends Activate Coins

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

                foreach (var cloud in clouds.Where(b => !b.activeInHierarchy)) //Revisamos por cada nube que no este activo
                {
                    cloudPosition = ChangeXPosition(cloudPosition); //Se cambia la posició´n
                    cloudPosition.y -= distanceBetweenClouds; //Distancia para evitar choques
                    lastCloudYPosition = cloudPosition.y; //Ultima nube

                    cloud.transform.position = cloudPosition; //Se le da la posición a la nube
                    cloud.SetActive(true); //Se activan para recrearlas.

                    if(cloud.tag != "Deadly")
                    {
                        int randomNumber = Random.Range(0, collectables.Length);

                        if (!collectables[randomNumber].activeInHierarchy)
                        {
                            Vector3 temp = cloud.transform.position;
                            temp.y += 0.7f;
                            collectables[randomNumber].transform.position = temp;
                            collectables[randomNumber].SetActive(true);
                        }
                    }
                }//Ends Foreach

            }//Ends Inner If

        }//Ends If

    }//Ends OnTriggerEnter

}//Ends Class




