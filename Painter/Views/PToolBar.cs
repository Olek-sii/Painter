using Painter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.Views
{
    public class PToolBar : ToolStrip
    {
        private XCommand _xCommand;

        ToolStripButton newBtn;
        ToolStripButton openBtn;
        ToolStripButton saveBtn;
        ToolStripButton loadCloudBtn;
        ToolStripButton saveCloudBtn;

        ToolStripComboBox typeCb;
        ToolStripComboBox widthCb;

        ToolStripButton colorBtn;

        public PToolBar(XCommand xCommand)
        {
            _xCommand = xCommand;

            newBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);
            openBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);
            saveBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);
            loadCloudBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);
            saveCloudBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);

            typeCb = new ToolStripComboBox();
            widthCb = new ToolStripComboBox();

            colorBtn = new ToolStripButton(Localization.GetText("new_text_id"), null);


            Items.Add(newBtn);
            Items.Add(openBtn);
            Items.Add(saveBtn);
            Items.Add(loadCloudBtn);
            Items.Add(saveCloudBtn);
            Items.Add(typeCb);
            Items.Add(widthCb);
            Items.Add(colorBtn);


        }
    }
}
