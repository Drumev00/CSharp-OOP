using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
	public string StealFieldInfo(string investigatedClass, params string[] fields)
	{
		Type classType = Type.GetType(investigatedClass);
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
	public string AnalyzeAcessModifiers(string className)
	{
		StringBuilder sb = new StringBuilder();

		Type classType = Type.GetType(className);
		FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

		MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
		MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

		foreach (FieldInfo field in fields)
		{
			sb.AppendLine($"{field.Name} must be private!");
		}
		foreach (MethodInfo method in privateMethods.Where(m => m.Name.StartsWith("get")))
		{
			sb.AppendLine($"{method.Name} have to be public!");
		}
		foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
		{
			sb.AppendLine($"{method.Name} have to be private!");
		}

		return sb.ToString().TrimEnd();
	}
	public string RevealPrivateMethods(string className)
	{
		StringBuilder sb = new StringBuilder();

		Type classType = Type.GetType(className);
		sb.AppendLine($"All Private Methods of Class: {classType}");
		sb.AppendLine($"Base Class: {classType.BaseType.Name}");

		MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
		foreach (MethodInfo method in privateMethods)
		{
			sb.AppendLine(method.Name);
		}

		return sb.ToString().TrimEnd();
	}
}

