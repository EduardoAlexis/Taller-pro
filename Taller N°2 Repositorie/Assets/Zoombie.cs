using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombie:MonoBehaviour
{
    GameObject ob;
    string msg;
    float distancia;
    bool activo = true;
    int estado_Actual;
    Vector3 destino;
    public enum Estados // en este enum se definen estados de "animaciones" de los zombies
    {
        idle, moving
    }
    Estados estado_zombie;

    public enum CuerpoParte   // en este enum se encuentran las partes del cuerpo
    {
        sesos, corazon, estomago, intestinos, cuello
    }

    CuerpoParte partes;
    public struct DatosZombie   // esta estructura controla el color y que se hace con las partes del cuerpo
    {
        public Color color;
        public CuerpoParte partes;

    }
   
    public void Start()
    {
        ob = gameObject;
        int escoge_color = Random.Range(0, 3);  // numero al azar entre 3 posibles numeros para definir el color del zombie
        if (escoge_color == 0)
        {
            ob.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (escoge_color == 1)
        {
            ob.GetComponent<Renderer>().material.color = Color.green;
        }
        if (escoge_color == 2)
        {
            ob.GetComponent<Renderer>().material.color = Color.magenta;
        }
        ob.transform.position = new Vector3(Random.Range(-15, 25), 0.4f, Random.Range(-25, 26)); // posicion random en la que aparecera
        ob.name = "Zombie";              // se define como zombie
        ob.AddComponent<Rigidbody>();         // añade componente Rigidbody
        
        if (activo)      // booleano para comenzar o detener la corrutina
        {
            StartCoroutine(estados_Z());
        }

        else if (activo == false)
        {
            StopCoroutine(estados_Z());
        }


    }

    public DatosZombie ObtenerZombieInfo()  // Clase con la informacion y lo que dice el zombie
    {
        DatosZombie dato = new DatosZombie(); // obtencion de datos
        // Datos datos = new Datos();
        int parte = Random.Range(0, 4);      // valor al azar para definir el gusto del zombie

        if (parte == 0)
        {
            dato.partes = CuerpoParte.corazon;
            msg = "Warrrrr soy un zombie y quiero comer " + dato.partes;

        }
        if (parte == 1)
        {
            dato.partes = CuerpoParte.cuello;
            msg = "Warrrrrr soy un Zombie y quiero comer " + dato.partes;
        }
        if (parte == 2)
        {
            dato.partes = CuerpoParte.estomago;
            msg = "Warrrrr soy un zombie y quiero comer " + dato.partes;
        }

        if (parte == 3)
        {
            dato.partes = CuerpoParte.intestinos;
            msg = "Warrrrr soy un zombie y quiero comer " + dato.partes;

        }
        if (parte == 4)
        {
            dato.partes = CuerpoParte.sesos;
            msg = "Warrrrr soy un zombie y quiero comer" + dato.partes;
        }
        return dato;
    }

     void Update()
    {
        if (estado_zombie == Estados.idle) // con esto se puede saber si el zombie esta quieto 
        {
            Debug.Log("Estoy Quieto");
        }

        if (estado_zombie == Estados.moving) // animacion moving del zombie
        {
            transform.Translate(destino * Time.deltaTime*0.3f);
        }
    }

    public IEnumerator estados_Z() // clase de corrutina
    {
        estado_zombie = (Estados)Random.Range(0, 2); 
        if (estado_zombie == Estados.moving)
        {
            destino = new Vector3(Random.Range(-15, 15), 0f, Random.Range(-15, 15) ); // ronda del zombie
            yield return null;
        }
      
        yield return new WaitForSeconds(5f);
        yield return estados_Z();
       

    }

   
}

