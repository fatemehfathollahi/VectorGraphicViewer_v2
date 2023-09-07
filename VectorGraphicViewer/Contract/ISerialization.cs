using System.Collections.Generic;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Contract
{
    public interface ISerialization
    {
        List<Graphic> Deserialize(string data);
    }
}