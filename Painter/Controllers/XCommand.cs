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

        internal void ShowElements()
        {
            throw new NotImplementedException();
        }

        internal void ShowProperties()
        {
            throw new NotImplementedException();
        }

        internal void ShowAbout()
        {
            throw new NotImplementedException();
        }

        internal void AddJSON()
        {
            throw new NotImplementedException();
        }

        internal void AddYAML()
        {
            throw new NotImplementedException();
        }

        internal void AddXML()
        {
            throw new NotImplementedException();
        }

        internal void AddBIN()
        {
            throw new NotImplementedException();
        }

        internal void EmptyFigure()
        {
            throw new NotImplementedException();
        }

        internal void RussianLanguage()
        {
            throw new NotImplementedException();
        }

        internal void EnglishLanguage()
        {
            throw new NotImplementedException();
        }

        internal void LightSkin()
        {
            throw new NotImplementedException();
        }

        internal void DarkSkin()
        {
            throw new NotImplementedException();
        }

        internal void FigureColor()
        {
            throw new NotImplementedException();
        }

        internal void LineType()
        {
            throw new NotImplementedException();
        }

        internal void RectangleType()
        {
            throw new NotImplementedException();
        }

        internal void EllipseType()
        {
            throw new NotImplementedException();
        }

        internal void RoundedRectangleType()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth1()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth3()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth5()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth10()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth15()
        {
            throw new NotImplementedException();
        }

        internal void ChangeLineWidth20()
        {
            throw new NotImplementedException();
        }
    }
}
