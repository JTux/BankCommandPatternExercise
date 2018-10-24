using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Receiver
{
    public class BankAccount : IAccount
    {
        public decimal AccountBalance { get; set; }
        public decimal InterestPercentage { get; set; }

        public bool CalculateInterest()
        {
            var oldBal = AccountBalance;

            var newMoney = AccountBalance * InterestPercentage;

            var decimalPosition = newMoney.ToString().IndexOf('.');
            if (decimalPosition > 0)
                newMoney = decimal.Parse(newMoney.ToString().Substring(0, decimalPosition + 3));

            if (AccountBalance + newMoney != oldBal)
            {
                AccountBalance += (AccountBalance * InterestPercentage);

                decimalPosition = AccountBalance.ToString().IndexOf('.');
                AccountBalance = decimal.Parse(AccountBalance.ToString().Substring(0, decimalPosition + 3));

                Console.WriteLine($"Account has added {newMoney} in interest." +
                    $"Current account balance is {AccountBalance}.");
                return true;
            }
            else return false;
        }

        public bool CheckBalance()
        {
            Console.WriteLine($"Current account balance is ${AccountBalance}.");
            return true;
        }

        public bool Deposit(decimal depositValue)
        {
            var oldBal = AccountBalance;

            AccountBalance += depositValue;
            Console.WriteLine($"New account balance is: ${AccountBalance}.");

            if (oldBal != AccountBalance) return true;
            else return false;
        }

        public bool Withdraw(decimal withdrawValue)
        {
            var oldBal = AccountBalance;

            if ((AccountBalance - withdrawValue) >= 0)
            {
                AccountBalance -= withdrawValue;
                Console.WriteLine($"New account balance is: ${AccountBalance}.");
                return true;
            }
            else
            {
                Console.WriteLine("Withdrawal could not go through.");
                return false;
            }
        }
    }
}
