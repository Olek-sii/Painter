using Painter.Models;
using Painter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigureWithImage
{
    class PluginImage : IPluginFigure
    {
        XCommand _xCommand = new XCommand();

        public PFigure ActiveFigure { set => _xCommand.ActiveFigure = value; }
        public string Name => "Figure with image";
        public bool Enabled { get; set; }

        public RadioButton GetElements()
        {
            throw new NotImplementedException();
        }

        public ToolStripMenuItem GetMenuStrip()
        {
            throw new NotImplementedException();
        }

        public GroupBox GetToolBox()
        {
            throw new NotImplementedException();
        }

        public ToolStrip GetToolStrip()
        {
            throw new NotImplementedException();
        }

        public PFigure Process(PFigure figure)
        {
            throw new NotImplementedException();
        }
    }
}
