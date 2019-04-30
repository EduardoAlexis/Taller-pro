using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad : MonoBehaviour
{
    GameObject Cube;
    GameObject heroe;

     void Start()
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Sphere); //Esto es para crear una primitiva del heroe y se hace en el start para que solo se cree una vez iniciado
        heroe.AddComponent<Heroe>();       //Aca se le añade el componente de gameobject

        for(int i = 0; i < 11; i++) // con el for se crea un ciclo para la instancia de los cubos
        {
            Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			int CorZ = Random.Range(0, 2);  // esto se usa para dar un rango entre 0 y 1 para posteriormente asignarle un componente de zombie o ciudadano
            if (CorZ == 0)
            {
                Cube.AddComponent<Zoombie>();
            }
			if (CorZ == 1)
            {
                Cube.AddComponent<Ciudadano>();
            }
        }
    }
}
