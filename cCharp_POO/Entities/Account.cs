using System;
using cCharp_POO.Entities.Exceptions;


namespace cCharp_POO.Entities
{
    class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public double WithDrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > WithDrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            else if (amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }
            else
            {
                Balance -= amount;
            }

        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

    }
}
