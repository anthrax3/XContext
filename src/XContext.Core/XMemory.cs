using System.Collections.Generic;
using System.Linq;
using XContext.Core.Models;

namespace XContext.Core
{
    internal class XMemory
    {
        #region Dependencies

        private List<List<XEntity>> EntityContents { get; set; } = new List<List<XEntity>>();

        #endregion Dependencies

        internal List<T> Read<T>()
        {
            var entityContent = EntityContents.FirstOrDefault();

            if (entityContent == null)
                return null;

            return entityContent.Cast<T>().ToList();
        }

        internal void Write<T>(List<T> entityContent)
        {
            var inputType = entityContent.GetType().Name;

            var existingContent = EntityContents.FirstOrDefault(x => x.GetType().Name == inputType);

            if (existingContent != null)
                EntityContents.Remove(existingContent);

            EntityContents.Add(entityContent.Cast<XEntity>().ToList());
        }
    }
}