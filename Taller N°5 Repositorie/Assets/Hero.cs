using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using zom = NPC.UNDEAD;
using DEMON = NPC.EsPundead;
using civbody = NPC.Ally;

/// <summary>
/// se crea la clase que tendra todo lo relacionado con el heroe
/// se crean dos variables publicas tipo float que seran las encargadas de las distancias
/// y una privada que sera usa para implementar un contador
/// se crean dos elementos de gui tipo texto 
/// se crea un array de gameobjects el cual contiene las instancias zombies y citizens
/// se crean nuevas instancias de cada estructura tanto de zombie como de citizen
/// </summary>
public sealed class Hero : MonoBehaviour
{
    public Creacion OL;
    float distanciaA;
    float distanciaB;
    public float tempus;
    public int salud;
    public TextMeshProUGUI TextZombie;
    public TextMeshProUGUI TextDemon;
    public TextMeshProUGUI Textcitizen;
    public TextMeshProUGUI Textvida;
    GameObject[] citizens, zombies, Demons;
    public GameObject weapon;
    Civitasinfo civinfo = new Civitasinfo();
    zomboidinfo zombieinfo = new zomboidinfo();

    /// <summary>
    /// se le agrega un rigidbody al heroe
    /// se cambia el tag del objeto por el de heroe y asi mismo se le cambia el nombres
    /// se accede a las constraits del rigidbody del objeto para habilitarlas todas
    /// se accede al rigidbody del objeto para deshabilitar la  gravedad
    /// si inicia la corrutina que se encarga de buscar a los npcs
    /// las variables tipo texto son usadas par preguntar por un tag que debe ser asignado manualmente desde el inpector
    /// </summary>
    void Start()
    {
        //StartCoroutine(Buscarnpcs());
        print("weapon");
        weapon = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        weapon.transform.position = new Vector3(this.gameObject.transform.position.x + .314f, this.gameObject.transform.position.y + .314f, this.gameObject.transform.position.z + .314f);
        weapon.transform.localScale = new Vector3(.3f, .3f, .3f);
        weapon.transform.Rotate(90, 0, 0);
        weapon.transform.SetParent(this.gameObject.transform);
        weapon.AddComponent<Weapon>();
        salud = 100;
        //Rigidbody hero = this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.tag = "Hero";
        this.gameObject.name = "Hero";
        //hero.constraints = RigidbodyConstraints.FreezeAll;
        //hero.useGravity = false;

        TextZombie = GameObject.FindGameObjectWithTag("TextZombie").GetComponent<TextMeshProUGUI>();
        TextDemon = GameObject.FindGameObjectWithTag("TextDemon").GetComponent<TextMeshProUGUI>();
        Textcitizen = GameObject.FindGameObjectWithTag("TextCitizen").GetComponent<TextMeshProUGUI>();
        Textvida = GameObject.FindGameObjectWithTag("Textvida").GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    ///se inicia el contador con la variable flotante declarada en la clase
    /// </summary>
    public void Update()
    {
        tempus += Time.fixedDeltaTime;
        Textvida.text = salud.ToString();

        if (salud <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            OL = FindObjectOfType <Creacion>();

            OL.mensajezombie.text = "Waaaarrrr quiero comer ";
        }
        if (collision.gameObject.tag == "Demon")
        {
            OL = FindObjectOfType<Creacion>();
            
            OL.mensajezombie.text = "Waaaarrrr quiero comer " + zombieinfo.antojo;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Medicine")
        {
            salud += 5;
            if(salud >= 100)
            {
                salud = 100;
                other.gameObject.SetActive(false);
            }

        }
    }

    /// <summary>
    /// se crea la corutina encargada de medir las distancias entre el heroe y los npcs para y entregar la informacion al usuario
    /// dentro de la corutina se pregunta primero si los objetos poseen el el tag de zombie o villager
    /// se define la distanciaA y la distciaB 
    /// las cuales pertenecen a las instacias de citizen y zombie estas son llevadas a cabo cada que finaliza el frame
    /// luego en los dos condicionales siguientes se calcula la distancia y en base a si esta mas cerca
    /// o lejos se entrega un texto sin embargo en esta parte solo se de escribe el mensaje pero no se entrega
    /// esta corutina se ejecuta cada 0.1 segundos
    /// </summary>
    /// <returns></returns>
   

    /// <summary>
    /// se crea uan clase la cual contiene los axis con los que se mueve y rota el heroe
    /// </summary>
    public sealed class MoverH : MonoBehaviour
    {
        Velocidad velocidad;
        public readonly float MovX;
        private void Start()
        {
            velocidad = new Velocidad(Random.Range(0.25f, 2f));
        }

        private void Update()
        {
            float MovX = Input.GetAxisRaw("Horizontal");
            float MovY = Input.GetAxisRaw("Vertical");
            transform.Translate(0f, 0f, MovY * velocidad.velo);
            transform.Rotate(0f, MovX * 2f, 0);
        }
    }

    
    
}

/// <summary>
/// Clase para el desplazamiento read only del heroe
/// </summary>
public sealed class Velocidad
{
    public readonly float velo;
    public Velocidad(float vel)
    {
        velo = vel;
    }
}
