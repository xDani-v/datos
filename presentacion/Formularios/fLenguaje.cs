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
    public partial class fLenguaje : Form
    {
        private Lenguaje objeto;

        public fLenguaje(Lenguaje objeto = null)
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
                    // Obtener los valores de los TextBox y crear una nueva instancia de Lenguaje
                    Lenguaje nuevo = crearObjeto();

                    // Llamar al método createLenguaje de la capa de negocio
                    if (new LenguajeNegocio().createLenguaje(nuevo))
                    {
                        MessageBox.Show("Lenguaje creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el Lenguaje.");
                    }

                }
                else
                {
                    Lenguaje nuevo = crearObjeto();
                    nuevo.LenguajeID = objeto.LenguajeID;

                    // Llamar al método createLenguaje de la capa de negocio
                    if (new LenguajeNegocio().updateLenguaje(nuevo))
                    {
                        MessageBox.Show("Lenguaje actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el Lenguaje.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Lenguaje crearObjeto()
        {
            string nombre = textBox1.Text;

            Lenguaje nuevo = new Lenguaje(0, nombre);

            return nuevo;
        }

        private void fLenguaje_Load(object sender, EventArgs e)
        {
            if (objeto != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                textBox1.Text = objeto.Nombre;


            }
        }
    }
}
