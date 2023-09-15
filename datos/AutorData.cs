using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class AutorData
    {
        public static List<sp_ListarAutoresResult> listarAutores()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarAutores().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar autores capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static void insertAutor(Autor op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_CrearAutor(op.Nombre, op.Apellido);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar autor capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateAutor(Autor op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ModificarAutor(op.AutorID, op.Nombre, op.Apellido);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar autor capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteAutor(Autor op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarAutor(op.AutorID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar autor capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Autores> FiltrarAutor(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Autores.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.Nombre.Contains(terminoBusqueda) ||
                                             l.Apellido.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
