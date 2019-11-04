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
			this.components = new System.ComponentModel.Container();
			this.startButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.mapSelect = new System.Windows.Forms.ComboBox();
			this.modeSelect = new System.Windows.Forms.ComboBox();
			this.mazeTable = new System.Windows.Forms.TableLayoutPanel();
			this.update = new System.Windows.Forms.Timer(this.components);
			this.show = new System.Windows.Forms.Label();
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
			this.resetButton.Location = new System.Drawing.Point(785, 629);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(185, 48);
			this.resetButton.TabIndex = 1;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// mapSelect
			// 
			this.mapSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.mapSelect.Tag = "";
			this.mapSelect.SelectedIndexChanged += new System.EventHandler(this.mapSelect_SelectedIndexChanged);
			// 
			// modeSelect
			// 
			this.modeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.modeSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.modeSelect.ForeColor = System.Drawing.SystemColors.MenuText;
			this.modeSelect.FormattingEnabled = true;
			this.modeSelect.IntegralHeight = false;
			this.modeSelect.ItemHeight = 16;
			this.modeSelect.Items.AddRange(new object[] {
            "player",
            "computer",
            "player vs computer",
            "player vs player"});
			this.modeSelect.Location = new System.Drawing.Point(207, 653);
			this.modeSelect.Margin = new System.Windows.Forms.Padding(0);
			this.modeSelect.Name = "modeSelect";
			this.modeSelect.Size = new System.Drawing.Size(173, 24);
			this.modeSelect.TabIndex = 2;
			this.modeSelect.SelectedIndexChanged += new System.EventHandler(this.modeSelect_SelectedIndexChanged);
			// 
			// mazeTable
			// 
			this.mazeTable.ColumnCount = 24;
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.Location = new System.Drawing.Point(10, 10);
			this.mazeTable.Margin = new System.Windows.Forms.Padding(0);
			this.mazeTable.Name = "mazeTable";
			this.mazeTable.RowCount = 15;
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mazeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mazeTable.Size = new System.Drawing.Size(960, 600);
			this.mazeTable.TabIndex = 0;
			this.mazeTable.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.mazeTable_CellPaint);
			// 
			// update
			// 
			this.update.Interval = 50;
			this.update.Tick += new System.EventHandler(this.update_Tick);
			// 
			// show
			// 
			this.show.Location = new System.Drawing.Point(547, 653);
			this.show.Name = "show";
			this.show.Size = new System.Drawing.Size(100, 23);
			this.show.TabIndex = 3;
			this.show.Text = "average";
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(975, 689);
			this.Controls.Add(this.show);
			this.Controls.Add(this.modeSelect);
			this.Controls.Add(this.mapSelect);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.mazeTable);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Game";
			this.Text = "Game";
			this.Load += new System.EventHandler(this.Game_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.ComboBox mapSelect;
		private System.Windows.Forms.ComboBox modeSelect;
		private System.Windows.Forms.TableLayoutPanel mazeTable;
		private System.Windows.Forms.Timer update;
		private System.Windows.Forms.Label show;
	}
}

