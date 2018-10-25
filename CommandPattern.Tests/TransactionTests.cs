using System;
using CommandPattern.UserInterface.Command;
using CommandPattern.UserInterface.Command.ConcreteCommands;
using CommandPattern.UserInterface.Invoker;
using CommandPattern.UserInterface.Receiver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandPattern.Tests
{
    [TestClass]
    public class TransactionTests
    {
        private int _transactionCount;
        private IAccount _account;
        private ITransaction _interest, _balance, _deposit, _withdraw, _revert;
        private Teller _teller;

        [TestInitialize]
        public void Arrange()
        {
            _transactionCount = 0;
            _account = new BankAccount();
            _interest = new CalculateInterest(_account, _transactionCount);

        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
