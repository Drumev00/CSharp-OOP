using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
	public static class Engine
	{
		static long sum;
		public static void Run()
		{
			int[] dimensions = IntArrayMaker();
			int rows = dimensions[0];
			int cols = dimensions[1];

			int[,] matrix = new int[rows, cols];
			InitializeMatrix(matrix, rows, cols);


			string command = Console.ReadLine();
			while (command != "Let the Force be with you")
			{
				int[] playerCoordinates = command
					.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();
				int[] evilCoordinates = IntArrayMaker();

				int evilRow = evilCoordinates[0];
				int evilCol = evilCoordinates[1];

				MoveEvilPower(matrix, evilRow, evilCol);


				int playerRow = playerCoordinates[0];
				int playerCol = playerCoordinates[1];
				MovePlayer(matrix, playerRow, playerCol);


				command = Console.ReadLine();
			}

			Console.WriteLine(sum);

		}

		private static void MovePlayer(int[,] matrix, int playerRow, int playerCol)
		{
			while (playerRow >= 0 && playerCol < matrix.GetLength(1))
			{
				if (IsInside(matrix, playerRow, playerCol))
				{
					sum += matrix[playerRow, playerCol];
				}

				playerCol++;
				playerRow--;
			}
		}

		private static void MoveEvilPower(int[,] matrix, int evilRow, int evilCol)
		{
			while (evilRow >= 0 && evilCol >= 0)
			{
				if (IsInside(matrix, evilRow, evilCol))
				{
					matrix[evilRow, evilCol] = 0;
				}
				evilRow--;
				evilCol--;
			}
		}

		private static int[] IntArrayMaker()
		{
			return Console.ReadLine()
				.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
		}

		private static bool IsInside(int[,] matrix, int evilRow, int evilCol)
		{
			return evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1);
		}

		private static void InitializeMatrix(int[,] matrix, int rows, int cols)
		{
			int value = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = value++;
				}
			}
		}
	}
	
}
