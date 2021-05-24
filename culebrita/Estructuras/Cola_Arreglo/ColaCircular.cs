using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.clases.ColaArreglo
{
    class ColaCircular
    {
        private static int fin;
        private static int MAXTAMQ = 1000;
        protected int frente;
        protected Object[] listaCola;
        public int tamaño;

        //CONSTRUCTOR
        public ColaCircular()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            listaCola = new object[MAXTAMQ];
        }

        //AVANZA UNA POSICION
        public int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;
        }

        //VALIDACIONES
        //COLA VACIA
        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }

        public bool colaLlena()
        {
            return frente == siguiente(siguiente(fin));
        }

        //METODOS COLA CIRCULAR
        //INSERTAR DATO
        public void insertarFinalCola(Object elemento)
        {
            if (!colaLlena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;
                tamaño++;//
            }
            else
            {
                throw new Exception("DESBORDAMEINTO DE COLA");
            }


        }
        //QUITAR DATO
        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                frente = siguiente(frente);
                tamaño--;//
                return tm;
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
        }

        //BORRAR COLA
        public void borrarCola()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
        }

        //RETORNA VALOR FRENTE DE LA COLA
        public Object frenteColaCircular()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
        }

        //RETORNA VALOR FINAL DE LA COLA
        public Object finalColaCircular()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
        }

        //RETORNA EL TAMAÑO DE LA COLA
        //YA SE ENCUENTRA INSTANCIADA UNA VARIABLE TAMAÑO LA CUAL SE INCREMENTA AL AGREGAR UN ELEMENTO
        // Y SE DECREMENTA AL QUITAR UN ELEMENTO DE LA COLA
        public int Tamaño()
        {
            int tam;
            tam = tamaño;
            return tamaño;
        }

        //EL METODO ANY DETERMINA SI UNA SECUENCIA CONTIENE ELEMENTOS.
        public bool Any(Point x)
        {
            bool encontrado = false;
            for(int i = 0; i<Tamaño(); i++)
            {
                Point dato =(Point)listaCola[i];
                if(dato.X == x.X && dato.Y == x.Y)
                {
                    encontrado = true;
                }
                dato = new Point();
            }
            return encontrado;
        }
    }//FIN DE LA CLASE
}