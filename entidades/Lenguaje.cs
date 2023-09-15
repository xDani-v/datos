using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Lenguaje
    {
        public Lenguaje(int lenguajeID, string nombre)
        {
            LenguajeID = lenguajeID;
            Nombre = nombre;
        }

        public Lenguaje(int lenguajeID)
        {
            LenguajeID = lenguajeID;
        }

        public int LenguajeID { get; set; }
        public string Nombre { get; set; }
    }
}
