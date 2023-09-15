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

namespace presentacion.Vistas
{
    public partial class vDetalle : Form
    {

        VentaNegocios negocio = new VentaNegocios();

        public vDetalle(int id)
        {
            InitializeComponent();
            cargar(id);
        }

        void cargar(int id)
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = negocio.viewVentasDetalle(id).ToList();
        }
    }
}
