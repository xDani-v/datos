using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Editorial
    {
        public Editorial(int editorialID, string nombre)
        {
            EditorialID = editorialID;
            Nombre = nombre;
        }

        public Editorial(int editorialID)
        {
            EditorialID = editorialID;
        }

        public int EditorialID { get; set; }
        public string Nombre { get; set; }
    }
}
