using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldeano 
{
    private string name;
    private int edad;
    GameObject aldeano;


    public Aldeano(string name,int edad) // recibe parametros de nombre y edad 
    { 
        this.name = name;
        this.edad= edad;
        aldeano = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // creacion de primitiva del aldeano
        Vector3 pos = new Vector3(Random.Range(-20, 25), 1f, Random.Range(-35, 30));  // posicion al azar en el mapa
        aldeano.name = "Aldeano"; // nombre del objeto
        aldeano.transform.position = pos; 
        aldeano.GetComponent<Renderer>().material.color = Color.yellow; // asignacion del color

    }

	public string Info()
	{
		string info = "Soy un Ciudadano mi nombres es: " + getName() + " " + "y tengo " + getEdad() + " años"; // imprime datos de nombre y edad
		return info;
	}

    public string getName() // metodo para obtener nombre y edad
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public int getEdad()
    {
        return edad;
    }
    public void setEdad(int edad)
    {
        this.edad = edad;
    }
}
