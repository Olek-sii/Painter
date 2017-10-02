using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PMainMenu : MenuStrip
    {
		private XCommand _xCommand = null;

		private ToolStripButton _debugBtn;
        private ToolStripButton _fileBtn;
        private ToolStripButton _viewBtn;
        private ToolStripButton _pluginsBtn;
        private ToolStripButton _tabsBtn;
        private ToolStripButton _propertiesBtn;
        private ToolStripButton _preferencesBtn;
        private ToolStripButton _helpBtn;

        public PMainMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

			_debugBtn = new ToolStripButton(Localization.GetText("debug_text_id"), null, delegate { _xCommand.Debug(); });
            _fileBtn = new ToolStripButton(Localization.GetText("file_text_id"), null);
            _viewBtn = new ToolStripButton(Localization.GetText("view_text_id"), null);
            _pluginsBtn = new ToolStripButton(Localization.GetText("plugins_text_id"), null);
            _tabsBtn = new ToolStripButton(Localization.GetText("tabs_text_id"), null);
            _propertiesBtn = new ToolStripButton(Localization.GetText("properties_text_id"), null);
            _preferencesBtn = new ToolStripButton(Localization.GetText("preferences_text_id"), null);
            _helpBtn = new ToolStripButton(Localization.GetText("help_text_id"), null);


            Items.Add(_debugBtn);
            Items.Add(_fileBtn);
            Items.Add(_viewBtn);
            Items.Add(_pluginsBtn);
            Items.Add(_tabsBtn);
            Items.Add(_propertiesBtn);
            Items.Add(_preferencesBtn);
            Items.Add(_helpBtn);

            foreach (IPluginFigure item in xCommand.FigurePlugins)
			{
				Items.Add(item.GetMenuStrip());
			}

			Localization.OnLocalChange += Localization_OnLocalChange;
		}

		private void Localization_OnLocalChange()
		{
			_debugBtn.Text = Localization.GetText("debug_text_id");
            _fileBtn.Text = Localization.GetText("file_text_id");
            _viewBtn.Text = Localization.GetText("view_text_id");
            _pluginsBtn.Text = Localization.GetText("plugins_text_id");
            _tabsBtn.Text = Localization.GetText("tabs_text_id");
            _propertiesBtn.Text = Localization.GetText("properties_text_id");
            _preferencesBtn.Text = Localization.GetText("preferences_text_id");
            _helpBtn.Text = Localization.GetText("help_text_id");
        }
	}
}
