using entidades;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion.Reportes
{
    public partial class vrVenta : Form
    {
        public vrVenta()
        {
            InitializeComponent();
        }
        dsVenta re = new dsVenta();
        VentaNegocios na = new VentaNegocios();
   
        private void vrVenta_Load(object sender, EventArgs e)
        {
            try
            {
                List<vistaVenta> la = na.ListaviewVentas();

                foreach (vistaVenta Venta in la)
                {
                  
                    re.vistaVenta.AddvistaVentaRow(Venta.Nombre,Venta.Apellido,Venta.FechaRenta,Venta.FechaDevolucion,Venta.Total,(DateTime)Venta.FechaRealDevolucion,(decimal)Venta.Multa);
                }
                rVenta rpt = new rVenta();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
