using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldeano 
{
    private string name;
    private int edad;
    GameObject aldeano;


    public Aldeano(string name,int edad)
    { 
        this.name = name;
        this.edad= edad;
        aldeano = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Vector3 pos = new Vector3(Random.Range(-20, 25), 1f, Random.Range(-35, 30));
        aldeano.name = "Aldeano";
        aldeano.transform.position = pos;
        aldeano.GetComponent<Renderer>().material.color = Color.yellow;

    }

	public string Info()
	{
		string info = "Soy un Ciudadano mi nombres es: " + getName() + " " + "y tengo " + getEdad() + " años";
		return info;
	}

    public string getName()
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
