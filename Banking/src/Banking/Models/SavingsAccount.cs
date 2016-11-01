using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class SavingsAccount: BankAccount
    {
        protected const decimal WithdrawCost = 0.25M;
        public decimal InterestRate { get; private set; }

        public SavingsAccount(String bankAccountNumber, decimal interestRate): base(bankAccountNumber)
        {
            InterestRate = interestRate;
        }

        public void AddInterest()
        {
            Deposit(Balance * InterestRate);
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);
            base.Withdraw(WithdrawCost);
        }
    }
}
