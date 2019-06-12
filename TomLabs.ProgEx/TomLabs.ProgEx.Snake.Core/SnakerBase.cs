using System;
using System.Drawing;
using System.Linq;

namespace TomLabs.ProgEx.Snake.Core
{
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}

	public abstract class SnakerBase
	{
		private Random rnd = new Random();

		public readonly int MAX_X;
		public readonly int MAX_Y;

		public Point Gem { get; protected set; }

		public Point Head => SnakeBody[0];
		public Point[] SnakeBody { get; protected set; }

		public Direction Steering { get; set; }
		public Direction Heading { get; set; }

		public bool GameOver { get; protected set; }

		public int Score { get; protected set; }

		protected int ScoreIncrement { get; set; } = 10;

		public SnakerBase(int maxX, int maxY, int snakeLength = 3)
		{
			MAX_X = maxX;
			MAX_Y = maxY;

			Init(snakeLength);
		}

		public virtual void Cycle()
		{
			if (!GameOver)
			{
				var head = Head;

				if ((Steering == Direction.Up && Heading != Direction.Down) || (Steering == Direction.Down && Heading == Direction.Up))
				{
					head.Y--;
					Heading = Direction.Up;
				}
				else if ((Steering == Direction.Down && Heading != Direction.Up) || (Steering == Direction.Up && Heading == Direction.Down))
				{
					head.Y++;
					Heading = Direction.Down;
				}
				else if ((Steering == Direction.Left && Heading != Direction.Right) || (Steering == Direction.Right && Heading == Direction.Left))
				{
					head.X--;
					Heading = Direction.Left;
				}
				else if ((Steering == Direction.Right && Heading != Direction.Left) || (Steering == Direction.Left && Heading == Direction.Right))
				{
					head.X++;
					Heading = Direction.Right;
				}

				if (head.X < 0 || head.Y < 0 || head.X > MAX_X || head.Y > MAX_Y || CheckSelfHarm())
				{
					GameOver = true;
					return;
				}
				else if (head == Gem)
				{
					EatGem();
				}

				SnakeBody = SnakeMove(SnakeBody, head);

				Render();
			}
		}

		protected abstract void Render();

		protected virtual void Init(int snakeLength = 3)
		{
			GameOver = false;
			Score = 0;
			NewGem();

			SnakeBody = new Point[snakeLength];
			for (int i = 0; i < SnakeBody.Length; i++)
			{
				SnakeBody[i] = new Point(MAX_X / 2, i + MAX_Y / 2); //TODO
			}
		}

		protected virtual void EatGem()
		{
			var last = SnakeBody.Last();
			SnakeBody = ArrayAddItem(SnakeBody, new Point(last.X + 1, last.Y + 1));
			NewGem();

			Score += ScoreIncrement;
		}

		protected virtual void NewGem()
		{
			Gem = new Point(rnd.Next(0, MAX_X), rnd.Next(0, MAX_Y));
		}

		private bool CheckSelfHarm()
		{
			bool res = false;
			for (int i = 1; i < SnakeBody.Length; i++)
			{
				if (Head == SnakeBody[i])
				{
					res = true;
				}
			}

			return res;
		}

		private Point[] SnakeMove(Point[] array, Point head)
		{
			var newSnake = new Point[array.Length];
			newSnake[0] = head;

			for (int i = 1; i < newSnake.Length; i++)
			{
				newSnake[i] = array[i - 1];
			}

			return newSnake;
		}

		private Point[] ArrayAddItem(Point[] array, Point item)
		{
			Array.Resize(ref array, array.Length + 1);
			array[array.Length - 1] = item;

			return array;
		}
	}
}