namespace SnippetSharp
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniVeriTabanıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veriTabanıAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veriTabanınıKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniKategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snippetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSnippetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSnippet = new System.Windows.Forms.RichTextBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.CategoryIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.snippetContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.snippetContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.kategoriToolStripMenuItem,
            this.snippetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1331, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniVeriTabanıToolStripMenuItem,
            this.veriTabanıAçToolStripMenuItem,
            this.saveDatabaseToolStripMenuItem,
            this.veriTabanınıKaydetToolStripMenuItem,
            this.toolStripSeparator1,
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.dosyaToolStripMenuItem.Text = "File";
            // 
            // yeniVeriTabanıToolStripMenuItem
            // 
            this.yeniVeriTabanıToolStripMenuItem.Name = "yeniVeriTabanıToolStripMenuItem";
            this.yeniVeriTabanıToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.yeniVeriTabanıToolStripMenuItem.Text = "New database...";
            this.yeniVeriTabanıToolStripMenuItem.Click += new System.EventHandler(this.NewDatabaseToolStripMenuItem_Click);
            // 
            // veriTabanıAçToolStripMenuItem
            // 
            this.veriTabanıAçToolStripMenuItem.Name = "veriTabanıAçToolStripMenuItem";
            this.veriTabanıAçToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.veriTabanıAçToolStripMenuItem.Text = "Open database...";
            this.veriTabanıAçToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseToolStripMenuItem_Click);
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            this.saveDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDatabaseToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.saveDatabaseToolStripMenuItem.Text = "Save database";
            this.saveDatabaseToolStripMenuItem.Click += new System.EventHandler(this.saveDatabaseToolStripMenuItem_Click_1);
            // 
            // veriTabanınıKaydetToolStripMenuItem
            // 
            this.veriTabanınıKaydetToolStripMenuItem.Name = "veriTabanınıKaydetToolStripMenuItem";
            this.veriTabanınıKaydetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.veriTabanınıKaydetToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.veriTabanınıKaydetToolStripMenuItem.Text = "Save database as ...";
            this.veriTabanınıKaydetToolStripMenuItem.Click += new System.EventHandler(this.SaveDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.çıkışToolStripMenuItem.Text = "Exit";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.CheckOnClick = true;
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay on top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // kategoriToolStripMenuItem
            // 
            this.kategoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKategoriEkleToolStripMenuItem});
            this.kategoriToolStripMenuItem.Name = "kategoriToolStripMenuItem";
            this.kategoriToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.kategoriToolStripMenuItem.Text = "Category";
            // 
            // yeniKategoriEkleToolStripMenuItem
            // 
            this.yeniKategoriEkleToolStripMenuItem.Name = "yeniKategoriEkleToolStripMenuItem";
            this.yeniKategoriEkleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.yeniKategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yeniKategoriEkleToolStripMenuItem.Text = "New category";
            this.yeniKategoriEkleToolStripMenuItem.Click += new System.EventHandler(this.yeniKategoriEkleToolStripMenuItem_Click);
            // 
            // snippetToolStripMenuItem
            // 
            this.snippetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSnippetToolStripMenuItem});
            this.snippetToolStripMenuItem.Name = "snippetToolStripMenuItem";
            this.snippetToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.snippetToolStripMenuItem.Text = "Snippet";
            // 
            // newSnippetToolStripMenuItem
            // 
            this.newSnippetToolStripMenuItem.Name = "newSnippetToolStripMenuItem";
            this.newSnippetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.newSnippetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newSnippetToolStripMenuItem.Text = "New snippet";
            this.newSnippetToolStripMenuItem.Click += new System.EventHandler(this.newSnippetToolStripMenuItem_Click);
            // 
            // reSnippet
            // 
            this.reSnippet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reSnippet.ContextMenuStrip = this.snippetContextMenu;
            this.reSnippet.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reSnippet.Location = new System.Drawing.Point(471, 324);
            this.reSnippet.Name = "reSnippet";
            this.reSnippet.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.reSnippet.Size = new System.Drawing.Size(853, 425);
            this.reSnippet.TabIndex = 3;
            this.reSnippet.Text = "";
            this.reSnippet.WordWrap = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.DescriptionColumn,
            this.Column6});
            this.dgvDetail.Location = new System.Drawing.Point(471, 59);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 62;
            this.dgvDetail.Size = new System.Drawing.Size(851, 259);
            this.dgvDetail.TabIndex = 2;
            this.dgvDetail.TabStop = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DetailId";
            this.Column4.HeaderText = "DetailId";
            this.Column4.MinimumWidth = 2;
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            this.Column4.Width = 2;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CategoryId";
            this.Column5.HeaderText = "CategoryId";
            this.Column5.MinimumWidth = 2;
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 2;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.MinimumWidth = 8;
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.Width = 600;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DateCreated";
            this.Column6.HeaderText = "Date Created";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryIdColumn,
            this.Column1,
            this.Column2});
            this.dgvCategory.Location = new System.Drawing.Point(9, 26);
            this.dgvCategory.MultiSelect = false;
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowHeadersWidth = 62;
            this.dgvCategory.Size = new System.Drawing.Size(457, 721);
            this.dgvCategory.TabIndex = 4;
            this.dgvCategory.TabStop = false;
            // 
            // CategoryIdColumn
            // 
            this.CategoryIdColumn.DataPropertyName = "CategoryId";
            this.CategoryIdColumn.HeaderText = "CategoryId";
            this.CategoryIdColumn.MinimumWidth = 2;
            this.CategoryIdColumn.Name = "CategoryIdColumn";
            this.CategoryIdColumn.Visible = false;
            this.CategoryIdColumn.Width = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CategoryName";
            this.Column1.HeaderText = "Category";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DateCreated";
            this.Column2.HeaderText = "Date Created";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Filter";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(531, 29);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(604, 20);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // snippetContextMenu
            // 
            this.snippetContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.snippetContextMenu.Name = "snippetContextMenu";
            this.snippetContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 756);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reSnippet);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.dgvCategory);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Snippet Sharp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.snippetContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniVeriTabanıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veriTabanıAçToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veriTabanınıKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniKategoriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snippetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSnippetToolStripMenuItem;
        private System.Windows.Forms.RichTextBox reSnippet;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ContextMenuStrip snippetContextMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

