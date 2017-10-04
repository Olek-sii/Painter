using Painter.Models;
using System;
using System.Windows.Forms;
using Painter.Views;

namespace FigureWithText
{
	class PluginText : IPluginFigure
	{
		XCommand _xCommand = new XCommand();

		public PFigure ActiveFigure { set => _xCommand.ActiveFigure = value; }
		public string Name { get => "Figure with text"; }

		public RadioButton GetElements()
		{
			RadioButton radioButton = new RadioButton();
			radioButton.Text = Name;
			radioButton.Name = Name;
			return radioButton;
		}

		public ToolStripMenuItem GetMenuStrip()
		{
			ToolStripMenuItem menu = new ToolStripMenuItem("Text plugin");
			menu.DropDownItems.Add(new ToolStripMenuItem("qwerty", null, delegate
			{
				_xCommand.SetText("qwerty");
			}));

			menu.DropDownItems.Add(new ToolStripMenuItem("QWERTY", null, delegate
			{
				_xCommand.SetText("QWERTY");
			}));

			return menu;
		}

		public Panel GetToolBox()
		{
			throw new NotImplementedException();
		}

		public ToolStrip GetToolStrip()
		{
			throw new NotImplementedException();
		}

		public PFigure Process(PFigure figure)
		{
			return new FigureWithText(figure, _xCommand.xText);
		}
	}
}
