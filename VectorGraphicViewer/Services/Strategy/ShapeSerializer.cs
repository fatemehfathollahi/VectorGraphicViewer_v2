using System.Collections.Generic;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Services.Strategy
{
    public class ShapeSerializer
    {
        private readonly ISerialization _serialization;
        public ShapeSerializer(ISerialization serialization)
        {
            _serialization = serialization;
        }

        public List<Graphic> Deserialize(string data)
        {
            return _serialization.Deserialize(data);
        }
    }
}