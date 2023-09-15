using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class UsuarioData
    {
        public static List<sp_ListarUsuariosResult> listarUsuarios()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarUsuarios().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static void insertUsuario(Usuario op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_InsertarUsuario(op.Login, op.Email, op.Password, op.Rol);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void updateUsuario(Usuario op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ActualizarUsuario(op.UsuarioID,op.Login, op.Email, op.Password, op.Rol);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteUsuario(Usuario op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarUsuario(op.UsuarioID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Usuarios> Filtrar(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Usuarios.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.NombreUsuario.Contains(terminoBusqueda) ||
                     l.Rol.Contains(terminoBusqueda) || l.Correo.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }
    }
}
