using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class Transaction
    {
        private decimal _amount;

        private decimal Amount {
            get { return _amount; }
            set { _amount = value; }
        }

        public DateTime DateOfTrans { get; set; }

        private bool isDeposit {
            get { return TransactionType == TransactionType.Deposit; }
        }

        private bool isWithdraw
        {
            get { return TransactionType == TransactionType.Withdraw; }
        }

        private TransactionType TransactionType { get; set; }

        public Transaction(decimal amount, TransactionType type)
        {
            Amount = amount;
            TransactionType = type;
            DateOfTrans = DateTime.Now;
        }
    }
}
