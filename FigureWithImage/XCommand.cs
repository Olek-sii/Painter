using Painter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureWithImage
{
    class XCommand
    {
        public PFigure ActiveFigure { get; set; }
        public XImage xImage = new XImage();


        public void SetImage(string img)
        {
            if (ActiveFigure == null)
            {
                xImage.img = img;
            }
            else
            {
                (ActiveFigure as FigureWithImage).XImage.img = img;
                ActiveFigure.Invalidate();
            }
        }
    }
}
