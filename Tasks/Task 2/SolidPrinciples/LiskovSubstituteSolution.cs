using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LiskovSubstituteSolution
{
    internal class LiskovSubstituteSolution
    {
        public void Execute()
        {
            Account account = new MicroAccount(50);
            account.GetInterest();
        }
    }

    public abstract class Account
    {
        protected int _capital;
        protected decimal rate = 0M;

        public Account(int capital)
        {
            if (capital < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid capital value");
            }
            else
            {
                _capital = capital;
                
            }

        }

        public virtual int Capital
        {
            get { return _capital; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("invalid capital value");
                }
                _capital = value;
            }
        }

        public void GetInterest()
        {
            Console.WriteLine($"Amount on the account: {Capital} + {Capital * rate / 100}");
        }


    }



    public class DepositAccount : Account
    {


        public DepositAccount(int capital) : base(capital)
        {
            rate = 10M;
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




        public override int Capital
        {
            get { return _capital; }
            set
            {
                if (value < 100)
                {
                    try
                    {
                        throw new ArgumentException("Capital is too small");
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                    
                }

                _capital = value;
            }
        }

    }


    public class MicroAccount : Account
    {

        public MicroAccount(int capital) : base(capital)
        {
            _capital = capital;
            rate = 5M;
        }

    }



}
