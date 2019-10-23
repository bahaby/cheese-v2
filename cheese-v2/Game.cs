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

		// 2-) cheese 3-) 1. mouse 4-) 2. mouse
		Object mouse1 = new Object(3);
		Object mouse2 = new Object(4);
		Object cheese = new Object(2);
		Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		bool gameOver;
		Direction pressed = Direction.None;
		public Game()
		{
			InitializeComponent();
			SetDoubleBuffered(mazeTable);
			this.KeyPreview = true;
			gameOver = false;
			selectMaze(0);
			cheese = findUniqueObject(2);
			mouse1 = findUniqueObject(3);
			mouse2 = findUniqueObject(4);
		}

		int[,] steps = new int[10, 15];
		int[,,] mazeMaps = { {
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 3, 1},
				{ 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			},{
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 2, 0, 0, 0, 1, 1, 0, 0, 0, 4, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 3, 1},
				{ 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			},{
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 2, 0, 0, 1, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 3, 1},
				{ 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			} };
		int[,] mazeMap = new int[10, 15];
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
		private int checkSteps(Object mouse, Direction direction)
		{
			switch (direction)
			{
				case Direction.Up:
					return steps[mouse.X - 1, mouse.Y];
				case Direction.Down:
					return steps[mouse.X + 1, mouse.Y];
				case Direction.Left:
					return steps[mouse.X, mouse.Y - 1];
				case Direction.Right:
					return steps[mouse.X, mouse.Y + 1];
			}
			return -1;
		}
		private Tuple<int, Direction> checkAround(Object mouse)
		{
			int objectType = 0;
			int lowestStep = 0;
			Direction lowestDirection = Direction.None;
			bool first = true;
			foreach(Direction direction in directions)
			{
				switch (checkDirection(mouse, direction))
				{
					case 2:
						objectType = 2;
						break;
					case 3:
						objectType = 3;
						break;
					case 4:
						objectType = 4;
						break;
				}
				if (stepValidate(mouse, direction))
				{
					if (first)
					{
						lowestStep = checkSteps(mouse, direction);
						lowestDirection = direction;
					}
					if (lowestStep > checkSteps(mouse, direction))
					{
						lowestStep = checkSteps(mouse, direction);
						lowestDirection = direction;
					}
					first = false;
				}
			}
			

			var results = new Tuple<int, Direction> (objectType, lowestDirection);
			return results;
		}
		private void autoMove(Object mouse)
		{
			var results = checkAround(mouse);
			//check if found cheese
			if (results.Item1 == 2)
			{
				gameOver = true;
			}
			else
			{
				step(mouse, results.Item2);
			}
			
		}

		private void keyboardMove(Object mouse)
		{
			if (pressed != Direction.None)
			{
				step(mouse, pressed);
			}
		}
		private void step(Object mouse, Direction direction)
		{
			int newX = mouse.X, newY = mouse.Y;
			if (!stepValidate(mouse, direction))
				return;
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
			mazeMap[mouse.X, mouse.Y] = 0;
			mazeMap[newX, newY] = mouse.Id;
			steps[mouse.X, mouse.Y]++;
			mouse.X = newX;
			mouse.Y = newY;
			mazeTable.Refresh();
		}
		private bool stepValidate(Object mouse, Direction direction)
		{
			int check = checkDirection(mouse, direction);
			if (check == 1 || check == 3 || check == 4)
				return false;
			return true;
		}
		private void startButton_Click(object sender, EventArgs e)
		{
			update.Enabled = true;
			update.Start();
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
		private void selectMaze(int n)
		{
			for (int i = 0; i<10; i++)
			{
				for (int j = 0; j<15; j++)
				{
					mazeMap[i, j] = mazeMaps[n, i, j];
				}
			}
		}
		private void update_Tick(object sender, EventArgs e)
		{
			if (!gameOver)
			{
				autoMove(mouse1);;
			}
		}

		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					step(mouse2, Direction.Up);
					break;
				case Keys.S:
					step(mouse2, Direction.Down);
					break;
				case Keys.A:
					step(mouse2, Direction.Left);
					break;
				case Keys.D:
					step(mouse2, Direction.Right);
					break;
				default:
					break;
			}
		}
		public void resetGame()
		{
			update.Stop();
			selectMaze(mapSelect.SelectedIndex);
			mouse1 = findUniqueObject(3);
			mouse2 = findUniqueObject(4);
			steps = new int[10, 15];
			gameOver = false;
		}
		private void Game_Load(object sender, EventArgs e)
		{
			
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			resetGame();
			mazeTable.Refresh();
		}

		private void mapSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			resetGame();
			selectMaze(mapSelect.SelectedIndex);
			mazeTable.Refresh();
		}
	}
}
