using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
   namespace enemy
   {
        public class Zombie:MonoBehaviour
        {
            GameObject zom;
            Vector3 destino;
            Vector3 rotacion;
         
            //Enum de colores
            public enum Colores
            {
                cyan,magenta,verde
            }
            Colores colores;
            
            //Enum Comportamiento
            public enum Comportamiento
            {
                idle,Moving,Rotating
            }
            Comportamiento comportamiento;
             
            //Enum Partes
            public enum Partes
            {
                sesos,corazon,intestinos,estomago,cuello
            }
            public Partes gustos;

             //Estructura que contiene los Enums colores,comportamiento y gustos
              public struct DatosZombie
            {
               public  Colores color;
                public Partes gustos;
                public Comportamiento estados;

            }
            

             void Start()
            {
                //crea un gameobject vacio y escoge un color aleatorio entre cyan , verde, magenta 
                // asi como tambien escoge una posicion aleatoria en el mundo para aparecer y agrega componentes como Rigidbody , modifica ciertas propiedades como Constrain, y gravedad
                int aleatorio = Random.Range(0, 3);
                zom = gameObject;
                zom.name = "Zombie";
                zom.transform.position = new Vector3(Random.Range(-35, 30), 0f, Random.Range(-30, 35));
                zom.AddComponent<Rigidbody>();
                zom.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                zom.GetComponent<Rigidbody>().useGravity = false;
                 colores = (Colores)Random.Range(0, 3);
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
               
                    StartCoroutine(EstadosZombie());
                
               
                
                
            }

             void Update()
                  // ejecuta el comportamiento esocogido en la corutine

             {
                if (comportamiento == Comportamiento.idle)
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


            //metodo que devuelve un estructura con los Datos del zombie :Gustos 
            public DatosZombie ObtenerZombieInfo()
            {
                gustos = (Partes)Random.Range(0, 4); 
                DatosZombie datos = new DatosZombie();
                if (gustos == Partes.sesos)
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

            // corutine que escoge un comportamiento al azar etre idle,moving y rotating cada 3 segundos 

             public IEnumerator EstadosZombie()
            {
               
                comportamiento = (Comportamiento)Random.Range(0, 3);

                if (comportamiento == Comportamiento.idle)
                {
                    
                }

                if (comportamiento == Comportamiento.Moving)
                {
                    destino = new Vector3(Random.Range(-30, 30), 0f, Random.Range(-25, 25));
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

            // Enums 20 nombres
            public enum Nombres
            {
                Trinity, Morfeo, Neo, Hank, Nabucodonosor, Smith, Xiu, Marduk, Leviatan, Belzebu, Astarot, Behemont, Legion, Nerdal, Hawck,
                Edard, Robert, Aria, Jhon, Jamie, Rob, Catalyn
            }
          
            // Structura DatosCiudadano con 2 datos edad, nombres
            public struct DatosCiudadano
            {
                public int edad;
                public string nombre;

            }
           // DatosCiudadano date;

            void  Start()
            {
              //se crea un gameobject vacio y agrega color amarillo se escoge una posicion aleatoria en el mundo y se agrega rigidbody y modifica ciertas propiedades
                ciud = gameObject;
                ciud.GetComponent<Renderer>().material.color = Color.yellow;
                ciud.name = "Ciudadano";
                ciud.transform.position = new Vector3(Random.Range(-30, 30), 0f, Random.Range(-30, 30));
                ciud.AddComponent<Rigidbody>();
                ciud.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ciud.GetComponent<Rigidbody>().useGravity = false;
               
                
            }

            //metodo que devueve una estructura con los datos del ciudadano
            public DatosCiudadano Datos()
            {
                DatosCiudadano date = new DatosCiudadano();
                date.nombre = ((Nombres)Random.Range(0, 21)).ToString();
                date.edad = Random.Range(15, 101);

                return date;
            }

        }
    }


}
