using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

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
		Computer,
		Player,
		PlayervsComputer
	}
	//mazeMap dizisindeki int değerlere karşılık gelecek terimler
	public enum Map
	{
		Road,
		Wall,
		Cheese,
		Computer,
		Player
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
		Object mouseComputer = new Object(Map.Computer);
		Object mousePlayer = new Object(Map.Player);
		Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		GameMode gameMode = GameMode.Player;
		bool gameOver = false;
		bool timerEnabled = false, keyboardEnabled = false;

		public Game()
		{
			InitializeComponent();
			SetDoubleBuffered(mazeTable); // dalgalanma sorunu için
			string json = File.ReadAllText(@"..\\..\\maps.json");
			mazeMaps = JsonConvert.DeserializeObject<int[,,]>(json);
			selectMaze(0);
		}

		int[,,] mazeMaps;
		int[,] mazeMap = new int[15, 24];
		int[,] steps = new int[15, 24];
		private Object findObject(Map mapItem)
		{
			Object obj = new Object(mapItem);
			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 24; j++)
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
		//ayar lazım
		private Map checkAround(Object mouse)
		{
			foreach (Direction direction in directions)
			{
				switch ((Map)mouse.check(mazeMap, direction))
				{
					case Map.Cheese:
						gameOver = true;
						return Map.Cheese;
				}
			}
			foreach (Direction direction in directions)
			{
				switch ((Map)mouse.check(mazeMap, direction))
				{
					case Map.Computer:
						return Map.Computer;
					case Map.Player:
						return Map.Player;
				}
			}
			return Map.Road;
		}
		private Direction findDirection(Object mouse)
		{
			float lowestAverage = 999999, average;
			int highestCount = 0, count;
			Direction bestDirection = Direction.None;
			bool first = true;
			Object temp = new Object(mouse.Id);
			//var mixedDirection = directions.OrderBy(a => Guid.NewGuid()).ToList();
			foreach (Direction direction in directions)
			{
				if (stepValidate(mouse, direction) && direction != mouse.BackDirection)
				{
					average = 0;
					temp.X = mouse.X;
					temp.Y = mouse.Y;
					for (count = 0; stepValidate(temp, direction); count++)
					{
						average += temp.check(steps, direction);
						temp.move(direction);
						first = false;
					}
					average /= count;
					if (average < lowestAverage && !first)
					{
						lowestAverage = average;
						bestDirection = direction;
					}
					if (average == lowestAverage && count > highestCount && !first)
					{
						highestCount = count;
						bestDirection = direction;
					}
				}
				if (direction == mouse.BackDirection && first)
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
			if (mouse.Id == Map.Computer)
				steps[mouse.X, mouse.Y]++;
			mouse.move(direction);
			mazeMap[mouse.X, mouse.Y] = (int)mouse.Id;
			mazeTable.Refresh();
			checkAround(mouse);
		}
		private bool stepValidate(Object mouse, Direction direction)
		{
			Map check = (Map)mouse.check(mazeMap, direction);
			if (check == Map.Wall || check == Map.Computer || check == Map.Player)
				return false;
			return true;
		}

		private void selectMaze(int n)
		{
			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 24; j++)
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
			if (check == Map.Computer)
				message = "kazanan computer " + mouseComputer.StepCount + " adımda bitirdi";
			if (check == Map.Player)
				message = "kazanan player " + mousePlayer.StepCount + " adımda bitirdi";
			resetGame();
			startButton.Enabled = false;
			MessageBox.Show(message);
		}

		public void resetGame()
		{
			update.Stop();
			selectMaze(mapSelect.SelectedIndex);
			startButton.Enabled = true;
			steps = new int[15, 24];
			gameOver = false;
			keyboardEnabled = false;
			timerEnabled = false;
			mouseComputer = findObject(Map.Computer);
			mousePlayer = findObject(Map.Player);
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
			}
		}
		private void Game_Load(object sender, EventArgs e)
		{
			mapSelect.SelectedIndex = 0;
			modeSelect.SelectedIndex = 0;

/*
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(mazeMaps, Formatting.Indented);
			File.WriteAllText(@"..\\..\\maps.json", output);*/


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
				step(mouseComputer, findDirection(mouseComputer));
			}
		}
		private void Game_KeyDown(object sender, KeyEventArgs e)
		{
			if (!gameOver && keyboardEnabled)
			{
				switch (e.KeyCode)
				{
					case Keys.W:
						step(mousePlayer, Direction.Up);
						break;
					case Keys.S:
						step(mousePlayer, Direction.Down);
						break;
					case Keys.A:
						step(mousePlayer, Direction.Left);
						break;
					case Keys.D:
						step(mousePlayer, Direction.Right);
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
			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 24; j++)
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

		private void Game_Leave(object sender, EventArgs e)
		{
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
