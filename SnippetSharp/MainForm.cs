using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SnippetSharp
{
    public partial class MainForm : Form
    {
        // we are using the dataset as our database
        private DataSet _dataBase = null;

        // category table and the binding source
        private DataTable _categoryTable = null;

        private BindingSource _categoryBS = null;

        // jobs table and the binding source
        private DataTable _snippetTable = null;

        private BindingSource _snippetBS = null;
        private string _lastDb;
        private readonly NotifyIcon _notifyIcon = null;

        public MainForm()
        {
            InitializeComponent();
            _notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.items1,

                Visible = true,
                Text = "Snippets",
                ContextMenu = new ContextMenu(new MenuItem[]
               {
                    new MenuItem("Exit", exitToolStripMenuItem_Click)
               })
            };
            _notifyIcon.DoubleClick += (object sender, EventArgs e) =>
            {
                if (WindowState == FormWindowState.Minimized)
                    WindowState = FormWindowState.Normal;
            };
            Icon = Properties.Resources.items1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetSharp");
            string lastDb = key.GetValue("lastDb", "").ToString();
            CreateDatabase();
            if (!String.IsNullOrEmpty(lastDb) && File.Exists(lastDb))
            {
                // load the database we used before
                try
                {
                    _dataBase.ReadXml(lastDb);
                    _lastDb = lastDb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cannot find file {lastDb}.");
                }
            }
        }

        private void CreateDatabase()
        {
            // Create a dataset to hold our database in memory
            _dataBase = new DataSet("JobsDatabase");

            // Create a category table
            _categoryTable = new DataTable("Categories");
            _categoryTable.Columns.Add(new DataColumn("CategoryId", typeof(Int32)));
            _categoryTable.Columns.Add(new DataColumn("CategoryName", typeof(string)));
            _categoryTable.Columns.Add(new DataColumn("DateCreated", typeof(DateTime)));
            // Set the primary key
            _categoryTable.PrimaryKey = new DataColumn[] { _categoryTable.Columns["CategoryId"] };
            // Make it autoincrement, 1 by 1
            _categoryTable.Columns["CategoryId"].AutoIncrement = true;
            _categoryTable.Columns["CategoryId"].AutoIncrementSeed = 2;
            _categoryTable.Columns["CategoryId"].AutoIncrementStep = 2;
            // Add the table to the database
            _dataBase.Tables.Add(_categoryTable);

            _snippetTable = new DataTable("Snippets");
            _snippetTable.Columns.Add(new DataColumn("SnippetId", typeof(Int32)));
            _snippetTable.Columns.Add(new DataColumn("CategoryId", typeof(Int32)));
            _snippetTable.Columns.Add(new DataColumn("Description", typeof(string)));
            _snippetTable.Columns.Add(new DataColumn("DateCreated", typeof(DateTime)));
            _snippetTable.Columns.Add(new DataColumn("CodeSnippet", typeof(string)));
            _snippetTable.PrimaryKey = new DataColumn[] { _snippetTable.Columns["SnippetId"] };

            // Fantasize with auto increment seed, starts from 100, increases 3 by 3
            _snippetTable.Columns["SnippetId"].AutoIncrement = true;
            _snippetTable.Columns["SnippetId"].AutoIncrementSeed = 101;
            _snippetTable.Columns["SnippetId"].AutoIncrementStep = 2;
            _dataBase.Tables.Add(_snippetTable);

            // Set table relations
            _dataBase.Relations.Add("CategoryJob", _categoryTable.Columns["CategoryId"], _snippetTable.Columns["CategoryId"]);
            _dataBase.Relations["CategoryJob"].Nested = true;

            // Create a binding source and set it as a datasource for our grid
            _categoryBS = new BindingSource();
            _categoryBS.DataSource = _categoryTable;
            dgvCategory.DataSource = _categoryBS;

            _snippetBS = new BindingSource();
            _snippetBS.DataSource = _snippetTable;
            dgvDetail.AutoGenerateColumns = false;
            dgvDetail.DataSource = _snippetBS;

            // set RTB data binding
            reSnippet.DataBindings.Add("Text", _snippetBS, "CodeSnippet");

            // filter jobs according to the category
            _categoryBS.CurrentChanged += _categoryBS_CurrentChanged;

            // make grids faster
            SetGridDoubleBufferingOn(dgvCategory);
            SetGridDoubleBufferingOn(dgvDetail);
        }

        private void _categoryBS_CurrentChanged(object sender, EventArgs e)
        {
            string filterText = "";
            if (_categoryBS.Current == null)
                _snippetBS.Filter = filterText;
            else
            {
                filterText = "CategoryId=" + (_categoryBS.Current as DataRowView).Row["CategoryId"];

                if (!String.IsNullOrEmpty(textBoxSearch.Text))
                    filterText += $" and Description LIKE '%{textBoxSearch.Text}%'";
                _snippetBS.Filter = filterText;
            }
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = stayOnTopToolStripMenuItem.Checked;
        }

        private void NewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _snippetTable.Clear();
            _categoryTable.Clear();
        }

        private void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog od = new OpenFileDialog())
            {
                od.Filter = "XML files (*.xml)|*.xml";
                var res = od.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _dataBase.ReadXml(od.FileName);
                    _lastDb = od.FileName;
                }
            }
        }

        public void SetGridDoubleBufferingOn(DataGridView dgv)
        {
            // Double buffering can make DGV slow in remote desktop
            if (!SystemInformation.TerminalServerSession)
            {
                typeof(DataGridView).InvokeMember(
                   "DoubleBuffered",
                   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                   null,
                   dgv,
                   new object[] { true });
            }
        }

        private void SaveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvCategory.EndEdit();
            dgvDetail.EndEdit();
            dgvDetail.Focus();
            using (SaveFileDialog sd = new SaveFileDialog())
            {
                sd.Filter = "XML files (*.xml)|*.xml";
                var res = sd.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _dataBase.WriteXml(sd.FileName);
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetSharp");
                    key.SetValue("lastDb", sd.FileName);
                    _lastDb = sd.FileName;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_categoryBS.Current == null)
                return;

            var row = (DataRowView)_snippetBS.AddNew();
            row["CategoryID"] = (_categoryBS.Current as DataRowView).Row["CategoryID"];
            row["DateCreated"] = DateTime.Now;
        }

        private void yeniKategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = (DataRowView)_categoryBS.AddNew();
            row["DateCreated"] = DateTime.Now;
        }

        private void saveDatabaseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgvCategory.EndEdit();
            dgvDetail.EndEdit();
            dgvDetail.Focus();
            Application.DoEvents();
            _dataBase.WriteXml(_lastDb);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall))
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _categoryBS_CurrentChanged(sender, e);
        }
    }
}