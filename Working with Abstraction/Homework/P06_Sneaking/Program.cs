using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
		static int samRow;
		static int samCol;


        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
			InitializeRoom(n);

            var moves = Console.ReadLine().ToCharArray();
            
            for (int i = 0; i < moves.Length; i++)
            {
				MoveEnemy();

                int[] getEnemy = new int[2];
				EnemySpotted(getEnemy);
                
                if (samCol < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samRow)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
					GameOver();
                    
                }
                else if (getEnemy[1] < samCol && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samRow)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
					GameOver();
                }

                room[samRow][samCol] = '.';
				MovePlayer(moves, i);

				EnemySpotted(getEnemy);
                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samRow == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
					GameOver();
                }
            }
        }

		private static void EnemySpotted(int[] getEnemy)
		{
			for (int j = 0; j < room[samRow].Length; j++)
			{
				if (room[samRow][j] != '.' && room[samRow][j] != 'S')
				{
					getEnemy[0] = samRow;
					getEnemy[1] = j;
				}
			}
		}

		private static void MovePlayer(char[] moves, int i)
		{
			switch (moves[i])
			{
				case 'U':
					samRow--;
					break;
				case 'D':
					samRow++;
					break;
				case 'L':
					samCol--;
					break;
				case 'R':
					samCol++;
					break;
				default:
					break;
			}
			room[samRow][samCol] = 'S';
		}

		private static void GameOver()
		{
			for (int row = 0; row < room.Length; row++)
			{
				for (int col = 0; col < room[row].Length; col++)
				{
					Console.Write(room[row][col]);
				}
				Console.WriteLine();
			}
			Environment.Exit(0);
		}

		private static void MoveEnemy()
		{
			for (int row = 0; row < room.Length; row++)
			{
				for (int col = 0; col < room[row].Length; col++)
				{
					if (room[row][col] == 'b')
					{
						if (IsInTheRoom(row, col + 1))
						{
							room[row][col] = '.';
							room[row][col + 1] = 'b';
							col++;
						}
						else
						{
							room[row][col] = 'd';
						}
					}
					else if (room[row][col] == 'd')
					{
						if (IsInTheRoom(row, col - 1))
						{
							room[row][col] = '.';
							room[row][col - 1] = 'd';
						}
						else
						{
							room[row][col] = 'b';
						}
					}
				}
			}
		}

		private static bool IsInTheRoom(int row, int col)
		{
			return row >= 0 && row < room.Length && col >= 0 && col < room[row].Length;
		}

		private static void InitializeRoom(int n)
		{
			room = new char[n][];

			for (int row = 0; row < n; row++)
			{
				var input = Console.ReadLine().ToCharArray();
				room[row] = new char[input.Length];
				for (int col = 0; col < input.Length; col++)
				{
					room[row][col] = input[col];
					if (room[row][col] == 'S')
					{
						samRow = row;
						samCol = col;
					}
				}
			}
		}
	}
}
