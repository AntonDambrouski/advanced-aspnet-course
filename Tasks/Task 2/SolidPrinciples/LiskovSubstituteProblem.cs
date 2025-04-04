using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LiskovSubstituteProblem
{
    internal class LiskovSubstituteProblem
    {
        public void Execute()
        {
            Account account = new MicroAccount(50);
            account.GetInterest();                          
        }
    }


    public class Account
    {
        protected int _capital;
        protected decimal rate = 10M; 
        public Account(int capital)
        {
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




        public virtual int Capital
        {
            get { return _capital; }
            set
            {
                if (value < 100)
                {
                    throw new ArgumentException("Capital is too small");
                }               

                _capital = value;
            }
        }

        public void GetInterest() 
        {
            Console.WriteLine($"Amount on the account: { Capital} + { Capital* rate/ 100}");
        }





    }


    public class MicroAccount: Account
    {
        
        public MicroAccount(int capital): base(capital)
        {
            _capital = capital;
            rate = 5M;
        }

    }



}
