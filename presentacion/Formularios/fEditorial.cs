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

namespace presentacion.Formularios
{
    public partial class fEditorial : Form
    {

        private Editorial objeto;

        public fEditorial(Editorial objeto = null)
        {
            InitializeComponent();
            this.objeto = objeto;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Aquí va el mismo código de antes, pero con una pequeña modificación
                if (objeto == null)
                {
                    // Obtener los valores de los TextBox y crear una nueva instancia de editorial
                    Editorial nuevo = crearObjeto();

                    // Llamar al método createeditorial de la capa de negocio
                    if (new EditorialNegocio().createEditorial(nuevo))
                    {
                        MessageBox.Show("editorial creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el editorial.");
                    }

                }
                else
                {
                    Editorial nuevo = crearObjeto();
                    nuevo.EditorialID = objeto.EditorialID;

                    // Llamar al método createeditorial de la capa de negocio
                    if (new EditorialNegocio().updateEditorial(nuevo))
                    {
                        MessageBox.Show("editorial actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el editorial.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Editorial crearObjeto()
        {
            string nombre = textBox1.Text;

            Editorial nuevo = new Editorial(0, nombre);

            return nuevo;
        }

        private void fEditorial_Load(object sender, EventArgs e)
        {
            if (objeto != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                textBox1.Text = objeto.Nombre;


            }
        }
    }
}
