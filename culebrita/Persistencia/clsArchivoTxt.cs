using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace culebrita.clases
{
    class clsArchivoTxt
    {
        String path = @"G:\1.  UNIVERSIDAD 2021\1 PROGRAMACION\PROYECTOSC-SHARP\culebrita\culebrita\culebrita\Persistencia\data.txt";

        public clsArchivoTxt()
        {
           
        }
        public int punteoAnterior()
        {
            TextReader leer = new StreamReader(path);
            int punteo = Convert.ToInt32(leer.ReadLine());
            leer.Close();
            return punteo;
            
        }
        public int mejorPunteo(int punteoActual)
        {
            if(punteoActual > punteoAnterior())
            {
                TextWriter addPunteo = new StreamWriter(path);
                addPunteo.WriteLine(punteoActual);
                addPunteo.Close();
                return punteoAnterior();
            }
            else
            {
                return punteoAnterior();
            }
        }
    }
}
