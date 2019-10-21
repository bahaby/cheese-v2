namespace cheese_v2
{
	partial class Game
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.startButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.mapSelect = new System.Windows.Forms.ComboBox();
			this.selectMode = new System.Windows.Forms.ComboBox();
			this.mazeTable = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startButton.Location = new System.Drawing.Point(10, 629);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(185, 48);
			this.startButton.TabIndex = 1;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetButton.Location = new System.Drawing.Point(725, 629);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(185, 48);
			this.resetButton.TabIndex = 1;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			// 
			// mapSelect
			// 
			this.mapSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mapSelect.ForeColor = System.Drawing.SystemColors.MenuText;
			this.mapSelect.FormattingEnabled = true;
			this.mapSelect.IntegralHeight = false;
			this.mapSelect.ItemHeight = 16;
			this.mapSelect.Items.AddRange(new object[] {
            "map1",
            "map2",
            "map3"});
			this.mapSelect.Location = new System.Drawing.Point(207, 629);
			this.mapSelect.Margin = new System.Windows.Forms.Padding(0);
			this.mapSelect.Name = "mapSelect";
			this.mapSelect.Size = new System.Drawing.Size(173, 24);
			this.mapSelect.TabIndex = 2;
			this.mapSelect.Text = "Select Map";
			// 
			// selectMode
			// 
			this.selectMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.selectMode.ForeColor = System.Drawing.SystemColors.MenuText;
			this.selectMode.FormattingEnabled = true;
			this.selectMode.IntegralHeight = false;
			this.selectMode.ItemHeight = 16;
			this.selectMode.Items.AddRange(new object[] {
            "computer",
            "player vs computer",
            "player vs player"});
			this.selectMode.Location = new System.Drawing.Point(207, 653);
			this.selectMode.Margin = new System.Windows.Forms.Padding(0);
			this.selectMode.Name = "selectMode";
			this.selectMode.Size = new System.Drawing.Size(173, 24);
			this.selectMode.TabIndex = 2;
			this.selectMode.Text = "Select Mode";
			// 
			// mazeTable
			// 
			this.mazeTable.ColumnCount = 15;
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.Location = new System.Drawing.Point(10, 10);
			this.mazeTable.Margin = new System.Windows.Forms.Padding(0);
			this.mazeTable.Name = "mazeTable";
			this.mazeTable.RowCount = 10;
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.mazeTable.Size = new System.Drawing.Size(900, 600);
			this.mazeTable.TabIndex = 0;
			this.mazeTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.mazeTable_CellPaint);
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(920, 690);
			this.Controls.Add(this.selectMode);
			this.Controls.Add(this.mapSelect);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.mazeTable);
			this.Name = "Game";
			this.Text = "Game";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.ComboBox mapSelect;
		private System.Windows.Forms.ComboBox selectMode;
		private System.Windows.Forms.TableLayoutPanel mazeTable;
	}
}

