using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudadano : MonoBehaviour
{
    string msg;
    int edad;
    string nombres;
    public enum Nombres
    {
		Alex, Daniel,Toby,Arjemiro,Germna,Santiago,Saul,Alejandro,Aldruvar,Benzema,Cesar,Simon,Samuel,Lucas,Lorenzo,
		Antonio, Nicolas,Eric,Felix,Jamie,Rob,Paola
    }

    public struct Datos
    {
        public int edad;
        public string nombre;
    }
    GameObject ob;
    public void Start()
    {
        ob = gameObject;
        ob.GetComponent<Renderer>().material.color = Color.yellow;
        ob.name = "Ciudadano";
        nombres = ((Nombres)Random.Range(0, 20)).ToString();
        edad = Random.Range(15, 100);
        ob.transform.position = new Vector3(Random.Range(-25, 20), 0.4f, Random.Range(-20, 20));
        ob.AddComponent<Rigidbody>();
    }

    public Datos DatosCiudadano()
    {
        Datos dato = new Datos();
        dato.edad = edad;
        dato.nombre = nombres;
        return dato;



    }

}
