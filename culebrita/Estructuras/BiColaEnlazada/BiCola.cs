using culebrita.clases.ColaLista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.clases.BicolaEnlazada
{
    class BiCola : ColaConLista
    {
        //Insertar por el final de la bicola
        public void insertarFinalBiCola(Point elemento)
        {
            insertar(elemento);
        }

        //Insertar al frente
        public void insertarFrenteBiCola(Point elemento)
        {
            Nodo a; //Variable auxiliar
            a = new Nodo(elemento);
            if (colaVacia())
            {
                fin = a;
            }
            else
            {
                a.siguiente = frente;
                frente = a;
            }
        }

        //Quitar elemento
        public Object quitarFrente()
        {
            return quitar();
        }

        //Retirar elemento al final
        //Metodo propio de bicola
        //Es necesario hacer una iteracion de la bicola completa para llegar del nodo anterior al final, para despues enlazar y ajustar la cola
        public Object quitarFinal()
        {
            Object aux;
            if (colaVacia())
            {
                if (frente == fin)//La bicola solo tiene un nodo
                {
                    aux = quitar();
                }
                else
                {
                    //Como no tiene elementos vamos a iterar
                    Nodo a = frente;
                    while (a.siguiente != fin)
                    {
                        a = a.siguiente;
                    }
                    //Siguiente del nodo anterior lo vamos a poner en null
                    a.siguiente = null;
                    aux = fin.elemento;
                    fin = a;
                }
            }
            else
            {
                throw new Exception("La cola esta vacia");
            }
            return aux;
        }

        //Retorna el valor que se encuentra en el primer elemento o frente de la cola
        //Devuelve el valor que esta en frente de la bicola
        public Object frenteCola()
        {
            return frenteCola();
        }

        //Devolver el final de la cola el ultimo valor de la cola
        public Object finalBicola()
        {
            if (colaVacia())
            {
                throw new Exception("Cola Vacia");
            }
            return (fin.elemento);

        }

        //RETORNA SI LA COLA ESTA VACIA
        public bool biColaVacia()
        {
            return colaVacia();
        }

        //ELIMINAR BICOLA
        public void borrarBIcola()
        {
            borrarCola();
        }

        //CUENTA ELEMENTOS
        public int elementosBicola()
        {
            int n;
            Nodo a = frente;
            if (biColaVacia())
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

        public bool Any(Point elemento)
        {
            return busquda(elemento);
        }

    }//end class
}

