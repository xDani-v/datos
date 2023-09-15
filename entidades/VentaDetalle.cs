using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class VentaDetalle
    {
        public int VentaDetalleID { get; set; }
        public int VentaID { get; set; }
        public int LibroID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        // Constructor vacío
        public VentaDetalle()
        {
        }

        // Constructor con parámetros
        public VentaDetalle(int ventaDetalleID, int ventaID, int libroID, int cantidad, decimal precio)
        {
            VentaDetalleID = ventaDetalleID;
            VentaID = ventaID;
            LibroID = libroID;
            Cantidad = cantidad;
            Precio = precio;
        }

    }
}
