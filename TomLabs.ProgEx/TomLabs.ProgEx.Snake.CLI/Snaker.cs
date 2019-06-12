using System.Drawing;
using System.Linq;
using TomLabs.ProgEx.Snake.Core;
using static System.Console;

namespace TomLabs.ProgEx.Snake.CLI
{
	public class Snaker : SnakerBase
	{
		private Point? removeNext;

		public Snaker(int maxX, int maxY, int snakeLenght = 3) : base(maxX, maxY, snakeLenght)
		{
			RenderBorder();
		}

		protected override void Render()
		{
			RenderPoint(Gem, "@", 1);

			foreach (var s in SnakeBody)
			{
				RenderPoint(s, "o", 1);
			}

			if (removeNext.HasValue)
			{
				RenderPoint(removeNext.Value, " ", 1);
			}
			removeNext = SnakeBody.Last();

			RenderScore();

			if (GameOver)
			{
				RenderPoint(Head, "x", 1);
			}
		}

		private void RenderScore()
		{
			CursorTop = MAX_Y + 2;
			CursorLeft = 0;
			WriteLine($"Score: {Score}; x={SnakeBody.First().X},y={SnakeBody.First().Y}");
		}

		private void RenderBorder()
		{
			for (int y = 0; y < MAX_Y + 2; y++)
			{
				RenderPoint(0, y, "|");
			}

			for (int x = 0; x < MAX_X + 2; x++)
			{
				RenderPoint(x, 0, "_");
			}

			for (int y = 1; y < MAX_Y + 2; y++)
			{
				RenderPoint(MAX_X + 2, y, "|");
			}

			for (int x = 0; x < MAX_X + 2; x++)
			{
				RenderPoint(x, MAX_Y + 1, "_");
			}
		}

		private void RenderCanvas()
		{
			for (int x = 0; x < MAX_X; x++)
			{
				for (int y = 0; y < MAX_Y; y++)
				{
					RenderPoint(x, y, "_");
				}
			}
		}

		private void RenderPoint(int x, int y, string value, int offset = 0)
		{
			CursorLeft = x + offset;
			CursorTop = y + offset;
			Write(value);
		}

		private void RenderPoint(Point p, string value, int offset = 0)
		{
			RenderPoint(p.X, p.Y, value, offset);
		}
	}
}