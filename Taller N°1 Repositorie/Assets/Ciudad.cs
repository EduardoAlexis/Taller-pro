using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad : MonoBehaviour
{
    public float posx;
    public float posy;

    void Start()
    {
        string[] namesCiudadanos =
        {
            "Alex", "Daniel","Toby","Arjemiro","Germna","Santiago","Saul","Alejandro","Aldruvar","Benzema","Cesar","Simon","Samuel","Lucas","Lorenzo",
            "Antonio", "Nicolas","Eric","Felix","Jamie","Rob","Paola"
        };
        // nombres de los ciudadanos

        int aleatorio = Random.Range(2, 5); // numero random de zombies

        for (int i = 0; i < aleatorio; i++)
        {
            Zoombie z = new Zoombie();
            Debug.Log(z.Info());

        }
        int aleatorio1 = Random.Range(2, 6); // numero random de aldeanos
        for (int i = 0; i < aleatorio1; i++) // eleccion de numero random
        {
            Aldeano a = new Aldeano(namesCiudadanos[Random.Range(0, 20)], Random.Range(15, 100)); // random entre nombres y edades
            Debug.Log(a.Info());
        }
        Heroe h = new Heroe(); // inicia el script del heroe

    }
}

