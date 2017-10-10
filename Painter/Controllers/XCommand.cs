using Painter.Models;
using Painter.Views;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Painter.Controllers
{
	public class XCommand : IXCommand
	{	
		private PDraw _activePDraw = null;
		private IPluginFigure _activePlugin = null;
		private PluginManager _pluginManager = null;
		public TabControl TabControl { get; set; }
		public PFigure ActiveFigure { get; set; }
		public PDraw ActivePDraw
		{
			get => _activePDraw;
			set
			{
				_activePDraw = value;
				ActiveFigure = _activePDraw.ActiveFigure;
				if (_activePlugin != null)
					_activePlugin.ActiveFigure = _activePDraw.ActiveFigure;
			}
		}

		public IPluginFigure ActiveFigurePlugin { get => _activePlugin; set { _activePlugin = value; OnFigurePluginChanged(); } }
		public List<IPluginFigure> FigurePlugins { get => _pluginManager.figurePlugins; }
		public List<IPluginFile> FilePlugins { get => _pluginManager.formatPlugins; }

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
			PDraw pDraw = new PDraw(this);
			pDraw.Text = "New tab";
			TabControl.TabPages.Add(pDraw);
			TabControl.SelectedTab = pDraw;
		}

		public void FileOpen()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				var extension = Path.GetExtension(openFileDialog.FileName);
				using (Stream stream = File.Open(openFileDialog.FileName, FileMode.Open))
				{
					using (var streamReader = new StreamReader(stream))
					{
						MTab mTab = FilePlugins.Find((x) => x.Name.ToLower() == extension.Substring(1)).Deserialize(streamReader.ReadToEnd());

						PDraw pDraw = new PDraw(this);
						pDraw.SetMemento(mTab);
						TabControl.TabPages.Add(pDraw);
						TabControl.SelectedTab = pDraw;
					}
				}
			}
		}

		public void FileSave()
		{
			throw new NotImplementedException();
		}

		public void FileSaveAs()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "";
			foreach (var plugin in FilePlugins)
			{
				//if (plugin.Enabled == true)
					saveFileDialog.Filter += plugin.Name + "|*." + plugin.Name.ToLower();
			}
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				var extension = Path.GetExtension(saveFileDialog.FileName);
				using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create))
				{
					using (var streamWritter = new StreamWriter(stream))
					{
						streamWritter.Write(
							FilePlugins.Find((x) => x.Name.ToLower() == extension.Substring(1)).Serialize(_activePDraw.GetMemento())
						);
					}
				}
			}
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

		public void ToggleVisible(Control control)
		{
			control.Visible = !control.Visible;
		}

		public void SetType(XData.FigureType type)
		{
			if (ActiveFigure == null)
				_activePDraw._xData.type = type;
			else
				ActiveFigure.Type = type;
		}

		public void SetColor(Color color)
		{
			if (ActiveFigure == null)
				_activePDraw._xData.color = color;
			else
				ActiveFigure.Color = color;
		}

		public void SetLineWidth(int width)
		{
			if (ActiveFigure == null)
				_activePDraw._xData.lineWidth = width;
			else
				ActiveFigure.LineWidth = width;
		}

		public void TogglePlugin(IPluginFigure plugin)
		{
			plugin.Enabled = !plugin.Enabled;
		}

		public void InitializePluginManager()
		{

			_pluginManager = new PluginManager();
		}
	}
}