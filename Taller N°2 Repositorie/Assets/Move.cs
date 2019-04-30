using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Zoombie z;
    Vector3 movimiento;
    Rigidbody rb;
    float velocidad = 7.8f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");    // input de movimiento
        float v = Input.GetAxisRaw("Vertical");
        Mov(h, v);                                   // clase de flotantes se pone en el update para iniciarlo y se siga ejecutando
        rotar();                                     // clase de rotacion se pone en el update para iniciarlo y se siga ejecutando
    }

    public void Mov(float ph, float pv)              // clase para los flotantes de los ejes
    {
        movimiento.Set(ph, 0, pv);                   // movimiento horizontal en el eje x y vertical en el eje z
        movimiento = movimiento.normalized * Time.deltaTime * velocidad;  // controlar la velocidad en la que se mueve
        rb.MovePosition(transform.position + movimiento);                 // movimiento controlado
    } 

    public void rotar()                              // clase 
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit))
        {
            // resta entre el punto del rayo y la posicion del jugador
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;
            //agrego al quaternion 
            Quaternion newRotacion = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotacion);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Zoombie>())
        {
            Zoombie z = collision.collider.GetComponent<Zoombie>();                           
            // accediendo al script de zombie se se escriben sus gustos
			Debug.Log(" Waarrrrr Soy zombie y me gusta "+z.ObtenerZombieInfo().partes);
        }

        if(collision.collider.GetComponent<Ciudadano>())
        {
            Ciudadano c = collision.collider.GetComponent<Ciudadano>();
            // se accede al script de ciudadado y se escriben sus datos al azar
			Debug.Log("Mi Nombre es :" + c.DatosCiudadano().nombre + " y tengo " + c.DatosCiudadano().edad+" años");
        }
    }
}


