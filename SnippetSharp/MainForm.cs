﻿using Microsoft.Win32;
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

        private BindingSource _jobBS = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetSharp");
            string lastDb = key.GetValue("lastDb", "").ToString();
            if (!String.IsNullOrEmpty(lastDb) && File.Exists(lastDb))
            {
                // load the database we used before
                try
                {
                    _dataBase.ReadXml(lastDb);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cannot find file {lastDb}.");
                    CreateDatabase();
                }
            }
            else
            {
                CreateDatabase();
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
            _categoryTable.Columns["CategoryId"].AutoIncrementSeed = 1;
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
            _snippetTable.Columns["SnippetId"].AutoIncrementSeed = 100;
            _snippetTable.Columns["SnippetId"].AutoIncrementStep = 3;
            _dataBase.Tables.Add(_snippetTable);

            // Set table relations
            _dataBase.Relations.Add("CategoryJob", _categoryTable.Columns["CategoryId"], _snippetTable.Columns["CategoryId"]);
            _dataBase.Relations["CategoryJob"].Nested = true;

            // Create a binding source and set it as a datasource for our grid
            _categoryBS = new BindingSource();
            _categoryBS.DataSource = _categoryTable;
            dgvCategory.DataSource = _categoryBS;

            _jobBS = new BindingSource();
            _jobBS.DataSource = _snippetTable;
            dgvDetail.DataSource = _jobBS;

            // set RTB data binding
            richTextBox1.DataBindings.Add("Text", _jobBS, "CodeSnippet");

            // filter jobs according to the category
            _categoryBS.CurrentChanged += _categoryBS_CurrentChanged;

            // make grids faster
            SetGridDoubleBufferingOn(dgvCategory);
            SetGridDoubleBufferingOn(dgvDetail);
        }

        private void _categoryBS_CurrentChanged(object sender, EventArgs e)
        {
            if (_categoryBS.Current == null)
                _jobBS.Filter = "";
            else
                _jobBS.Filter = "CategoryId=" + (_categoryBS.Current as DataRowView).Row["CategoryId"];
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = stayOnTopToolStripMenuItem.Checked;
        }

        private void NewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDatabase();
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
            using (SaveFileDialog sd = new SaveFileDialog())
            {
                sd.Filter = "XML files (*.xml)|*.xml";
                var res = sd.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _dataBase.WriteXml(sd.FileName);
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SnippetSharp");
                    key.SetValue("lastDb", sd.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_categoryBS.Current == null)
                return;

            var row = (DataRowView)_jobBS.AddNew();
            row["CategoryID"] = (_categoryBS.Current as DataRowView).Row["CategoryID"];
            row["DateCreated"] = DateTime.Now;
        }

        private void yeniKategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = (DataRowView)_categoryBS.AddNew();
            row["DateCreated"] = DateTime.Now;
        }
    }
}