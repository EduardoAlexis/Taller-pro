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
    public enum Estados
    {
        idle, moving
    }
    Estados estado_zombie;

    public enum CuerpoParte
    {
        sesos, corazon, estomago, intestinos, cuello
    }

    CuerpoParte partes;
    public struct DatosZombie
    {
        public Color color;
        public CuerpoParte partes;

    }
   
    public void Start()
    {
        ob = gameObject;
        int escoge_color = Random.Range(0, 3);
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
        ob.transform.position = new Vector3(Random.Range(-15, 25), 0.4f, Random.Range(-25, 26));
        ob.name = "Zombie";
        ob.AddComponent<Rigidbody>();
        
        if (activo)
        {
            StartCoroutine(estados_Z());
        }

        else if (activo == false)
        {
            StopCoroutine(estados_Z());
        }


    }

    public DatosZombie ObtenerZombieInfo()
    {
        DatosZombie dato = new DatosZombie();
        // Datos datos = new Datos();
        int parte = Random.Range(0, 4);

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
        if (estado_zombie == Estados.idle)
        {
            Debug.Log("Estoy Quieto");
        }

        if (estado_zombie == Estados.moving)
        {
            transform.Translate(destino * Time.deltaTime*0.3f);
        }
    }

    public IEnumerator estados_Z()
    {

        estado_zombie = (Estados)Random.Range(0, 2);
        
        if (estado_zombie == Estados.moving)
        {
            destino = new Vector3(Random.Range(-15, 15), 0f, Random.Range(-15, 15) );
            yield return null;

        }
      
       
      
        yield return new WaitForSeconds(5f);
        yield return estados_Z();
       

    }

   
}

