using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{

	public string StealFieldInfo(string investigatedClass, params string[] fields)
	{
		Type classType = Type.GetType($"{investigatedClass}");
		FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

		StringBuilder sb = new StringBuilder();
		object classInstance = Activator.CreateInstance(classType, null);

		sb.AppendLine($"Class under investigation: {investigatedClass}");
		foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
		{
			sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
		}

		return sb.ToString().TrimEnd();
	}
}

