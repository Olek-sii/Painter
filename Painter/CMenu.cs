using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	class CMenu : MenuStrip
	{
		private XCommand _xCommand = null;
		private ToolStripMenuItem _tabs = new ToolStripMenuItem("Tabs");
		private ToolStripMenuItem _tools = new ToolStripMenuItem("Tools");
		private ToolStripMenuItem _file = new ToolStripMenuItem("File");

		public CMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

			ToolStripButton newBtn = new ToolStripButton("New file");
			newBtn.Click += delegate { _xCommand.AddTab(); };
			ToolStripButton openBtn = new ToolStripButton("Open");
			openBtn.Click += delegate { _xCommand.Open(Utilities.LoadFile()); };
			ToolStripButton saveBtn = new ToolStripButton("Save");
			saveBtn.Click += delegate { Utilities.SaveFile(_xCommand.Save()); };
			ToolStripButton closeBtn = new ToolStripButton("Close");
			closeBtn.Click += delegate { _xCommand.CloseTab(); };

			_file.DropDownItems.Add(newBtn);
			_file.DropDownItems.Add(openBtn);
			_file.DropDownItems.Add(saveBtn);
			_file.DropDownItems.Add(closeBtn);

			

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

			_tools.DropDownItems.Add(setColor);
			_tools.DropDownItems.Add(setLineWidth);
			_tools.DropDownItems.Add(setType);

			Items.Add(_file);
			Items.Add(_tools);
			Items.Add(_tabs);

			_xCommand.OnChangeTabs += OnChangeTabs;
		}

		void OnChangeTabs(List<string> tabNames)
		{
			_tabs.DropDownItems.Clear();
			foreach (string tabName in tabNames)
			{
				ToolStripButton tabBtn = new ToolStripButton(tabName);
				tabBtn.Click += delegate { _xCommand.SelectTab(tabName); };
				_tabs.DropDownItems.Add(tabBtn);
			}

			_tools.Enabled = tabNames.Count != 0;
			_file.DropDownItems[2].Enabled = tabNames.Count != 0;
			_file.DropDownItems[3].Enabled = tabNames.Count != 0;
		}
	}
}
