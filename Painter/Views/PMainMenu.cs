using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PMainMenu : MenuStrip
    {
		private XCommand _xCommand = null;
		public XCommand XCommand { set => _xCommand = value; }

		public PMainMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

			Items.Add(new ToolStripButton("debug", null, delegate { _xCommand.Debug(); }));

			foreach (IPluginFigure item in PluginManager.figurePlugins)
			{
				Items.Add(item.GetMenuStrip());
			}
		}
	}
}
