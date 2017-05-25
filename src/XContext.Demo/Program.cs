using System.Collections.Generic;
using XContext.Demo.Models;

namespace XContext.Demo
{
    class Program
    {
        static Core.XContext context = new Core.XContext();

        static void Main(string[] args)
        {
            WriteSampleFile();

            var sampleFile = ReadSampleFile();

            ExtendSampleFile(sampleFile);
        }

        private static void WriteSampleFile()
        {
            var sampleList = new List<DemoEntity>
            {
                new DemoEntity { TestNumber = 1}
            };

            context.Write(sampleList);
        }

        private static List<DemoEntity> ReadSampleFile()
        {
            var sampleFileContents = context.Get<DemoEntity>();

            return sampleFileContents;
        }

        private static void ExtendSampleFile(List<DemoEntity> sampleFile)
        {
            sampleFile.Add(new DemoEntity { TestNumber = 2 });

            context.Write(sampleFile);
        }
    }
}