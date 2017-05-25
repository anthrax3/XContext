using System.Collections.Generic;
using XContext.Demo.Models;

namespace XContext.Demo
{
    class Program
    {
        static Core.XContext _context = new Core.XContext();

        static void Main(string[] args)
        {
            WriteSampleFile();

            ReadSampleFile();

            InsertNewRecord();
        }

        private static void WriteSampleFile()
        {
            var sampleList = new List<DemoEntity>
            {
                new DemoEntity { TestNumber = 1}
            };

            _context.Write(sampleList);
        }

        private static List<DemoEntity> ReadSampleFile()
        {
            var sampleFileContents = _context.Get<DemoEntity>();

            return sampleFileContents;
        }

        private static void InsertNewRecord()
        {
            _context.Insert(new DemoEntity { TestNumber = 2 });
        }       
    }
}