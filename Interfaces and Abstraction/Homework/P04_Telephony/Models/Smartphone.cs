using System;

using P04_Telephony.Interfaces;

namespace P04_Telephony.Models
{
	public class Smartphone : ICallable, IBrowsable
	{
		public void Browse(string website)
		{
			bool isValid = true;
			foreach (char letter in website)
			{
				if (!WebsiteValidator(letter))
				{
					Console.WriteLine("Invalid URL!");
					isValid = false;
					break;
				}
			}
			if (isValid)
			{
				Console.WriteLine($"Browsing: {website}!");
			}
		}

		public void Call(string number)
		{
			bool isValid = true;
			foreach (char letter in number)
			{
				if (!TelephoneNumberValidator(letter))
				{
					Console.WriteLine("Invalid number!");
					isValid = false;
					break;
				}
			}
			if (isValid)
			{
				Console.WriteLine($"Calling... {number}");
			}
		}

		private bool WebsiteValidator(char letter)
		{
			bool isValid = true;
			if (char.IsDigit(letter))
			{
				isValid = false;
			}
			return isValid;
		}
		private bool TelephoneNumberValidator(char letter)
		{
			bool isValid = true;
			if (!char.IsDigit(letter))
			{
				isValid = false;
			}
			return isValid;
		}
	}
}
