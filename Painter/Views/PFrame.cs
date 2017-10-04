using Painter.Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Views
{
	class PFrame : Panel
	{
		public PFrame()
		{
			XCommand xCommand = new XCommand();

			PDraw pDraw = new PDraw(xCommand);
			pDraw.Dock = DockStyle.Fill;
			//pDraw.BackColor = Color.Wheat;
			pDraw.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(pDraw);

			PElements pElements = new PElements(xCommand);
			pElements.Dock = DockStyle.Left;
			//pElements.BackColor = Color.Aqua;
            pElements.Width = 100;
			Controls.Add(pElements);

            PToolBar pToolBar = new PToolBar(xCommand);
            pToolBar.Dock = DockStyle.Top;
            Controls.Add(pToolBar);

            PMainMenu pMainMenu = new PMainMenu(xCommand);
			pMainMenu.Dock = DockStyle.Top;
			pMainMenu.Height = 50;
			//pMainMenu.BackColor = Color.Green;
			Controls.Add(pMainMenu);
            
            PStatusBar pStatusBar = new PStatusBar(xCommand);
            pStatusBar.Dock = DockStyle.Bottom;
            Controls.Add(pStatusBar);

            

        }
	}
}
