using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using XContext.Core.Helpers;

namespace XContext.Core
{
    public class XContext
    {
        #region Dependencies

        private readonly XMemory _memoryInstance = new XMemory();

        private string _storageLocation = ConfigurationManager.AppSettings["StorageLocation"];

        #endregion Dependencies

        public List<T> Get<T>()
        {
            var entityContent = _memoryInstance.Read<T>();
            if (entityContent != null) return entityContent;

            entityContent = LoadEntityFile<T>();

            return entityContent;
        }

        public List<T> Get<T>(Expression<Func<T, bool>> predicate)
        {
            var entityContent = Get<T>();

            return entityContent.Where(predicate.Compile()).ToList();
        }

        public void Write<T>(List<T> entityList)
        {
            _memoryInstance.Write(entityList);

            var filePath = DetermineFilePath<T>();

            var xmlContent = SerialisationHelper.Serialize(entityList);

            File.WriteAllText(filePath, xmlContent);
        }

        public void Insert<T>(T entity)
        {
            var entityList = Get<T>();

            entityList.Add(entity);

            Write(entityList);

            _memoryInstance.Write(entityList);
        }

        public void Update<T>(Expression<Func<T, bool>> predicate)
        {
            var entityList = Get<T>();
        }

        #region Private Methods

        private string DetermineFilePath<T>()
        {
            var entityFilePath = $@"{_storageLocation}\{typeof(T).Name}.xml";

            return entityFilePath;
        }

        private List<T> LoadEntityFile<T>()
        {
            var entityFilePath = DetermineFilePath<T>();

            if (File.Exists(entityFilePath))
            {
                var entityContents = SerialisationHelper.Deserialise<T>(entityFilePath);

                _memoryInstance.Write(entityContents);

                return entityContents;
            }

            return new List<T>();
        }

        #endregion Private Methods
    }
}