using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class OpenClosedPrincipleProblem
    {
		public void Execute()
		{
			NotificationService notificationService = new NotificationService();
			notificationService.sendMessage("email", "message for email");
			notificationService.sendMessage("sms", "message for sms");
		}
    }

	public class NotificationService
	{
		public void sendMessage(String typeMessage, String message)
		{
			if (typeMessage == "email")
			{
				Console.WriteLine("Send Email: " + message);
			}
			if (typeMessage == "sms")
			{
				Console.WriteLine("Send SMS: " + message);
			}

		}
	}
}
