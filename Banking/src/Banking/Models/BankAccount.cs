using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class BankAccount : IBankAccount
    {
        private string _accountNumber;
        public decimal Balance { get; set; }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        private IList<Transaction> _transactions;

        public int NumberOfTransactions
        {
            get { return _transactions.Count; }
        }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = Decimal.Zero;
            _transactions = new List<Transaction>();
        }

        public virtual void Withdraw(decimal amount)
        {
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
            Balance += amount;
        }

        public IEnumerable<Transaction> GetTransactions(DateTime ? from, DateTime ? till)
        {
            IList<Transaction> transactionList = new List<Transaction>();
            foreach (Transaction t in _transactions)
                if (t.DateOfTrans >= from && t.DateOfTrans <= till)
                    transactionList.Add(t);
            return transactionList;
        }

        public override string ToString()
        {
            return $"{AccountNumber} - {Balance}";
        }

        public override bool Equals(object obj)
        {
            BankAccount account = obj as BankAccount;
            if (account == null) return false;
            return AccountNumber == account.AccountNumber;
        }

        public override int GetHashCode()
        {
            return AccountNumber?.GetHashCode() ?? 0;
        }
    }
}
