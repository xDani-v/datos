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
    public partial class fAutor : Form
    {

        private Autor objeto;

        public fAutor(Autor objeto = null)
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
                    // Obtener los valores de los TextBox y crear una nueva instancia de autor
                    Autor nuevo = crearObjeto();

                    // Llamar al método createautor de la capa de negocio
                    if (new AutorNegocios().createAutor(nuevo))
                    {
                        MessageBox.Show("autor creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el autor.");
                    }

                }
                else
                {
                    Autor nuevo = crearObjeto();
                    nuevo.AutorID = objeto.AutorID;

                    // Llamar al método createautor de la capa de negocio
                    if (new AutorNegocios().updateAutor(nuevo))
                    {
                        MessageBox.Show("autor actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el autor.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Autor crearObjeto()
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;


            Autor nuevo = new Autor(0, nombre,apellido);

            return nuevo;
        }

        private void fAutor_Load(object sender, EventArgs e)
        {

            if (objeto != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                txtNombre.Text = objeto.Nombre;
                txtApellido.Text = objeto.Apellido;

            }
        }
    }
}
