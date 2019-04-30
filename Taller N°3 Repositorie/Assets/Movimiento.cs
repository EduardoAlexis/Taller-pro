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
        float V = Input.GetAxisRaw("Vertical"); // input de movimiento
        float H = Input.GetAxisRaw("Horizontal");

        transform.Translate(0f, 0f, V * 0.5f); // movimiento hacia adelante
        transform.Rotate(0f, H * 2f, 0); // rotacion hacia los lados
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<zombie.Zombie>()) // colision para detectar si el heroe toco al zombie
        {
            zombie.Zombie zombie = collision.collider.GetComponent<zombie.Zombie>();
            Debug.Log("Wrrrrrr soy un Zombie y quiero comer"+" "+zombie.ObtenerZombieInfo().gustos);
        }

        if (collision.collider.GetComponent<ciudadano.Ciudadano>()) // colision con ciudadano 
        {
            ciudadano.Ciudadano ciud = collision.collider.GetComponent<ciudadano.Ciudadano>();
            Debug.Log("Hola soy " + ciud.Datos().nombre + " y tengo " + ciud.Datos().edad + " años");
        }
    }
}
