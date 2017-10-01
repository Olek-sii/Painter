using Painter.Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Views
{
	class PFrame : Panel
	{
		public PFrame()
		{
			PluginManager.LoadPlugins();
			XCommand xCommand = new XCommand();

			PMainMenu pMainMenu = new PMainMenu(xCommand);
			pMainMenu.Dock = DockStyle.Top;
			pMainMenu.Height = 50;
			pMainMenu.BackColor = Color.Green;
			Controls.Add(pMainMenu);

			PDraw pDraw = new PDraw(xCommand);
			pDraw.Dock = DockStyle.Fill;
			pDraw.BackColor = Color.Wheat;
			pDraw.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(pDraw);
		}
	}
}
