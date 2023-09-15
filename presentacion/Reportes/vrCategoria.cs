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
    public partial class vrCategoria : Form
    {
        public vrCategoria()
        {
            InitializeComponent();
        }

        dsCategoria re = new dsCategoria();
        CategoriaNegocios na = new CategoriaNegocios();

        private void vrCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                List<Categoria> la = na.viewCategorias();
                foreach (Categoria c in la)
                {
                    re.Categorias.AddCategoriasRow(c.Nombre);
                }
                rCategoria rpt = new rCategoria();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
