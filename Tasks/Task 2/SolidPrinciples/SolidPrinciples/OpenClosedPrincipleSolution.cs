using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class OpenClosedPrincipleSolution
    {
		public void Execute()
		{
			EmailNotificationService emailNotificationService = new EmailNotificationService();
			MobileNotificationService mobileNotificationService = new MobileNotificationService();

			emailNotificationService.sendMessage("message for email");
			mobileNotificationService.sendMessage("message for mobile");
		}
    }

	public interface INotificationService
	{
		public void sendMessage(string message);
	}

	public class EmailNotificationService : INotificationService
	{
		public void sendMessage(string message)
		{
			Console.WriteLine("Send Email: " + message);
		}
	}

	public class MobileNotificationService : INotificationService
	{
		public void sendMessage(string message)
		{
			Console.WriteLine("Send SMS: " + message);
		}
	}


}
