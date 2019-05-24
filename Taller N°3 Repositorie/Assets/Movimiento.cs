using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemy;
using ciudadano = NPC.Ally;

public class Movimiento : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // se utiliza las variables V y H para capturan los eventos de entrada y con estos se modifican la traslacion y rotacion del Objeto que llevara este script
        float V = Input.GetAxisRaw("Vertical");
        float H = Input.GetAxisRaw("Horizontal");

        transform.Translate(0f, 0f, V * 0.5f);
        transform.Rotate(0f, H * 2f, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // detecta si el objeto con el que colisiono es de tipo Zombie
        if (collision.collider.GetComponent<zombie.Zombie>())
        {

            //accede al componente zombie y crea una referencia  de este tipo
            zombie.Zombie zombie = collision.collider.GetComponent<zombie.Zombie>();
            //imprime sus gustos por que tipo de parte de tu cuerpo quiere comer 
            Debug.Log("Wrrrrrr soy un Zombie y quiero comer"+" "+zombie.ObtenerZombieInfo().gustos);
        }
        // detecta si el objeto con el que colisiono es de tipo Ciudadano
        if (collision.collider.GetComponent<ciudadano.Ciudadano>())
        {
            //accede al componente Ciudadano y crea un objeto de este tipo
            ciudadano.Ciudadano ciud = collision.collider.GetComponent<ciudadano.Ciudadano>();
            //imprime datos como nombre y edad
            Debug.Log("Hola soy " + ciud.Datos().nombre + " y tengo " + ciud.Datos().edad + " años");
        }
    }
}
