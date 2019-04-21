using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seg_Cam : MonoBehaviour
{
    public Transform Personaje;
    public float smmothing = 4.9f;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Personaje.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 campo = Personaje.position + offset;
        transform.position = Vector3.Lerp(transform.position, campo, smmothing * Time.deltaTime); 
    }
}
