using System.Drawing.Printing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Button primary_btn = new Button();
        private Button default_btn = new Button();

        public Form1()
        {
            InitializeComponent();
            TestImage();
		}

        private void TestImage()
        {
			// ¸ø´°ÌåÌí¼Ó±³¾°Í¼Æ¬
			Image back = Image.FromFile(GetImgPath("image/back.png"));
			this.BackgroundImage = back;
			this.BackgroundImageLayout = ImageLayout.Stretch;

			// ¸ø¿Ø¼þÌí¼Ó±³¾°Í¼Æ¬
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

