using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Threading;
using culebrita.DatosIniciales;

namespace culebrita.clases.ColaArreglo
{
    class CulebritaColaCircular
    {
        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }
        
        private static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita Comelona - Cola Circular";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }

        private static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }

        private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }

        //IMPLEMENTAR ESTRUCTURA COLA CIRCULAR
        private static bool MoverLaCulebrita(ColaCircular culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)

        {
            var lastPoint = (Point)culebra.finalColaCircular();//METODO DEVUELVE FINAL COLA

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.Any(posiciónObjetivo))  return false;


            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
               || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine("X");

            culebra.insertarFinalCola(posiciónObjetivo);//METODO INSERTAR DE COLACIRCULAR

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");


            //ELIMINAR COLA
            if (culebra.Tamaño() > longitudCulebra)
            {
                var removePoint = (Point)culebra.quitar();//METODO QUITAR DE COLACIRCULAR
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        //IMPLEMENTAR METODO COLACIRCULAR
        private static Point MostrarComida(Size screenSize, ColaCircular culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.frenteColaCircular();//RETORNA VALOR FRENTE DE LA COLA
            var coordenada = cabezaCulebra.X;

            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(x => coordenada != x || coordenada != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                    Console.Beep(659, 125); Console.Beep(659, 125);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }

        private static void imprimirPunteo(int punteo, int vidas)
        {
            ArchivoTxt archivo = new ArchivoTxt();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuacion: {punteo.ToString("00000000")}");
            Console.SetCursorPosition(25, 0);
            Console.Write($"Máximo: {archivo.mejorPunteo(punteo)}");
            Console.SetCursorPosition(40, 0);
            Console.Write($"Vidas: {vidas}");
        }

        private int vidas = ValoresIniciales.vidas();
        private int punteo = ValoresIniciales.punteo();
        private int velocidadInicial = ValoresIniciales.velocidad();
        private int tamañoInicial = ValoresIniciales.longitud();
        private int valorComida = ValoresIniciales.valorComida();
        private int velocidadNivel = ValoresIniciales.velocidadNivel();

        public void jugarConIntentos()
        {
            var velocidad = velocidadInicial; //VELOCIDAD DE LA CULEBRITA
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20); //DIMENSION DE LA PANTALLA
            var culebrita = new ColaCircular();
            var longitudCulebra = tamañoInicial; //LARGO DE LA CULEBRITA
            var posiciónActual = new Point(0, 9); //ENTRADA DE LA CULEBRITA
            culebrita.insertarFinalCola(posiciónActual);
            var dirección = Direction.Derecha; //DIRECCION DE SALIDA

            DibujaPantalla(tamañoPantalla);
            imprimirPunteo(punteo, vidas);

            while (vidas != 0)
            {
                bool juegarsi = MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla);

                if (juegarsi)
                {
                    Thread.Sleep(velocidad);
                    dirección = ObtieneDireccion(dirección);
                    posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                    if (posiciónActual.Equals(posiciónComida))
                    {
                        posiciónComida = Point.Empty;
                        longitudCulebra++; //SE INCREMENTA EL TAMA;O DE 1 EN 1
                        punteo += valorComida; //CADA COMIDA AUMENTA 10 EL PUNTEO
                        imprimirPunteo(punteo, vidas);
                        velocidad -= velocidadNivel;
                    }

                    if (posiciónComida == Point.Empty) //CUANDO LA COMIDA ESTA EN UNA POSICION
                    {
                        posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                    }
                }
                else
                {
                    vidas--;
                    Console.ResetColor();
                    if (vidas != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(8, 2);
                        Console.Write($"\t\tTe quedan {vidas} vidas");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(12, 10);
                        Console.Write($"¡FIN DEL JUEGO!\tPuntaje Optenido: {punteo}");
                    }
                    Thread.Sleep(2000);
                    Console.ReadKey();
                    jugarConIntentos();
                }
            }
        }
    }
}



