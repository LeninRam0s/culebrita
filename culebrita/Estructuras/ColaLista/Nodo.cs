using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.clases.ColaLista
{
    class Nodo
    {
        public Point elemento;
        public Nodo siguiente;

        //CONSTRUCTOR
        public Nodo(Point x)
        {
            elemento = x;
            siguiente = null;
        }
    }
}
