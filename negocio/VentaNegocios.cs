using datos;
using entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocios
    {
        public List<Venta> viewVentas()
        {
            List<Venta> lista = new List<Venta>();
            Venta op = null;
            try
            {
                List<sp_ListarVentasResult> auxlista = VentaData.listarVentas();
                foreach (sp_ListarVentasResult obj in auxlista)
                {
                    decimal roundedTotal = Math.Round((decimal)obj.Total, 2);
                    decimal roundedMulta = obj.Multa.HasValue ? Math.Round(obj.Multa.Value, 2) : default(decimal);
                    op = new Venta(obj.VentaID,(int)obj.ClienteID, (int)obj.UsuarioID, (DateTime)obj.FechaRenta, (DateTime)obj.FechaDevolucion, obj.FechaRealDevolucion ?? default(DateTime), roundedTotal, roundedMulta);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Ventas capa negocio:" + ex);
            }
        }

        public List<VentaDetalle> viewVentasDetalle (int id)
        {
            List<VentaDetalle> lista = new List<VentaDetalle>();
            VentaDetalle op = null;
            try
            {
                List<sp_ListarVentaDetalleResult> auxlista = VentaData.listarVentasDetalle(id);
                foreach (sp_ListarVentaDetalleResult obj in auxlista)
                {
                    decimal roundedTotal = Math.Round((decimal)obj.Precio, 2);
                    op = new VentaDetalle(obj.VentaDetalleID,(int)obj.VentaID, (int)obj.LibroID, (int)obj.Cantidad, roundedTotal);
                    lista.Add(op);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Ventas capa negocio:" + ex);
            }
        }

        public bool createVenta(Venta op, List<VentaDetalle> detalles)
        {
            try
            {
                VentaData.InsertarVentaYDetalles(op,detalles);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar venta capa negocio:" + ex);
            }
        }

        public bool devolver(int id, DateTime fecha)
        {
            try
            {
                VentaData.devolverLibros(id,fecha);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar datos capa negocio:" + ex);
            }
        }

        public List<Venta> Filtrar(DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                List<Venta> lista = new List<Venta>();
                Venta op = null;

                List<Ventas> auxlista = VentaData.FiltrarPorFecha(fechainicio,fechafin);
                foreach (Ventas obj in auxlista)
                {
                    decimal roundedTotal = Math.Round((decimal)obj.Total, 2);
                    decimal roundedMulta = obj.Multa.HasValue ? Math.Round(obj.Multa.Value, 2) : default(decimal);
                    op = new Venta(obj.VentaID, (int)obj.ClienteID, (int)obj.UsuarioID, (DateTime)obj.FechaRenta, (DateTime)obj.FechaDevolucion, obj.FechaRealDevolucion ?? default(DateTime), roundedTotal, roundedMulta);
                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar Venta: " + ex.Message);
            }


        }

        public List<vistaVenta> ListaviewVentas()
        {
            List<vistaVenta> lista = new List<vistaVenta>();
            vistaVenta op = null;
            try
            {
                List<sp_VistaVentasResult> auxlista = VentaData.listavistaVentas();
                foreach (sp_VistaVentasResult obj in auxlista)
                {
                    decimal roundedTotal = Math.Round((decimal)obj.Total, 2);
                    decimal roundedMulta = obj.Multa.HasValue ? Math.Round(obj.Multa.Value, 2) : default(decimal);

                    op = new vistaVenta(
                        obj.Nombre, // Suponiendo que estos campos existen en sp_ListarVentasResult
                        obj.Apellido, // Suponiendo que estos campos existen en sp_ListarVentasResult
                        (DateTime)obj.FechaRenta,
                        (DateTime)obj.FechaDevolucion, roundedTotal,
                        obj.FechaRealDevolucion ?? default(DateTime),
     
                        roundedMulta
                    );

                    lista.Add(op);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar Ventas capa negocio:" + ex);
            }
        }


    }
}
