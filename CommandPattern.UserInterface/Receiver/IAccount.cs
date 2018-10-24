﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Receiver
{
    public interface IAccount
    {
        decimal AccountBalance { get; set; }
        decimal InterestPercentage { get; set; }

        bool CalculateInterest();
        bool CheckBalance();
        bool Deposit(decimal depositValue);
        bool Withdraw(decimal withdrawValue);
    }
}
