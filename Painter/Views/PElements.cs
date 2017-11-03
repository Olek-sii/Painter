using System.Windows.Forms;
using Painter.Controllers;
using System.Drawing;

namespace Painter.Views
{
	public class PElements : Panel
	{
		private IXCommand _xCommand;



		public PElements(IXCommand xCommand)
		{
			_xCommand = xCommand;

			int y = 30;
			Button r = new Button();
			r.Text = "Empty Figure";
            r.Location = new Point(10, y);
            r.Width = 130;
			y += 30;
			r.Click += delegate
			{
                _xCommand.ActiveFigurePlugin = null;
			};
			Controls.Add(r);

			foreach (var plugin in xCommand.FigurePlugins)
			{
				Button b = plugin.GetElements();
				b.Location = new Point(10, y);
                b.Width = 130;
                b.Click += delegate
				{
                    _xCommand.ActiveFigurePlugin = plugin;
				};
				y += 30;
				Controls.Add(b);
			}

            SkinController.OnSkinChange += SkinController_OnSkinChange;
		}

        private void SkinController_OnSkinChange()
        {
            BackColor = SkinController.GetColor("primaryColor");
            ForeColor = SkinController.GetColor("primaryTextColor");
        }
    }
}
