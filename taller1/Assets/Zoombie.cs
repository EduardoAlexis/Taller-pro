using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombie
{

    private string name;
    Renderer colorOb;
    private int ataque;
    GameObject mesh;
    int numazar = 0;
    string msm;

    public Zoombie(string name, int ataque)
    {
        this.name = name;
		numazar = Random.Range(1, 4);
        this.ataque = ataque;
        mesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mesh.name = "Zombie";
		if (numazar == 1)
        {
            mesh.GetComponent<Renderer>().material.color = Color.cyan;
        }
		if (numazar == 2)
        {
            mesh.GetComponent<Renderer>().material.color = Color.green;
        }
		if (numazar == 3)
        {
            mesh.GetComponent<Renderer>().material.color = Color.magenta;
        }

        Vector3 pos = new Vector3();
        pos.x = Random.Range(-20, 25);
        pos.y = 0.56f;
        pos.z = Random.Range(-35, 30);
        mesh.transform.position = pos;
    }

   public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }
		    
    public string Info()
    {       
		if (numazar == 1)
        {
            msm = "Hola mi nombres: " + getName() +" "+ "Soy un Zombie y soy de color Cyan";
        }
		if (numazar == 2)
        {
             msm = "Hola mi nombres: " + getName() + " " + "Soy un Zombie y soy de color Verde";
        }
		if (numazar == 3)
        {
           msm= "Hola mi nombres: " + getName() + " " + "Soy un Zombie y soy de color Magenta";
        }
        return msm;
    }
}

public class Ciudadano
{
    public GameObject ciudadano;
    private string nombre;
    private int edad;
    private string inf;
    string[] nombres = new string[] {
              "Roberto","Clara","Alberto","Jorge","Federico","Juan","Emilio","Ebaristo","Camilo","Carlos","Mario","Alfonso","Feipe",
              "Leopoldo","Luis","Argemiro","Mauricio","Elkin","Humberto","Libardo" };

    public Ciudadano(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
        ciudadano = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ciudadano.name = "Ciudadano";
        Vector3 pos = new Vector3(Random.Range(-20, 28), 1.08f, Random.Range(-37, 32));
        ciudadano.transform.position = pos;

    }
	public string Mensaje()
	{
		inf = "Mi nombre es :"+this.nombre+" "+"y tengo :"+this.edad+" años ";
		return inf;
	}

    public void NombreyEdad()
    {
        int aleatorio = Random.Range(0, 19);
        nombre = nombres[aleatorio];
        edad = Random.Range(15, 101);
    }

    
}

