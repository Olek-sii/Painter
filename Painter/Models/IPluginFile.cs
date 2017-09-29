using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Models
{
    interface IPluginFile : IPlugin
    {
        string Serialize(MTab mTab);
        MTab DeSerialize(string str);
    }
}
