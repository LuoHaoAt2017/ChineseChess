using ChineseChess.Helpers;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ChineseChess
{
	public enum Role
	{
		General, Premier, Guard, Horse, Chariot, Gun, Soldier
	}

	public struct Location
	{
		public int rowPos;

		public int colPos;

		private int CellSize = 80;

		public Location(int rowIndex, int colIndex)
		{
			rowPos = rowIndex * CellSize;
			colPos = colIndex * CellSize;
		}
	}

	public struct Option
	{
		public string name;
		public Role role;

		public Option(string name, Role role)
		{
			this.name = name;
			this.role = role;
		}
	}

	public partial class ChessGame : Form
	{
		private Button primary_btn = new Button();
		private Button default_btn = new Button();
		private int ClientW = 900;
		private int ClientH = 900;
		private int RowCount = 9;
		private int ColCount = 8;
		private int CellSize = 80;
		private int delta = 80 / 2;
		private Panel panel = new Panel();
		public ChessGame()
		{
			InitializeComponent();
			InitializeBackground();
			InitializeChessboard();
		}

		private void InitializeBackground()
		{
			LogHelper.Info("================================InitializeBackground======================================");
		}

		/*
         * 绘制一张十行九列的棋盘
         */
		private void InitializeChessboard()
		{
			int W = this.ColCount * this.CellSize + CellSize;
			int H = this.RowCount * this.CellSize + CellSize;
			int px = (this.ClientW - W) / 2, py = (this.ClientH - H) / 2;
			panel.Size = new Size(W, H);
			panel.Location = new Point(px, py);
			panel.BackColor = Color.Black;
			panel.ForeColor = Color.White;
			panel.Paint += new PaintEventHandler(this.DrawChessboard);
			panel.Paint += new PaintEventHandler(this.DrawChessPiece);
			this.Controls.Add(panel);
		}

		private void DrawChessboard(object? sender, PaintEventArgs e)
		{
			if (sender == null)
			{
				throw new ArgumentNullException("sender 不存在");
			}
			int W = this.ColCount * this.CellSize;
			int H = this.RowCount * this.CellSize;
			Graphics ctx = e.Graphics;
			Pen pen = new Pen(Color.White, 1);
			
			// 横向线
			for (int i = 0; i < RowCount; i++)
			{
				ctx.DrawLine(pen, new Point(0 + delta, i * CellSize + delta), new Point(W + delta, i * CellSize + delta));
			}
			// 纵向线
			for (int j = 0; j < ColCount; j++)
			{
				ctx.DrawLine(pen, new Point(j * CellSize + delta, 0 + delta), new Point(j * CellSize + delta, 4 * CellSize + delta));
				ctx.DrawLine(pen, new Point(j * CellSize + delta, 5 * CellSize + delta), new Point(j * CellSize + delta, H + delta));
			}
			// 斜向线
			Point p1 = new Point(3 * CellSize + delta, 0 + delta);
			Point p2 = new Point(5 * CellSize + delta, 2 * CellSize + delta);
			Point p3 = new Point(3 * CellSize + delta, 2 * CellSize + delta);
			Point p4 = new Point(5 * CellSize + delta, 0 + delta);
			Point p5 = new Point(3 * CellSize + delta, 7 * CellSize + delta);
			Point p6 = new Point(5 * CellSize + delta, 9 * CellSize + delta);
			Point p7 = new Point(3 * CellSize + delta, 9 * CellSize + delta);
			Point p8 = new Point(5 * CellSize + delta, 7 * CellSize + delta);
			ctx.DrawLine(pen, p1, p2);
			ctx.DrawLine(pen, p3, p4);
			ctx.DrawLine(pen, p5, p6);
			ctx.DrawLine(pen, p7, p8);
			// 边线
			Point topLeft = new Point(0 + delta, 0 + delta);
			Point topRight = new Point(W + delta, 0 + delta);
			Point bottomLeft = new Point(0 + delta, H + delta);
			Point bottomRight = new Point(W + delta, H + delta);
			ctx.DrawLine(pen, topLeft, topRight);
			ctx.DrawLine(pen, bottomLeft, bottomRight);
			ctx.DrawLine(pen, topLeft, bottomLeft);
			ctx.DrawLine(pen, topRight, bottomRight);
			// 楚河汉界
			FontFamily fontFamily = new FontFamily("Arial");
			Brush brush = new SolidBrush(Color.White);
			Font font = new Font(fontFamily, 24, FontStyle.Bold);
			ctx.DrawString("楚", font, brush, new PointF(1.25f * CellSize + delta, 4.25f * CellSize + delta));
			ctx.DrawString("河", font, brush, new PointF(2.25f * CellSize + delta, 4.25f * CellSize + delta));
			ctx.DrawString("汉", font, brush, new PointF(5.25f * CellSize + delta, 4.25f * CellSize + delta));
			ctx.DrawString("界", font, brush, new PointF(6.25f * CellSize + delta, 4.25f * CellSize + delta));
			// 十字花
			Point[] points = new Point[]
			{
				new Point(1 * CellSize, 2 * CellSize),
				new Point(0 * CellSize, 3 * CellSize),
				new Point(2 * CellSize, 3 * CellSize),
				new Point(4 * CellSize, 3 * CellSize),
				new Point(1 * CellSize, 7 * CellSize),
				new Point(0 * CellSize, 6 * CellSize),
				new Point(2 * CellSize, 6 * CellSize),
				new Point(7 * CellSize, 2 * CellSize),
				new Point(6 * CellSize, 3 * CellSize),
				new Point(8 * CellSize, 3 * CellSize),
				new Point(4 * CellSize, 6 * CellSize),
				new Point(7 * CellSize, 7 * CellSize),
				new Point(6 * CellSize, 6 * CellSize),
				new Point(8 * CellSize, 6 * CellSize),
			};
			for (int i = 0; i < points.Length; i++)
			{
				int cell = CellSize / 2;
				int px = points[i].X + delta;
				int py = points[i].Y + delta;
				if (points[i].X == 0)
				{
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px + cell / 5, py - cell / 2),
						new PointF(px + cell / 4, py - cell / 4),
						new PointF(px + cell / 2, py - cell / 5),
					});
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px + cell / 5, py + cell / 2),
						new PointF(px + cell / 4, py + cell / 4),
						new PointF(px + cell / 2, py + cell / 5),
					});
				}
				else if (points[i].X == 8 * CellSize)
				{
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px - cell / 5, py - cell / 2),
						new PointF(px - cell / 4, py - cell / 4),
						new PointF(px - cell / 2, py - cell / 5),
					});
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px - cell / 5, py + cell / 2),
						new PointF(px - cell / 4, py + cell / 4),
						new PointF(px - cell / 2, py + cell / 5),
					});
				} 
				else
				{
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px - cell / 5, py - cell / 2),
						new PointF(px - cell / 4, py - cell / 4),
						new PointF(px - cell / 2, py - cell / 5),
					});
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px + cell / 5, py - cell / 2),
						new PointF(px + cell / 4, py - cell / 4),
						new PointF(px + cell / 2, py - cell / 5),
					});
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px - cell / 5, py + cell / 2),
						new PointF(px - cell / 4, py + cell / 4),
						new PointF(px - cell / 2, py + cell / 5),
					});
					ctx.DrawCurve(pen, new PointF[3]
					{
						new PointF(px + cell / 5, py + cell / 2),
						new PointF(px + cell / 4, py + cell / 4),
						new PointF(px + cell / 2, py + cell / 5),
					});
				}
			}
		}

		private void DrawChessPiece(object? sender, PaintEventArgs e)
		{
			if (sender == null)
			{
				throw new ArgumentNullException("sender 不存在");
			}
			Graphics ctx = e.Graphics;
			Pen pen = new Pen(Color.White, 1);

			Random random = new Random();
			List<Chess> chuChessList = new List<Chess>(16);
			List<Chess> hanChessList = new List<Chess>(16);
			List<Option> chesses = new List<Option>()
			{
				new Option(name: "车", role: Role.Chariot),
				new Option(name: "马", role: Role.Horse),
				new Option(name: "相", role: Role.Premier),
				new Option(name: "士", role: Role.Guard),
				new Option(name: "将", role: Role.General),
				new Option(name: "士", role: Role.Guard),
				new Option(name: "相", role: Role.Premier),
				new Option(name: "马", role: Role.Horse),
				new Option(name: "车", role: Role.Chariot),
			};
			for(int index = 0; index < chesses.Count; index++)
			{
				Option chess = chesses[index];
				Chess chuChess = new Chess(random.Next().ToString(), chess.name, chess.role, Color.Green);
				Chess hanChess = new Chess(random.Next().ToString(), chess.name, chess.role, Color.Orange);
				chuChess.Position = new Location(rowIndex: 0, colIndex: index);
				hanChess.Position = new Location(rowIndex: 9, colIndex: index);
				chuChessList.Add(chuChess);
				hanChessList.Add(hanChess);
			}

			Font font = new Font(new FontFamily("Arial"), 16, FontStyle.Bold);
			foreach (var chess in chuChessList)
			{
				float px = chess.Position.colPos - CellSize / 4 + delta;
				float py = chess.Position.rowPos - CellSize / 4 + delta;
				float width = CellSize / 2;
				float height = CellSize / 2;
				PointF point = new PointF(px + CellSize / 16, py + CellSize / 8);
				ctx.FillPie(new SolidBrush(Color.White), px, py, width, height, 0, 360);
				ctx.DrawString(chess.Name, font, new SolidBrush(chess.Color), point);
			}
			foreach (var chess in hanChessList)
			{
				float px = chess.Position.colPos - CellSize / 4 + delta;
				float py = chess.Position.rowPos - CellSize / 4 + delta;
				float width = CellSize / 2;
				float height = CellSize / 2;
				PointF point = new PointF(px + CellSize / 16, py + CellSize / 8);
				ctx.FillPie(new SolidBrush(Color.White), px, py, width, height, 0, 360);
				ctx.DrawString(chess.Name, font, new SolidBrush(chess.Color), point);
			}
			ctx.Dispose();
		}

		/*
         * 容器和布局
         * 表格布局：TableLayoutPanel
         */
		private void TestLayout()
		{
			int N = 9;
			TableLayoutPanel panel = new TableLayoutPanel();
			Button[] buttons = new Button[N];
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i] = new Button();
			}
		}

		private void TestImage()
		{
			// 给窗体添加背景图片
			Image back = Image.FromFile(GetImgPath("image/back.png"));
			this.BackgroundImage = back;
			this.BackgroundImageLayout = ImageLayout.Stretch;

			// 给控件添加背景图片
			Image image = Image.FromFile(GetImgPath("image/logo.png"));
			PictureBox pictureBox = new PictureBox();
			pictureBox.Size = new Size(800, 200);
			pictureBox.BorderStyle = BorderStyle.FixedSingle;
			pictureBox.Image = image;
			pictureBox.BackgroundImageLayout = ImageLayout.Center;
			this.Controls.Add(pictureBox);
		}

		private void TestPanel()
		{

		}

		private void TestDock()
		{
			TextBox textBox = new TextBox();
			textBox.Location = new Point(15, 15);
			textBox.Margin = new Padding(4, 4, 4, 4);

			GroupBox groupBox1 = new GroupBox();
			groupBox1.Enabled = true;
			groupBox1.Text = "Group Box 10";
			groupBox1.Dock = DockStyle.Top;

			GroupBox groupBox11 = new GroupBox();
			groupBox11.Enabled = true;
			groupBox11.Text = "Group Box 11";
			groupBox11.Dock = DockStyle.Top;

			GroupBox groupBox2 = new GroupBox();
			groupBox2.Enabled = true;
			groupBox2.Text = "Group Box 2";
			groupBox2.Dock = DockStyle.Bottom;

			GroupBox groupBox3 = new GroupBox();
			groupBox3.Enabled = true;
			groupBox3.Text = "Group Box 3";
			groupBox3.Dock = DockStyle.Left;

			GroupBox groupBox4 = new GroupBox();
			groupBox4.Enabled = true;
			groupBox4.Text = "Group Box 4";
			groupBox4.Dock = DockStyle.Right;

			GroupBox groupBox41 = new GroupBox();
			groupBox41.Enabled = true;
			groupBox41.Text = "Group Box 41";
			groupBox41.Dock = DockStyle.Right;

			GroupBox groupBox5 = new GroupBox();
			groupBox5.Enabled = true;
			groupBox5.Text = "Group Box 5";
			groupBox5.Dock = DockStyle.Fill;

			//groupBox1.Controls.Add(textBox);
			//groupBox2.Controls.Add(textBox);
			//groupBox3.Controls.Add(textBox);
			//groupBox4.Controls.Add(textBox);
			//groupBox5.Controls.Add(textBox);

			this.Controls.Add(groupBox1);
			this.Controls.Add(groupBox11);
			this.Controls.Add(groupBox2);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox4);
			this.Controls.Add(groupBox41);
			this.Controls.Add(groupBox5);
		}

		private void TestAnchor()
		{
			GroupBox groupBox1 = new GroupBox();
			groupBox1.Text = "Group Box 1";
			groupBox1.Anchor = AnchorStyles.Top;

			GroupBox groupBox2 = new GroupBox();
			groupBox2.Text = "Group Box 2";
			groupBox2.Anchor = AnchorStyles.Bottom;

			GroupBox groupBox3 = new GroupBox();
			groupBox3.Text = "Group Box 3";
			groupBox3.Anchor = AnchorStyles.Left;

			GroupBox groupBox4 = new GroupBox();
			groupBox4.Text = "Group Box 4";
			groupBox4.Anchor = AnchorStyles.Right;

			GroupBox groupBox5 = new GroupBox();
			groupBox5.Text = "Group Box 5";
			groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left;

			GroupBox groupBox6 = new GroupBox();
			groupBox6.Text = "Group Box 6";
			groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;

			GroupBox groupBox7 = new GroupBox();
			groupBox7.Text = "Group Box 7";
			groupBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

			GroupBox groupBox8 = new GroupBox();
			groupBox8.Text = "Group Box 8";
			groupBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			GroupBox groupBox9 = new GroupBox();
			groupBox9.Text = "Group Box 9";
			groupBox9.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			groupBox9.AutoSizeMode = AutoSizeMode.GrowAndShrink;

			this.Controls.Add(groupBox1);
			this.Controls.Add(groupBox2);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox4);
			this.Controls.Add(groupBox5);
			this.Controls.Add(groupBox6);
			this.Controls.Add(groupBox7);
			this.Controls.Add(groupBox8);
			this.Controls.Add(groupBox9);
		}

		private void ResizeWindow()
		{
			primary_btn.Size = new Size(120, 40);
			primary_btn.Location = new Point(30, 30);
			primary_btn.Text = "PrimaryBtn";
			primary_btn.Click += new EventHandler(PrimaryBtnClick);

			default_btn.Size = new Size(120, 40);
			default_btn.Location = new Point(90, 90);
			default_btn.Text = "DefaultBtn";
			default_btn.Click += new EventHandler(DefaultBtnClick);

			this.Controls.Add(primary_btn);
			this.Controls.Add(default_btn);
		}

		private void PrimaryBtnClick(object sender, EventArgs e)
		{
			if (this.ClientSize.Width >= 600)
			{
				MessageBox.Show("Width <= 600");
			}
			else
			{
				this.ClientSize = new Size(this.ClientSize.Width + 10, this.ClientSize.Height + 10);
			}
		}

		private void DefaultBtnClick(object sender, EventArgs e)
		{
			if (this.ClientSize.Width <= 240)
			{
				MessageBox.Show("Width <= 240");
			}
			else
			{
				this.ClientSize = new Size(this.ClientSize.Width - 10, this.ClientSize.Height - 10);
			}
		}

		private string GetImgPath(string path)
		{
			// D:\github\hello-window-form\WinFormsApp\bin\Debug\net6.0-windows\
			return AppDomain.CurrentDomain.BaseDirectory + path;
		}
	}
}

