using System;
using System.Collections.Generic;

namespace Bank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal v)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(decimal v)
        {
            throw new NotImplementedException();
        }
    }
}
