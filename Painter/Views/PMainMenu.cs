using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PMainMenu : MenuStrip
    {
		private XCommand _xCommand = null;
		public XCommand XCommand { set => _xCommand = value; }

		private ToolStripButton _debugBtn;

		public PMainMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

			_debugBtn = new ToolStripButton(Localization.GetText("debug_text_id"), null, delegate { _xCommand.Debug(); });

			Items.Add(_debugBtn);

			foreach (IPluginFigure item in PluginManager.figurePlugins)
			{
				Items.Add(item.GetMenuStrip());
			}

			Localization.OnLocalChange += Localization_OnLocalChange;
		}

		private void Localization_OnLocalChange()
		{
			_debugBtn.Text = Localization.GetText("debug_text_id");
		}
	}
}
