using System;
using XContext.Core.Models;

namespace XContext.Demo.Models
{
    public class DemoEntity : XEntity
    {
        public int TestNumber { get; set; } = 0;

        public DateTime CurrentDateTime { get; set; } = DateTime.Now;
    }
}