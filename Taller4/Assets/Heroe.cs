using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zom = NPC.Enemy;
using villa = NPC.Ally;

/// <summary>
/// calculamos las distancias con respecto a las demas entidades
/// </summary>
public class Heroe : MonoBehaviour
{
    float distanciaUno;
    float distanciaDos;
    public float time;
    public Text TextZombie;
    public Text TextVillager;
    GameObject[] aldeanos, zombie;

    InformacionVillager informacionAldeano = new InformacionVillager();
    InformacionZombie informacionZombie = new InformacionZombie();

    /// <summary>
    /// Le damos la informacion al heroe
    /// </summary>
    void Start()
    {
        this.gameObject.tag = "Hero";
        Rigidbody hero = this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.name = "Heroe";
        hero.constraints = RigidbodyConstraints.FreezeAll;
        hero.useGravity = false;
        StartCoroutine(BuscaEntidades());
        TextZombie = GameObject.FindGameObjectWithTag("TextZombie").GetComponent<Text>();
        TextVillager = GameObject.FindGameObjectWithTag("TextAldeano").GetComponent<Text>();
    }

    /// <summary>
    /// Colocamos un conteo
    /// </summary>
    public void Update()
    {
        time += Time.fixedDeltaTime;
    }

    /// <summary>
    /// Podemos ver la distancia entre el heroe y lo demas para permitirnos una mejor dirreccion
    /// </summary>
    /// <returns></returns>
    IEnumerator BuscaEntidades()
    {
        zombie = GameObject.FindGameObjectsWithTag("Zombie");
        aldeanos = GameObject.FindGameObjectsWithTag("Villager");

        // Informacion sobre el villager
        foreach (GameObject item in aldeanos)
        {
            yield return new WaitForEndOfFrame();
            villa.Villager componenteAldeano = item.GetComponent<villa.Villager>();
            if (componenteAldeano != null)
            {              
                distanciaUno = Mathf.Sqrt(Mathf.Pow((item.transform.position.x - transform.position.x), 2) + Mathf.Pow((item.transform.position.y - transform.position.y), 2) + Mathf.Pow((item.transform.position.z - transform.position.z), 2));
                if (distanciaUno < 5f)
                {
                    time = 0;
                    informacionAldeano = item.GetComponent<villa.Villager>().informacionAldeano;
                    TextVillager.text = "Hola, soy " + informacionAldeano.nombre + " y tengo " + informacionAldeano.edad.ToString() + " años";
                }
                if (time > 3)
                {
                    TextVillager.text = " ";
                }
            }
        }

        // Informacion sobre el zombie
        foreach (GameObject itemZ in zombie)
        {
            yield return new WaitForEndOfFrame();
            zom.Zombie componenteZombie = itemZ.GetComponent<zom.Zombie>();
            if (componenteZombie != null)
            {              
                distanciaDos = Mathf.Sqrt(Mathf.Pow((itemZ.transform.position.x - transform.position.x), 2) + Mathf.Pow((itemZ.transform.position.y - transform.position.y), 2) + Mathf.Pow((itemZ.transform.position.z - transform.position.z), 2));
                if (distanciaDos < 5f)
                {
                    time = 0;
                    informacionZombie = itemZ.GetComponent<zom.Zombie>().informacionZombie;
                    TextZombie.text = "Waaaarrrr quiero comer " + informacionZombie.sabor;
                }
                if (time > 3)
                {
                    TextZombie.text = " ";
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(BuscaEntidades());
    }

    /// <summary>
    /// Clase que permite el movimiento del heroe
    /// </summary>
    public class MoverH : MonoBehaviour
    {

        Velocidad velocidad;

        private void Start()
        {
            velocidad  = new Velocidad(Random.Range(0.25f, 0.5f));
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.transform.Translate(0, 0, velocidad.velo);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.gameObject.transform.Translate(0, 0, -velocidad.velo);
            }
        }
    }

    /// <summary>
    /// Clase para la rotacion del heroe
    /// </summary>
    public class MirarH : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.Rotate(0, -3, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.Rotate(0, 3, 0);
            }
        }
    }
}

/// <summary>
/// Clase para el desplazamiento read only del heroe
/// </summary>
public class Velocidad
{
    public readonly float velo;
    public Velocidad(float vel)
    {
        velo = vel;
    }
}
