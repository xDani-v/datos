using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades;

namespace datos
{
    public class ClienteData
    {
        public static List<sp_ListarClientesResult> listarClientes()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarClientes().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar cliente capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }



        public static void insertCliente(Cliente op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_InsertarCliente(op.Nombre, op.Apellido, op.Direccion, op.Telefono, op.Email);
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

        public static void updateCliente(Cliente op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_ActualizarCliente(op.ClienteID, op.Nombre, op.Apellido, op.Direccion, op.Telefono, op.Email);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar cliente capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static void deleteCliente(Cliente op)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_EliminarCliente(op.ClienteID);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Clientes> Filtrar(string terminoBusqueda)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Clientes.AsQueryable();


                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    query = query.Where(l => l.Apellido.Contains(terminoBusqueda)
                    || l.Nombre.Contains(terminoBusqueda) || l.Nombre.Contains(terminoBusqueda) || l.Email.Contains(terminoBusqueda));
                }

                return query.ToList();
            }
        }

    }
}
