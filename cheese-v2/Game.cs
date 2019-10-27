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
	//oyun modları
	public enum GameMode
	{
		Player,
		Computer,
		PlayervsComputer,
		PlayervsPlayer
	}
	//mazeMap dizisindeki int değerlere karşılık gelecek terimler
	public enum Map
	{
		Road,
		Wall,
		Cheese,
		Player1,
		Player2
	}
	public partial class Game : Form
	{
		//resim dosyalarını ekleme
		Image mouseImage1 = Properties.Resources.mouse1;
		Image mouseImage2 = Properties.Resources.mouse2;
		Image wallImage = Properties.Resources.wall;
		Image groundImage = Properties.Resources.ground;
		Image cheeseImage = Properties.Resources.cheese;
		

		Object cheese = new Object(Map.Cheese);
		Object mouse1 = new Object(Map.Player1);
		Object mouse2 = new Object(Map.Player2);
		Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		GameMode gameMode = GameMode.Player;
		bool gameOver = false;
		bool timerEnabled = false, keyboardEnabled = false;
		public Game()
		{
			InitializeComponent();
			SetDoubleBuffered(mazeTable); // dalgalanma sorunu için
			this.KeyPreview = true;
			selectMaze(0);
		}
		
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
				{ 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 4, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 3, 1},
				{ 1, 2, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			},{
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 3, 1},
				{ 1, 0, 1, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			} };
		int[,] mazeMap = new int[10, 15];
		int[,] steps = new int[10, 15];
		private Object findObject(Map mapItem)
		{
			Object obj = new Object(mapItem);
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					if ((Map)mazeMap[i, j] == mapItem)
					{
						obj.X = i;
						obj.Y = j;
					}
				}
			}
			return obj;
		}
		private Map checkAround(Object mouse)
		{
			foreach (Direction direction in directions)
			{
				switch ((Map)mouse.check(mazeMap, direction))
				{
					case Map.Cheese:
						gameOver = true;
						return Map.Cheese;
						break;
					case Map.Player1:
						return Map.Player1;
						break;
					case Map.Player2:
						return Map.Player2;
						break;
				}
			}
			return Map.Road;
		}
		private Direction findDirection(Object mouse)
		{
			int lowestStep = 0;
			Direction bestDirection = Direction.None;
			bool first = true;
			Object temp = new Object(mouse.Id);

			foreach (Direction direction in directions)
			{
				if (stepValidate(mouse, direction) && direction != mouse.BackDirection)
				{
					temp.X = mouse.X;
					temp.Y = mouse.Y;
					while (stepValidate(temp, direction))
					{
						if (first)
						{
							lowestStep = temp.check(steps, direction);
							bestDirection = direction;
						}
						else if (lowestStep > temp.check(steps, direction))
						{
							lowestStep = temp.check(steps, direction);
							bestDirection = direction;
						}
						temp.move(direction);
						first = false;
					}
				}
				if (direction == mouse.BackDirection && first == true)
				{
					bestDirection = mouse.BackDirection;
				}
			}
			return bestDirection;
		}

		private void step(Object mouse, Direction direction)
		{
			if (!stepValidate(mouse, direction))
				return;
			mazeMap[mouse.X, mouse.Y] = 0;
			if (mouse.Id == Map.Player1)
				steps[mouse.X, mouse.Y]++;
			mouse.move(direction);
			mazeMap[mouse.X, mouse.Y] = (int)mouse.Id;
			mazeTable.Refresh();
			checkAround(mouse);
		}
		private bool stepValidate(Object mouse, Direction direction)
		{
			Map check = (Map)mouse.check(mazeMap, direction);
			if (check == Map.Wall || check == Map.Player1 || check == Map.Player2)
				return false;
			return true;
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
		}
		private void endGame()
		{
			Map check = checkAround(cheese);
			string message="";
			if (check == Map.Player1)
				message = "kazanan computer " + mouse1.StepCount + " adımda bitirdi";
			if (check == Map.Player2)
				message = "kazanan player " + mouse2.StepCount + " adımda bitirdi";
			resetGame();
			startButton.Enabled = false;
			MessageBox.Show(message);
		}

		public void resetGame()
		{
			update.Stop();
			selectMaze(mapSelect.SelectedIndex);
			startButton.Enabled = true;
			steps = new int[10, 15];
			gameOver = false;
			keyboardEnabled = false;
			timerEnabled = false;
			mouse1 = findObject(Map.Player1);
			mouse2 = findObject(Map.Player2);
			cheese = findObject(Map.Cheese);
			switch (gameMode)
			{
				case GameMode.Computer:
					timerEnabled = true;
					break;
				case GameMode.Player:
					update.Enabled = true;
					update.Stop();
					break;
				case GameMode.PlayervsComputer:
					timerEnabled = true;
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

		private void startButton_Click(object sender, EventArgs e)
		{
			update.Start();
			if (gameMode != GameMode.Computer)
				keyboardEnabled = true;
			startButton.Enabled = false;
		}
		private void resetButton_Click(object sender, EventArgs e)
		{
			resetGame();
			mazeTable.Refresh();
		}

		private void mapSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectMaze(mapSelect.SelectedIndex);
			resetGame();
			mazeTable.Refresh();
		}

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
		private void update_Tick(object sender, EventArgs e)
		{
			if (gameOver)
				endGame();
			else if (timerEnabled)
			{
				step(mouse1, findDirection(mouse1));
			}
		}
		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			if (!gameOver && keyboardEnabled)
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
			else if (gameOver)
				endGame();
		}
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
							case 0:
								e.Graphics.DrawImage(groundImage, e.CellBounds);
								//e.Graphics.DrawString(steps[i, j].ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), e.CellBounds);
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
		public static void SetDoubleBuffered(Control c)
		{
			if (SystemInformation.TerminalServerSession)
				return;
			System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
			System.Reflection.BindingFlags.NonPublic |
			System.Reflection.BindingFlags.Instance);
			aProp.SetValue(c, true, null);
		}
	}
}
