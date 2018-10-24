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

        private List<ITransaction> _accountHistory;

        public Teller(ITransaction calcInterest, ITransaction checkBal, ITransaction deposit, ITransaction withdraw)
        {
            _accountHistory = new List<ITransaction>();
            _calculateInterestCommand = calcInterest;
            _checkBalanceCommand = checkBal;
            _depositCommand = deposit;
            _withdrawCommand = withdraw;
        }

        public Teller(ITransaction calcInterest, ITransaction checkBal, ITransaction deposit, ITransaction withdraw, List<ITransaction> newList)
        {
            _accountHistory = newList;
            _calculateInterestCommand = calcInterest;
            _checkBalanceCommand = checkBal;
            _depositCommand = deposit;
            _withdrawCommand = withdraw;
        }
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

        public List<ITransaction> GetHistory()
        {
            return _accountHistory;
        }
    }
}
