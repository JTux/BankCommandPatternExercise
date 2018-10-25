using CommandPattern.UserInterface.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Command.ConcreteCommands
{
    public class CheckBalance : ITransaction
    {
        public bool ValidTransaction { get; set; }
        public int TransactionID { get; set; }
        public decimal TransactionValue { get; set; }
        private IAccount _account;

        public CheckBalance(IAccount account, int id)
        {
            TransactionID = id;
            _account = account;
        }

        public bool Execute()
        {
            if (_account.CheckBalance())
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }
        public override string ToString() => $"{TransactionID}. Balance check. Valid: {ValidTransaction}";
    }
}
