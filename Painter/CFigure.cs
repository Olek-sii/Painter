using Painter.Model;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Painter
{
	public class CFigure : UserControl
	{
		public enum FigureKeyPoint
		{
			none,
			topLeft, top, topRight, right,
			bottomRight, bottom, bottomLeft, left
		};

		private bool isMoving = false;
		private bool isResizing = false;
		private Point startPoint;
		private FigureKeyPoint figureKeyPoint;

		private Color _color;
		private int _lineWidth;
		private XData.FigureType _type;

		public Color Color { set { _color = value; Invalidate(); } }
		public int LineWidth { set { _lineWidth = value; Invalidate(); } }
		public XData.FigureType Type { set { _type = value; Invalidate(); } }

		public MFigure GetMemento()
		{
			MFigure memento = new MFigure();
			memento.x = Left;
			memento.y = Top;
			memento.w = Width;
			memento.h = Height;

			memento.xData = new XData();
			memento.xData.color = _color;
			memento.xData.lineWidth = _lineWidth;
			memento.xData.type = _type;
			return memento;
		}

		public CFigure(int x, int y, int w, int h, XData xData, XCommand xCommand)
		{
			ContextMenuStrip = new CtxMenu(xCommand);

			Location = new Point(x, y);
			Size = new Size(w, h);
			_color = xData.color;
			_lineWidth = xData.lineWidth;
			_type = xData.type;

			Paint += CFigure_Paint;
			MouseDown += CFigure_MouseDown;
			MouseMove += CFigure_MouseMove;
			MouseUp += CFigure_MouseUp;
			Click += CFigure_Click;

		}

		private void CFigure_Click(object sender, System.EventArgs e)
		{
			(Parent as CTabPage).ActiveFigure = this;
		}

		private void CFigure_MouseUp(object sender, MouseEventArgs e)
		{
			isMoving = false;
			isResizing = false;
			figureKeyPoint = FigureKeyPoint.none;
		}

		private void CFigure_MouseMove(object sender, MouseEventArgs e)
		{
			Cursor[] cursors = { Cursors.Default,
				Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE,
				Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE
			};

			if (figureKeyPoint == FigureKeyPoint.none)
				Cursor.Current = cursors[(int)GetResizePoint(e.X, e.Y)];
			else
				Cursor.Current = cursors[(int)figureKeyPoint];

			if (e.Button == MouseButtons.Left)
			{
				if (isMoving == true)
					Move(e.X - startPoint.X, e.Y - startPoint.Y);
				else if (isResizing == true)
					Resize(figureKeyPoint, e.X, e.Y);
			}
		}

		private void CFigure_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				figureKeyPoint = GetResizePoint(e.X, e.Y);
				isMoving = (figureKeyPoint == FigureKeyPoint.none);
				isResizing = (figureKeyPoint != FigureKeyPoint.none);
				startPoint = new Point(e.X, e.Y);
			}
		}

		private void CFigure_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = CreateGraphics();
			Pen pen = new Pen(_color, _lineWidth);
			if (_type == XData.FigureType.Rectangle)
				g.DrawRectangle(pen, new Rectangle(0, 0, Width - 3, Height - 3));
			else if (_type == XData.FigureType.Round)
				g.DrawEllipse(pen, new Rectangle(0, 0, Width - 3, Height - 3));
			else if (_type == XData.FigureType.Line)
				g.DrawLine(pen, 0, 0, Width, Height);
			else if (_type == XData.FigureType.RoundRectangle)
			{
				GraphicsPath path = new GraphicsPath();
				Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
				Size size = new Size(20, 20);
				Rectangle arc = new Rectangle(bounds.Location, size);
				path.AddArc(arc, 180, 90);
				arc.X = bounds.Right - 20;
				path.AddArc(arc, 270, 90);
				arc.Y = bounds.Bottom - 20;
				path.AddArc(arc, 0, 90);
				arc.X = bounds.Left;
				path.AddArc(arc, 90, 90);
				arc.Y = bounds.Top;
				path.CloseFigure();
				g.DrawPath(pen, path);
			}
		}

		private new void Move(int dx, int dy)
		{
			Left += dx;
			Top += dy;
		}

		public new void Resize(FigureKeyPoint resizePoint, int dx, int dy)
		{
			if (resizePoint == FigureKeyPoint.right)
			{
				Width = dx;
			}
			else if (resizePoint == FigureKeyPoint.left)
			{
				Width -= dx;
				Left += dx;
			}
			else if (resizePoint == FigureKeyPoint.topLeft)
			{
				Width -= dx;
				Left += dx;
				Height -= dy;
				Top += dy;
			}
			else if (resizePoint == FigureKeyPoint.bottomRight)
			{
				Width = dx;
				Height = dy;
			}

			Invalidate();
		}

		public FigureKeyPoint GetResizePoint(int x, int y)
		{
			FigureKeyPoint result = FigureKeyPoint.none;
			int padding = 10;

			if (x > Width - padding)
			{
				if (y < padding)
					result = FigureKeyPoint.topRight;
				else if (y > Height - padding)
					result = FigureKeyPoint.bottomRight;
				else
					result = FigureKeyPoint.right;
			}
			else if (x < padding)
			{
				if (y < padding)
					result = FigureKeyPoint.topLeft;
				else if (y > Height - padding)
					result = FigureKeyPoint.bottomLeft;
				else
					result = FigureKeyPoint.left;
			}
			else
			{
				if (y < padding)
					result = FigureKeyPoint.top;
				else if (y > Height - padding)
					result = FigureKeyPoint.bottom;
			}

			return result;
		}
	}
}
