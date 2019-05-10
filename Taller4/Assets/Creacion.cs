using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zom = NPC.Enemy;
using villa = NPC.Ally;

public class Creacion : MonoBehaviour
{
    public Text cantidadZombies;
    public Text cantidadVillagers;
    public int varZombies;
    public int varVillagers;
    public GameObject[] Zom,Villa;
    void Start()
    {
        new CrearInstancias();

    }


    /// <summary>
    /// Utilizamos el canvas en escena para mostrar cuantos zombies y villagers ahi en el momento
    /// </summary>
    private void Update()
    {
        Zom = GameObject.FindGameObjectsWithTag("Zombie");
        Villa = GameObject.FindGameObjectsWithTag("Villager");
        foreach (GameObject item in Zom)
        {
            varZombies = Zom.Length;
        }
        foreach (GameObject item in Villa)
        {
            varVillagers = Villa.Length;
        }

        if(Villa.Length == 0)
        {
            cantidadVillagers.text = 0.ToString();
        }
        else
        {
            cantidadVillagers.text = varVillagers.ToString();
        }

        cantidadZombies.text = varZombies.ToString();
    }
}
/// <summary>
/// Se cran al azar ciertas instancias y se les asigna al azar un componente a estas
/// </summary>
 class CrearInstancias 
{
    public GameObject cube;
    public readonly int minInstancias = Random.Range(5, 16);
    int escoger = 0;
    const int MAX = 26;
    public CrearInstancias()
    {
        for (int i = 0; i < Random.Range(minInstancias,MAX); i++)
        {
            
            if (escoger == 0)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Camera>();
                cube.AddComponent<Heroe>();
                cube.AddComponent<Heroe.MirarH>();
                cube.AddComponent<Heroe.MoverH>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));
                escoger += 1;
            }

            int selec = Random.Range(escoger, 3);

            if (selec == 1)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<villa.Villager>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));
            }
            if (selec == 2)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<zom.Zombie>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));
            }
        }
    }
}