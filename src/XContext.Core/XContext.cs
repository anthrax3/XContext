using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using XContext.Core.Helpers;
using XContext.Core.Models;

namespace XContext.Core
{
    public class XContext
    {
        #region Dependencies

        private readonly XMemory _memory;
        private string _storageLocation = ConfigurationManager.AppSettings["StorageLocation"];

        public XContext()
        {
            _memory = new XMemory();
        }

        #endregion Dependencies

        public List<T> Get<T>()
        {
            var entityMemory = _memory.Read<T>();

            if (entityMemory != null)
            {
                return entityMemory;
            }
            else
            {
                var filePath = DetermineFilePath<T>();

                if (File.Exists(filePath))
                {
                    var entityContents = SerialisationHelper.Deserialise<T>(filePath);

                    return entityContents;
                }

                return new List<T>();
            }
            
        }

        public List<T> Get<T>(Expression<Func<T, bool>> predicate)
        {
            var entityContents = Get<T>();

            return entityContents.Where(predicate.Compile()).ToList();
        }

        public void Write<T>(List<T> entityList)
        {
            var filePath = DetermineFilePath<T>();

            var xmlContent = SerialisationHelper.Serialize(entityList);

            File.WriteAllText(filePath, xmlContent);
        }

        public void Insert<T>(T entity)
        {
            var entityList = Get<T>();

            entityList.Add(entity);

            Write(entityList);
        }

        public void Update<T>(Expression<Func<T, bool>> predicate)
        {
            var entityList = Get<T>();
        }

        private string DetermineFilePath<T>()
        {
            var typeName = typeof(T).Name;

            return $@"{_storageLocation}\{typeName}.xml";
        }
    }
}