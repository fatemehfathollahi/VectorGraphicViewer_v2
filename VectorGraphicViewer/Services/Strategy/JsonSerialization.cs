using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Converters;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer.Services.Strategy
{
    public class JsonSerialization : ISerialization
    {
        public List<Graphic> Deserialize(string data)
        {
            try
            {
                List<ShapeDTO> shapeDto = JsonSerializer.Deserialize<List<ShapeDTO>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if (shapeDto != null)
                    return shapeDto.Select(shape => ShapeMapper.ToGraphic(shape)).ToList();
            }
            catch (JsonException exception)
            {
                throw exception;
            }
            return new List<Graphic>();
        }
    }
}