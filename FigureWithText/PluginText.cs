using Painter.Models;
using System;
using System.Windows.Forms;
using Painter.Views;

namespace FigureWithText
{
	class PluginText : IPluginFigure
	{
		XCommand xCommand = new XCommand();

		public PFigure ActiveFigure { set => xCommand.ActiveFigure = value; }
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
			menu.DropDownItems.Add(new ToolStripButton("qwerty", null, delegate
			{
				xCommand.SetText("qwerty");
			}));

			menu.DropDownItems.Add(new ToolStripButton("QWERTY", null, delegate
			{
				xCommand.SetText("QWERTY");
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
			return new FigureWithText(figure, xCommand.xText);
		}
	}
}
