namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Button primary_btn = new Button();
        public Button default_btn = new Button();

        public Form1()
        {
            InitializeComponent();

            primary_btn.Size = new Size(120, 40);
            primary_btn.Location = new Point(30, 30);
            primary_btn.Text = "Click Me";
            primary_btn.Click += new EventHandler(primary_btn_click);

            default_btn.Size = new Size(120, 40);
            default_btn.Location = new Point(90, 90);
            default_btn.Text = "Click Me";
            default_btn.Click += new EventHandler(default_btn_click);

            this.Controls.Add(primary_btn);
            this.Controls.Add(default_btn);
        }

        private void primary_btn_click(object sender, EventArgs args)
        {
            MessageBox.Show("Hello World for primary btn");
        }

        private void default_btn_click(object sender, EventArgs args)
        {
            MessageBox.Show("Hello World for default btn");
        }
    }
}

