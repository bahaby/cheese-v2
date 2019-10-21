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
		public Object(int id = 0)
		{
			this.Id = id;
		}
		public int Id { get; private set; }

	}
}
