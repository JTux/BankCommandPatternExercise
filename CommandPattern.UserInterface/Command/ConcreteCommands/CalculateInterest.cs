using CommandPattern.UserInterface.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Command.ConcreteCommands
{
    public class CalculateInterest : ITransaction
    {
        public bool ValidTransaction { get; set; }
        public int TransactionID { get; set; }
        private IAccount _account;

        public CalculateInterest(IAccount account, int id)
        {
            TransactionID = id;
            _account = account;
        }

        public bool Execute()
        {
            if (_account.CalculateInterest())
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        public override string ToString() => $"{TransactionID}. Accrued interest.";
    }
}
