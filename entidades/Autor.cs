using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Autor
    {
        public Autor(int autorID, string nombre, string apellido)
        {
            AutorID = autorID;
            Nombre = nombre;
            Apellido = apellido;
        }

        public Autor(int autorID)
        {
            AutorID = autorID;
        }

        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DisplayText
        {
            get { return $"{Nombre} - {Apellido}"; }
        }
    }
}
