using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class EditorialData
    {
        public static List<sp_ListarEditorialesResult> listarEditorial()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarEditoriales().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar editoriales capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static void insertEditorial(Editorial op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_CrearEditorial(op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar editorial capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateEditorial(Editorial op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ModificarEditorial(op.EditorialID, op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar editorial capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteEditorial(Editorial op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarAutor(op.EditorialID);
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

        public static List<Editoriales> Filtrar(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Editoriales.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.NombreEditorial.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
