using Painter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	public class CTabPage : TabPage
	{
		private XCommand _xCommand = null;

		public XData xData = new XData();
		public XText xText = new XText();

		private CFigure _newFigure = null;
		private Point _clickPoint;

		private CFigure _activeFigure = null;
		public CFigure ActiveFigure
		{
			get => _activeFigure;
			set
			{
				if (_activeFigure != null)
					_activeFigure.BorderStyle = BorderStyle.None;

				_activeFigure = value;

				if (_activeFigure != null)
					_activeFigure.BorderStyle = BorderStyle.FixedSingle;
			}
		}

		public CTabPage(XCommand xCommand)
		{
			_xCommand = xCommand;

			Click += CTabPage_Click;
			MouseDown += CTabPage_MouseDown;
			MouseMove += CTabPage_MouseMove;
			MouseUp += CTabPage_MouseUp;
		}

		private void CTabPage_MouseUp(object sender, MouseEventArgs e)
		{
			_newFigure = null;
		}

		private void CTabPage_MouseMove(object sender, MouseEventArgs e)
		{
			if (_newFigure != null)
				_newFigure.Resize(
					_newFigure.GetResizePoint(e.X, e.Y),
					e.X - _clickPoint.X,
					e.Y - _clickPoint.Y
				);
		}

		private void CTabPage_MouseDown(object sender, MouseEventArgs e)
		{
			_clickPoint = new Point(e.X, e.Y);
			_newFigure = new CFigure(e.X, e.Y, 1, 1, xData, _xCommand);
			Controls.Add(_newFigure);
			_newFigure.BringToFront();
		}

		private void CTabPage_Click(object sender, EventArgs e)
		{
			ActiveFigure = null;
		}

		internal MTab GetMemento()
		{
			MTab mTab = new MTab();
			mTab.tabName = Text;
			mTab.figures = new List<MFigure>();
			List<MFigure> memento = new List<MFigure>();
			foreach (CFigure cFigure in Controls)
			{
				mTab.figures.Add(cFigure.GetMemento());
			}
			return mTab;
		}

		internal void SetMemento(MTab mTab)
		{
			Text = mTab.tabName;
			Controls.Clear();
			foreach (MFigure mFigure in mTab.figures)
			{
				CFigure cFigure = new CFigure(
					mFigure.x,
					mFigure.y,
					mFigure.w,
					mFigure.h,
					mFigure.xData,
					_xCommand
				);
				Controls.Add(cFigure);
				cFigure.BringToFront();
			}
		}
	}
}
