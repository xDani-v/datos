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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace presentacion.Reportes
{
    public partial class vrCliente : Form
    {
        public vrCliente()
        {
            InitializeComponent();
        }

        dsCliente re = new dsCliente();
        ClienteNegocios na = new ClienteNegocios();

        private void vrCliente_Load(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> la = na.viewClientes();
                foreach (Cliente c in la)
                {
                    re.Clientes.AddClientesRow(c.Nombre, c.Apellido, c.Direccion, c.Telefono, c.Email);
                }
                rCliente rpt = new rCliente();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
