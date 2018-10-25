using System.Collections.Generic;
using CommandPattern.UserInterface;
using CommandPattern.UserInterface.ConsoleItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandPattern.Tests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void ProgramUI_WithdrawCommand_BalanceReturnsCorrectValue()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "2", "100", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            var expected = 400m;
            var actual = program.GetCurrentAccount().AccountBalance;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProgramUI_OverdrawWithdrawCommand_BalanceShouldNotChange()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "2", "9000.01", "7" });
            var program = new ProgramUI(console);

            //-- Act
            var expected = program.GetCurrentAccount().AccountBalance;

            program.Run();

            var actual = program.GetCurrentAccount().AccountBalance;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProgramUI_DepositCommand_BalanceReturnsCorrectValue()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "3", "100", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            var expected = 600m;
            var actual = program.GetCurrentAccount().AccountBalance;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProgramUI_RevertCommand_BalanceReturnsCorrectValue()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "3", "200", "6", "1", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            var expected = 500m;
            var actual = program.GetCurrentAccount().AccountBalance;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProgramUI_DepositAndHistoryCommands_HistoryShouldShowDeposit()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "3", "200", "5", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            //--Arrange
            Assert.IsTrue(console.Output.Contains("1. Deposited $200"));
        }

        [TestMethod]
        public void ProgramUI_WithdrawAndHistoryCommands_HistoryShouldShowWithdraw()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "2", "200", "5", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            //--Arrange
            Assert.IsTrue(console.Output.Contains("1. Withdrew $200"));
        }

        [TestMethod]
        public void ProgramUI_RevertAndHistoryCommands_HistoryShouldShowRevert()
        {
            //-- Arrange
            var console = new MockConsole(new string[] { "2", "200", "6", "1", "5", "7" });
            var program = new ProgramUI(console);

            //-- Act
            program.Run();

            //--Arrange
            Assert.IsTrue(console.Output.Contains("2. Reverted Transaction 1"));
        }
    }
}
