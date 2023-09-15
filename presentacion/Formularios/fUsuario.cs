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
    public partial class fUsuario : Form
    {
        private Usuario usuario;

        public fUsuario(Usuario usuario = null)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Aquí va el mismo código de antes, pero con una pequeña modificación
                if (usuario == null)
                {
                    // Obtener los valores de los TextBox y crear una nueva instancia de usuario
                    Usuario nuevousuario = crearObjeto();

                    // Llamar al método createusuario de la capa de negocio
                    if (new UsuarioNegocio().createUsuario(nuevousuario))
                    {
                        MessageBox.Show("usuario creado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el usuario.");
                    }

                }
                else
                {
                    Usuario nuevousuario = crearObjeto();
                    nuevousuario.UsuarioID = usuario.UsuarioID;

                    // Llamar al método createusuario de la capa de negocio
                    if (new UsuarioNegocio().updateUsuario(nuevousuario))
                    {
                        MessageBox.Show("usuario actualizado con éxito.");
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        Usuario crearObjeto()
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string contra = txtContraseña.Text;
            string rol = txtrol.Text;


            Usuario nuevo = new Usuario(0, nombre,contra,correo,rol);

            return nuevo;
        }

        private void fUsuario_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                // Rellena los TextBox con los datos del cliente para editar
                txtNombre.Text = usuario.Login;
                txtCorreo.Text = usuario.Email;
                txtContraseña.Text = usuario.Password;
                txtrol.Text = usuario.Rol;
            }
        }
    }
}
