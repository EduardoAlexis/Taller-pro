using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad : MonoBehaviour
{
    GameObject Cube;
    GameObject heroe;

     void Start()
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        heroe.AddComponent<Heroe>();       

        for(int i = 0; i < 11; i++)
        {
            Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			int CorZ = Random.Range(0, 2);
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
