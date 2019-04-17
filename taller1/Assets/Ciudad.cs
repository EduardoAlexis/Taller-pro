using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad : MonoBehaviour
{
    public float posx;
    public float posy;
   
    // Start is called before the first frame update
    void Start()
    {
        string[] namesZombie =
        {
            "Sofia","Ricardo","Marta", "Lucia","Leo","Andres"

        };

        string[] namesCiudadanos =
        {
            "Alex", "Daniel","Toby","Arjemiro","Germna","Santiago","Saul","Alejandro","Aldruvar","Benzema","Cesar","Simon","Samuel","Lucas","Lorenzo",
            "Antonio", "Nicolas","Eric","Felix","Jamie","Rob","Paola"
        };


        int aleatorio = Random.Range(1, 5);

        for (int i = 0; i < aleatorio; i++)
        {
            Zoombie z = new Zoombie(namesZombie[i], Random.Range(40, 98));
            Debug.Log(z.Info());
            
        }
        int aleatorio1 = Random.Range(1, 6);
        for (int i =0;i<aleatorio1;i++)
        {
            Aldeano a = new Aldeano(namesCiudadanos[Random.Range(0, 20)], Random.Range(15, 100));
            Debug.Log(a.Info());
        }
        Heroe h = new Heroe();
       

       

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}

