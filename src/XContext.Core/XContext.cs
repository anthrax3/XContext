using System.Collections.Generic;
using System.Configuration;
using System.IO;
using XContext.Core.Helpers;

namespace XContext.Core
{
    public class XContext
    {
        private string _storageLocation = ConfigurationManager.AppSettings["StorageLocation"];

        public List<T> Get<T>()
        {
            var filePath = DetermineFilePath<T>();

            if (File.Exists(filePath))
            {
                var entityContents = SerialisationHelper.Deserialise<T>(filePath);

                return entityContents;
            }

            return new List<T>();
        }

        public void Write<T>(List<T> entityList)
        {
            var filePath = DetermineFilePath<T>();

            var xmlContent = SerialisationHelper.Serialize(entityList);

            File.WriteAllText(filePath, xmlContent);
        }

        private string DetermineFilePath<T>()
        {
            var typeName = typeof(T).Name;

            return $@"{_storageLocation}\{typeName}.xml";
        }
    }
}