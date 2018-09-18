using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace El_Buen_Tamal_Bordeado
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> Tamalito;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog tamalitoOfd = new OpenFileDialog();

            if (tamalitoOfd.ShowDialog() == DialogResult.OK)
            {
                Tamalito = new Image<Bgr, byte>(tamalitoOfd.FileName);

                imageBox1.Image = Tamalito;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tamalito == null)
            {
                return;
            }

            Image<Gray, byte> TamalitoCanny = new Image<Gray, byte>(Tamalito.Width, Tamalito.Height, new Gray(0));

            TamalitoCanny = Tamalito.Canny(50, 30);
            imageBox1.Image = TamalitoCanny;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tamalito == null)
            {
                return;
            }

            Image<Gray, byte> TamalitoGray = Tamalito.Convert<Gray, byte>();
            Image<Gray, float> TamalitoSobel = new Image<Gray, float>(Tamalito.Width, Tamalito.Height, new Gray(0));

            TamalitoSobel = TamalitoGray.Sobel(1, 1, 1);
            imageBox1.Image = TamalitoSobel;
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tamalito == null)
            {
                return;
            }

            Image<Gray, byte> TamalitoGray = Tamalito.Convert<Gray, byte>();
            Image<Gray, float> TamalitoLaplacian = new Image<Gray, float>(Tamalito.Width, Tamalito.Height, new Gray(0));

            TamalitoLaplacian = TamalitoGray.Laplace(9);
            imageBox1.Image = TamalitoLaplacian;
        }
    }
}
