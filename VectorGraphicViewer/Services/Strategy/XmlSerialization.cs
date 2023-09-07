using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Services.Strategy
{
    public class XmlSerialization : ISerialization
    {
        public List<Graphic> Deserialize(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Graphic>), new XmlRootAttribute("Shapes"));

            List<Graphic> graphics;
            using (FileStream fileStream = new FileStream(data, FileMode.Open))
            {
                graphics = (List<Graphic>)serializer.Deserialize(fileStream);
            }

            return graphics;
        }
    }
}