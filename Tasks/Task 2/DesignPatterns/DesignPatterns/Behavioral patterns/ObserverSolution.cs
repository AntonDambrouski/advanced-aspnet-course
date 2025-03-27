using DesignPatterns.Behavioral_patterns.Implementations;


namespace DesignPatterns.Behavioral_patterns
{
	// клиенты подписываются на изменения продукта, и продукт
	// отправляет уведомления об изменении только тем кто подписался
	public class ObserverSolution : IExecutor
	{
		public void Execute()
		{
			Product product = new Product();
			ClientA observerA = new ClientA();
			product.Attach(observerA);

			product.SomeBusinessLogic();

			ClientB observerB = new ClientB();
			product.Attach(observerB);

			
			product.SomeBusinessLogic();

			product.Detach(observerA);

			product.SomeBusinessLogic();
		}
	}



	






}
