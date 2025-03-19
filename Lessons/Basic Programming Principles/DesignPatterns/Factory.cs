namespace Basic_Programming_Principles.DesignPatterns
{
    public interface INotification
    {
        void Send(string message);
    }

    public class NotificationFactory
    {
        public INotification GetNotification(string notificationType)
        {
            if (notificationType == "email")
            {
                return new EmailNotification();
            }
           
            if (notificationType == "sms")
            {
                return new SMSNotification();
            }
           
            if (notificationType == "push")
            {
                return new PushNotification();
            }

            return null;
        }
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }

    class FactoryDemo
    {
        public static void Execute()
        {
            string notificationType = "email";
            NotificationFactory factory = new NotificationFactory();
            var notification = factory.GetNotification(notificationType);
            notification.Send("Hello via Email!");

        }
    }

}
