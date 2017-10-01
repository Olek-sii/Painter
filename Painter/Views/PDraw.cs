using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
	public class PDraw : UserControl
	{
		public XData _xData = new XData();
		public PFigure activeFigure = null;

		private XCommand _xCommand = null;

		public PDraw(XCommand xCommand)
		{
			_xCommand = xCommand;

			Controls.Add(new PFigure(50, 50, 100, 50, _xData, xCommand));

			PFigure pFigure = new PFigure(50, 150, 100, 50, _xData, _xCommand);
			IPluginFigure pluginFigure = PluginManager.figurePlugins[0];
			var f = pluginFigure.Process(pFigure);
			pluginFigure.ActiveFigure = f;
			Controls.Add(f);
		}
	}
}
