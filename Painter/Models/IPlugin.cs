using System.Windows.Forms;

namespace Painter.Models
{
    public interface IPlugin
    {
        string Name { get; }

        ToolStrip GetToolStrip();
        ToolStripMenuItem GetMenuStrip();
        Panel GetToolBox();
        RadioButton GetElements();
    }
}
