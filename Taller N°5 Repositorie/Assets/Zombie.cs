using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using zombie = NPC.Ally;

namespace NPC
{
    namespace UNDEAD
    {

        /// <summary>
        /// en esta clase se declaran todas las variables que seran utilizadas para dar vida  al zombie
        /// se crea una instancia la la estructura contenida en otro script
        /// se declaran 3 variables tipo flotantes una par la edad,velocidad de movimiento y una que sera utilizada para iplementar un contador
        /// se dclara una variable tipo int que sera utilizada mas adelante para iplementar el comportamiento del zombie mas adelante
        /// se crean tres variables de tipo booleano una para implementar la conversion de los aldeanos a zombis y un game over con reinicio de scena
        /// otro para dar seguimiento del comportamiento del zombie con respecto a las otroas instancias creadas
        /// y otro para implementar un metodo de persecucucion
        /// el Sabor del zombie, los posibles estados del zombie
        /// se crea una variable del tipo del enum para poder operar y acceder con los elementos de este mas delante
        /// se crean 2 variables de tipo gameobjcet que serviran como referente al zombie a la hora de encontrar victimas
        /// </summary>
        public  class Zombie : MonoBehaviour
        {
            public zomboidinfo zombiestats;
            public Hero Daño;
            bool cursed = false;
            int asigna;
            public string Partes;
            public int Accion = 0;
            public float edad = 0;
            public float tempus = 0;
            public bool mirar = false;
            public float followSpeed;
            public State Zombiestate;
            public Vector3 direccion;
            float PuntoA;
            float PuntoB;
            public bool persigue = false;
            GameObject objetivo, heroe;
            GameObject[] Citizens;
            /// <summary>
            /// se crea un coruttina cuya funcion es buscar entre las instancias generadas cuales poseen los tags de heroe o ciudadano
            /// este a su vez  barre las posiciones del array de gameobjects 
            /// y espera hasta el que termine el frame para volver a ejecutar la corrutina
            /// se crea una varible local referenciada con el script de citizen para acceder al rigidbody de este
            /// se crean dos variables locales las cuales representan las distancias del citizen y del heroe
            /// luego se crea un condicional manejado por uno de los booleanos declarados en la clase
            /// y dentro de ese condicional se gneneran otros dos los cuales calculan las distancias y en base a cual sea mayor o menor se fija un objetivo
            /// despues dentro de otro condicional se calculan las distancias nuevamente en caso de que ambas sean menores a las del anterior condiconal el objetivo pasa
            /// a ser el person es decir el ciudadano en caso tal de que ambas distancias sean mayores a las ya citas entonces el booleano encargado de esta funcion sera falso
            /// la corrutina espera 0.1 segundos para volver a ser ejecutada
            /// </summary>
            /// <returns></returns>
            IEnumerator seekingvictims()
            {
                heroe = GameObject.FindGameObjectWithTag("Hero");
                Citizens = GameObject.FindGameObjectsWithTag("Citizen");
                foreach (GameObject person in Citizens)
                {
                    yield return new WaitForEndOfFrame();
                    zombie.Citizen referenciaciv = person.GetComponent<zombie.Citizen>();
                    if (referenciaciv != null)
                    {
                        PuntoB = Mathf.Sqrt(Mathf.Pow((heroe.transform.position.x - transform.position.x), 2) + Mathf.Pow((heroe.transform.position.y - transform.position.y), 2) + Mathf.Pow((heroe.transform.position.z - transform.position.z), 2));
                        PuntoA = Mathf.Sqrt(Mathf.Pow((person.transform.position.x - transform.position.x), 2) + Mathf.Pow((person.transform.position.y - transform.position.y), 2) + Mathf.Pow((person.transform.position.z - transform.position.z), 2));
                        if (!persigue)
                        {

                            if(PuntoA < 5f)
                            {
                                Zombiestate = State.Pursuing;
                                objetivo = person;
                                persigue = true;
                            }
                            else if (PuntoB < 5f)
                            {
                                Zombiestate = State.Pursuing;
                                objetivo = heroe;
                                persigue = true;
                            }
                        }
                        if (PuntoA < 5f && PuntoB < 5f)
                        {
                            objetivo = person;
                        }
                    }
                }

                if (persigue)
                {
                    if (PuntoA > 5f && PuntoB > 5f)
                    {
                        persigue = false;
                    }
                }
                
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(seekingvictims());
            }

            /// <summary>
            /// se crea un enum cuyos items corresponden a las partes del cuerpo que quiere comer el zombie
            /// </summary>
            public enum BodyParts
            {
                Cerebros, Higados, Riñones, Brazos, Piernas
            }

            /// <summary>
            /// se crea un enum cuyos items corresponden a los estados del zombie
            /// </summary>
            public enum State
            {
                Moving, Idle, Rotating, Pursuing
            }

