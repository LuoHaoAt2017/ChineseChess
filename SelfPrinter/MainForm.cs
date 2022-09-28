

using System.Windows.Forms;

namespace SelfPrinter
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage hospitalTab;
        private System.Windows.Forms.TabPage docotorTab;
        private System.Windows.Forms.TabPage nurseTab;
        private System.Windows.Forms.TabPage patientTab;

        public MainForm()
        {
            InitializeComponent();
            InitializeTabControl();
        }

        public void InitializeTabControl()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.hospitalTab = new System.Windows.Forms.TabPage("医院");
            this.docotorTab = new System.Windows.Forms.TabPage("医生");
            this.nurseTab = new System.Windows.Forms.TabPage("护士");
            this.patientTab = new System.Windows.Forms.TabPage("患者");
            this.tabControl.Size = new Size(600, 400);

            this.tabControl.Controls.Add(hospitalTab);
            this.tabControl.Controls.Add(docotorTab);
            this.tabControl.Controls.Add(nurseTab);
            this.tabControl.Controls.Add(patientTab);

            this.Controls.Add(this.tabControl);

            this.InitializeHospital();
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