using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Painter
{
	public class CTabControl : TabControl
	{
		private XCommand _xCommand = null;
		private int _tabNextNameNumber = 1;

		public CTabControl(XCommand xCommand)
		{
			_xCommand = xCommand;

			AddTab();
		}

		public CTabPage GetActiveTab()
		{
			return SelectedTab as CTabPage;
		}

		internal List<string> GetTabNames()
		{
			List<string> names = new List<string>();
			foreach (TabPage tab in TabPages)
			{
				names.Add(tab.Name);
			}
			return names;
		}

		internal void CloseTab()
		{
			TabPages.Remove(SelectedTab);
		}

		internal void AddTab()
		{
			CTabPage cTabPage = new CTabPage(_xCommand);
			cTabPage.Text = "New file " + _tabNextNameNumber++;
			TabPages.Add(cTabPage);
			SelectTab(cTabPage);
		}
	}
}
