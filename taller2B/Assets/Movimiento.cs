using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Zoombie z;
    Vector3 movimiento;
    Rigidbody rb;
    float velocidad = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Mov(h, v);
        rotar();
    }

    public void Mov(float ph, float pv)
    {
        movimiento.Set(ph, 0, pv);
        movimiento = movimiento.normalized * Time.deltaTime * velocidad;
        rb.MovePosition(transform.position + movimiento);
    }

    public void rotar()
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
			Debug.Log(" Waarrrrr Soy un zombie y me gusta "+z.ObtenerZombieInfo().partes);
        }

        if(collision.collider.GetComponent<Ciudadano>())
        {
            Ciudadano c = collision.collider.GetComponent<Ciudadano>();
			Debug.Log("Mi Nombre es :" + c.DatosCiudadano().nombre + " y tengo " + c.DatosCiudadano().edad+" años");
        }
    }
}


