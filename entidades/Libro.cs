using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Libro
    {
        public Libro(int libroID, string titulo,string isbn, int categoriaID, int autorID, int editorialID, int lenguajeID, int stock,string tipo, decimal precio)
        {
            LibroID = libroID;
            Titulo = titulo;
            CategoriaID = categoriaID;
            AutorID = autorID;
            EditorialID = editorialID;
            LenguajeID = lenguajeID;
            Stock = stock;
            Isbn = isbn;
            Tipo = tipo;
            Precio = precio;
        }

        public Libro(int libroID)
        {
            LibroID = libroID;
        }

        public int LibroID { get; set; }
        public string Titulo { get; set; }
        public int CategoriaID { get; set; }
        public int AutorID { get; set; }
        public int EditorialID { get; set; }
        public int LenguajeID { get; set; }
        public int Stock { get; set; }
        public string Isbn { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }

    }
}
