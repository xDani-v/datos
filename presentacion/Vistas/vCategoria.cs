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
    public partial class vCategoria : Form
    {

        CategoriaNegocios negocio = new CategoriaNegocios();

        public vCategoria()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = negocio.viewCategorias().ToList();
        }

        private void vCategoria_Load(object sender, EventArgs e)
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
            fCategoria formularioCrear = new fCategoria();
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
                int categoriaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["categoriaID"].Value);
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();




                // Crear una instancia de Cliente con los datos obtenidos
                Categoria Seleccionado = new Categoria(categoriaID, nombre);

                // Abrir el formulario de edición con el cliente seleccionado
                fCategoria formularioEditar = new fCategoria(Seleccionado);
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
                int categoriaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["categoriaID"].Value);

                // Crear una instancia de Cliente con los datos obtenidos
                Categoria Seleccionado = new Categoria(categoriaID);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este categoria?", "Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Si el categoria confirma, eliminar el cliente
                    try
                    {
                        if (new CategoriaNegocios().deleteCategoria(Seleccionado))
                        {
                            MessageBox.Show("categoria eliminado con éxito.");
                            cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el categoria.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Si el categoria cancela, no hacer nada
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = textBox1.Text;

            dataGridView1.DataSource = negocio.Filtrar(terminoBusqueda).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vrCategoria reporte = new vrCategoria();
            reporte.Show();
        }
    }
}
