using System;
using System.Drawing;

namespace culebrita.clases.ColaArreglo
{
    class ColaLineal
    {
        protected int fin;
        private static int MAXTAMQ = 1000;
        protected int frente;
        protected Object[] listaCola;
        public int tamaño;

        //CONSTRUCTOR
        public ColaLineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new object[MAXTAMQ];
        }

        //VALIDADORES
        //COLA VACIA
        public bool colaVacia()
        {
            return frente > fin;
        }

        //COLA LLENA
        public bool colaLlena()
        {
            return fin == MAXTAMQ - 1;
        }

        //METODOS DE COLA
        public void insertarColaLineal(Object elemento)
        {
            if (!colaLlena())
            {
                listaCola[++fin] = elemento;
                tamaño++;
            }
            else
            {
                throw new Exception("DESBORDAMIENTO DE LA COLA");
            }
        }

        //QUITAR ELEMENTO
        public Object quitarColaLineal()
        {
            if (!colaVacia())
            {
                tamaño--;
                return listaCola[frente++];
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
        }

        //BORRAR COLA
        public void borrarColaLineal()
        {
            frente = 0;
            fin = -1;
        }

        //RETORNA FRENTE COLA
        public Object frenteColalineal()
        {
            if (!colaVacia())
            {
                tamaño--;
                return listaCola[frente];
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
        }

        //RETORNA FINAL COLA
        public Object finalColaLineal()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("Cola vacia");
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
            for (int i = 0; i < Tamaño(); i++)
            {
                Point dato = (Point)listaCola[i];
                if (dato.X == x.X && dato.Y == x.Y)
                {
                    encontrado = true;
                }
                dato = new Point();
            }
            return encontrado;
        }

    }//FIN DE LA CLASE
}