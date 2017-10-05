using System;
using System.Collections.Generic;
using System.Drawing;

namespace Painter
{
	public class XCommand
	{
		private CTabControl _cTabControl = null;
		public CTabControl CTabControl { set => _cTabControl = value; }

		internal void AddTab()
		{
			_cTabControl.AddTab();
			OnChangeTabs(_cTabControl.GetTabNames());
		}

		internal void SelectTab(string tabName)
		{
			_cTabControl.SelectTab(tabName);
		}

		internal void CloseTab()
		{
			_cTabControl.CloseTab();
			OnChangeTabs(_cTabControl.GetTabNames());
		}

		internal void Open(string str)
		{
			_cTabControl.AddTab();
			_cTabControl.GetActiveTab().SetMemento(Serializer.FromJson(str));
			OnChangeTabs(_cTabControl.GetTabNames());
		}

		internal string Save()
		{
			return Serializer.ToJson(_cTabControl.GetActiveTab().GetMemento());
		}

		internal void SetLineWidth(int lineWidth)
		{
			CTabPage activeTab = _cTabControl.GetActiveTab();
			if (activeTab.ActiveFigure == null)
				activeTab.xData.lineWidth = lineWidth;
			else
				activeTab.ActiveFigure.LineWidth = lineWidth;
		}

		internal void SetColor(Color color)
		{
			CTabPage activeTab = _cTabControl.GetActiveTab();
			if (activeTab.ActiveFigure == null)
				activeTab.xData.color = color;
			else
				activeTab.ActiveFigure.Color = color;
		}

		

		internal void SetFigureType(XData.FigureType figureType)
		{
			CTabPage activeTab = _cTabControl.GetActiveTab();
			if (activeTab.ActiveFigure == null)
				activeTab.xData.type = figureType;
			else
				activeTab.ActiveFigure.Type = figureType;
		}

		//public PPanel pPanel = null;

		//public void AddTab()
		//{
		//	pPanel.AddTab();
		//	OnChangeTabs();
		//}

		//public void SelectTab(string tabName)
		//{
		//	pPanel.SelectTab(tabName);
		//}

		//public void CloseTab()
		//{
		//	pPanel.CloseTab();
		//	OnChangeTabs();
		//}

		//public void CloseAllTabs()
		//{
		//	pPanel.CloseAllTabs();
		//	OnChangeTabs();
		//}

		//public List<string> GetTabNames()
		//{
		//	return pPanel.GetTabNames();
		//}

		//public MTab GetMemento()
		//{
		//	return pPanel.GetMemento();
		//}

		//public void SetMemento(MTab mTab)
		//{
		//	pPanel.SetMemento(mTab);
		//	OnChangeTabs();
		//}

		//public void SetColor(Color color)
		//{
		//	if (pPanel.GetPDraw().currentFigure == null)
		//		xData.color = color;
		//	else
		//		pPanel.GetPDraw().currentFigure.Color = color;
		//}

		//public void SetLineWidth(int lineWidth)
		//{
		//	if (pPanel.GetPDraw().currentFigure == null)
		//		xData.lineWidth = lineWidth;
		//	else
		//		pPanel.GetPDraw().currentFigure.LineWidth = lineWidth;
		//}



		//public void SetText(string text)
		//{
		//	//xData.text = text;
		//}

		public delegate void ChangeTabs(List<string> tabNames);
		public event ChangeTabs OnChangeTabs;

		
	}
}
