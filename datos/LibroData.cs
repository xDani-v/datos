using entidades;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class LibroData
    {
        public static List<sp_ListarLibrosResult> listarLibros()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarLibros().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Libro capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }



        public static void insertLibro(Libro op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_CrearLibro(op.Titulo,op.Isbn,op.CategoriaID,op.AutorID,op.EditorialID,op.LenguajeID,op.Stock,op.Tipo,op.Precio);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Libro capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateLibro(Libro op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ModificarLibro(op.LibroID,op.Titulo, op.Isbn, op.CategoriaID, op.AutorID, op.EditorialID, op.LenguajeID, op.Stock, op.Tipo, op.Precio);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar Libro capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteLibro(Libro op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarLibro(op.LibroID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Libro capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Libros> FiltrarLibros(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Libros.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.Titulo.Contains(terminoBusqueda) ||
                                             l.ISBN.Contains(terminoBusqueda) ||
                                             l.Tipo.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
