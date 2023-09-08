using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Services.Strategy
{
    public class XmlSerialization : ISerialization
    {
        public XmlSerialization()
        {
        }
        public List<Graphic> Deserialize(string data)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Graphic>), new XmlRootAttribute("Shapes"));

                using (StringReader stringReader = new StringReader(data))
                {
                    return (List<Graphic>)serializer.Deserialize(stringReader);
                }
            }
            catch (Exception exception)
            {
                throw new XmlException("An error occurred while deserializing the XML data.", exception);
            }
        }
    }
}