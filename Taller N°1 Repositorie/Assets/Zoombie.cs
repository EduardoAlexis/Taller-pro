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

    public Zoombie() // declaracion de parametros
    {
		numazar = Random.Range(1, 4); // random de 3 colores diferentes
        mesh = GameObject.CreatePrimitive(PrimitiveType.Cube); // creacion de primitiva para zombie
        mesh.name = "Zombie"; // adquirir nombre zombie
		if (numazar == 1)
        {
            mesh.GetComponent<Renderer>().material.color = Color.cyan;// asignacion de color segun valor del numero random
        }
		if (numazar == 2)
        {
            mesh.GetComponent<Renderer>().material.color = Color.green;
        }
		if (numazar == 3)
        {
            mesh.GetComponent<Renderer>().material.color = Color.magenta;
        }

        Vector3 pos = new Vector3(); // vector 3 con las posiciones en la que aparece el zombie
        pos.x = Random.Range(-20, 25);
        pos.y = 0.56f;
        pos.z = Random.Range(-35, 30);
        mesh.transform.position = pos; //asignar al gameObject 
    }
		    
    public string Info()  //  toma el valor dado e imprime su respectivo color
    {       
		if (numazar == 1)
        {
            msm = "Soy un Zombie y soy de color Cyan";
        }
		if (numazar == 2)
        {
             msm = "Soy un Zombie y soy de color Verde";
        }
		if (numazar == 3)
        {
           msm= "Soy un Zombie y soy de color Magenta";
        }
        return msm;
    }
}


    


