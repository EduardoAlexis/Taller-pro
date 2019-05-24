using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zom = NPC.UNDEAD;
using Deemon = NPC.EsPundead;
namespace NPC
{
    namespace Ally
    {
        /// <summary>
        /// esta clase es la encargada de todo lo relacionado con el ciudadano
        /// se crea una nueva instancia de la estructura del ciudadano
        /// se crea una variable del tipo del enum
        /// se crea una variable flotante que sera utilizada en un contador
        /// se crea una variable flotante que sera utilizda para calcular distancias
        /// se crea una variable tipo flotante que sera asignada a la edad del ciudadano
        /// se crea un variable entera que representa las acciones que tomara el zombie es decir sus estados
        /// se crea un booleano el cual servira para implementar el estado de runing
        /// y otro par llevar el control de la direccion del objeto
        /// se crea una variable tipo vector 3 la cual sera usada para referenciar la posicion del objeto
        /// y dos gameobjects uno que hara las veces de enemigo
        /// y el otro un array de gameobjects que lleva la cuenta de las instancias del ciudadano
        /// </summary>
        public sealed class Citizen : MonoBehaviour
        {
            public Civitasinfo citizenstats = new Civitasinfo();
            public Estado citizenstate;
            float tempus;
            public float distancia;
            public float velhuida;
            public float edad;
            int Accion;
            public bool Huida = false;
            bool mirar = false;
            public Vector3 direccion;
            GameObject Objetivo;
            GameObject[] Zombie,Demon;

            //se crea un enum cuyos elementos seran asignados a los nombres de los ciudadano
            public enum nombres
            {
                pablo, hilario, sergio, ramon, socorro, auxilio, jose, maria, luisa, nicanor, neptalí, eulalia, jacinta, ufano, candido, teodosia,
                castulo, gervasia, eufemio, higinio
            }

            /// <summary>
            /// se crea un enum cuyos elementos crresponden a los estados del ciudadano
            /// </summary>
            public enum Estado
            {
                Idle, Moving, Rotating, Running
            }

            /// <summary>
            /// se crea la corutina que controla la huida de los ciudadanos
            /// primero barre las posiciones del array y busca los objetos que poosean el  tag de zombie
            /// luego se asegura que de obtener el componente zombie es decir el script que contiene todo lo referente al zombie
            /// se crea un condicional para que en caso de que no se  tenga el componente zombie
            /// se establece una distancia propia
            /// se crean dos condicionales manejados por el boolenao encargado censar la huida del ciudadano
            /// estos trabajan en base a la distancia establecida segun sea mayor o menor activa el estado runing 
            /// y esta se ejecuta cada 0.1 segundos
            /// </summary>
            /// <returns></returns>
            IEnumerator buscaZombies()
            {
                Demon = GameObject.FindGameObjectsWithTag("Demon");
                Zombie = GameObject.FindGameObjectsWithTag("Zombie");
                foreach (GameObject Elemento in Zombie)
                {
                    zom.Zombie referentezombie = Elemento.GetComponent<zom.Zombie>();
                    if (referentezombie != null)
                    {
                        distancia = Mathf.Sqrt(Mathf.Pow((Elemento.transform.position.x - transform.position.x), 2) + Mathf.Pow((Elemento.transform.position.y - transform.position.y), 2) + Mathf.Pow((Elemento.transform.position.z - transform.position.z), 2));
                        if (!Huida)
                        {
                            if (distancia < 5f)
                            {
                                citizenstate = Estado.Running;
                                Objetivo = Elemento;
                                Huida = true;
                            }
                        }
                    }
                }

                foreach (GameObject Elemento2 in Demon)
                {
                    Deemon.Zombieesp referentezombieesp = Elemento2.GetComponent<Deemon.Zombieesp>();
                    if (referentezombieesp != null)
                    {
                       distancia = Mathf.Sqrt(Mathf.Pow((Elemento2.transform.position.x - transform.position.x), 2) + Mathf.Pow((Elemento2.transform.position.y - transform.position.y), 2) + Mathf.Pow((Elemento2.transform.position.z - transform.position.z), 2));
                        if (!Huida)
                        {
                            if(distancia < 5f)
                            {
                                citizenstate = Estado.Running;
                                Objetivo = Elemento2;
                                Huida = true;
                            }
                        }
                    }    
                }

                if (Huida)
                {
                    if (distancia > 5f)
                    {
                        Huida = false;
                    }
                }

                yield return new WaitForSeconds(0.2f);
                StartCoroutine(buscaZombies());
            }
            /// <summary>
            /// Se le asigna la informacio al ciuidadano
            /// se crea un rigidbody
            /// se cambia el nombre del objeto
            /// se le agrega el rigidbody creado anteriormente al mismo objeto
            /// se accede a las constraits del rigidbody para frezear
            /// se deshabilita la gravedad del rigidbody
            /// se crea una variable del tipo del enum que contiene los nombres
            /// se establece un rango aleatorio 
            /// por medio la nueva instancia del construtor creada en la clase se accede a la variable nombre contenida en la clase
            /// y se iguala a la variable local llamada tambien asi para convertirlo en un operador de tipo texto
            /// se establece un rango aleatorio para la edad
            /// y de nuevo usando la instancia de la estructura declarada en la clase se accede a la variable edad de la estructura
            /// y se iguala a la variable edad a la cual se le dio un rango aleatorio anteriormente
            /// se le da una velocidad a huida al ciudadano dependiendo de la edad asignada 
            /// luego se cambia el nombre del objeto por el que le asigna el enum
            /// se ejecuta la corrutina encargada de de buscar y huir de los zombies
            /// </summary>
            void Start()
            {
                Rigidbody civbody;
                this.gameObject.tag = "Citizen";
                civbody = this.gameObject.AddComponent<Rigidbody>();
                civbody.constraints = RigidbodyConstraints.FreezeAll;
                civbody.useGravity = false;
                nombres nombre;
                civbody.GetComponent<Renderer>().material.color = Color.yellow;
                nombre = (nombres)Random.Range(0, 20);
                citizenstats.nombre = nombre.ToString();
                edad = (int)Random.Range(15, 101);
                citizenstats.edad = (int)edad;
                velhuida = 10 / edad;
                this.gameObject.name = nombre.ToString();
                StartCoroutine(buscaZombies());
            }

            /// <summary>
            /// se iplementa
            /// se usa la variable tempus declarada en el constructor para implementar un contador
            /// se asigna una rango aleatorio a la variable accion que usada en en los condionales para determinar el comportamiento del zombie seugn el nuemero asignado
            /// </summary>
            void Update()
            {
                tempus += Time.deltaTime;
                if (!Huida)
                {
                    if (tempus >= 3)
                    {
                        Accion = Random.Range(0, 3);
                        mirar = true;
                        tempus = 0;
                        if (Accion == 0)
                        {
                            citizenstate = Estado.Idle;
                        }
                        else if (Accion == 1)
                        {
                            citizenstate = Estado.Moving;
                        }
                        else if (Accion == 2)
                        {
                            citizenstate = Estado.Rotating;

                        }
                    }
                }

                //se crean los casos para estado que determiba las acciones a seguir
                switch (citizenstate)
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
                        this.gameObject.transform.Rotate(0, Random.Range(1, 50), 0);
                        break;

                    case Estado.Running:
                        direccion = Vector3.Normalize(Objetivo.transform.position - transform.position);
                        transform.position -= direccion * velhuida;
                        break;
                }
            }


            
        }
    }
}

