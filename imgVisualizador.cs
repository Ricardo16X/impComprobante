using System;
using System.Drawing;
using System.Windows.Forms;

namespace Impresora_Comprobantes
{
    public partial class imgVisualizador : Form
    {
        public imgVisualizador()
        {
            InitializeComponent();
        }

        public imgVisualizador(Form p)
        {
            InitializeComponent();
            // RECOLOCACION DE FORMULARIO DE VISTA A LA PAR DEL FORMULARIO PADRE.
            Point parentLocation = p.Location;
            Size parentSize = p.Size;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parentLocation.X + parentSize.Width, parentLocation.Y);
            
        }

        private void imgVisualizador_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            Image tmp = Clipboard.GetImage();
            if (tmp.Size.Width > Size.Width || tmp.Size.Height > Size.Height)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            pictureBox1.Image = tmp;
        }
    }
}
