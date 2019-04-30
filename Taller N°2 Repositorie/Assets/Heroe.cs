using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe: MonoBehaviour
{
    GameObject heroe;

    void Start()
    {
        heroe = gameObject;                                             // se hace el nombre heroe a gameobject 
        heroe.name = "Heroe";                                           // se define como heroe
        heroe.GetComponent<Renderer>().material.color = Color.red;      // se accede al componente renderer para cambiar su color
        heroe.AddComponent<Rigidbody>();                                // se le añade componente Rigidbody
        heroe.AddComponent<Move>();                                     // y se le asigna el script de movimiento
        //heroe.AddComponent<Camera>();

    }

   


}
