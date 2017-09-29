using System.Windows.Forms;

namespace Painter.Models
{
    public interface IPlugin
    {
        string Name { get; set; }
        ToolStrip GetToolStrip();
        MenuStrip GetMenuStrip();
        Panel GetToolBox();
        Panel GetElements();
    }
}
