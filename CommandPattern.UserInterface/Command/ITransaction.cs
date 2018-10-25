using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Command
{
    //-- This is the Command, or the Interface that will be implemented across all ConcreteCommands
    public interface ITransaction
    {
        int TransactionID { get; set; }
        bool ValidTransaction { get; set; }
        decimal TransactionValue { get; set; }
        bool Execute();
    }
}
