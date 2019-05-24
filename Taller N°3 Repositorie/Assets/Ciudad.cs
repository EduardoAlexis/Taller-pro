using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemy;
using ciudadano = NPC.Ally;
using UnityEngine.UI;

public class Ciudad : MonoBehaviour
{
  
    int contadorZombie;
    int contadorCiudadanos;
    public Text num_Z;
    public Text num_C;
  

    
    // Start is called before the first frame update
    void Start()
    {
        //Creacion de Objeto tipo Creador datos y ejecuccion de su contructor y llamada a corutina de conteo
        CreadorDatos c = new CreadorDatos();
        StartCoroutine(CountNPC());
      
    }

    void Update()
    {
        
    }

   
    // Corutine que me sirve para contar la cantidad de zombies y ciudadanos que se crean en cada ejecucion del juego y los muestra en un text en el canvas del juego
    IEnumerator CountNPC()
    {
      
        zombie.Zombie[] zombies = FindObjectsOfType<zombie.Zombie>();
        foreach (zombie.Zombie z in zombies)
        {
           contadorZombie++;
        }
        num_Z.text = "# de Zombies : " + contadorZombie.ToString();
        ciudadano.Ciudadano[] citizen = FindObjectsOfType<ciudadano.Ciudadano>();
        foreach(ciudadano.Ciudadano c in citizen)
        {
            contadorCiudadanos++;
        }
        num_C.text = "# de Ciudadanos : " + contadorCiudadanos.ToString();
        yield return new WaitForSeconds(0.3f);
        
    }
}

//se crea una clase que no deriva de nada y se agregan 2 variables una de tipo read only y otra Const en el contructor de ella se crea aleatoriamente
// la cantidad de cubos entre 5 y 25 y aleatoriamente se decidie si son de tipo Zombie o Ciudadano, se crea un unico heroe 
public class CreadorDatos
{

    public readonly int minimo_Cubos = Random.Range(5, 16);
    const int MAXI_CUBOS = 25;
    GameObject cube;
    GameObject hero;

     public CreadorDatos()
    {
        hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hero.AddComponent<Heroe>();

        for(int i = 0; i <= Random.Range(minimo_Cubos, MAXI_CUBOS); i++)
        {

            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            int aleatorio = Random.Range(0, 2);
            if (aleatorio == 0)
            {
                cube.AddComponent<zombie.Zombie>();
            }
            if (aleatorio == 1)
            {
                cube.AddComponent<ciudadano.Ciudadano>();
            }
        }
    }

}
