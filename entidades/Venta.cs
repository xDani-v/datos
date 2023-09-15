using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Venta
    {
        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime? FechaRealDevolucion { get; set; }  // Puede ser nulo si aún no se ha devuelto
        public decimal Total { get; set; }
        public decimal? Multa { get; set; }  // Puede ser nulo si no hay multa

        // Constructor vacío
        public Venta()
        {
        }

        // Constructor con parámetros
        public Venta(int ventaID, int clienteID, int usuarioID, DateTime fechaRenta, DateTime fechaDevolucion, DateTime? fechaRealDevolucion, decimal total, decimal? multa)
        {
            VentaID = ventaID;
            ClienteID = clienteID;
            UsuarioID = usuarioID;
            FechaRenta = fechaRenta;
            FechaDevolucion = fechaDevolucion;
            FechaRealDevolucion = fechaRealDevolucion;
            Total = total;
            Multa = multa;
        }
    }
}
