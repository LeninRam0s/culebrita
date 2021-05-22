using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace culebrita.clases
{
    class Archivo
    {
        String path;

        public Archivo()
        {
            path = @"G:\1.  UNIVERSIDAD 2021\1 PROGRAMACION\PROYECTOSC-SHARP\culebrita\culebrita\culebrita\Persistencia\data.txt";
        }
        public int punteo()
        {
            TextReader leer = new StreamReader(path);
            int dato = Convert.ToInt32(leer.ReadLine());
            leer.Close();
            return dato;
            
        }
        public int mejorPunteo(int punteoActual)
        {
            if(punteoActual > punteo())
            {
                TextWriter agregr = new StreamWriter(path);
                agregr.WriteLine(punteoActual);
                agregr.Close();
                return punteo();
            }
            else
            {
                return punteo();
            }
        }
    }
}
