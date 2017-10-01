using Painter.Views;
using System;
using System.Windows.Forms;

namespace Painter
{

	public partial class Form1 : Form
    {
        public Form1()
        {
			//InitializeComponent();

			PFrame pFrame = new PFrame();
			pFrame.Dock = DockStyle.Fill;
			Controls.Add(pFrame);
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{

		}
	}
}
