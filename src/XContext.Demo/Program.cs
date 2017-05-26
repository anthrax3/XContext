using XContext.Demo.Models;

namespace XContext.Demo
{
    class Program
    {
        static Core.XContext _context = new Core.XContext();

        static void Main(string[] args)
        {
            var sample = new DemoEntity
            {
                TestNumber = 1
            };

            _context.Insert(sample);

            var example = _context.Get<DemoEntity>();
        }
    }
}