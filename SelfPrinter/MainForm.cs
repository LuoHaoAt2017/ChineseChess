

using System.Windows.Forms;

namespace SelfPrinter
{
    public partial class MainForm : Form
    {
        private TabControl tabControl;
        private TabPage hospitalTab;
        private TabPage docotorTab;
        private TabPage nurseTab;
        private TabPage patientTab;

        public MainForm()
        {
            InitializeComponent();
            InitializeTabControl();
        }

        public void InitializeTabControl()
        {
            this.tabControl = new TabControl();
            this.hospitalTab = new TabPage("医院");
            this.docotorTab = new TabPage("医生");
            this.nurseTab = new TabPage("护士");
            this.patientTab = new TabPage("患者");
            this.tabControl.Size = new Size(600, 400);

            this.tabControl.Controls.Add(hospitalTab);
            this.tabControl.Controls.Add(docotorTab);
            this.tabControl.Controls.Add(nurseTab);
            this.tabControl.Controls.Add(patientTab);

            this.Controls.Add(this.tabControl);

            this.InitializeHospital();
            this.InitializeDocotor();
        }
        /*
         * 医院页面
         * 
         */
        public void InitializeHospital()
        {
            // Button
            Button primaryBtn = new Button();  
            Button defaultBtn = new Button();
            primaryBtn.Text = "Primary";
            defaultBtn.Text = "Default";
            primaryBtn.Size = new Size(100, 40);
            defaultBtn.Size = new Size(100, 40);
            primaryBtn.BackColor = Color.Green;
            primaryBtn.ForeColor = Color.White;
            defaultBtn.BackColor = Color.Black;
            defaultBtn.ForeColor = Color.White;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = new Size(320, 100);
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.Controls.Add(primaryBtn);
            panel.Controls.Add(defaultBtn);
            
            // DataGridView 
            DataGridView grid = new DataGridView();
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font,FontStyle.Bold);
            grid.MultiSelect = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.GridColor = Color.Black;
            grid.Size = new Size(5 * 80, 32 * 10);
            string[] columns = { "Name", "Count", "Created", "Updated", "Action" };
            grid.ColumnCount = columns.Length;
            for(int i = 0; i < columns.Length; i++)
            {
                grid.Columns[i].Name = columns[i];
                grid.Columns[i].DisplayIndex = i;
                grid.Columns[i].DefaultCellStyle.Font = new Font(grid.DefaultCellStyle.Font, FontStyle.Italic);
            }
            for(int i = 0; i < 9; i++)
            {
                Random rdm = new Random();
                grid.Rows.Add(rdm.Next(), rdm.Next(), rdm.Next(), rdm.Next(), rdm.Next());
            }
            this.hospitalTab.Controls.Add(grid);
            this.hospitalTab.Controls.Add(panel);
        }
        /*
         * 医生页面
         * 
         */
        public void InitializeDocotor()
        {
            FlowLayoutPanel btnLayout = new FlowLayoutPanel();
            btnLayout.FlowDirection = FlowDirection.LeftToRight;
            btnLayout.AutoSize = true; // FlowLayoutPanel 根据其内容自动调整大小。
            btnLayout.BorderStyle = BorderStyle.FixedSingle;
            string[] texts = { "东风", "西风", "南风", "北风", "东南风", "西北风", "东北风", "西南风" };
            for(int i = 0; i < texts.Length; i++)
            {
                Button button = new Button();
                button.Cursor = Cursors.Hand;
                button.Padding = new Padding(10, 5, 10, 5);
                button.Text = texts[i];
                button.AutoSize = true;
                btnLayout.Controls.Add(button);
            }
            this.docotorTab.Controls.Add(btnLayout);

            CheckedListBox checkedList = new CheckedListBox();
            checkedList.Location = new Point(0, 150);
            checkedList.AutoSize = true;
            checkedList.CheckOnClick = true;
            // ItemCheckEventHandler 是委托
            checkedList.ItemCheck += new ItemCheckEventHandler(this.OnItemCheck);
            for (int j = 0; j < texts.Length; j++)
            {
                checkedList.Items.Add(texts[j], false);
            }
            this.docotorTab.Controls.Add(checkedList);
            this.docotorTab.AutoScroll = true;
        }

        public void OnItemCheck(object? sender, ItemCheckEventArgs args)
        {
            
            if (args.NewValue == CheckState.Checked && args.CurrentValue == CheckState.Unchecked)
            {
                Console.WriteLine("正选");
            } else
            {
                Console.WriteLine("反选");
            }
        }
        /*
         * 护士页面
         * 
         */
        public void InitializeNurse()
        {
        }
        /*
         * 患者页面
         * 
         */
        public void InitializePatient()
        {
        }
    }
}