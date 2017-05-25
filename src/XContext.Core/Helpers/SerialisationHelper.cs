using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XContext.Core.Helpers
{
    public static class SerialisationHelper
    {
        public static List<T> Deserialise<T>(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                FileStream fs = new FileStream(filePath, FileMode.Open);

                StreamReader stream = new StreamReader(fs, Encoding.UTF8);
                XmlReader reader = XmlReader.Create(fs);

                if (fs.Position > 0)
                    fs.Position = 0;

                var entityContents = (List<T>)serializer.Deserialize(stream);
                fs.Close();

                return entityContents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Serialize<T>(this T value)
        {
            try
            {
                var xmlSerialiser = new XmlSerializer(typeof(T));

                using (var stringWriter = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
                    {
                        xmlSerialiser.Serialize(writer, value);

                        return stringWriter.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}