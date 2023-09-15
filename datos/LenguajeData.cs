using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class LenguajeData
    {
        public static List<sp_ListarLenguajesResult> listarLenguajes()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarLenguajes().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Lenguaje capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }



        public static void insertLenguaje(Lenguaje op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_CrearLenguaje(op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Lenguaje capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateLenguaje(Lenguaje op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ModificarLenguaje(op.LenguajeID, op.Nombre);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar Lenguaje capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteLenguaje(Lenguaje op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarLenguaje(op.LenguajeID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Lenguaje capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Lenguajes> Filtrar(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Lenguajes.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.NombreLenguaje.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
