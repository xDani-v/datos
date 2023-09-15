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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace presentacion.Vistas
{
    public partial class vVenta : Form
    {
        VentaNegocios negocio = new VentaNegocios();


        public vVenta()
        {
            InitializeComponent();
            cargar();
        }

        void cargar()
        {
            // Llamar a la función ListarClientes y asignar el resultado al DataGridView
            dataGridView1.DataSource = negocio.viewVentas().ToList();
        }

        private void vVenta_Load(object sender, EventArgs e)
        {
            AddButtonColumns();
        }

        private void AddButtonColumns()
        {
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.Text = "Ver detalles";
            btnEditar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "Devolver";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEliminar);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  // Asegura que no se seleccionen los encabezados de columna

            // Detectar clic en la columna "Editar"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                int ventaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VentaID"].Value);
                vDetalle vd = new vDetalle(ventaID);
                vd.Show();
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int ventaID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VentaID"].Value);
                fdevolver vd = new fdevolver(ventaID);

                DialogResult result = vd.ShowDialog();

                // Si el formulario se cerró después de un 'Guardar exitoso', recarga los datos
                if (result == DialogResult.OK)
                {
                    cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fVenta formularioCrear = new fVenta();
            DialogResult result = formularioCrear.ShowDialog();

            // Si el formulario se cerró después de un 'Guardar exitoso', recarga los datos
            if (result == DialogResult.OK)
            {
                cargar();  // Suponiendo que 'Cargar()' es tu método para cargar datos en la tabla
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime f1 = dateTimePicker1.Value;
            DateTime f2= dateTimePicker2.Value;

            dataGridView1.DataSource = negocio.Filtrar(f1,f2).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vrVenta reporte = new vrVenta();
            reporte.Show();
        }
    }
}
