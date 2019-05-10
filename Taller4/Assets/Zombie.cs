using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using villa = NPC.Ally;
namespace NPC
{
    namespace Enemy
    {

        /// <summary>
        /// Clase zombie nos encargamos de la busqueda de los aldeanos y los zombies
        /// el Sabor del zombie, los posibles estados del zombie
        /// </summary>
        public class Zombie : MonoBehaviour
        {
            public InformacionZombie informacionZombie;
            bool Infected = false;
            int numColor;
            public string Gus;
            public int D = 0;
            public float edad = 0;
            public float tiempo = 0;
            public bool mirar = false;
            public float followSpeed;
            public Estado zombieEstado;
            public Vector3 direccion;
            float distanciaUno;
            float distanciaDos;
            public bool followState = false;
            GameObject Target, heroe;
            GameObject[] aldeanos;
            /// <summary>
            /// Aqui creamos una corrutyna que otorga el estado follow del zombie
            /// </summary>
            /// <returns></returns>
            IEnumerator buscaAldeanos()
            {
                heroe = GameObject.FindGameObjectWithTag("Hero");
                aldeanos = GameObject.FindGameObjectsWithTag("Villager");
                foreach (GameObject item in aldeanos)
                {
                    yield return new WaitForEndOfFrame();
                    villa.Villager componenteAldeano = item.GetComponent<villa.Villager>();
                    if (componenteAldeano != null)
                    {
                        distanciaDos = Mathf.Sqrt(Mathf.Pow((heroe.transform.position.x - transform.position.x), 2) + Mathf.Pow((heroe.transform.position.y - transform.position.y), 2) + Mathf.Pow((heroe.transform.position.z - transform.position.z), 2));
                        distanciaUno = Mathf.Sqrt(Mathf.Pow((item.transform.position.x - transform.position.x), 2) + Mathf.Pow((item.transform.position.y - transform.position.y), 2) + Mathf.Pow((item.transform.position.z - transform.position.z), 2));
                        if (!followState)
                        {

                            if(distanciaUno < 5f)
                            {
                                zombieEstado = Estado.Pursuing;
                                Target = item;
                                followState = true;
                            }
                            else if (distanciaDos < 5f)
                            {
                                zombieEstado = Estado.Pursuing;
                                Target = heroe;
                                followState = true;
                            }
                        }
                        if (distanciaUno < 5f && distanciaDos < 5f)
                        {
                            Target = item;
                        }
                    }
                }

                if (followState)
                {
                    if (distanciaUno > 5f && distanciaDos > 5f)
                    {
                        followState = false;
                    }
                }
                
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(buscaAldeanos());
            }

            // Partes del cuerpo a comer del zombie
            public enum Sabor
            {
                Cabezas, Dedos, Lenguas, Higados, Muslos
            }

            //Diferentes estados del zombie
            public enum Estado
            {
                Moving, Idle, Rotating, Pursuing
            }

            /// <summary>
            /// Se le asigna la informacio al zombie
            /// </summary>
            void Start()
            {
                if (!Infected)
                {
                    edad = (int)Random.Range(15, 101);
                    informacionZombie = new InformacionZombie();
                    numColor = Random.Range(0, 3);
                    Rigidbody Zom;
                    Zom = this.gameObject.AddComponent<Rigidbody>();
                    Zom.constraints = RigidbodyConstraints.FreezeAll;
                    Zom.useGravity = false;
                    this.gameObject.name = "Zombie";
                }
                else
                {
                    edad = informacionZombie.edad;
                    this.gameObject.name = informacionZombie.nombre;
                }
                StartCoroutine(buscaAldeanos());
                followSpeed = 10 / edad;
                this.gameObject.tag = "Zombie";
                Sabor Sabor;
                Sabor = (Sabor)Random.Range(0, 5);
                Gus = Sabor.ToString();
                informacionZombie.sabor = Gus;

                if (numColor == 0)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (numColor == 1)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (numColor == 2)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }
            /// <summary>
            /// Se escoge de manera al azar el estado del zombie
            /// </summary>
            void Update()
            {
                tiempo += Time.deltaTime;
                if (!followState)
                {
                    if (tiempo >= 3)
                    {
                        D = Random.Range(0, 3);
                        mirar = true;
                        tiempo = 0;
                        if (D == 0)
                        {
                            zombieEstado = Estado.Idle;
                        }
                        else if (D == 1)
                        {
                            zombieEstado = Estado.Moving;
                        }
                        else if (D == 2)
                        {
                            zombieEstado = Estado.Rotating;
                        }
                    }
                }
                
                // Dependiendo del caso asi mismo se le otorga un valor segun el enum
                switch (zombieEstado)
                {
                    case Estado.Idle:
                        break;

                    case Estado.Moving:
                        if (mirar)
                        {
                            this.gameObject.transform.Rotate(0, Random.Range(0, 361), 0);
                        }
                        this.gameObject.transform.Translate(0, 0, 0.05f);
                        mirar = false;
                        break;

                    case Estado.Rotating:
                        this.gameObject.transform.Rotate(0, Random.Range(1, 10), 0);
                        break;

                    case Estado.Pursuing:
                        direccion = Vector3.Normalize(Target.transform.position - transform.position);
                        transform.position += direccion * followSpeed;
                        break;
                }
            }

            /// <summary>
            /// Un choque que otorga el virus hacia los humanos y la forma de perder
            /// </summary>
            private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.tag == "Villager")
                {
                    collision.gameObject.AddComponent<Zombie>().informacionZombie = collision.gameObject.GetComponent<NPC.Ally.Villager>().informacionAldeano;
                    collision.gameObject.GetComponent<Zombie>().Infected = true;
                    Destroy(collision.gameObject.GetComponent<NPC.Ally.Villager>());
                }

                if (collision.gameObject.tag == "Hero")
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
