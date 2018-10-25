using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Receiver
{
    //-- Class that implements the IAccount interface and will act as the Receiver
    public class BankAccount : IAccount
    {
        public decimal AccountBalance { get; set; }
        public decimal InterestPercentage { get; set; }

        public bool CalculateInterest()
        {
            var oldBal = AccountBalance;

            var newMoney = AccountBalance * InterestPercentage;
            newMoney = TruncateBalance(newMoney);

            if (AccountBalance + newMoney != oldBal)
            {
                AccountBalance += (AccountBalance * InterestPercentage);
                AccountBalance = TruncateBalance(AccountBalance);

                Console.WriteLine($"Account has added ${newMoney} in interest.\n" +
                    $"Current account balance is ${AccountBalance}.");
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

        public bool Revert(decimal revertValue)
        {
            AccountBalance += revertValue;
            Console.WriteLine($"Current account balance is ${AccountBalance}.");
            return true;
        }

        //-- Helper method that makes sure the value does not go past the 100ths place
        private decimal TruncateBalance(decimal value)
        {
            var decimalPosition = value.ToString().IndexOf('.');
            if (decimalPosition > 0)
                value = decimal.Parse(value.ToString().Substring(0, decimalPosition + 3));
            return value;
        }
    }
}
