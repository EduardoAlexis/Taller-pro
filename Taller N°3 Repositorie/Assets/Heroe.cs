using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    GameObject hero;
  
    void Start()
    {
        //se crea un gameobject vacio y se agregan propiedades a este . Como color,rigidbody,camara y se modifican algunas propiedades del rigidbody como Constrain y gravedad
        hero = gameObject;
        hero.name = "Heroe";
        hero.GetComponent<Renderer>().material.color = Color.red;
        hero.AddComponent<Rigidbody>();
        hero.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        hero.GetComponent<Rigidbody>().useGravity = false;
        hero.AddComponent<Movimiento>();
        hero.AddComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
