using System;
using culebrita.DatosIniciales;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace culebrita.clases
{
    class clsArchivoTxt
    {
        
        String path = ValoresIniciales.pathArchivoTxt();
        
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
