using Painter.Models;
using Painter.Views;
using System;
using System.Collections.Generic;

namespace Painter.Controllers
{
	public interface IXCommand
	{
		PDraw ActivePDraw { set; }

		IPluginFigure ActivePlugin { get; set; }
		List<IPluginFigure> FigurePlugins { get; }

		
		event Action OnFigurePluginChanged;

		PFigure PluginProcess(PFigure figure);

		void New();
		void FileOpen();
		void FileSave();
		void FileSaveAs();
		void CloseTab();
		void RenameTab();
		void OpenFromCloud();
		void SaveInCloud();
		void Exit();
		void ShowElements();
		void ShowProperties();
		void ShowAbout();
		void EmptyFigure();
		void RussianLanguage();
		void EnglishLanguage();
		void LightSkin();
		void DarkSkin();
		void FigureColor();
		void LineType();
		void RectangleType();
		void EllipseType();
		void RoundedRectangleType();
		void ChangeLineWidth1();
		void ChangeLineWidth3();
		void ChangeLineWidth5();
		void ChangeLineWidth10();
		void ChangeLineWidth15();
		void ChangeLineWidth20();
		void Debug();
	}
}