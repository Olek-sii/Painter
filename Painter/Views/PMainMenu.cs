using Painter.Controllers;
using Painter.Models;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PMainMenu : MenuStrip
    {
		private XCommand _xCommand = null;

        // MainMenu
        private ToolStripMenuItem _debugBtn;
        private ToolStripMenuItem _fileBtn;
        private ToolStripMenuItem _viewBtn;
        private ToolStripMenuItem _pluginsBtn;
        private ToolStripMenuItem _tabsBtn;
        private ToolStripMenuItem _propertiesBtn;
        private ToolStripMenuItem _preferencesBtn;
        private ToolStripMenuItem _helpBtn;

        // MainMenu: File
        private ToolStripMenuItem _newBtn;
        private ToolStripMenuItem _openBtn;
        private ToolStripMenuItem _saveBtn;
        private ToolStripMenuItem _saveAsBtn;
        private ToolStripMenuItem _closeTabBtn;
        private ToolStripMenuItem _renameTabBtn;
        private ToolStripMenuItem _openFromCloudBtn;
        private ToolStripMenuItem _saveInCloudBtn;
        private ToolStripMenuItem _exitBtn;

        // MainMenu: View
        private ToolStripMenuItem _elementsBtn;
        private ToolStripMenuItem _propertiesFileBtn;

        // MainMenu: Plug-ins
        private ToolStripMenuItem _formatsBtn;
        private ToolStripMenuItem _elementsPluginsBtn;

        // MainMenu: Preferences
        private ToolStripMenuItem _languageBtn;
        private ToolStripMenuItem _skinBtn;

        // MainMenu: Heop
        private ToolStripMenuItem _aboutBtn;

        public PMainMenu(XCommand xCommand)
		{
			_xCommand = xCommand;

            // MainMenu
            _debugBtn = new ToolStripMenuItem(Localization.GetText("debug_text_id"), null, delegate { _xCommand.Debug(); });
            _fileBtn = new ToolStripMenuItem(Localization.GetText("file_text_id"));
            _viewBtn = new ToolStripMenuItem(Localization.GetText("view_text_id"));
            _pluginsBtn = new ToolStripMenuItem(Localization.GetText("plugins_text_id"));
            _tabsBtn = new ToolStripMenuItem(Localization.GetText("tabs_text_id"));
            _propertiesBtn = new ToolStripMenuItem(Localization.GetText("properties_text_id"));
            _preferencesBtn = new ToolStripMenuItem(Localization.GetText("preferences_text_id"));
            _helpBtn = new ToolStripMenuItem(Localization.GetText("help_text_id"));

            // MainMenu: File
            _newBtn = new ToolStripMenuItem(Localization.GetText("new_text_id"), null);
            _openBtn = new ToolStripMenuItem(Localization.GetText("open_text_id"), null);
            _saveBtn = new ToolStripMenuItem(Localization.GetText("save_text_id"), null);
            _saveAsBtn = new ToolStripMenuItem(Localization.GetText("save_as_text_id"), null);
            _closeTabBtn = new ToolStripMenuItem(Localization.GetText("close_tab_text_id"), null);
            _renameTabBtn = new ToolStripMenuItem(Localization.GetText("rename_tab_text_id"), null);
            _openFromCloudBtn = new ToolStripMenuItem(Localization.GetText("open_from_cloud_text_id"), null);
            _saveInCloudBtn = new ToolStripMenuItem(Localization.GetText("save_in_text_id"), null);
            _exitBtn = new ToolStripMenuItem(Localization.GetText("exit_text_id"), null);

            // MainMenu
            Items.Add(_debugBtn);
            Items.Add(_fileBtn);
            Items.Add(_viewBtn);
            Items.Add(_pluginsBtn);
            Items.Add(_tabsBtn);
            Items.Add(_propertiesBtn);
            Items.Add(_preferencesBtn);
            Items.Add(_helpBtn);

            // MainMenu: FileItems
            _fileBtn.DropDownItems.Add(_newBtn);
            _fileBtn.DropDownItems.Add(_openBtn);
            _fileBtn.DropDownItems.Add(_saveBtn);
            _fileBtn.DropDownItems.Add(_saveAsBtn);
            _fileBtn.DropDownItems.Add(_closeTabBtn);
            _fileBtn.DropDownItems.Add(_renameTabBtn);
            _fileBtn.DropDownItems.Add(_openFromCloudBtn);
            _fileBtn.DropDownItems.Add(_saveInCloudBtn);
            _fileBtn.DropDownItems.Add(_exitBtn);

            foreach (IPluginFigure item in PluginManager.figurePlugins)
			{
				Items.Add(item.GetMenuStrip());
			}

			Localization.OnLocalChange += Localization_OnLocalChange;
		}

		private void Localization_OnLocalChange()
		{
            // MainMenu
            _debugBtn.Text = Localization.GetText("debug_text_id");
            _fileBtn.Text = Localization.GetText("file_text_id");
            _viewBtn.Text = Localization.GetText("view_text_id");
            _pluginsBtn.Text = Localization.GetText("plugins_text_id");
            _tabsBtn.Text = Localization.GetText("tabs_text_id");
            _propertiesBtn.Text = Localization.GetText("properties_text_id");
            _preferencesBtn.Text = Localization.GetText("preferences_text_id");
            _helpBtn.Text = Localization.GetText("help_text_id");

            // MainMenu: FileItems
            _newBtn.Text = Localization.GetText("new_text_id");
            _openBtn.Text = Localization.GetText("open_text_id");
            _saveBtn.Text = Localization.GetText("save_text_id");
            _saveAsBtn.Text = Localization.GetText("save_as_text_id");
            _closeTabBtn.Text = Localization.GetText("close_tab_text_id");
            _renameTabBtn.Text = Localization.GetText("rename_tab_text_id");
            _openFromCloudBtn.Text = Localization.GetText("open_from_cloud_text_id");
            _saveInCloudBtn.Text = Localization.GetText("save_in_text_id");
            _exitBtn.Text = Localization.GetText("exit_text_id");
        }
    }
}
