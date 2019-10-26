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
		public Object(Map id)
		{
			this.Id = id;
		}
		public Map Id { get; set; }
		public void move(Direction direction)
		{
			this.StepCount++;
			switch (direction)
			{
				case Direction.Up:
					BackDirection = Direction.Down;
					this.X -= 1;
					break;
				case Direction.Down:
					BackDirection = Direction.Up;
					this.X += 1;
					break;
				case Direction.Left:
					BackDirection = Direction.Right;
					this.Y -= 1;
					break;
				case Direction.Right:
					BackDirection = Direction.Left;
					this.Y += 1;
					break;
			}

		}
		public int check(int[,] array, Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return array[this.X - 1, this.Y];
				case Direction.Down:
					return array[this.X + 1, this.Y];
				case Direction.Left:
					return array[this.X, this.Y - 1];
				case Direction.Right:
					return array[this.X, this.Y + 1];
			}
			return 0;
		}
	}
}
