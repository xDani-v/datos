using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AutorNegocios
    {
        public List<Autor> viewAutors()
        {
            List<Autor> lista = new List<Autor>();
            Autor op = null;
            try
            {
                List<sp_ListarAutoresResult> auxlista = AutorData.listarAutores();
                foreach (sp_ListarAutoresResult obj in auxlista)
                {
                    op = new Autor(obj.AutorID, obj.Nombre, obj.Apellido);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Autors capa negocio:" + ex);
            }
        }

        public bool createAutor(Autor op)
        {
            try
            {
                AutorData.insertAutor(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Autor capa negocio:" + ex);
            }
        }

        public bool updateAutor(Autor op)
        {
            try
            {
                AutorData.updateAutor(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Autor capa negocio:" + ex);
            }
        }

        public bool deleteAutor(Autor op)
        {
            try
            {
                AutorData.deleteAutor(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Autor capa negocio:" + ex);
            }
        }

        public List<Autor> FiltrarAutores(string termino)
        {
            try
            {
                List<Autor> lista = new List<Autor>();
                Autor op = null;

                List<Autores> auxlista = AutorData.FiltrarAutor(termino);
                foreach (Autores obj in auxlista)
                {
                    op = new Autor(obj.AutorID, obj.Nombre, obj.Apellido);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar libros: " + ex.Message);
            }

       
        }
    }
}
