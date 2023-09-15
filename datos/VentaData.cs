using entidades;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class VentaData
    {
        public static List<sp_ListarVentasResult> listarVentas()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarVentas().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar venta capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static List<sp_ListarVentaDetalleResult> listarVentasDetalle(int id)
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_ListarVentaDetalle(id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar venta detalle capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

        public static int InsertarVentaYDetalles(Venta venta, List<VentaDetalle> detalles)
        {
            using (var db = new rentaDataContext())
            {
                // Variables para almacenar los resultados de los procedimientos almacenados
                int? nuevaVentaID = 0;

                // Llamar al procedimiento almacenado para insertar una nueva venta
                db.sp_InsertarVenta(venta.ClienteID, venta.UsuarioID, venta.FechaRenta, venta.FechaDevolucion, venta.Total, ref nuevaVentaID);

                // Ahora nuevaVentaID contiene el ID de la nueva venta

                // Llamar al procedimiento almacenado para insertar los detalles de la venta
                foreach (var detalle in detalles)
                {
                    db.sp_InsertarVentaDetalle(nuevaVentaID, detalle.LibroID, detalle.Cantidad, detalle.Precio);
                }

                return nuevaVentaID ?? 0; // Devuelve el nuevo VentaID
            }
        }

        public static void devolverLibros(int id, DateTime fecha)
        {
            rentaDataContext db = null;

            try
            {
                using (db = new rentaDataContext())
                {
                    db.sp_DevolverLibros(id,fecha);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar fecha capa datos", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static List<Ventas> FiltrarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var context = new rentaDataContext())
            {
                var query = context.Ventas.AsQueryable();

                if (fechaInicio != null && fechaFin != null)
                {
                    query = query.Where(u => u.FechaRenta >= fechaInicio && u.FechaDevolucion <= fechaFin);
                }

                return query.ToList();
            }
        }

        public static List<sp_VistaVentasResult> listavistaVentas()
        {
            rentaDataContext BD = null;
            try
            {
                using (BD = new rentaDataContext())
                {
                    return BD.sp_VistaVentas().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar venta capa datos", ex);
            }
            finally
            {
                BD = null;
            }
        }

    }
}
