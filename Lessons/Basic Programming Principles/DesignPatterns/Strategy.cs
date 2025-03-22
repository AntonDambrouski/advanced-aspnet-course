namespace Basic_Programming_Principles.DesignPatterns
{
    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment(double amount)
        {
            _paymentStrategy.ProcessPayment(amount);
        }
    }

    public interface IPaymentStrategy
    {
        void ProcessPayment(double amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing {amount} using Credit Card.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing {amount} using PayPal.");
        }
    }

    static class StrategyDemo
    {
        public static void Execute()
        {
            PaymentProcessor processor = new PaymentProcessor();
            var creditCardPayment = new CreditCardPayment();
            processor.SetPaymentStrategy(creditCardPayment);
            while (true)
            {
                var strategy = Console.ReadLine();
                if (strategy == "PayPal")
                {
                    var payPalPayment = new PayPalPayment();
                    processor.SetPaymentStrategy(payPalPayment);
                }
                else if (strategy == "CreditCard")
                {
                    processor.SetPaymentStrategy(creditCardPayment);
                }

                processor.ProcessPayment(100);
            }

        }
    }
}
