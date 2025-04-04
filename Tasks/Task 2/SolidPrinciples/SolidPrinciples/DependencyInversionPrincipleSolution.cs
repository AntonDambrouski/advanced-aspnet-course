using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	// при соблюдении принципа инверсии зависимостей классу Shop на вход 
	// можно подавать любой способ оплаты, который реализует интерфейс Payments
	public class DependencyInversionPrincipleSolution
	{
		public void Execute()
		{
			Cash cash = new Cash();
			PayByPhone payByPhone = new PayByPhone();
			Shop shop1 = new Shop(cash);
			shop1.doPayment(25);
			Shop shop2 = new Shop(payByPhone);
			shop2.doPayment(44);
		}
	}

	public interface Payments
	{
		void doTransaction(decimal amount);
	}

	public class Cash : Payments
	{
		public void doTransaction(decimal amount)
		{
			Console.WriteLine(this.ToString() + " Payment " + amount + "$");
		}
	}

	public class BankCard : Payments
	{
		public void doTransaction(decimal amount)
		{
			Console.WriteLine(this.ToString() + " Payment " + amount + "$");
		}
	}

	public class PayByPhone : Payments
	{
		public void doTransaction(decimal amount)
		{
			Console.WriteLine(this.ToString() + " Payment " + amount + "$");
		}
	}

	public class Shop
	{
		private Payments payments;

		public Shop(Payments payments)
		{
			this.payments = payments;
		}

		public void doPayment(decimal amount)
		{
			payments.doTransaction(amount);
		}
	}
}