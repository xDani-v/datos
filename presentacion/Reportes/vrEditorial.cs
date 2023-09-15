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
    public partial class vrEditorial : Form
    {
        public vrEditorial()
        {
            InitializeComponent();
        }
        dsEditorial re = new dsEditorial();
        EditorialNegocio na = new EditorialNegocio();
        private void vrEditorial_Load(object sender, EventArgs e)
        {
            try
            {
                List<Editorial> la = na.viewEditorials();
                foreach (Editorial c in la)
                {
                    re.Editoriales.AddEditorialesRow(c.Nombre);
                }
                rEditorial rpt = new rEditorial();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
