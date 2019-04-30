using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemy;
using ciudadano = NPC.Ally;
using UnityEngine.UI;

public class Ciudad : MonoBehaviour
{
    GameObject cube;
    GameObject hero;
    int contadorZombie;
    int contadorCiudadanos;
    public Text num_Z;
    public Text num_C;
    public readonly int minimo_Cubos = Datos.mini_Cubos; // toma las variables minimas del script datos 
    const int maximoCubos = Datos.maxi_Cubos;            // toma las variables maximas del script datos 


    // Start is called before the first frame update
    void Start()
    {
       
        hero = GameObject.CreatePrimitive(PrimitiveType.Cube);  // creacion de la primitiva cubo 
        hero.AddComponent<Heroe>(); // añadir script
        
        for(int i = minimo_Cubos;  i < maximoCubos; i++) // creacion al azar de zombie o ciudadado
        {
            int aleatorio = Random.Range(0, 2);
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (aleatorio == 0)
            {
                cube.AddComponent<zombie.Zombie>();
            }
            if (aleatorio == 1)
            {
                cube.AddComponent<ciudadano.Ciudadano>();
            }
           
        }
        StartCoroutine(CountNPC()); // inicio de corrutina al dar play
      
    }

    void Update()
    {
        
    }

    public void Stop()
    {
        StopCoroutine(CountNPC()); // detencion de corrutina 
    }

    IEnumerator CountNPC()
    {
      
        zombie.Zombie[] zombies = FindObjectsOfType<zombie.Zombie>(); //array de zombies
        foreach (zombie.Zombie z in zombies) // cuenteo de zombies
        {
           contadorZombie++;
        }
        num_Z.text = "# de Zombies :" + contadorZombie.ToString(); // impresion del cuenteo
        ciudadano.Ciudadano[] citizen = FindObjectsOfType<ciudadano.Ciudadano>(); // array de ciudadano
        foreach(ciudadano.Ciudadano c in citizen)  // cuenteo de ciudadano
        {
            contadorCiudadanos++;
        }
        num_C.text = "# de Ciudadanos : " + contadorCiudadanos.ToString(); // impresion de cuenteo
        yield return new WaitForSeconds(0.3f);
        
    }
}
