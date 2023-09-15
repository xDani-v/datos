
using negocio;
using presentacion.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class Form1 : Form
    {
         

        public Form1()
        {
            InitializeComponent();
            // Crear una nueva instancia del formulario de cliente
            vClientes vc = new vClientes();
            vUsuarios vu = new vUsuarios();
            vAutor va = new vAutor();
            vCategoria vca = new vCategoria();
            vEditorial ve = new vEditorial();
            vLenguaje vL = new vLenguaje();
            vLibros vli = new vLibros();
            vVenta vv = new vVenta();
            vEncuesta vEncu = new vEncuesta();

            AbrirFormularioEnPestana(vu, "Usuarios");
            AbrirFormularioEnPestana(vc, "Clientes");
            AbrirFormularioEnPestana(va, "Autores");
            AbrirFormularioEnPestana(vca, "Categorias");
            AbrirFormularioEnPestana(ve, "Editorial");
            AbrirFormularioEnPestana(vL, "Lenguaje");
            AbrirFormularioEnPestana(vli, "Libros");
            AbrirFormularioEnPestana(vv, "Ventas");
            AbrirFormularioEnPestana(vEncu, "Encuesta");
           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            vClientes vC = new vClientes();
            vC.Show();
        }

        public void AbrirFormularioEnPestana(Form formulario, string nombrePestana)
        {
            // Crear una nueva pestaña
            TabPage nuevaPestana = new TabPage(nombrePestana);

            // Añadir la pestaña al TabControl
            tabControl1.TabPages.Add(nuevaPestana);

            // Configurar el formulario para que se muestre dentro de la pestaña
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Añadir el formulario a la pestaña y mostrarlo
            nuevaPestana.Controls.Add(formulario);
            formulario.Show();
        }

    }
}
