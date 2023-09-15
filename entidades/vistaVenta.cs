using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class vistaVenta
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaRealDevolucion { get; set; } // Puede ser nulo
        public decimal? Multa { get; set; } // Puede ser nulo

        // Constructor vacío
        public vistaVenta()
        {
        }

        // Constructor con parámetros
        public vistaVenta(string nombre, string apellido, DateTime fechaRenta, DateTime fechaDevolucion, decimal total, DateTime? fechaRealDevolucion, decimal? multa)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaRenta = fechaRenta;
            FechaDevolucion = fechaDevolucion;
            Total = total;
            FechaRealDevolucion = fechaRealDevolucion;
            Multa = multa;
        }
    }
}
