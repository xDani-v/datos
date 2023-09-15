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
    public partial class fLibro : Form
    {
        private Libro objeto;

        public fLibro(Libro objeto = null)
        {
            InitializeComponent();
            this.objeto = objeto;
            LlenarComboBoxCategorias();
            LlenarComboBoxAutor();
            LlenarComboBoxEditorial();
            LlenarComboBoxLenguaje();
        }

        private void LlenarComboBoxCategorias()
        {
            try
            {
                CategoriaNegocios categoriaNegocios = new CategoriaNegocios();
                // Obtener la lista de categorías desde la capa de negocio
                List<Categoria> categorias = categoriaNegocios.viewCategorias();

                // Configurar el ComboBox
                cCategoria.DataSource = categorias;
                cCategoria.DisplayMember = "nombre";  // El nombre de la propiedad que quieres mostrar
                cCategoria.ValueMember = "categoriaID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxAutor()
        {
            try
            {
               AutorNegocios negocio = new AutorNegocios();
                // Obtener la lista de categorías desde la capa de negocio
                List<Autor> lista = negocio.viewAutors();

                // Configurar el ComboBox
                cAutor.DataSource = lista;
                cAutor.DisplayMember = "DisplayText";  // El nombre de la propiedad que quieres mostrar
                cAutor.ValueMember = "AutorID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxEditorial()
        {
            try
            {
                EditorialNegocio negocio = new EditorialNegocio();
                // Obtener la lista de categorías desde la capa de negocio
                List<Editorial> lista = negocio.viewEditorials();

                // Configurar el ComboBox
                cEditorial.DataSource = lista;
                cEditorial.DisplayMember = "Nombre";  // El nombre de la propiedad que quieres mostrar
                cEditorial.ValueMember = "EditorialID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void LlenarComboBoxLenguaje()
        {
            try
            {
                LenguajeNegocio negocio = new LenguajeNegocio();
                // Obtener la lista de categorías desde la capa de negocio
                List<Lenguaje> lista = negocio.viewLenguajes();

                // Configurar el ComboBox
                cLenguaje.DataSource = lista;
                cLenguaje.DisplayMember = "Nombre";  // El nombre de la propiedad que quieres mostrar
                cLenguaje.ValueMember = "LenguajeID";  // El nombre de la propiedad que quieres usar como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí va el mismo código de antes, pero con una pequeña modificación
                if (objeto == null)
                {
                    // Obtener los valores de los TextBox y crear una nueva instancia de categoria
                    Libro nuevo = crearObjeto();

                    // Llamar al método createcategoria de la capa de negocio
                    if (new LibroNegocio().createLibro(nuevo))
                    {
                        MessageBox.Show("libro creado con éxito.");
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
                    Libro nuevo = crearObjeto();
                    nuevo.LibroID = objeto.LibroID;

                    // Llamar al método createcategoria de la capa de negocio
                    if (new LibroNegocio().updateLibro(nuevo))
                    {
                        MessageBox.Show("libro actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el libro.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Libro crearObjeto()
        {
            string titulo = txtTitulo.Text;
            string isbn = txtISBN.Text;
            int stock = int.Parse(txtStock.Text); // Podrías querer convertir esto a un número
            string tipo = txtTipo.Text;
            int categoriaID = (int)cCategoria.SelectedValue;
            int autorID = (int)cAutor.SelectedValue;
            int editorialID = (int)cEditorial.SelectedValue;
            int lenguajeID = (int)cLenguaje.SelectedValue;
            decimal precio = decimal.Parse(txtPrecio.Text);

            Libro obj = new Libro(0,titulo,isbn,categoriaID,autorID,editorialID,lenguajeID,stock,tipo, precio);
            return obj;
        }

        private void fLibro_Load(object sender, EventArgs e)
        {
            if (objeto != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                txtTitulo.Text = objeto.Titulo;
                txtISBN.Text=objeto.Isbn;
                txtStock.Text = objeto.Stock.ToString();
                txtTipo.Text = objeto.Tipo;
                cCategoria.SelectedValue = objeto.CategoriaID;
                cAutor.SelectedValue = objeto.AutorID;
                cEditorial.SelectedValue = objeto.EditorialID;
                cLenguaje.SelectedValue = objeto.LenguajeID;
                txtPrecio.Text = objeto.Precio.ToString();
            }
        }
    }
}
