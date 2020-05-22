using System;
using System.Collections.Generic;

namespace Account
{
    public class Account
    {
        public static int accountNumberSeed { get; private set; } = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                return GetBalance();
            }
        }

        //hint: Balance should be counted as sum of all transactions
        private decimal GetBalance()
        {
            decimal sum = 0;
            foreach (var transaction in allTransactions)
            {
                sum += transaction.Amount;
            }
            return sum;
        }

        public Account(string name, decimal initialBalance) : this()
        {
            Owner = name;
            var initialTransaction = new Transaction(initialBalance);
            allTransactions.Add(initialTransaction);
        }

        public Account()
        {
            Owner = "";
            accountNumberSeed += 1;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var transaction = new Transaction(amount);
            allTransactions.Add(transaction);
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException();
            }
            var transaction = new Transaction(-amount);
            allTransactions.Add(transaction);
        }
    }
}
