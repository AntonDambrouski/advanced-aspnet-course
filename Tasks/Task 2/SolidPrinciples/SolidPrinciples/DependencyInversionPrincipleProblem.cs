using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	// В данной реализации класс Shop связан с классом Cash, следовательно 
	// чтобы добавить в магазин новый способ оплаты придётся влезать
	// и переписывать сам класс Shop
    public class DependencyInversionPrincipleProblem
    {
		public void Execute()
		{
			CashProblem cash = new CashProblem();
			ShopProblem shop = new ShopProblem(cash);
			shop.doPayment(25);
		}
    }

	public class CashProblem
	{
		public void doTransaction(decimal amount)
		{
			Console.WriteLine(this.ToString() + " Payment " + amount + "$");
		}
	}
	public class ShopProblem
	{
		private CashProblem cash;
		public ShopProblem(CashProblem cash)
		{
			this.cash = cash;
		}
		public void doPayment(decimal amount)
		{
			cash.doTransaction(amount);
		}
	}

}
