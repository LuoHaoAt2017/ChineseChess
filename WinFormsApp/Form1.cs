namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Button primary_btn = new Button();
        private Button default_btn = new Button();
        private Button addNewRowButton = new Button();
        private Button deleteRowButton = new Button();
        private Panel buttonPanel = new Panel();
        private DataGridView dataGridView = new DataGridView();

        public Form1()
        {
            InitializeComponent();
            //AddBtns();
            //InitForm();
        }

        public void InitForm()
        {
            Label label = new Label();
            label.Location = new Point(80, 160);
            label.Name = "label-1";
            label.Size = new Size(132, 80);
            this.Controls.Add(label);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            label.Text = "Start Position Information" + FormBorderStyle;
        }

        public void AddBtns()
        {
            primary_btn.Size = new Size(120, 40);
            primary_btn.Location = new Point(30, 30);
            primary_btn.Text = "变大一点";
            primary_btn.Click += new EventHandler(primary_btn_click);

            default_btn.Size = new Size(120, 40);
            default_btn.Location = new Point(90, 90);
            default_btn.Text = "变小一点";
            default_btn.Click += new EventHandler(default_btn_click);

            this.Controls.Add(primary_btn);
            this.Controls.Add(default_btn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 600);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addNewRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Location = new Point(100, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(buttonPanel);
        }

        private void SetupDataGridView()
        {

        }

        public void PopulateDataGridView()
        {

        }

        private void addNewRowButton_Click(object sender, EventHandler evt)
        {
            // this.dataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventHandler evt)
        {

        }

        private void primary_btn_click(object sender, EventArgs e)
        {
            if (this.ClientSize.Width >= 600)
            {
                MessageBox.Show("最大不能超过600");
            }
            else
            {
                this.ClientSize = new Size(this.ClientSize.Width + 10, this.ClientSize.Height + 10);
            }
        }

        private void default_btn_click(object sender, EventArgs e)
        {
            if (this.ClientSize.Width <= 240)
            {
                MessageBox.Show("最小不能超过160");
            }
            else
            {
                this.ClientSize = new Size(this.ClientSize.Width - 10, this.ClientSize.Height - 10);
            }
        }
    }
}

