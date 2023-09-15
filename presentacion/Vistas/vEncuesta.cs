using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace presentacion.Vistas
{
    public partial class vEncuesta : Form
    {
        public vEncuesta()
        {
            InitializeComponent();
            generarQR();
        }

        private void generarQR()
        {
            // Reemplaza esta URL con la de tu formulario de Google Forms
            string urlFormulario = "https://forms.gle/rohbFTauNxMMZV32A";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlFormulario, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            pictureBox1.Image = qrCodeImage;
        }
    }
}
