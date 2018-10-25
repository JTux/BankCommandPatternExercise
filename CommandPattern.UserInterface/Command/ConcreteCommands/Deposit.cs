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
        public decimal TransactionValue { get; set; }
        private IAccount _account;

        public Deposit(IAccount account, decimal depositValue, int id)
        {
            TransactionID = id;
            _account = account;
            TransactionValue = depositValue;
        }

        public bool Execute()
        {
            if (_account.Deposit(TransactionValue))
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        public override string ToString() => $"{TransactionID}. Deposited ${TransactionValue}. Valid: {ValidTransaction}";
    }
}
