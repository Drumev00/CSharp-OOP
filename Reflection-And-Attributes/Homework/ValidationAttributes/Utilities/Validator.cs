using System.Linq;
using System.Reflection;

using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
	public static class Validator
	{
		public static bool IsValid(object obj)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties();
			foreach (var prop in properties)
			{
				MyValidationAttribute[] attributes = prop
					.GetCustomAttributes()
					.Where(a => a is MyValidationAttribute)
					.Cast<MyValidationAttribute>()
					.ToArray();
				foreach (MyValidationAttribute attribute in attributes)
				{
					if (!attribute.IsValid(prop.GetValue(obj)))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
