using System;
using Xunit;

namespace Bank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void BankAccount_new_account_should_have_0_as_balance()
        {
            var ba = new BankAccount();
            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);

            Assert.Equal(12m, ba.Balance);
        }

        [Fact]
        public void BankAccount_deposit_should_summarize_to_the_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);
            ba.Deposit(6m);

            Assert.Equal(18m, ba.Balance);
        }

        [Fact]
        public void BankAccount_deposit_a_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(-4));
        }

        [Fact]
        public void BankAccount_deposit_0_as_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(0));
        }

        [Fact]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);
            ba.Withdraw(4m);

            Assert.Equal(8m, ba.Balance);
        }

        [Fact]
        public void BankAccount_withdraw_a_negative_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(-4));
        }

        [Fact]
        public void BankAccount_withdraw_0_as_value_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(0));
        }

        [Fact]
        public void BankAccount_withdraw_below_zero_InvalidOperationException()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(20m));
        }
    }
}