            /// <summary>
            /// Se le asigna la informacio al zombie en caso de que el booleano del condicional sea falso 
            /// se fija la edad en un rango aleatorio
            /// se crea una nueva instancia de la estructura que contiene los datos del zombie
            /// se fija otro rango aleatorio para ser usado a la hora de asignar el color del zombie
            /// se crea un rigidbody que sera asignado al zombie
            /// se le agrega el rigidbody declarado ante al zombie
            /// se accede a las costraits del rigidbody para frezear 
            /// se deshabilita la gravedad del rigidbody
            /// se cambia el nombre del objeto
            /// si el booleano es verdareo simplemente se accede a la edad y al nombre
            /// se inicia la corutina que se encarga de buscar y seguir 
            /// se le da una velociadad al zombie dependiendo de la edad asignada
            /// se cre un entero con un rango aleatorio el cual servira para asignar una parte del cuerpo al azar
            /// se usa la variable de tipo string declarada en la clase para convertir el item asignado del enum partes en un operador de tipo texto
            /// se accede una de las variables de la estructura en este caso entojo que representa el gusto del zombie para hacer que sea el item del enum que le haya tocado
            /// se crean los condicionales para acceder a este mismo objeto y poder cambiar su color en base al numero asignado
            /// </summary>
            void Start()
            {
                if (!cursed)
                {
                    edad = (int)Random.Range(15, 101);
                    zombiestats = new zomboidinfo();
                    asigna = Random.Range(0, 3);
                    Rigidbody Zom;
                    Zom = this.gameObject.AddComponent<Rigidbody>();
                    Zom.constraints = RigidbodyConstraints.FreezeAll;
                    Zom.useGravity = false;
                    this.gameObject.name = "Zombie";
                }
                else
                {
                    edad = zombiestats.edad;
                    this.gameObject.name = zombiestats.nombre;
                }
                
                StartCoroutine(seekingvictims());
                Daño = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
                followSpeed = 10 / edad;
                this.gameObject.tag = "Zombie";
                BodyParts bodyparts;
                bodyparts = (BodyParts)Random.Range(0, 5);
                Partes = bodyparts.ToString();
                zombiestats.antojo = Partes;
                this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                
            }
            /// <summary>
            /// se fija un contador y se crea un condicional en caso de que el booleano encargado de seguir a las otras instancias sea falso
            /// luego se crea otra condicion par cuando el contador sea mayor a cierto valor
            /// se le asigne un rango aleatorio a la accion que llevara a cabo el zobie es decir su estado
            /// se activa el booleano que activa que se encarga del movimiento
            /// se reinicia el contador y se le asigna un estado segun el numero asignado dentro del rango
            /// se crea swich case para llevar el control de los stados del zombie
            /// </summary>
            void Update()
            {
                tempus += Time.deltaTime;
                if (!persigue)
                {
                    if (tempus >= 3)
                    {
                        Accion = Random.Range(0, 3);
                        mirar = true;
                        tempus = 0;
                        if (Accion == 0)
                        {
                            Zombiestate = State.Idle;
                        }
                        else if (Accion == 1)
                        {
                            Zombiestate = State.Moving;
                        }
                        else if (Accion == 2)
                        {
                           Zombiestate = State.Rotating;
                        }
                    }
                }
                
               
                //se crea un caso para cada estado cada cosa contiene las acciones a seguir segun el estado que le corrsponda
                switch (Zombiestate)
                {
                    case State.Idle:
                        break;

                    case State.Moving:
                        if (mirar)
                        {
                            this.gameObject.transform.Rotate(0, Random.Range(0, 361), 0);
                        }
                        this.gameObject.transform.Translate(0, 0, 0.05f);
                        mirar = false;
                        break;

                    case State.Rotating:
                        this.gameObject.transform.Rotate(0, Random.Range(0.5f,2f), 0);
                        break;

                    case State.Pursuing:
                        direccion = Vector3.Normalize(objetivo.transform.position - transform.position);
                        transform.position += direccion * followSpeed;
                        break;
                }
            }

            /// <summary>
            /// se crea una colision que asigna los atributos de la clase  y los sustituye por los los del ciudadano
            /// y se crea una colision con el heroe para reinicial la scena
            /// </summary>
             void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.tag == "Citizen")
                {
                    Destroy(collision.gameObject.GetComponent<NPC.Ally.Citizen>());
                    collision.gameObject.AddComponent<Zombie>().zombiestats = collision.gameObject.GetComponent<NPC.Ally.Citizen>().citizenstats;
                    collision.gameObject.GetComponent<Zombie>().cursed = true;
                   
                }

                if (collision.gameObject.tag == "Hero")
                {
                    Daño.salud -= 10;
                }
                if (collision.gameObject.tag == "Bullet")
                {
                    this.gameObject.tag = "Muerto";
                    this.gameObject.SetActive(false);
                    collision.gameObject.SetActive(false);
                }
            }

           
        }
    }
}
