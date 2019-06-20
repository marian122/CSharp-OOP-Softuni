using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    [TestFixture]
    public class Tests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CheckPropertyGettersWorkCorrectly()
        {
            this.bankAccount = new BankAccount("Ivan", 340.53m);
            string name = bankAccount.Name;
            decimal balance = bankAccount.Balance;

            string expectedName = "Ivan";
            decimal expectedBalance = 340.53m;

            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedBalance, balance);
        }

        [Test]
        [TestCase("Iv")]
        [TestCase("sdsdsdsdfghgjyhgfrtghyujkioplfrhtghyhggjgfjhgj")]
        public void ThrowArgumentExceptionWhenNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, 340.53m));
        }

        [Test]
        public void ThrowArgumentExceptionWhenBalanceIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount("Ivan", -2));
        }

        [Test]
        public void DepositMethodShouldIncreaseBankAccount()
        {
            this.bankAccount = new BankAccount("Ivan", 340);
            this.bankAccount.Deposit(10);

            var actualResult = this.bankAccount.Balance;
            var expectedResult = 350;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DepositMethodShouldThrowExceptionWhenDepositInvalidMoney()
        {
            this.bankAccount = new BankAccount("Ivan", 340);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(-5));
        }

        [Test]
        public void WithdrawMethodShouldReduceBankAccount()
        {
            this.bankAccount = new BankAccount("Ivan", 340);
            this.bankAccount.Withdraw(10);

            var actualResult = this.bankAccount.Balance;
            var expectedResult = 330;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(500)]
        [TestCase(-400)]
        public void WithdrawMethodShouldThrowExceptionWhenWithdrawInvalidMoney(decimal amount)
        {
            this.bankAccount = new BankAccount("Ivan", 340);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }
    }
}