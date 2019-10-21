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
		Up,
		Down,
		Left,
		Right
	};
	public partial class Game : Form
	{
		Image mouseImage = Image.FromFile("..\\..\\img\\mouse.jpg");
		Image wallImage = Image.FromFile("..\\..\\img\\wall.jpg");
		Image groundImage = Image.FromFile("..\\..\\img\\ground.jpg");
		Image cheeseImage = Image.FromFile("..\\..\\img\\cheese.jpg");
		public Game()
		{
			bool gameOver = false;
			InitializeComponent();
			SetDoubleBuffered(mazeTable);
		}

		int[,] mazeMap ={
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1},
				{ 1, 4, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 1},
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
								e.Graphics.DrawImage(mouseImage, e.CellBounds);
								break;
							case 4:
								e.Graphics.DrawImage(mouseImage, e.CellBounds);
								break;
						}
					}
				}
			}
		}
		private Object findUniqueObject(int mapItem)
		{
			Object obj = new Object();
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
		private int checkAround(Object mouse, Direction direction)
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

		private void move(Object mouse, Direction direction)
		{
			int newX = mouse.X, newY = mouse.Y;
			switch (direction)
			{
				case Direction.Up:
					newX -= 1;
					break;
				case Direction.Down:
					newX += 1;
					break;
				case Direction.Left:
					newY -= 1;
					break;
				case Direction.Right:
					newY += 1;
					break;
			}
			mazeMap[newX, newY] = mouse.Id;
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
