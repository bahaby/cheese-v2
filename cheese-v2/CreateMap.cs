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
	public partial class CreateMap : Form
	{
		public CreateMap()
		{
			InitializeComponent();
			SetDoubleBuffered(mazeTable);
			int [,] mazeMap = {
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 4, 1, 0, 0, 0, 1, 0, 1},
				{ 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1},
				{ 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1},
				{ 1, 0, 0, 0, 0, 1, 0, 0, 2, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
				{ 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
				{ 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1},
				{ 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
				{ 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1},
				{ 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 1},
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
			};
			MazeMap = mazeMap;
		}
		public int[,] MazeMap { get; set; }
		//resim dosyalarını ekleme
		Image mouseImage1 = Properties.Resources.mouse1;
		Image mouseImage2 = Properties.Resources.mouse2;
		Image wallImage = Properties.Resources.wall;
		Image groundImage = Properties.Resources.ground;
		Image cheeseImage = Properties.Resources.cheese;
		private void mazeTable_MouseClick(object sender, MouseEventArgs e)
		{
			var pt = new Point(e.X, e.Y);

			var colWidths = this.mazeTable.GetColumnWidths();
			var rowHeights = this.mazeTable.GetRowHeights();

			int col = -1, row = -1;
			int offset = 0;
			for (int iCol = 0; iCol < this.mazeTable.ColumnCount; ++iCol)
			{
				if (pt.X >= offset && pt.X <= (offset + colWidths[iCol]))
				{
					col = iCol;
					break;
				}

				offset += colWidths[iCol];
			}

			offset = 0;
			for (int iRow = 0; iRow < this.mazeTable.RowCount; ++iRow)
			{
				if (pt.Y >= offset && pt.Y <= (offset + rowHeights[iRow]))
				{
					row = iRow;
					break;
				}

				offset += rowHeights[iRow];
			}
			MazeMap[row, col]++;
			MazeMap[row, col] %= 5;
			mazeTable.Refresh();
		}
		
		private void mazeTable_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 24; j++)
				{
					if (e.Column == j && e.Row == i)
					{
						switch (MazeMap[i, j])
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
