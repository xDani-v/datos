using entidades;
using negocio;
using presentacion.Formularios;
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
    public partial class vLenguaje : Form
    {
        LenguajeNegocio negocio = new LenguajeNegocio();

        public vLenguaje()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = negocio.viewLenguajes().ToList();
        }

        private void vLenguaje_Load(object sender, EventArgs e)
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
            fLenguaje formularioCrear = new fLenguaje();
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
                int lenguajeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["lenguajeID"].Value);
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();




                // Crear una instancia de Cliente con los datos obtenidos
                Lenguaje Seleccionado = new Lenguaje(lenguajeID,nombre);

                // Abrir el formulario de edición con el cliente seleccionado
                fLenguaje formularioEditar = new fLenguaje(Seleccionado);
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
                int lenguajeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["lenguajeID"].Value);

                // Crear una instancia de Cliente con los datos obtenidos
                Lenguaje Seleccionado = new Lenguaje(lenguajeID);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este lenguaje?", "Confirmación", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Si el lenguaje confirma, eliminar el cliente
                    try
                    {
                        if (new LenguajeNegocio().deleteLenguaje(Seleccionado))
                        {
                            MessageBox.Show("lenguaje eliminado con éxito.");
                            cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el lenguaje.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Si el lenguaje cancela, no hacer nada
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = textBox1.Text;

            dataGridView1.DataSource = negocio.Filtrar(terminoBusqueda).ToList();
        }
    }
}
