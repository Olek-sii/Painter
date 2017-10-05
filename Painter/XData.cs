using System.Drawing;

namespace Painter
{
	public class XData
	{
		public enum FigureType { Free, Rectangle, Round, RoundRectangle, Line };

		public Color color = Color.Black;
		public int lineWidth = 1;
		public FigureType type = FigureType.Rectangle;
	}
}