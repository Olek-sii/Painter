using Painter.Models;
using Painter.Views;
using System;
using System.Windows.Forms;

namespace FigureWithText
{
	public class FigureWithText : PFigure, IPluginFigure
	{
		string IPlugin.Name { get => "FWT"; set => throw new NotImplementedException(); }

		public Panel GetElements()
		{
			throw new NotImplementedException();
		}

		public MenuStrip GetMenuStrip()
		{
			throw new NotImplementedException();
		}

		public Panel GetToolBox()
		{
			throw new NotImplementedException();
		}

		public ToolStrip GetToolStrip()
		{
			throw new NotImplementedException();
		}
	}
}