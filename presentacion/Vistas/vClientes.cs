using entidades;
using negocio;
using presentacion.Formularios;
using presentacion.Reportes;
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
    public partial class vClientes : Form
    {
        ClienteNegocios clienteNegocios = new ClienteNegocios();

        public vClientes()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = clienteNegocios.viewClientes().ToList();
        }

        private void vClientes_Load(object sender, EventArgs e)
        {
            AddButtonColumns();
        }


        private void AddButtonColumns()
        {
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEliminar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el formulario de creación de cliente como un diálogo modal
            fCliente formularioCrear = new fCliente();
            DialogResult result = formularioCrear.ShowDialog();

            // Si el formulario se cerró después de un 'Guardar exitoso', recarga los datos
            if (result == DialogResult.OK)
            {
                cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  // Asegura que no se seleccionen los encabezados de columna

            // Detectar clic en la columna "Editar"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                // Obtener los datos de la fila seleccionada
                int clienteID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ClienteID"].Value);
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string apellido = dataGridView1.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                string direccion = dataGridView1.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                string telefono = dataGridView1.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Crear una instancia de Cliente con los datos obtenidos
                Cliente clienteSeleccionado = new Cliente(clienteID, nombre, apellido, direccion, telefono, email);

                // Abrir el formulario de edición con el cliente seleccionado
                fCliente formularioEditar = new fCliente(clienteSeleccionado);
                DialogResult result = formularioEditar.ShowDialog();

                // Si el formulario se cerró después de un 'Guardar exitoso', recarga los datos
                if (result == DialogResult.OK)
                {
                    cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Obtener los datos de la fila seleccionada
                int clienteID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ClienteID"].Value);

                // Crear una instancia de Cliente con los datos obtenidos
                Cliente clienteSeleccionado = new Cliente(clienteID);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Si el usuario confirma, eliminar el cliente
                    try
                    {
                        if (new ClienteNegocios().deleteCliente(clienteSeleccionado))
                        {
                            MessageBox.Show("Cliente eliminado con éxito.");
                            cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el cliente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Si el usuario cancela, no hacer nada
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = textBox1.Text;

            dataGridView1.DataSource = clienteNegocios.FiltrarClientes(terminoBusqueda).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vrCliente report = new vrCliente();
            report.Show();
        }
    }
}
