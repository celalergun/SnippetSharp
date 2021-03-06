﻿using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
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

        // Snippets table and the binding source
        private DataTable _snippetTable = null;

        private BindingSource _snippetBS = null;
        private string _lastDb;
        private readonly NotifyIcon _notifyIcon = null;

        private string _exeName = Assembly.GetExecutingAssembly().Location;

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
            runAtStartupToolStripMenuItem.Checked = IsSetToRunAtStartUp();
        }

        private void CreateDatabase()
        {
            // Create a dataset to hold our database in memory
            _dataBase = new DataSet("SnippetsDatabase");

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
            _dataBase.Relations.Add("CategorySnippet", _categoryTable.Columns["CategoryId"], _snippetTable.Columns["CategoryId"]);
            _dataBase.Relations["CategorySnippet"].Nested = true;

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

            // filter Snippets according to the category
            _categoryBS.CurrentChanged += _categoryBS_CurrentChanged;

            // make grids faster
            SetGridDoubleBufferingOn(dgvCategory);
            SetGridDoubleBufferingOn(dgvDetail);
        }

        private void _categoryBS_CurrentChanged(object sender, EventArgs e)
        {
            string filterText = "";
            //check to see if there is any Category selected...
            if (_categoryBS.Current == null)
            {
                _snippetBS.Filter = filterText;
                EnableOrDisableUIItems(enabled: false);
            }
            else
            {
                EnableOrDisableUIItems(enabled: true);
                filterText = "CategoryId=" + (_categoryBS.Current as DataRowView).Row["CategoryId"];

                if (!String.IsNullOrEmpty(textBoxSearch.Text))
                    filterText += $" and Description LIKE '%{textBoxSearch.Text}%'";
                _snippetBS.Filter = filterText;
            }
        }

        private void EnableOrDisableUIItems(bool enabled)
        {
            dgvDetail.Enabled = enabled;
            textBoxSearch.Enabled = enabled;
            reSnippet.Enabled = enabled;
            newSnippetToolStripMenuItem.Enabled = enabled;
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

        private void newSnippetToolStripMenuItem_Click(object sender, EventArgs e)
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
            // force dataGridView controls to commit their changes into dataset
            dgvCategory.EndEdit();
            dgvDetail.EndEdit();
            // this is a little hack to commit changes in the rich text control
            // rich text control updates its properties when it loses focus
            // so we are focusing to something else :)
            dgvDetail.Focus();
            Application.DoEvents();
            _dataBase.WriteXml(_lastDb);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if Windows is shutting down or user clicked on the exit menu item(s)
            if (!(e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall))
            {
                // minimize the form if the user clicked on the X button, pressed Alt+F4 etc.
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _categoryBS_CurrentChanged(sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reSnippet.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pasting clipboard content into the richedit control.
            // first we will count the space characters from the beginning of every line to trim the spaces
            // from the beginning of the lines to keep the indentation
            string clp = Clipboard.GetText();
            string[] lines = clp.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int minSpaces = Int32.MaxValue;
            for (int j = 0; j < lines.Length; j++)
            {
                string l = lines[j];
                int spaceCount = 0;
                // if this line is an empty line, don't take it into consideration
                if (l.Trim().Length == 0)
                    continue;

                // if this is the first line and does not start with spaces, don't take it into consideration too
                if (j == 0 && !Char.IsWhiteSpace(l[0]))
                    continue;

                for (int i = 0; i < l.Length; i++)
                {
                    if (Char.IsWhiteSpace(l[i]))
                        spaceCount++;
                    else
                        break;
                }
                if (spaceCount < minSpaces)
                    minSpaces = spaceCount;
            }

            StringBuilder sb = new StringBuilder();
            string spacesToBeDeleted = new string(' ', minSpaces);
            foreach (var l in lines)
            {
                string s;
                if (l.StartsWith(spacesToBeDeleted))
                    s = l.Substring(spacesToBeDeleted.Length);
                else
                    s = l;
                sb.Append(s + Environment.NewLine);
            }
            reSnippet.Text = sb.ToString();
        }

        private bool IsSetToRunAtStartUp()
        {
            bool set = false;

            using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                var names = reg.GetValueNames();
                for (int i = 0; i < names.Length; i++)
                {
                    string path = (string)reg.GetValue(names[i]);
                    if (path.Equals(_exeName, StringComparison.OrdinalIgnoreCase))
                    {
                        set = true;
                        break;
                    }
                }
                reg.Close();
            }
            return set;
        }

        private void runAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isSet = IsSetToRunAtStartUp();
            using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            {
                if (isSet)
                {
                    // remove from run
                    var names = reg.GetValueNames();
                    for (int i = 0; i < names.Length; i++)
                    {
                        string path = (string)reg.GetValue(names[i]);
                        if (path.Equals(_exeName, StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                reg.DeleteValue(names[i]);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                MessageBox.Show($"Unable to modify the registry. Try running this application as Administrator\r\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    // add to run
                    try
                    {
                        reg.SetValue("SnippetSharp", _exeName);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"Unable to modify the registry. Try running this application as Administrator\r\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                reg.Close();
            }
        }
    }
}