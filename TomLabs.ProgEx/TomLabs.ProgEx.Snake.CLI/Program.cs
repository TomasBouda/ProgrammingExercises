using System;
using System.Threading;

namespace TomLabs.ProgEx.Snake.CLI
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var s = new Snaker(20, 20, 5);
			int pause = 400;

			var key = ConsoleKey.End;
			do
			{
				s.Init();
				while (key != ConsoleKey.Escape && !s.GameOver)
				{
					if (Console.KeyAvailable)
					{
						key = Console.ReadKey().Key;
						switch (key)
						{
							case ConsoleKey.UpArrow: s.Steering = Core.Direction.Up; break;
							case ConsoleKey.DownArrow: s.Steering = Core.Direction.Down; break;
							case ConsoleKey.LeftArrow: s.Steering = Core.Direction.Left; break;
							case ConsoleKey.RightArrow: s.Steering = Core.Direction.Right; break;
						}
					}

					s.Cycle();
					Thread.Sleep(pause - s.Score / 2);
				}
			} while (Console.ReadKey().Key == ConsoleKey.Enter);

			Console.ReadKey();
		}
	}
}