using Painter.Views;
using System.Drawing;

namespace FigureWithText
{
	class XCommand
	{
		public PFigure ActiveFigure { get; set; }
		public XText xText = new XText();

		public void SetText(string text)
		{
			if (ActiveFigure == null)
			{
				xText.text = text;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.text = text;
				ActiveFigure.Invalidate();
			}
		}

		public void SetFont(Font font)
		{
			if (ActiveFigure == null)
			{
				xText.font = font;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.font = font;
				ActiveFigure.Invalidate();
			}
		}

		public void SetFont(Color color)
		{
			if (ActiveFigure == null)
			{
				xText.color = color;
			}
			else
			{
				(ActiveFigure as FigureWithText).XText.color = color;
				ActiveFigure.Invalidate();
			}
		}
	}
}
