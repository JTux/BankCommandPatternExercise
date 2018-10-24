using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new ProgramUI();
            program.Run();
        }
    }
}
