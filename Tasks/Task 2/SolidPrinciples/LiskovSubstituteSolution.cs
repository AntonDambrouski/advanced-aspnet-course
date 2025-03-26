using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LiskovSubstituteSolution
{
    internal class LiskovSubstituteSolution
    {
        public void Execute()
        {
            Account account = new MicroAccount(50, 1M);
            account.GetInterest();

            Account acc = new DepositAccount(100, 10M);
            acc.GetInterest();
        }
    }

    public abstract class Account
    {
        protected int _capital;
        protected decimal _rate;

        public virtual void GetInterest()
        {
            Console.WriteLine($"Amount on the account:  {_capital} + {_capital * _rate / 100}");
        }


    }



    public class DepositAccount : Account
    {

        private decimal _bonus; 
        public DepositAccount(int capital, decimal rate) : base()
        {
            _rate = rate;
            _bonus = capital * rate * 0.5M / 100M;

            if (capital < 100)
            {
                try
                {
                    throw new ArgumentException("Capital is too small");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            else
            {
                _capital = capital;
            }

           
        }

        public override void GetInterest()
        {
            Console.WriteLine($"Amount on the account:  {_capital} + {_capital * _rate / 100} + {_bonus}");
        }

    }


    public class MicroAccount : Account
    {

        public MicroAccount(int capital, decimal rate) : base()
        {
            _capital = capital;
            _rate = rate;
        }

    }



}
