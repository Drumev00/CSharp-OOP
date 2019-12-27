using System;
using System.Globalization;

using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Exceptions;
using Logger.Models.Errors;

namespace Logger.Factories
{
	public class ErrorFactory
	{
		private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
		public IError GetError(string dateString, string levelString, string message)
		{
			Level level;
			bool parsed = Enum.TryParse<Level>(levelString, out level);
			if (!parsed)
			{
				throw new InvalidLevelTypeException();
			}

			DateTime dateTime;
			try
			{
				dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				throw new InvalidDateFormatException();
			}

			return new Error(dateTime, message, level);
		}
	}
}
