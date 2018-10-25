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
        public decimal TransactionValue { get; set; }
        private IAccount _account;

        public CalculateInterest(IAccount account, int id)
        {
            TransactionID = id;
            _account = account;
        }

        public bool Execute()
        {
            TransactionValue = _account.AccountBalance * _account.InterestPercentage;
            TransactionValue = TruncateBalance(TransactionValue);
            if (_account.CalculateInterest())
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        private decimal TruncateBalance(decimal value)
        {
            var decimalPosition = value.ToString().IndexOf('.');
            if (decimalPosition > 0)
                value = decimal.Parse(value.ToString().Substring(0, decimalPosition + 3));
            return value;
        }

        public override string ToString() => $"{TransactionID}. Accrued ${TransactionValue} in interest. Valid: {ValidTransaction}";
    }
}
