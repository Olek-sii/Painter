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
		public string Name => "Figure with text";
		public bool Enabled { get; set; }

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

		public GroupBox GetToolBox()
		{
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Text";

            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(10, 20);
            textBox.Size = new System.Drawing.Size(80,25);
            groupBox.Controls.Add(textBox);

            Button button = new Button();
            button.Text = "Submit";
            button.Location = new System.Drawing.Point(10, 50);
            button.Size = new System.Drawing.Size(60, 25);
            button.Click += delegate { _xCommand.SetText(textBox.Text); };
            groupBox.Controls.Add(button);

            return groupBox;
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
