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

namespace presentacion.Reportes
{
    public partial class vrUsuario : Form
    {
        public vrUsuario()
        {
            InitializeComponent();
        }
        dsUsuario re = new dsUsuario();
        UsuarioNegocio na = new UsuarioNegocio();

        private void vrUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> la = na.viewUsuarios();
                foreach (Usuario Usuario in la)
                {
                    re.Usuarios.AddUsuariosRow(Usuario.Login, Usuario.Email, Usuario.Password, Usuario.Rol, Usuario.fecha);
                }
                rUsuario rpt = new rUsuario();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
