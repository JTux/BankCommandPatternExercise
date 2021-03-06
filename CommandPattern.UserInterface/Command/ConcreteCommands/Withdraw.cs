﻿using CommandPattern.UserInterface.Receiver;
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
        public decimal TransactionValue { get; set; }
        private IAccount _account;

        public Withdraw(IAccount account, decimal withdrawValue, int id)
        {
            TransactionID = id;
            _account = account;
            TransactionValue = withdrawValue;
        }

        public bool Execute()
        {
            if (_account.Withdraw(TransactionValue))
            {
                ValidTransaction = true;
                return true;
            }
            else return false;
        }

        public override string ToString() => $"{TransactionID}. Withdrew ${TransactionValue}. Valid: {ValidTransaction}";
    }
}
