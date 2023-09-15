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
    public partial class fCategoria : Form
    {

        private Categoria objeto;

        public fCategoria(Categoria objeto = null)
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
                    // Obtener los valores de los TextBox y crear una nueva instancia de categoria
                    Categoria nuevo = crearObjeto();

                    // Llamar al método createcategoria de la capa de negocio
                    if (new CategoriaNegocios().createCategoria(nuevo))
                    {
                        MessageBox.Show("categoria creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el categoria.");
                    }

                }
                else
                {
                    Categoria nuevo = crearObjeto();
                    nuevo.CategoriaID = objeto.CategoriaID;

                    // Llamar al método createcategoria de la capa de negocio
                    if (new CategoriaNegocios().updateCategoria(nuevo))
                    {
                        MessageBox.Show("categoria actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el categoria.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Categoria crearObjeto()
        {
            string nombre = txtNombre.Text;

            Categoria nuevo = new Categoria(0, nombre);

            return nuevo;
        }

        private void fCategoria_Load(object sender, EventArgs e)
        {

            if (objeto != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                txtNombre.Text = objeto.Nombre;


            }
        }
    }
}
