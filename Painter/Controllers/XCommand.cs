using Painter.Models;
using Painter.Views;
using System.Collections.Generic;
using System;

namespace Painter.Controllers
{
	public class XCommand
	{
		private PDraw _activePDraw = null;
		private IPluginFigure _activePlugin = null;
		private PluginManager _pluginManager = null;

		public XCommand()
		{
			_pluginManager = new PluginManager();
		}


		public PDraw ActivePDraw
		{
			set
			{
				_activePDraw = value;
				_activePlugin.ActiveFigure = _activePDraw.ActiveFigure;
			}
		}

		public IPluginFigure ActivePlugin { set => _activePlugin = value; }        
        public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }

		

		int dCalls = 0;
		public void Debug()
		{
			System.Diagnostics.Debug.WriteLine("debug" + dCalls++);
			if (dCalls % 2 == 1)
				Localization.Locale = "ru";
			else
				Localization.Locale = "en";
		}

		public PFigure PluginProcess(PFigure figure)
		{
			if (_activePlugin == null)
				return figure;
			return _activePlugin.Process(figure);
		}

        internal void New()
        {
            throw new NotImplementedException();
        }

        internal void FileOpen()
        {
            throw new NotImplementedException();
        }

        internal void FileSave()
        {
            throw new NotImplementedException();
        }

        internal void FileSaveAs()
        {
            throw new NotImplementedException();
        }

        internal void CloseTab()
        {
            throw new NotImplementedException();
        }

        internal void RenameTab()
        {
            throw new NotImplementedException();
        }

        internal void OpenFromCloud()
        {
            throw new NotImplementedException();
        }

        internal void SaveInCloud()
        {
            throw new NotImplementedException();
        }

        internal void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
