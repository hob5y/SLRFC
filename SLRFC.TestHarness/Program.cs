using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLRFC.TestHarness
{
    using SLRFC.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            var bus = new SLRFC.Business.Events(new MyDbContext());

            var ev = new Event
                         {
                             EventName = 
                         };

            bus.AddSingleEvent();
        }
    }
}
