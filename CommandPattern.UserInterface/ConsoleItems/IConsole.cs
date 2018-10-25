﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.ConsoleItems
{
    public interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void Clear();
        void Write(string s);
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
