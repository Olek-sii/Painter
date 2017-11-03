using Painter.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureWithImage
{
    class FigureWithImage : PFigure
    {
        public XImage XImage { get; }

        public FigureWithImage(PFigure pFigure, XImage xImage)
			: base(pFigure)
		{
            XImage = xImage;
        }

        protected override void PFigure_Paint(object sender, PaintEventArgs e)
        {
            base.PFigure_Paint(sender, e);
            if (XImage.img != null)
            {
                Graphics g = CreateGraphics();
                g.DrawImage(XImage.img, 0, 0, Width, Height);
            }
        }
    }
}
