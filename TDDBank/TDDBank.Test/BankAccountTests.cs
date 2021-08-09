using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDBank.Test
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void New_account_should_have_0_as_Balance()
        {
            BankAccount ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_deposit()
        {
            BankAccount ba = new BankAccount();

            ba.Deposit(3m);
            Assert.AreEqual(3m, ba.Balance);

            ba.Deposit(8m);
            Assert.AreEqual(11m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_can_Withdraw()
        {
            BankAccount ba = new BankAccount();
            ba.Deposit(20m);

            ba.Withdraw(4m);
            Assert.AreEqual(16m, ba.Balance);

            ba.Withdraw(7m);
            Assert.AreEqual(9m, ba.Balance);
        }

        [TestMethod]
        public void BankAccount_Deposit_negative_or_0_throws_ArgumentException()
        {
            BankAccount ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(-1));
            Assert.ThrowsException<ArgumentException>(() => ba.Deposit(0));
        }

        [TestMethod]
        public void BankAccount_Withdraw_negative_or_0_throws_ArgumentException()
        {
            BankAccount ba = new BankAccount();

            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(-1));
            Assert.ThrowsException<ArgumentException>(() => ba.Withdraw(0));
        }

        [TestMethod]
        public void BankAccount_Withdraw_more_than_Balance_throws_InvalidOperationException()
        {
            BankAccount ba = new BankAccount();
            ba.Deposit(10m);

            Assert.ThrowsException<InvalidOperationException>(() => ba.Withdraw(11m));
        }
    }
}
