using CommandPattern.UserInterface.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Command.ConcreteCommands
{
    class Deposit : ITransaction
    {
        public bool ValidTransaction { get; set; }
        public int TransactionID { get; set; }
        private IAccount _account;
        private decimal _value;

        public Deposit(IAccount account, decimal depositValue, int id)
        {
            TransactionID = id;
            _account = account;
            _value = depositValue;
        }

        public bool Execute()
        {
            if (_account.Deposit(_value))
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        public override string ToString() => $"{TransactionID}. Deposited ${_value}";
    }
}
