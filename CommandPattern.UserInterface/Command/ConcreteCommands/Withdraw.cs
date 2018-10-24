using CommandPattern.UserInterface.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Command.ConcreteCommands
{
    public class Withdraw : ITransaction
    {
        public bool ValidTransaction { get; set; }
        public int TransactionID { get; set; }

        private IAccount _account;
        private decimal _value;

        public Withdraw(IAccount account, decimal withdrawValue, int id)
        {
            TransactionID = id;
            _account = account;
            _value = withdrawValue;
        }

        public bool Execute()
        {
            if (_account.Withdraw(_value))
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        public override string ToString() => $"{TransactionID}. Withdrew ${_value}";
    }
}
