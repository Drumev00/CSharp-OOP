using System;
using System.Text;

namespace RhombusOfStars
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			for (int i = 1; i <= n; i++)
			{
				int spaces = n - i;
				PrintRow(spaces, i);
			}
			for (int i = n - 1; i > 0; i--)
			{
				int spaces = n - i;
				PrintRow(spaces, i);
			}
		}

		private static void PrintRow(int spaces, int i)
		{
			string requiredSpaces = new string(' ', spaces);
			StringBuilder sb = new StringBuilder();
			sb.Append(requiredSpaces);
			for (int j = 0; j < i; j++)
			{
				sb.Append("* ");
			}
			Console.WriteLine(sb);
		}
	}
}
