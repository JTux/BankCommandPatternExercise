using CommandPattern.UserInterface.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.UserInterface.Invoker
{
    public class Teller
    {
        public ITransaction CalculateInterestCommand, CheckBalanceCommand, DepositCommand, WithdrawCommand, RevertCommand;
        public List<ITransaction> AccountHistory;

        //-- Constructor
        public Teller(ITransaction calcInterest, ITransaction checkBal, ITransaction deposit, ITransaction withdraw)
        {
            AccountHistory = new List<ITransaction>();
            CalculateInterestCommand = calcInterest;
            CheckBalanceCommand = checkBal;
            DepositCommand = deposit;
            WithdrawCommand = withdraw;
        }

        //-- Invoker methods that are used to store Transaction(ConcreteCommand) history and execute said ConcreteCommand
        public void CalculateInterest()
        {
            AccountHistory.Add(CalculateInterestCommand);
            CalculateInterestCommand.Execute();
        }
        public void CheckBalance()
        {
            CheckBalanceCommand.Execute();
        }
        public void Deposit()
        {
            AccountHistory.Add(DepositCommand);
            DepositCommand.Execute();
        }
        public void Withdraw()
        {
            AccountHistory.Add(WithdrawCommand);
            WithdrawCommand.Execute();
        }
        public void Revert(int id)
        {
            AccountHistory.Add(RevertCommand);
            if (RevertCommand.Execute()) AccountHistory[id-1].ValidTransaction = false;
        }
    }
}
