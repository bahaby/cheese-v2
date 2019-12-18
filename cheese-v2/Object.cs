using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cheese_v2
{
	class Object
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int StepCount { get; set; }
		public Direction BackDirection { get; set; }
		public Map Id { get; set; }
		public Object(Map id)
		{
			this.Id = id;
		}
		public void move(Direction direction)
		{
			StepCount++;
			switch (direction)
			{
				case Direction.Up:
					BackDirection = Direction.Down;
					X -= 1;
					break;
				case Direction.Down:
					BackDirection = Direction.Up;
					X += 1;
					break;
				case Direction.Left:
					BackDirection = Direction.Right;
					Y -= 1;
					break;
				case Direction.Right:
					BackDirection = Direction.Left;
					Y += 1;
					break;
			}

		}
		public int check(int[,] array, Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return array[X - 1, Y];
				case Direction.Down:
					return array[X + 1, Y];
				case Direction.Left:
					return array[X, Y - 1];
				case Direction.Right:
					return array[X, Y + 1];
			}
			return 0;
		}
	}
}
