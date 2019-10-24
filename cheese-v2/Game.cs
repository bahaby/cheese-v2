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
	public enum GameMode
	{
		Player,
		Computer,
		PlayervsComputer,
		PlayervsPlayer
	}
	public partial class Game : Form
	{
		Image mouseImage1 = Image.FromFile("..\\..\\img\\mouse1.jpg");
		Image mouseImage2 = Image.FromFile("..\\..\\img\\mouse2.jpg");
		Image wallImage = Image.FromFile("..\\..\\img\\wall.jpg");
		Image groundImage = Image.FromFile("..\\..\\img\\ground.jpg");
		Image cheeseImage = Image.FromFile("..\\..\\img\\cheese.jpg");

		// 2-) cheese 3-) 1. mouse 4-) 2. mouse
		Object cheese = new Object(2);
		Object mouse1 = new Object(3);
		Object mouse2 = new Object(4);
		Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		GameMode gameMode = GameMode.Player;
		bool gameOver;
		bool timer = false, keyboard = false;
		public Game()
		{
			InitializeComponent();
			SetDoubleBuffered(mazeTable);
			this.KeyPreview = true;
			gameOver = false;
			selectMaze(0);
			cheese = findUniqueObject(2);
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
		private int checkAround(Object mouse)
		{
			int objectType = 0;
			foreach (Direction direction in directions)
			{
				switch (checkDirection(mouse, direction))
				{
					case 2:
						objectType = 2;
						gameOver = true;
						break;
					case 3:
						objectType = 3;
						break;
					case 4:
						objectType = 4;
						break;
				}
			}
			return objectType;
		}
		private Direction findDirection(Object mouse)
		{
			int lowestStep = 0;
			Direction lowestDirection = Direction.None;
			bool first = true;

			foreach (Direction direction in directions)
			{
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
			return lowestDirection;
		}
		private void autoMove(Object mouse)
		{
			step(mouse, findDirection(mouse));
			checkAround(mouse);

		}

		/*private void keyboardMove(Object mouse)
		{
			if (pressed != Direction.None)
			{
				step(mouse, pressed);
			}
		}*/
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
			mouse.StepCount++;
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
			update.Start();
			if (gameMode != GameMode.Computer)
				keyboard = true;
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
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					if (mazeMaps[n, i, j] == 3 && gameMode == GameMode.Player)
						mazeMap[i, j] = 0;
					else if (mazeMaps[n, i, j] == 4 && gameMode == GameMode.Computer)
						mazeMap[i, j] = 0;
					else
						mazeMap[i, j] = mazeMaps[n, i, j];
				}
			}
			/*string message = "";
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					message += mazeMap[i, j] + " ,";
				}
				message += "\n";
			}
			MessageBox.Show(message);*/
		}
		private void endGame()
		{
			int check = checkAround(cheese);
			string message="";
			if (check == 3)
				message = "kazanan computer " + mouse1.StepCount + " adımda bitirdi";
			if (check == 4)
				message = "kazanan player " + mouse2.StepCount + " adımda bitirdi";
			resetGame();
			MessageBox.Show(message);
		}
		private void update_Tick(object sender, EventArgs e)
		{
			if (!gameOver && timer)
			{
				autoMove(mouse1);
			}
			if (gameOver)
				endGame();
		}

		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			if (!gameOver && keyboard)
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
			checkAround(mouse2);
			if (gameOver) endGame();
		}
		public void resetGame()
		{
			update.Stop();
			selectMaze(mapSelect.SelectedIndex);
			steps = new int[10, 15];
			gameOver = false;
			keyboard = false;
			timer = false;
			mouse1 = findUniqueObject(3);
			mouse2 = findUniqueObject(4);
			switch (gameMode)
			{
				case GameMode.Computer:
					timer = true;
					break;
				case GameMode.Player:
					update.Enabled = true;
					update.Stop();
					break;
				case GameMode.PlayervsComputer:
					timer = true;
					break;
				case GameMode.PlayervsPlayer:
					update.Enabled = true;
					update.Stop();
					break;
			}
		}
		private void Game_Load(object sender, EventArgs e)
		{
			mapSelect.SelectedIndex = 0;
			modeSelect.SelectedIndex = 0;
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			resetGame();
			mapSelect.SelectedIndex = 0;
			modeSelect.SelectedIndex = 0;
			mazeTable.Refresh();
		}

		private void mapSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectMaze(mapSelect.SelectedIndex);
			mazeTable.Refresh();
		}
		/*public void gameMode(int n)
		{
			mouse1 = findUniqueObject(3);
			mouse2 = findUniqueObject(4);
			if (n == 0)
			{
				mouse2.Id = 0;
				mazeMap[mouse2.X, mouse2.Y] = 0;
			}
			else if (n == 1)
			{
				mouse1.Id = 0;
				mazeMap[mouse1.X, mouse1.Y] = 0;
				mazeTable.Refresh();
			}
		}*/

		private void modeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (modeSelect.SelectedIndex)
			{
				case 0:
					gameMode = GameMode.Player;
					break;
				case 1:
					gameMode = GameMode.Computer;
					break;
				case 2:
					gameMode = GameMode.PlayervsComputer;
					break;
				case 3:
					gameMode = GameMode.PlayervsPlayer;
					break;
			}
			resetGame();
			mazeTable.Refresh();
		}
	}
}
