using Painter.Views;

namespace Painter.Models
{
    public interface IPluginFigure : IPlugin
    {
		PFigure ActiveFigure { set; }
		PFigure Process(PFigure figure);
	}
}
