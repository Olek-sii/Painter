using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	class CtxMenu : ContextMenuStrip
	{
		private XCommand _xCommand = null;

		public CtxMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

			ToolStripButton setColor = new ToolStripButton("Set Color");
			setColor.Click += delegate { _xCommand.SetColor(Utilities.GetColor()); };

			ToolStripMenuItem setLineWidth = new ToolStripMenuItem("Set line width");

			ToolStripButton setLineWidth1 = new ToolStripButton("1");
			setLineWidth1.Click += delegate { _xCommand.SetLineWidth(1); };
			ToolStripButton setLineWidth3 = new ToolStripButton("3");
			setLineWidth3.Click += delegate { _xCommand.SetLineWidth(3); };
			ToolStripButton setLineWidth5 = new ToolStripButton("5");
			setLineWidth5.Click += delegate { _xCommand.SetLineWidth(5); };

			setLineWidth.DropDown.Items.Add(setLineWidth1);
			setLineWidth.DropDown.Items.Add(setLineWidth3);
			setLineWidth.DropDown.Items.Add(setLineWidth5);

			ToolStripMenuItem setType = new ToolStripMenuItem("Set type");

			ToolStripButton setTypeRect = new ToolStripButton("Rectangle");
			setTypeRect.Click += delegate { _xCommand.SetFigureType(XData.FigureType.Rectangle); };
			ToolStripButton setTypeCircle = new ToolStripButton("Circle");
			setTypeCircle.Click += delegate { _xCommand.SetFigureType(XData.FigureType.Round); };
			ToolStripButton setTypeSquircle = new ToolStripButton("Squircle");
			setTypeSquircle.Click += delegate { _xCommand.SetFigureType(XData.FigureType.RoundRectangle); };

			setType.DropDown.Items.Add(setTypeRect);
			setType.DropDown.Items.Add(setTypeCircle);
			setType.DropDown.Items.Add(setTypeSquircle);

			Items.Add(setColor);
			Items.Add(setLineWidth);
			Items.Add(setType);
		}
	}
}
