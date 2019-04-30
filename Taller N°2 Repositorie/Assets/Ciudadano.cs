using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudadano : MonoBehaviour
{
    string msg;
    int edad;
    string nombres;
    public enum Nombres // en el enum se agrupan los string de los nombres 
    {
		Alex, Daniel,Toby,Arjemiro,Germna,Santiago,Saul,Alejandro,Aldruvar,Benzema,Cesar,Simon,Samuel,Lucas,Lorenzo,
		Antonio, Nicolas,Eric,Felix,Jamie,Rob,Paola
    }

    public struct Datos // esta estructura se usa para las variables de datos
    {
        public int edad;
        public string nombre;
    }
    GameObject ob;
    public void Start()
    {
        ob = gameObject;
        ob.GetComponent<Renderer>().material.color = Color.yellow; // se le agrega el componente renderer que permite manipular el color 
        ob.name = "Ciudadano";                                     // se define como ciudadano 
        nombres = ((Nombres)Random.Range(0, 20)).ToString();       // se le proporciona un nombre al azar 
        edad = Random.Range(15, 100);                              // se le da un valor de edad al azar
        ob.transform.position = new Vector3(Random.Range(-25, 20), 0.4f, Random.Range(-20, 20));    // esta es la posicion en la que aparecera 
        ob.AddComponent<Rigidbody>();                              // se agrega componente Rigidbody
    }

    public Datos DatosCiudadano() // en esta clase se almacenan los datos que anteriormente se le asignaron
    {
        Datos dato = new Datos();
        dato.edad = edad;
        dato.nombre = nombres;
        return dato;



    }

}
