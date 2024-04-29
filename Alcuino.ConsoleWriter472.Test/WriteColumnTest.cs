using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcuino.ConsoleWriter472.Test
{
    public class WriteColumnTest
    {
        public static void Test()
        {
            ConsoleWriter.WriteColumn(new string[] { "ID", "FROM", "TO", "EARNING" }, Align.Center, 16, ConsoleColor.Magenta);

            Dictionary<string, int> values = new Dictionary<string, int>()
            {
                { "ID", 5 },
                { "FROM", 8 },
                { "TO", 12 },
                { "EARNING", 8 }
            };
            ConsoleWriter.WriteColumn(values, Align.Center, ConsoleColor.Magenta);

        }
    }
}
