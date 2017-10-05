﻿using Painter.Models;
using Painter.Views;
using System.Collections.Generic;
using System;

namespace Painter.Controllers
{
	public class XCommand : IXCommand
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

		public IPluginFigure ActivePlugin { get => _activePlugin; set { _activePlugin = value; OnFigurePluginChanged(); } }
		public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }

		public event Action OnFigurePluginChanged;


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

		public void New()
		{
			throw new NotImplementedException();
		}

		public void FileOpen()
		{
			throw new NotImplementedException();
		}

		public void FileSave()
		{
			throw new NotImplementedException();
		}

		public void FileSaveAs()
		{
			throw new NotImplementedException();
		}

		public void CloseTab()
		{
			throw new NotImplementedException();
		}

		public void RenameTab()
		{
			throw new NotImplementedException();
		}

		public void OpenFromCloud()
		{
			throw new NotImplementedException();
		}

		public void SaveInCloud()
		{
			throw new NotImplementedException();
		}

		public void Exit()
		{
			throw new NotImplementedException();
		}

		public void ShowElements()
		{
			throw new NotImplementedException();
		}

		public void ShowProperties()
		{
			throw new NotImplementedException();
		}

		public void ShowAbout()
		{
			throw new NotImplementedException();
		}

		public void EmptyFigure()
		{
			throw new NotImplementedException();
		}

		public void RussianLanguage()
		{
			throw new NotImplementedException();
		}

		public void EnglishLanguage()
		{
			throw new NotImplementedException();
		}

		public void LightSkin()
		{
			throw new NotImplementedException();
		}

		public void DarkSkin()
		{
			throw new NotImplementedException();
		}

		public void FigureColor()
		{
			throw new NotImplementedException();
		}

		public void LineType()
		{
			throw new NotImplementedException();
		}

		public void RectangleType()
		{
			throw new NotImplementedException();
		}

		public void EllipseType()
		{
			throw new NotImplementedException();
		}

		public void RoundedRectangleType()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth1()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth3()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth5()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth10()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth15()
		{
			throw new NotImplementedException();
		}

		public void ChangeLineWidth20()
		{
			throw new NotImplementedException();
		}
	}
}