using Painter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PToolBox : Panel
    {
        private IXCommand _xCommand;
        public PToolBox(IXCommand xCommand)
        {
            _xCommand = xCommand;
        }
    }
}
