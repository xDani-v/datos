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
    public partial class fCliente : Form
    {
        private Cliente cliente;

        public fCliente(Cliente cliente = null)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí va el mismo código de antes, pero con una pequeña modificación
                if (cliente == null)
                {
                    // Obtener los valores de los TextBox y crear una nueva instancia de Cliente
                    Cliente nuevoCliente = crearObjeto();

                    // Llamar al método createCliente de la capa de negocio
                    if (new ClienteNegocios().createCliente(nuevoCliente))
                    {
                        MessageBox.Show("Cliente creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el cliente.");
                    }

                }
                else
                {
                    Cliente nuevoCliente = crearObjeto();
                    nuevoCliente.ClienteID = cliente.ClienteID;

                    // Llamar al método createCliente de la capa de negocio
                    if (new ClienteNegocios().updateCliente(nuevoCliente))
                    {
                        MessageBox.Show("Cliente actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void fCliente_Load(object sender, EventArgs e)
        {
            if (cliente != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                txtEmail.Text = cliente.Email;
            }
        }

        Cliente crearObjeto()
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;

            Cliente nuevoCliente = new Cliente(0, nombre, apellido, direccion, telefono, email);

            return nuevoCliente;
        }
    }
}
