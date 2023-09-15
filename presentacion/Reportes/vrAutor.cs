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
    public partial class vrAutor : Form
    {
        public vrAutor()
        {
            InitializeComponent();
        }

        DsReporte re = new DsReporte();
        AutorNegocios na = new AutorNegocios();

        private void vrAutor_Load(object sender, EventArgs e)
        {
            try
            {
                List<Autor> la = na.viewAutors();
                foreach (Autor autor in la)
                {
                    re.Autores.AddAutoresRow(autor.Nombre, autor.Apellido);
                }
                rAutor rpt = new rAutor();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }catch (Exception ex)
            {

            }

        }
    }
}
