using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Vector3 movimiento;
    float velocidad = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");// movimiento derecha - izquierda meidante input
        float v = Input.GetAxisRaw("Vertical");  // movimiento arriba - abajo
        transform.Translate(0f, 0f, v * 0.5f);  // movimiento hacia adelante
        transform.Rotate(0f, h * 1F, 0f); // rotacion 
    }

  
}
