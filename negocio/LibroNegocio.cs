using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class LibroNegocio
    {
        public List<Libro> viewLibros()
        {
            List<Libro> lista = new List<Libro>();
            Libro op = null;
            try
            {
                List<sp_ListarLibrosResult> auxlista = LibroData.listarLibros();
                foreach (sp_ListarLibrosResult obj in auxlista)
                {
                    decimal fPrecio = Math.Round((decimal)obj.Precio, 2);
                    op = new Libro(obj.LibroID, obj.Titulo, obj.ISBN, (int)obj.CategoriaID, (int)obj.AutorID, (int)obj.EditorialID, (int)obj.LenguajeID, (int)obj.Stock, obj.Tipo, fPrecio);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Libros capa negocio:" + ex);
            }
        }

        public bool createLibro(Libro op)
        {
            try
            {
                LibroData.insertLibro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Libro capa negocio:" + ex);
            }
        }

        public bool updateLibro(Libro op)
        {
            try
            {
                LibroData.updateLibro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Libro capa negocio:" + ex);
            }
        }

        public bool deleteLibro(Libro op)
        {
            try
            {
                LibroData.deleteLibro(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Libro capa negocio:" + ex);
            }
        }

        public List<Libro> FiltrarLibros(string terminoBusqueda)
        {
            try
            {
                List<Libro> lista = new List<Libro>();
                Libro op = null;

                List<Libros> auxlista = LibroData.FiltrarLibros(terminoBusqueda);
                foreach (Libros obj in auxlista)
                {
                    op = new Libro(obj.LibroID, obj.Titulo, obj.ISBN, (int)obj.CategoriaID, (int)obj.AutorID, (int)obj.EditorialID, (int)obj.LenguajeID, (int)obj.Stock, obj.Tipo, (decimal) obj.Precio);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar libros: " + ex.Message);
            }
        }

        public int ObtenerStockPorLibroID(int libroID)
        {
            int cantidad = 0;
            List<Libro> lista = new List<Libro>();
            Libro op = null;

            List<sp_ListarLibrosResult> auxlista = LibroData.listarLibros();
            foreach (sp_ListarLibrosResult obj in auxlista)
            {
                op = new Libro(obj.LibroID, obj.Titulo, obj.ISBN, (int)obj.CategoriaID, (int)obj.AutorID, (int)obj.EditorialID, (int)obj.LenguajeID, (int)obj.Stock, obj.Tipo, (decimal)obj.Precio);
                if(op.LibroID == libroID)
                {
                    cantidad = op.Stock;
                }
            }

            return cantidad;
        }
    }
}
