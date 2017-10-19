﻿using Painter.Views;
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
            Graphics g = CreateGraphics();
            //g.DrawString(XText.text, DefaultFont, Brushes.Red, new Point(0, 0));
        }
    }
}
