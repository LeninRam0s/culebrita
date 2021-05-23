using culebrita.clases.ColaLista;
using System;
using System.Drawing;

namespace culebrita.clases.BicolaEnlazada
{
    class BiCola : ColaLista.ClsColaLista
    {
        //INSERTAR FINAL
        public void insertarFinalBiCola(Point elemento)
        {
            insertar(elemento);
        }

        //INSERTAR AL FRENTE
        public void insertarFrenteBiCola(Point elemento)
        {
            Nodo a;
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

        //QUITAR ELEMENTO AL FRENTE
        public Object quitarFrente()
        {
            return quitar();
        }

        //QUITA EL ELEMENTO AL FINAL
        public Object quitarFinal()
        {
            Object aux;
            if (colaVacia())
            {
                if (frente == fin)//SOLO POSEE UN ELEMENTO
                {
                    aux = quitar();
                }
                else
                {
                    //NO TIENE ELEMENTOS, SE ITERA
                    Nodo a = frente;
                    while (a.siguiente != fin)
                    {
                        a = a.siguiente;
                    }
                    //EL SIGUIENTE NODO LE ASIGNAMOS VALOR NULL
                    a.siguiente = null;
                    aux = fin.elemento;
                    fin = a;
                }
            }
            else
            {
                throw new Exception("ERROR, COLA VACIA");
            }
            return aux;
        }

        //DEVUELVE EL VALOR QUE ESTA EN FRENTE DE LA BICOLA
        public Object frenteBiCola()
        {
            if (colaVacia())
            {
                throw new Exception("Error porque la cola esta vacía");
            }
            return (frente.elemento);
        }

        //DEVUELVE EL FINAL DE LA COLA CON EL ELEMENTO
        public Object finalBicola()
        {
            if (colaVacia())
            {
                throw new Exception("ERROR, COLA VACIA");
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

        //BUSCA ELEMENTOS
        public bool Any(Point elemento)
        {
            return busquda(elemento);
        }

    }//FIN DE LA CLASE
}
