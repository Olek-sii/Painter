namespace Painter.Models
{
    public interface IPluginFile : IPluginFigure
    {
        string Serialize(MTab mTab);
        MTab DeSerialize(string str);
    }
}
