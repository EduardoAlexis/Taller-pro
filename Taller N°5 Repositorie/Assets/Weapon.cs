using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// se crea la clase encargada de gestionar todo lo relacionado con el arma
/// se crea una referecia a la clase hero la cual sera usada para referenciar la poscicion del objeto
/// se crea una array de gameobjects en el cual se almacenaran los proyectiles del arma
/// se crea un gameobject el cual sera almacenado en el array declarado anteriormente
/// se crea una variable de tipo entero que sera utilizada en un contador
/// se crea una variable de tipo booleano la cual sera usada para censar si arma tiene balas
/// </summary>
public sealed class Weapon : MonoBehaviour
{
    public Hero Posicion;
    public GameObject[] bullets;
    public GameObject bullet;
    public int cuenta = 0;
    public bool ammo = true;
    /// <summary>
    /// se genera un pool de objetos que contiene todo lo necesario para el arma
    /// se fija la posicion del arma y se determina la cantidad de municion disponible
    /// se crea un ciclo for dentro del cual se administra todo lo relacionado con las balas
    /// se genera un gameobject que dara cuerpo al proyectil
    /// se le añade un rigidbody con el cual sera usado para dar un dezplazamiento al objeto
    /// se deshabilita el rigidbody del objeto
    /// se le da una posicion alejada de la escena
    /// se determina la escala del objeto
    /// se le asigna un tag al objeto
    /// se desactiva el objeto
    /// y por ultimo se almacena el objeto dentro del array
    /// </summary>
    void Start()
    {
        Posicion = FindObjectOfType<Hero>();
        bullets = new GameObject[100];

        for(int i = 0; i < bullets.Length; i++)
        {
       
            bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            
            bullet.GetComponent<Collider>().isTrigger = false;
            bullet.transform.position = new Vector3(10000, 10000, 10000);
            bullet.transform.localScale = new Vector3(.3f, .3f, .3f);
            bullet.tag = "Bullet";
            bullet.SetActive(false);
            bullets[i] = bullet;
        }
    }
   /// <summary>
   /// se crea el condicional para cuando el booleano sera verdero
   /// se implementa una tecla con la cual dispara 
   /// se iguala la posicion del objeto a la del arma
   /// se iguala la rotacion del objeto a la del arma
   /// se activa el objeto
   /// se accede al rigidbody del objeto para añadir fuerza y generar su desplazamiento constante
   /// y con cada disparo se suma uno al contador
   /// en caso de que este alcance cierta cantidad 
   /// el booleano se hace falso y por ende no se podran ejecutar mas disparos
   /// </summary>
    void Update()
    {
        if (ammo)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bullets[cuenta].transform.position = new Vector3(Posicion.weapon.transform.position.x, Posicion.weapon.transform.position.y, Posicion.weapon.transform.position.z);
                bullets[cuenta].transform.rotation = Posicion.weapon.transform.rotation;
                bullets[cuenta].SetActive(true);
                bullets[cuenta].GetComponent<Rigidbody>().AddForce(transform.up * 500f);
                cuenta += 1;
            }
            
        }
        if (cuenta == 100)
            ammo = false;
    }
}
