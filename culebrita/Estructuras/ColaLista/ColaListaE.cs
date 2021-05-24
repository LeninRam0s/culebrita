using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.clases.ColaLista
{
    class ColaListaE
    {
        public Nodo frente;
        public Nodo fin;

        public int tamaño;

        //CONSTRUCTOR: INICIA LA COLA VACIA
        public ColaListaE()
        {
            frente = fin = null;
            tamaño = 0;
        }

        //VALIDA SI LA COLA ESTA VACIA
        public bool colaVacia()
        {
            return (frente == null);
        }

        //INSERTAR AL FINAL DE LA COLA
        public void insertarFinalColaLista(Point elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                frente = a;  
            }
            else
            {
                fin.siguiente = a;
            }
            fin = a;
            tamaño++;
        }

        //EXTRAER ELEMENTO Y QUE LO DEVUELVA ANTES DE QUITARLO
        public Point quitar()
        {
            Point aux;
            if (!colaVacia())
            { 
                aux = frente.elemento;
                frente = frente.siguiente;
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
            return aux;
        }

        //Vaciar la cola, o liberar todos los nodos
        //Hacemos una iteracion por toda la cola 
        public void borrarCola()
        {
            for (; frente != null;)
            {
                frente = frente.siguiente;//Pasando el siguiente asi mismo y se va eliminando
            }
        }
        //Devolver el valor que esta al frente de la cola
        public Point frenteColaLista()
        {
            if (colaVacia())
            {
                throw new Exception("ERROR, COLA VACIA");
            }
            return (frente.elemento);
        }

        public Point finalColaLista()
        {
            if (!colaVacia())
            {
                return (fin.elemento);
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }

        }

        public int Tamaño2()
        {
            int tam;
            tam = tamaño;
            return tamaño;
        }

        public int Tamaño()
        {
            int n;
            Nodo a = frente;
            if (colaVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while (a != fin)
                {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;
        }

        //EL METODO ANY DETERMINA SI UNA SECUENCIA CONTIENE ELEMENTOS.
        public bool Any(Point elemento)
        {
            Nodo aux = frente;
            bool encontrado = false;
            while(aux.siguiente != null)
            {
                aux = aux.siguiente;
                if(aux.elemento.X == elemento.X && aux.elemento.Y == elemento.Y)
                {
                    encontrado = true;
                }
            }
            return encontrado;

        }
    }//end class
}
