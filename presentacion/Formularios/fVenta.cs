using entidades;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace presentacion.Formularios
{
    public partial class fVenta : Form
    {
        public fVenta()
        {
            InitializeComponent();
            LlenarComboBoxCliente();
            LlenarComboBoxUsuario();
            LlenarComboBoxProducto();
        }

        decimal precioAct = 0;
        List<VentaDetalle> listaDetalleT = new List<VentaDetalle>();


        private void AddButtonColumns()
        {

           
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnEliminar);
     
        }

        private void LlenarComboBoxCliente()
        {
            try
            {
                ClienteNegocios negocioT= new ClienteNegocios();
                // Obtener la lista de categorías desde la capa de negocio
                List<Cliente> lista = negocioT.viewClientes();

                // Configurar el ComboBox
                cCliente.DataSource = lista;
                cCliente.DisplayMember = "DisplayText";  // El nombre de la propiedad que quieres mostrar
                cCliente.ValueMember = "ClienteID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxUsuario()
        {
            try
            {
                UsuarioNegocio negocioT = new UsuarioNegocio();
                // Obtener la lista de categorías desde la capa de negocio
                List<Usuario> lista = negocioT.viewUsuarios();

                // Configurar el ComboBox
                cUsuario.DataSource = lista;
                cUsuario.DisplayMember = "login";  // El nombre de la propiedad que quieres mostrar
                cUsuario.ValueMember = "usuarioID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxProducto()
        {
            try
            {
                LibroNegocio negocioT = new LibroNegocio();
                // Obtener la lista de categorías desde la capa de negocio
                List<Libro> lista = negocioT.viewLibros();

                // Configurar el ComboBox
                cProducto.DataSource = lista;
                cProducto.DisplayMember = "Titulo";  // El nombre de la propiedad que quieres mostrar
                cProducto.ValueMember = "LibroID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxStock(int libroID)
        {
            try
            {
                // Aquí puedes obtener el stock del libro por su ID.
                // Supongamos que tienes un método en tu capa de negocio para hacerlo.
                LibroNegocio negocioT = new LibroNegocio();
                int stock = negocioT.ObtenerStockPorLibroID(libroID);

                // Llenar el ComboBox con los números del 1 al stock.
                List<int> listaStock = Enumerable.Range(1, stock).ToList();

                cCantidad.DataSource = listaStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox de stock: " + ex.Message);
            }
        }

        private void cProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Asumiendo que cProducto.SelectedItem te dará el objeto Libro seleccionado
                Libro libroSeleccionado = (Libro)cProducto.SelectedItem;

                // Ahora puedes acceder a las propiedades del libro, como LibroID
                int libroID = libroSeleccionado.LibroID;
                precioAct = libroSeleccionado.Precio;

                LlenarComboBoxStock(libroID);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("No se pudo convertir el valor seleccionado a un número entero.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void cCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue;
            if (int.TryParse(cCantidad.SelectedItem.ToString(), out selectedValue))
            {
                // Multiplicar el valor seleccionado por 2
                decimal subtotal = selectedValue * precioAct;

                // Hacer algo con el valor multiplicado (mostrarlo, usarlo en un cálculo, etc.)
                // Por ejemplo, podrías mostrarlo en un TextBox o en una etiqueta
                textBox1.Text = subtotal.ToString();
            }
            else
            {
                // Manejar el caso en que el valor seleccionado no sea un número entero
                MessageBox.Show("El valor seleccionado no es un número válido.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            VentaDetalle obj = objetoT();
            listaDetalleT.Add(obj);
            cargar();
           

        }   

        void cargar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaDetalleT;
            dataGridView1.Columns["VentaID"].Visible = false;
            dataGridView1.Columns["VentaDetalleID"].Visible = false;
             // Mueve la columna "Eliminar" al final
            if (!dataGridView1.Columns.Contains("Eliminar"))
            {
                AddButtonColumns();
            }
        }

        VentaDetalle objetoT()
        {
            VentaDetalle ventat = null;
           
      
                // Obtener los valores seleccionados de los ComboBox
                int value1 = (int)cProducto.SelectedValue;
                int value2 = (int)cCantidad.SelectedValue;
                decimal value = decimal.Parse(textBox1.Text);

               ventat = new VentaDetalle(0,0,value1,value2,value);

           
         
            return ventat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Venta dato1 = crearObjetoVenta();

            if (new VentaNegocios().createVenta(dato1,listaDetalleT))
           {
                MessageBox.Show("Nueva venta creada con éxito.");
                this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                this.Close();  // Cierra el formulario
            }
            else
            {
                MessageBox.Show("Error al crear venta.");
            }
        }

        Venta crearObjetoVenta()
        {

            Venta obj;
            int clientid = (int)cCliente.SelectedValue;
            int usuarioid = (int)cUsuario.SelectedValue;
            DateTime fechaR = dateTimePicker1.Value;
            DateTime fechaD = dateTimePicker2.Value;
            obj = new Venta(0,clientid,usuarioid,fechaR,fechaD,null,0,null);
            Console.WriteLine(obj.ToString());
            return obj;
        }

        private void fVenta_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int index = e.RowIndex;

                // Verificar si el índice es válido
                if (index >= 0 && index < listaDetalleT.Count)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este autor?", "Confirmación", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            // Eliminar el elemento de la lista
                            listaDetalleT.RemoveAt(index);

                            // Refrescar el DataGridView
                            cargar();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Índice no válido.");
                }
            }
        }
    }
}
