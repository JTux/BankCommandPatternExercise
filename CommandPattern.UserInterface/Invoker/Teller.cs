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
        private ITransaction _calculateInterestCommand;
        private ITransaction _checkBalanceCommand;
        private ITransaction _depositCommand;
        private ITransaction _withdrawCommand;
        private ITransaction _revertCommand;

        private List<ITransaction> _accountHistory;

        //-- There are two Constructors
        //-- The first Constructor is used when the Invoker is originally created on a brand new Account
        public Teller(ITransaction calcInterest, ITransaction checkBal, ITransaction deposit, ITransaction withdraw)
        {
            _accountHistory = new List<ITransaction>();
            _calculateInterestCommand = calcInterest;
            _checkBalanceCommand = checkBal;
            _depositCommand = deposit;
            _withdrawCommand = withdraw;
        }

        //-- The second Constructor is used anytime after the initial creation and allows the Concrete Commands to be updated
        //TODO: Create public methods that allow these to be updated in existing Invoker
        public Teller(ITransaction calcInterest, ITransaction checkBal, ITransaction deposit, ITransaction withdraw, List<ITransaction> newList, ITransaction revert)
        {
            _accountHistory = newList;
            _calculateInterestCommand = calcInterest;
            _checkBalanceCommand = checkBal;
            _depositCommand = deposit;
            _withdrawCommand = withdraw;
            _revertCommand = revert;
        }

        //-- Method that allows the Teller(Invoker) to pull the history out of the class
        public List<ITransaction> GetHistory()
        {
            return _accountHistory;
        }

        //-- Invoker methods that are used to store Transaction(ConcreteCommand) history and execute said ConcreteCommand
        public void CalculateInterest()
        {
            _accountHistory.Add(_calculateInterestCommand);
            _calculateInterestCommand.Execute();
        }
        public void CheckBalance()
        {
            _accountHistory.Add(_checkBalanceCommand);
            _checkBalanceCommand.Execute();
        }
        public void Deposit()
        {
            _accountHistory.Add(_depositCommand);
            _depositCommand.Execute();
        }
        public void Withdraw()
        {
            _accountHistory.Add(_withdrawCommand);
            _withdrawCommand.Execute();
        }
        public void Revert()
        {
            _accountHistory.Add(_revertCommand);
            _revertCommand.Execute();
        }
    }
}
