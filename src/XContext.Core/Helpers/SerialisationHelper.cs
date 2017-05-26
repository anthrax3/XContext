using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XContext.Core.Helpers
{
    internal static class SerialisationHelper
    {
        internal static List<T> Deserialise<T>(string filePath)
        {
            XmlSerializer xmlSerialiser = new XmlSerializer(typeof(List<T>));
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            XmlReader xmlReader = XmlReader.Create(fileStream);

            if (fileStream.Position > 0) fileStream.Position = 0;

            var entityContents = (List<T>)xmlSerialiser.Deserialize(streamReader);

            fileStream.Close();

            return entityContents;
        }

        internal static string Serialize<T>(this T value)
        {
            var xmlSerialiser = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
            {
                xmlSerialiser.Serialize(writer, value);

                return stringWriter.ToString();
            }
        }
    }
}