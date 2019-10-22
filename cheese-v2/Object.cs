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
		public Direction BackDirection { get; set; } 
		public Object(int id)
		{
			this.Id = id;
			BackDirection = Direction.None;
		}
		public int Id { get; private set; }

	}
}
