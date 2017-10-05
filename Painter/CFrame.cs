using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
	class CFrame : Panel
	{
		public CFrame()
		{
			XCommand xCommand = new XCommand();
			CMenu cMenu = new CMenu(xCommand);
			CTabControl cTabControl = new CTabControl(xCommand);
			cTabControl.Dock = DockStyle.Bottom;
			cTabControl.Height = 350;

			xCommand.CTabControl = cTabControl;

			Controls.Add(cMenu);
			Controls.Add(cTabControl);

		}
	}
}
