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
    public partial class vUsuarios : Form
    {
        UsuarioNegocio usuarioNegocios = new UsuarioNegocio();

        public vUsuarios()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = usuarioNegocios.viewUsuarios().ToList();
        }

        private void vUsuarios_Load(object sender, EventArgs e)
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
            fUsuario formularioCrear = new fUsuario();
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
                int usuarioID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UsuarioID"].Value);
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Login"].Value.ToString();
                string contraseña = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                string correo = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string rol = dataGridView1.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
    

                // Crear una instancia de Cliente con los datos obtenidos
                Usuario Seleccionado = new Usuario(usuarioID,nombre,contraseña,correo,rol);

                // Abrir el formulario de edición con el cliente seleccionado
                fUsuario formularioEditar = new fUsuario(Seleccionado);
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
                int usuarioID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UsuarioID"].Value);

                // Crear una instancia de Cliente con los datos obtenidos
                Usuario Seleccionado = new Usuario(usuarioID);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Si el usuario confirma, eliminar el cliente
                    try
                    {
                        if (new UsuarioNegocio().deleteUsuario(Seleccionado))
                        {
                            MessageBox.Show("usuario eliminado con éxito.");
                            cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el usuario.");
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

            dataGridView1.DataSource = usuarioNegocios.Filtrar(terminoBusqueda).ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            vrUsuario reporte = new vrUsuario();
            reporte.Show();
        }
    }
}
