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

namespace presentacion.Reportes
{
    public partial class vrLibro : Form
    {
        public vrLibro()
        {
            InitializeComponent();
        }
        dsLibro re = new dsLibro();
       LibroNegocio na = new LibroNegocio();
        private void vrLibro_Load(object sender, EventArgs e)
        {
            try
            {
                List<Libro> la = na.viewLibros();
                foreach (Libro Libro in la)
                {
                    re.Libros.AddLibrosRow(Libro.Titulo, Libro.Isbn, Libro.CategoriaID, Libro.AutorID, Libro.EditorialID, Libro.LenguajeID, Libro.Stock, Libro.Tipo, Libro.Precio);
                }
                rLibros rpt = new rLibros();
                rpt.SetDataSource(re);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
