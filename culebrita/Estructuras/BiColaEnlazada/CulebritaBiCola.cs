using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Threading;


namespace culebrita.clases.BicolaEnlazada
{

    class CulebritaBiCola
    {
        private int vidas = 3;
        private int punteo = 0;
        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }


        private static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita comelona - Bi Cola";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkCyan;//COLOR DE BORDE
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;//COLOR FONDO
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }

        private static void vistaPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuacion: {punteo.ToString("00000000")}");
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

        private static bool MoverLaCulebrita(BiCola culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
           
        {
            var lastPoint = (Point) culebra.finalBicola();//IMPLEMENTACION DE ESTRUCTURA BICOLA

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.Any(posiciónObjetivo)) return false;///////////////////
           

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Gray;//COLOR CUERPO
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertarFinalBiCola(posiciónObjetivo);//COLOCAR LA COMIDA AL FINAL DE BICOLA

            Console.BackgroundColor = ConsoleColor.Red; //COLOR CABEZA
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            if (culebra.elementosBicola() > longitudCulebra)//CUENTA LOS ELEMENTOS DE LA BICOLA
            {
                var removePoint = (Point) culebra.quitarFrente();//QUITA EL ELEMENTO DE BICOLA
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point MostrarComida(Size screenSize, BiCola culebra)
        {
            
            var lugarComida = Point.Empty;

            var cabezaCulebra = (Point) culebra.finalBicola();//DEVUELVE FINAL DE LA BICOLA CON EL ULTIMO DATO
            var coordenada = cabezaCulebra.X;//////////////////////////////////////////////////

            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(x => coordenada != x || coordenada != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                    Console.Beep(659, 125);
                    Console.Beep(659, 125);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }

        private static void MuestraPunteoK(int punteo, int vidas)
        {
            Archivo archivo = new Archivo();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuacion: {punteo.ToString("00000000")}");
            Console.SetCursorPosition(25, 0);
            Console.Write($"Máximo: {archivo.mejorPunteo(punteo)}");
            Console.SetCursorPosition(40, 0);
            

            switch (vidas)
            {
                case 1:
                    Console.Write($"VIDAS: {(char)3}");
                    break;
                case 2:
                    Console.Write($"VIDAS: {(char)3} {(char)3} ");
                    break;
                case 3:
                    Console.Write($"VIDAS: {(char)3} {(char)3} {(char)3}");
                    break;
            }
        }
        public void jugarConIntentos()
        {
            var velocidad = 80; //VELOCIDAD DE LA CULEBRITA
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20); //DIMENSION DE LA PANTALLA
            var culebrita = new BiCola();
            var longitudCulebra = 5; //LARGO DE LA CULEBRITA
            var posiciónActual = new Point(0, 9); //ENTRADA DE LA CULEBRITA
            culebrita.insertarFinalBiCola(posiciónActual);
            var dirección = Direction.Derecha; //DIRECCION DE SALIDA

            DibujaPantalla(tamañoPantalla);
            MuestraPunteoK(punteo, vidas);

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
                        punteo += 10; //CADA COMIDA AUMENTA 10 EL PUNTEO
                        MuestraPunteoK(punteo, vidas);
                        velocidad -= 10;
                    }

                    if (posiciónComida == Point.Empty) //entender qué hace esta linea
                    {
                        posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                    }
                }
                else
                {
                    vidas--;
                    Console.ResetColor();
                    Console.SetCursorPosition(tamañoPantalla.Width / 2 - 15, tamañoPantalla.Height / 2);
                    if (vidas == 0)
                    {
                        Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
                        Console.Write($"¡FIN DEL JUEGO!");
                    }
                    else
                    {
                        Console.Write($"\t\tTe quedan {vidas} vidas");
                    }

                    Thread.Sleep(2000);
                    Console.ReadKey();

                    jugarConIntentos();
                }

            }
        }
    }
}


