using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zom = NPC.Enemy;

namespace NPC
{
    namespace Ally
    {
        /// <summary>
        /// Le asignamos un nombre y años a los villagers aqui
        /// </summary>
        public class Villager : MonoBehaviour
        {
            public InformacionVillager informacionAldeano = new InformacionVillager();
            public Estado estadoVillager;
            float tiempo;
            public float distancia;
            public float velocidadCorrer;
            public float edad;
            int D;
            public bool velocidadEstado = false;
            bool mirar = false;
            public Vector3 direccion;
            GameObject Target;
            GameObject[] villagers;

            // array para los nombres que se asignaran a los villagers
            public enum nombres
            {
                Angie, Carlos, Felipe, Anderson, Thobias, Mateo,Freddy, Andres, Paola, Paula, Manuela, Jorge, Rosa, Fernando, Camilo, Alej, Camila, Laura, Daniela, Tifanny
            }

            // Diferentes estados de los villagers 
            public enum Estado
            {
                Idle, Moving, Rotating, Running
            }

            /// <summary>
            /// corrutina que hace  el estado running del villager
            /// </summary>
            /// <returns></returns>
            IEnumerator buscaZombies()
            {
                villagers = GameObject.FindGameObjectsWithTag("Zombie");
                foreach (GameObject item in villagers)
                {
                    zom.Zombie componenteZombie = item.GetComponent<zom.Zombie>();
                    if (componenteZombie != null)
                    {
                        distancia = Mathf.Sqrt(Mathf.Pow((item.transform.position.x - transform.position.x), 2) + Mathf.Pow((item.transform.position.y - transform.position.y), 2) + Mathf.Pow((item.transform.position.z - transform.position.z), 2));
                        if (!velocidadEstado)
                        {
                            if (distancia < 5f)
                            {
                                estadoVillager = Estado.Running;
                                Target = item;
                                velocidadEstado = true;
                            }
                        }
                    }
                }

                if (velocidadEstado)
                {
                    if (distancia > 5f)
                    {
                        velocidadEstado = false;
                    }
                }

                yield return new WaitForSeconds(0.1f);
                StartCoroutine(buscaZombies());
            }
            /// <summary>
            /// Se le asigna la informacion al villager
            /// </summary>
            void Start()
            {
                Rigidbody Villa;
                this.gameObject.tag = "Villager";
                Villa = this.gameObject.AddComponent<Rigidbody>();
                Villa.constraints = RigidbodyConstraints.FreezeAll;
                Villa.useGravity = false;
                nombres nombre;
                nombre = (nombres)Random.Range(0, 20);
                informacionAldeano.nombre = nombre.ToString();
                edad = (int)Random.Range(15, 101);
                informacionAldeano.edad = (int)edad;
                velocidadCorrer = 10 / edad;
                this.gameObject.name = nombre.ToString();
                StartCoroutine(buscaZombies());
            }

            /// <summary>
            /// Se escoge al azar el estado del villager
            /// </summary>
            void Update()
            {
                tiempo += Time.deltaTime;
                if (!velocidadEstado)
                {
                    if (tiempo >= 3)
                    {
                        D = Random.Range(0, 3);
                        mirar = true;
                        tiempo = 0;
                        if (D == 0)
                        {
                            estadoVillager = Estado.Idle;
                        }
                        else if (D == 1)
                        {
                            estadoVillager = Estado.Moving;
                        }
                        else if (D == 2)
                        {
                            estadoVillager = Estado.Rotating;

                        }
                    }
                }

                switch (estadoVillager)
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

                    case Estado.Running:
                        direccion = Vector3.Normalize(Target.transform.position - transform.position);
                        transform.position -= direccion * velocidadCorrer;
                        break;
                }
            }
        }
    }
}

