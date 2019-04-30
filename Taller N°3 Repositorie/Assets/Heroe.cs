using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    GameObject hero;
  
    void Start()
    {
        hero = gameObject;
        hero.name = "Heroe";
        hero.GetComponent<Renderer>().material.color = Color.red; // definir su color mediante componente renderer
        hero.AddComponent<Rigidbody>(); 
        hero.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; // restringir rotaciones
        hero.GetComponent<Rigidbody>().useGravity = false; // adicionar rigbody y volverlo falso
        hero.AddComponent<Movimiento>(); // añadir script de movimiento
        hero.AddComponent<Camera>(); // al crear al heroe adaptarle la camara
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
