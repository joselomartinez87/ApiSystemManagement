using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SystemManagement.Common.Utilities
{
    public class Xml
    {

        public XmlDocument GetXmlFromObject<T>(T entity)
        {
            XmlDocument xmlEntity = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, entity);
                xmlStream.Position = 0;
                xmlEntity.Load(xmlStream);
            }
            return xmlEntity;
        }

        public XmlDocument GetXmlFromObjectOmitHeader<T>(T entity)
        {
            XmlDocument xmlEntity = new XmlDocument();
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(entity.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, entity, emptyNamespaces);
                xmlEntity.LoadXml(stream.ToString());
            }
            return xmlEntity;      
        }

        public T GetObjectFromXml<T>(string xml)
        {
            T returnObject;
            using (StringReader stringReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(stringReader);
            }
            return returnObject;
        }

        public T GetObjectFromXmlWidtTag<T>(string xml, string tag)
        {
            T returnObject;
            using (StringReader stringReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(tag));
                returnObject = (T)serializer.Deserialize(stringReader);
            }
            return returnObject;
        }

    }
}
