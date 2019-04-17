using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe 
{
    GameObject heroe;
   
   
   
    

    public Heroe()
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 pos = new Vector3(0, 1.1f, 0);
        heroe.transform.position = pos;
        heroe.name = " heroe";
        heroe.AddComponent<Movimiento>();
        heroe.GetComponent<Renderer>().material.color = Color.red;
        heroe.AddComponent<Rigidbody>();
        heroe.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;
        heroe.AddComponent<Camera>();
        heroe.GetComponent<Rigidbody>().useGravity = false;
        
    }
   
    

  

  
}