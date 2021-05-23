using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.clases.ColaLista
{
    class ClsColaLista
    {
        public Nodo frente;
        public Nodo fin;

        public int tamaño;

        //CONSTRUCTOR: INICIA LA COLA VACIA
        public ClsColaLista()
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
        public void insertar(Point elemento)
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
        public Point frenteCola()
        {
            if (colaVacia())
            {
                throw new Exception("Error porque la cola esta vacía");
            }
            return (frente.elemento);
        }

        public Point finalColaConLista()
        {
            if (!colaVacia())
            {
                return (fin.elemento);
            }
            else
            {
                throw new Exception("Cola vacia");
            }

        }

        public int Tamaño()
        {
            return tamaño;
        }

        public bool busquda(Point elemento)
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
