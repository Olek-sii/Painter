using Painter.Controllers;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.Views
{
	class PFrame : Panel
	{
		public PFrame()
		{
			IXCommand xCommand = new XCommand();
			xCommand.InitializePluginManager();

			TabControl tabControl = new TabControl();
			tabControl.Dock = DockStyle.Fill;
			tabControl.Selected += delegate { xCommand.ActivePDraw = tabControl.SelectedTab as PDraw; };
			Controls.Add(tabControl);

			xCommand.TabControl = tabControl;

			xCommand.New();
			xCommand.New();

			PElements pElements = new PElements(xCommand);
			pElements.Dock = DockStyle.Left;
			//pElements.BackColor = Color.Aqua;
            pElements.Width = 150;
			Controls.Add(pElements);

			PToolBox pToolBox = new PToolBox(xCommand);
			pToolBox.Dock = DockStyle.Right;
			pToolBox.Width = 200;
			Controls.Add(pToolBox);

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
