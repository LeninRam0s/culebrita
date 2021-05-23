using culebrita.clases.BicolaEnlazada;
using culebrita.clases.Cola_Lista;
using culebrita.clases.ColaArreglo;
using System;
using System.Threading;

namespace culebrita.MenuJuego
{
    class menu
    {
        public static void menuOpciones()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Elija con que estructura de datos, empezar a jugar SNAKE");
                Console.WriteLine("\n1. BiCola\n2. Cola-Circular\n3. Cola-Lineal\n4. Cola-Lista\n5. Salir");
                opcion = int.Parse(Console.ReadLine());

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

                    default:
                        Console.WriteLine("Ingrese un valor valido del menu");
                        Thread.Sleep(1200);
                        break;
                }
            } while (opcion != 5);
        }
    }
}
