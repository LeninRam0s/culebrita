using culebrita.clases;
using culebrita.clases.BicolaEnlazada;
using culebrita.clases.Cola_Lista;
using culebrita.clases.ColaArreglo;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace culebrita
{
    class Program
    {
        static void Main(string[] args)
        {
            //SnakeQueue JuegoQueue = new SnakeQueue();
            //JuegoQueue.jugarConIntentos();

            Console.WriteLine("Elija con que estructura de datos, empezar a jugar");
            Console.WriteLine("\n1. BiCola\n2. Cola-Circular\n3. Cola-Lineal\n4. Cola-Lista\n5. Salir");
            //Persistencia.ConexionMongoDB.insertarDatos(10);
            //String pmax = Convert.ToString(Persistencia.ConexionMongoDB.punteo());
            //Console.WriteLine(pmax);

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CulebritaBiCola biCola = new CulebritaBiCola();
                    biCola.jugarConIntentos();
                    break;
                case 2:
                    SnakeConColaCircular colaCircular = new SnakeConColaCircular();
                    colaCircular.jugarConIntentos();
                    break;
                case 3:
                    SnakeConColaLineal colaLineal = new SnakeConColaLineal();
                    colaLineal.jugarConIntentos();
                    break;
                case 4:
                    SnakeColaConLista colaConLista = new SnakeColaConLista();
                    colaConLista.jugarConIntentos();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
