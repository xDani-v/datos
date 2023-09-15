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

namespace presentacion.Formularios
{
    public partial class fdevolver : Form
    {
        int ventaid = 0;
        public fdevolver(int ventaid)
        {
            InitializeComponent();
            this.ventaid = ventaid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechadevolucion = dateTimePicker1.Value;
            if (new VentaNegocios().devolver(ventaid, fechadevolucion)) {
                MessageBox.Show("Registro actualizado");
            this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
            this.Close();  // Cierra el formulario
            }
            else
            {
                MessageBox.Show("Error al realizar el proceso.");
            }
        }
                 

    }
}
