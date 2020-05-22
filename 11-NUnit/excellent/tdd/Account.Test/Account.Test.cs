using System;
using NUnit.Framework;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void SeedIncrement_Test()
        {
            //TODO: accountNumberSeed is incremented after each Account initialization
            var startingNumber = Account.accountNumberSeed;

            for (var i = 1; i <= 10; i++)
            {
                new Account();
                Assert.AreEqual(Account.accountNumberSeed, startingNumber + i);
            }
        }

        [Test]
        public void EmptyConstructor_Test()
        {
            //TODO: account initialized with empty constructor returns Balance equal to 0 and Owner as empty string
            var acc = new Account();
            Assert.AreEqual(acc.Balance, 0);
            Assert.AreEqual(acc.Owner, "");
        }

        [Test]
        public void Deposit_Test()
        {
            //TODO: Deposit method increases Balance with given amount
            var acc = new Account();
            acc.Deposit(1234);
            Assert.AreEqual(acc.Balance, 1234);
        }

        [Test]
        public void NotEmptyConstructor_Test()
        {
            //TODO: account initialized with not empty constructor returns Balance equal to initialBalance and Owner equal to given name
            var acc = new Account("john doe", 1234);
            Assert.AreEqual(acc.Balance, 1234);
            Assert.AreEqual(acc.Owner, "john doe");
        }

        [Test]
        public void DepositException_Test()
        {
            //TODO: negative amount parameter passed to Deposit method throws ArgumentOutOfRangeException exception
            var acc = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(NegativeDeposit);

            void NegativeDeposit()
            {
                acc.Deposit(-10);
            }
        }

        [Test]
        public void Withdraw_Test()
        {
            //TODO: Withdraw method decreases Balance with given amount
            var acc = new Account("John Doe", 1000);
            acc.Withdraw(123);
            Assert.AreEqual(acc.Balance, 877);
        }

        [Test]
        public void WithDrawExceptionOutOfRange_Test()
        {
            //TODO: negative amount parameter passed to Withdraw method throws ArgumentOutOfRangeException exception
            var acc = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(NegativeWithdraw);

            void NegativeWithdraw()
            {
                acc.Withdraw(-100);
            }
        }

        [Test]
        public void WithDrawExceptionInvalidOperation_Test()
        {
            //TODO: amount parameter greater than Balance passed to Withdraw method throws InvalidOperationException exception
            var acc = new Account("someone", 123);
            Assert.Throws<InvalidOperationException>(Overdraw);

            void Overdraw()
            {
                acc.Withdraw(200);
            }
        }
    }
}