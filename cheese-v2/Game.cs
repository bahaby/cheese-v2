using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cheese_v2
{
	public enum Direction
	{
		None,
		Up,
		Down,
		Left,
		Right
	};
	public partial class Game : Form
	{
		Image mouseImage1 = Image.FromFile("..\\..\\img\\mouse1.jpg");
		Image mouseImage2 = Image.FromFile("..\\..\\img\\mouse2.jpg");
		Image wallImage = Image.FromFile("..\\..\\img\\wall.jpg");
		Image groundImage = Image.FromFile("..\\..\\img\\ground.jpg");
		Image cheeseImage = Image.FromFile("..\\..\\img\\cheese.jpg");

		Object mouse = new Object(3);
		Object mouse2 = new Object(4);
		Object cheese = new Object(2);
		bool gameOver;
		public Game()
		{
			gameOver = false;
			InitializeComponent();
			SetDoubleBuffered(mazeTable);
			mouse = findUniqueObject(3);
			mouse2 = findUniqueObject(4);
			cheese = findUniqueObject(2);
			Console.WriteLine(checkAround(mouse).Item1 + " " + checkAround(mouse).Item2 + " " + checkAround(mouse).Item3 + " " + checkAround(mouse).Item4);
			Console.WriteLine(checkAround(mouse2).Item1 + " " + checkAround(mouse2).Item2 + " " + checkAround(mouse2).Item3 + " " + checkAround(mouse2).Item4);
		}

		int[,] mazeMap ={
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1},
				{ 1, 4, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			};

		private void mazeTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					if (e.Column == j && e.Row == i)
					{
						switch (mazeMap[i, j])
						{
							case -1:
							case 0:
								e.Graphics.DrawImage(groundImage, e.CellBounds);
								break;
							case 1:
								e.Graphics.DrawImage(wallImage, e.CellBounds);
								break;
							case 2:
								e.Graphics.DrawImage(cheeseImage, e.CellBounds);
								break;
							case 3:
								e.Graphics.DrawImage(mouseImage1, e.CellBounds);
								break;
							case 4:
								e.Graphics.DrawImage(mouseImage2, e.CellBounds);
								break;
						}
					}
				}
			}
		}
		private Object findUniqueObject(int mapItem)
		{
			Object obj = new Object(mapItem);
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					if (mazeMap[i, j] == mapItem)
					{
						obj.X = i;
						obj.Y = j;
					}
				}
			}
			return obj;
		}
		private int checkDirection(Object mouse, Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return mazeMap[mouse.X - 1, mouse.Y];
				case Direction.Down:
					return mazeMap[mouse.X + 1, mouse.Y];
				case Direction.Left:
					return mazeMap[mouse.X, mouse.Y - 1];
				case Direction.Right:
					return mazeMap[mouse.X, mouse.Y + 1];
			}
			return -1;
		}
		private Tuple<int, int, int, Direction> checkAround(Object mouse)
		{
			Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right};
			int wallCount = 0;
			int roadCount = 0;
			int objectType = 0;
			Direction objectDirection = Direction.None;
			foreach(Direction direction in directions)
			{
				switch (checkDirection(mouse, direction))
				{
					case 0:
						roadCount++;
						break;
					case 1:
						wallCount++;
						break;
					case 2:
						objectType = 2;
						objectDirection = direction;
						break;
					case 3:
						objectType = 3;
						objectDirection = direction;
						break;
					case 4:
						objectType = 4;
						objectDirection = direction;
						break;
				}
			}

			var results = new Tuple<int, int, int, Direction> (roadCount, wallCount, objectType, objectDirection);
			return results;
		}
	/*	private bool collide(Object obj1, Object obj2)
		{
			if (checkAround(obj1, Direction.Up) == obj2.Id ||
				checkAround(obj1, Direction.Down) == obj2.Id ||
				checkAround(obj1, Direction.Left) == obj2.Id ||
				checkAround(obj1, Direction.Right) == obj2.Id)
			{
				return true;
			}
			return false;
		}*/
	/*	private void moveTo(Object mouse, int x, int y)
		{
			while(mouse.X == x && mouse.Y == y)
			{
				if (collide(mouse, cheese))
				{
					gameOver = true;
				}
				else if (checkAround(mouse, Direction.Up) == 0)
					move(mouse, Direction.Up);
				else if (checkAround(mouse, Direction.Down) == 0)
					move(mouse, Direction.Down);
				else if (checkAround(mouse, Direction.Left) == 0)
					move(mouse, Direction.Left);
				else if (checkAround(mouse, Direction.Right) == 0)
					move(mouse, Direction.Right);
			}
		}*/
		private bool move(Object mouse, Direction direction)
		{
			int newX = mouse.X, newY = mouse.Y;
			Direction backDirection;
			if (mouse.BackDirection == direction)
				return false;
			switch (direction)
			{
				case Direction.Up:
					newX -= 1;
					backDirection = Direction.Down;
					
					break;
				case Direction.Down:
					newX += 1;
					backDirection = Direction.Up;
					break;
				case Direction.Left:
					newY -= 1;
					backDirection = Direction.Right;
					break;
				case Direction.Right:
					newY += 1;
					backDirection = Direction.Left;
					break;
				default:
					backDirection = Direction.None;
					return false;
			}
			mazeMap[mouse.X, mouse.Y] = 0;
			mazeMap[newX, newY] = mouse.Id;
			mouse.X = newX;
			mouse.Y = newY;
			mouse.BackDirection = backDirection;
			mazeTable.Refresh();
			return true;
		}

		private void startButton_Click(object sender, EventArgs e)
		{

		}
		public static void SetDoubleBuffered(System.Windows.Forms.Control c)
		{
			if (System.Windows.Forms.SystemInformation.TerminalServerSession)
				return;
			System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
			System.Reflection.BindingFlags.NonPublic |
			System.Reflection.BindingFlags.Instance);
			aProp.SetValue(c, true, null);
		}
	}
}
