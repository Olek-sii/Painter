using Painter.Views;

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
	}
}
