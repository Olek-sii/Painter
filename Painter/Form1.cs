using Painter.Views;
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
	}
}
