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
    public partial class vLibros : Form
    {
        LibroNegocio negocio = new LibroNegocio();

        public vLibros()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = negocio.viewLibros().ToList();
        }

        private void vLibros_Load(object sender, EventArgs e)
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
            fLibro formularioCrear = new fLibro();
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
                int LibroID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["LibroID"].Value);
                string titulo = dataGridView1.Rows[e.RowIndex].Cells["titulo"].Value.ToString();
                int categoriaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["categoriaID"].Value);
                int autorID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["autorID"].Value);
                int editorialID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["editorialID"].Value);
                int lenguajeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["lenguajeID"].Value);
                int stock = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["stock"].Value);
                string isbn = dataGridView1.Rows[e.RowIndex].Cells["isbn"].Value.ToString();
                string tipo = dataGridView1.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["precio"].Value);


                // Crear una instancia de Cliente con los datos obtenidos
                Libro Seleccionado = new Libro(LibroID, titulo, isbn,categoriaID,autorID,editorialID,lenguajeID,stock,tipo,precio);

                // Abrir el formulario de edición con el cliente seleccionado
                fLibro formularioEditar = new fLibro(Seleccionado);
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
                int LibroID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["LibroID"].Value);

                // Crear una instancia de Cliente con los datos obtenidos
                Libro Seleccionado = new Libro(LibroID);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este Libro?", "Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Si el Libro confirma, eliminar el cliente
                    try
                    {
                        if (new LibroNegocio().deleteLibro(Seleccionado))
                        {
                            MessageBox.Show("Libro eliminado con éxito.");
                            cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el Libro.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Si el Libro cancela, no hacer nada
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = textBox1.Text;

            dataGridView1.DataSource = negocio.FiltrarLibros(terminoBusqueda).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vrLibro reporte = new vrLibro();
            reporte.Show();
        }
    }
}
