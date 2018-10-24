using CommandPattern.UserInterface.Command;
using CommandPattern.UserInterface.Command.ConcreteCommands;
using CommandPattern.UserInterface.Invoker;
using CommandPattern.UserInterface.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface
{
    public class ProgramUI
    {
        private int _transactionCount;

        private ITransaction _interest;
        private ITransaction _balance;
        private ITransaction _deposit;
        private ITransaction _withdraw;

        private IAccount _account;

        private Teller _teller;

        public ProgramUI()
        {
            _transactionCount = 1;

            _account = new BankAccount
            {
                AccountBalance = 500.00m,
                InterestPercentage = 0.0215m
            };

            _interest = new CalculateInterest(_account, _transactionCount);
            _balance = new CheckBalance(_account, _transactionCount);
            _deposit = new Deposit(_account, 0m, _transactionCount);
            _withdraw = new Withdraw(_account, 0m, _transactionCount);

            _teller = new Teller(_interest, _balance, _deposit, _withdraw);
        }

        public void Run()
        {
            while (true)
            {
                var accountHistory = _teller.GetHistory();
                Console.WriteLine("What would you like to do?" +
                    "\n1) Check balance" +
                    "\n2) Make a withdrawal" +
                    "\n3) Make a deposit" +
                    "\n4) Calculate interest" +
                    "\n5) See Account History");

                int response;
                while (!int.TryParse(Console.ReadLine(), out response)) { }
                switch (response)
                {
                    case 1:
                        DoBalance();
                        break;
                    case 2:
                        DoWithdraw();
                        break;
                    case 3:
                        DoDeposit();
                        break;
                    case 4:
                        DoInterest();
                        break;
                    case 5:
                        DoHistory();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                EndSwitch();
            }
        }

        private void DoBalance()
        {
            _balance = new CheckBalance(_account, _transactionCount);
            UpdateTeller();
            _teller.CheckBalance();
        }
        private void DoWithdraw()
        {
            Console.WriteLine("How much is being withdrawn?");
            _withdraw = new Withdraw(_account, GetValue(), _transactionCount);
            UpdateTeller();
            _teller.Withdraw();
        }
        private void DoDeposit()
        {
            Console.WriteLine("How much is being deposited?");
            _deposit = new Deposit(_account, GetValue(), _transactionCount);
            UpdateTeller();
            _teller.Deposit();
        }
        private void DoInterest()
        {
            _interest = new CalculateInterest(_account, _transactionCount);
            UpdateTeller();
            _teller.CalculateInterest();
        }
        private void DoHistory()
        {
            var history = _teller.GetHistory();
            foreach (var transaction in history)
                Console.WriteLine(transaction);
        }

        private void EndSwitch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            UpdateTeller();
        }

        private decimal GetValue()
        {
            while (true)
                if (decimal.TryParse(Console.ReadLine(), out decimal output)) return output;
        }

        private void UpdateTeller()
        {
            var history = _teller.GetHistory();
            _transactionCount = history.Count + 1;
            _teller = new Teller(_interest, _balance, _deposit, _withdraw, history);
        }
    }
}
