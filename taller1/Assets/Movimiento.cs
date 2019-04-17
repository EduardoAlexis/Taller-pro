using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Vector3 movimiento;
    Rigidbody rb;
    float velocidad=7.8f;
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
        transform.Translate(0f, 0f, v * 0.5f);
        transform.Rotate(0f, h * 1F, 0f);
    }

  
}
