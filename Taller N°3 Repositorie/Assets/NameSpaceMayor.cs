using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC //  Un namespace es una colección de clases a las que se hace referencia usando un prefijo elegido en el nombre de la clase
{
   namespace enemy
   {
        public class Zombie:MonoBehaviour
        {
            GameObject zom;
            Vector3 destino;
            Vector3 rotacion;
         

            public enum Colores // enum con colores de los zombies
            {
                cyan,magenta,verde
            }
            Colores colores;

            public enum Comportamiento // Animaciones - Comportamiento
            {
                idle,Moving,Rotating
            }
            Comportamiento comportamiento;
             
            public enum Partes // Partes del cuerpo y gustos
            {
                sesos,corazon,intestinos,estomago,cuello
            }
            public Partes gustos;

              public struct DatosZombie // estructura con los enums
            {
               public  Colores color;
                public Partes gustos;
                public Comportamiento estados;

            }
            

             void Start()
            {
                int aleatorio = Random.Range(0, 3); // un numero random de 1 a 3
                zom = gameObject;
                zom.name = "Zombie"; // definicion de zombie
                zom.transform.position = new Vector3(Random.Range(-20, 20), 0f, Random.Range(-20, 15)); // posicion en la cual puede aparecer al azar
                zom.AddComponent<Rigidbody>();
                zom.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //restringir rotacion o movimiento
                zom.GetComponent<Rigidbody>().useGravity = false;
                 colores = (Colores)Random.Range(0, 3); // eleccion al azar entre 3 numeros
                if (colores== Colores.cyan)
                {

                    zom.GetComponent<Renderer>().material.color = Color.cyan;

                }
                if (colores==Colores.magenta)
                {
                    zom.GetComponent<Renderer>().material.color = Color.magenta;
                }

                if (colores == Colores.verde)
                {
                    zom.GetComponent<Renderer>().material.color = Color.green;
                }
               
                    StartCoroutine(EstadosZombie()); // comienzo de corrutina
                
            }

             void Update()
            {
                if (comportamiento == Comportamiento.idle) // comportamientos del zombie
                {
                    Debug.Log("Estoy quieto");
                }

                if (comportamiento == Comportamiento.Moving)
                {
                    transform.Translate(destino * Time.deltaTime*0.3f);
                }
                if (comportamiento == Comportamiento.Rotating)
                {
                    transform.Rotate(rotacion);
                }
                
            }

            public DatosZombie ObtenerZombieInfo()
            {
                gustos = (Partes)Random.Range(0, 4);  // partes del cuerpo al azar
                DatosZombie datos = new DatosZombie(); // toma los datos del script datos
                if (gustos == Partes.sesos) // imprimir los gustos del zombie 
                {
                    datos.gustos = Partes.sesos;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tus" + datos.gustos);
                }
                if (gustos == Partes.corazon)
                {
                    datos.gustos = Partes.corazon;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tu" + datos.gustos);
                }
                if (gustos == Partes.intestinos)
                {
                    datos.gustos = Partes.intestinos;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tus " + datos.gustos);
                }

                if (gustos == Partes.estomago)
                {
                    datos.gustos = Partes.estomago;
                    Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.gustos);

                }
                if (gustos == Partes.cuello)
                {
                    datos.gustos = Partes.cuello;
                    Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.gustos);
                }
                return datos;

               
            }

             public IEnumerator EstadosZombie() // comportamiento de 3 distintas opciones
            {
               
                comportamiento = (Comportamiento)Random.Range(0, 3); // eleccion de comportamiento

                if (comportamiento == Comportamiento.idle)
                {
                    
                }

                if (comportamiento == Comportamiento.Moving)
                {
                    destino = new Vector3(Random.Range(-22, 20), 0f, Random.Range(-20, 20)); // espacios en los que se puede mover la corrutina
                    yield return null;
                }

                if (comportamiento == Comportamiento.Rotating)
                {
                    rotacion = new Vector3(0f, 1f, 0f);
                    yield return null;
                }

                yield return new WaitForSeconds(3f);
                yield return EstadosZombie();
            }


        }
    }

    namespace Ally
    {
        public class Ciudadano:MonoBehaviour
        {
            GameObject ciud;
            public enum Nombres // agrupacion de nombres 
            {
                Trinity, Morfeo, Neo, Hank, Nabucodonosor, Smith, Xiu, Marduk, Leviatan, Belzebu, Astarot, Behemont, Legion, Nerdal, Hawck,
                Edard, Robert, Aria, Jhon, Jamie, Rob, Catalyn
            }
          

            public struct DatosCiudadano // estructura con las variables de edad y nombre
            {
                public int edad;
                public string nombre;

            }
           // DatosCiudadano date;

            void  Start() // adicion de componentes 
            {
                ciud = gameObject;
                ciud.GetComponent<Renderer>().material.color = Color.yellow;
                ciud.name = "Ciudadano";
                ciud.transform.position = new Vector3(Random.Range(-25, 20), 0f, Random.Range(-20, 25)); // posicion en la que pueden aparecer
                ciud.AddComponent<Rigidbody>();
                ciud.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ciud.GetComponent<Rigidbody>().useGravity = false;
               
                
            }

            public DatosCiudadano Datos() // clase que toma datos como nombres y edades al azar
            {
                DatosCiudadano date = new DatosCiudadano();
                date.nombre = ((Nombres)Random.Range(0, 21)).ToString();
                date.edad = Random.Range(15, 101);

                return date;
            }

        }
    }


}
