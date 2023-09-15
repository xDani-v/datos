using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Categoria
    {
        public Categoria(int categoriaID, string nombre)
        {
            CategoriaID = categoriaID;
            Nombre = nombre;
        }

        public Categoria(int categoriaID)
        {
            CategoriaID = categoriaID;
        }

        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
    }
}
