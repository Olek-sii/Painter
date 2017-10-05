using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;
using System;

namespace Painter.Views
{
	public class PDraw : UserControl
	{
		private IXCommand _xCommand = null;
		private PFigure _activeFigure;

		public XData _xData = new XData();
		public PFigure ActiveFigure
		{
			get => _activeFigure;
			set
			{
				_activeFigure = value;
				_xCommand.ActivePDraw = this;
			}
		}

		public PDraw(IXCommand xCommand)
		{
			_xCommand = xCommand;
			Click += PDraw_Click;
		}

		private void PDraw_Click(object sender, EventArgs e)
		{
			var mouse = e as MouseEventArgs;
			PFigure figure = new PFigure(mouse.X, mouse.Y, 50, 50, _xData, _xCommand);
			Controls.Add(_xCommand.PluginProcess(figure));
		}
	}
}
