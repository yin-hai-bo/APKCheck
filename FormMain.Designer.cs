namespace APKCheck {
    partial class FormMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvApkList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddFoloer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRemoveSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPack = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPack = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuItemAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuItemAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuItemRemoveSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuItemPack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvApkList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 393);
            this.panel2.TabIndex = 1;
            // 
            // lvApkList
            // 
            this.lvApkList.AllowDrop = true;
            this.lvApkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvApkList.ContextMenuStrip = this.contextMenuStrip1;
            this.lvApkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvApkList.FullRowSelect = true;
            this.lvApkList.GridLines = true;
            this.lvApkList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvApkList.HideSelection = false;
            this.lvApkList.Location = new System.Drawing.Point(0, 0);
            this.lvApkList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvApkList.Name = "lvApkList";
            this.lvApkList.ShowItemToolTips = true;
            this.lvApkList.Size = new System.Drawing.Size(870, 393);
            this.lvApkList.TabIndex = 0;
            this.lvApkList.UseCompatibleStateImageBehavior = false;
            this.lvApkList.View = System.Windows.Forms.View.Details;
            this.lvApkList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvApkList_ItemSelectionChanged);
            this.lvApkList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvApkList_DragDrop);
            this.lvApkList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvApkList_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "目录";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件大小";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "签名指纹";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "文件MD5";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "VN";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "VC";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "渠道";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "友盟";
            this.columnHeader9.Width = 180;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "极光";
            this.columnHeader10.Width = 180;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddFile,
            this.menuItemAddFoloer,
            this.toolStripMenuItem3,
            this.menuItemRemoveSelection,
            this.toolStripMenuItem4,
            this.menuItemPack});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 128);
            // 
            // menuItemAddFile
            // 
            this.menuItemAddFile.Name = "menuItemAddFile";
            this.menuItemAddFile.Size = new System.Drawing.Size(208, 28);
            this.menuItemAddFile.Text = "添加文件(&F)...";
            this.menuItemAddFile.Click += new System.EventHandler(this.ctrlAddFils_Click);
            // 
            // menuItemAddFoloer
            // 
            this.menuItemAddFoloer.Name = "menuItemAddFoloer";
            this.menuItemAddFoloer.Size = new System.Drawing.Size(208, 28);
            this.menuItemAddFoloer.Text = "添加文件夹(&D)...";
            this.menuItemAddFoloer.Click += new System.EventHandler(this.ctrlAddFolder_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemRemoveSelection
            // 
            this.menuItemRemoveSelection.Enabled = false;
            this.menuItemRemoveSelection.Name = "menuItemRemoveSelection";
            this.menuItemRemoveSelection.Size = new System.Drawing.Size(208, 28);
            this.menuItemRemoveSelection.Text = "移除所选项(&R)";
            this.menuItemRemoveSelection.Click += new System.EventHandler(this.ctrlRemoveSelection_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemPack
            // 
            this.menuItemPack.Enabled = false;
            this.menuItemPack.Name = "menuItemPack";
            this.menuItemPack.Size = new System.Drawing.Size(208, 28);
            this.menuItemPack.Text = "打包(&P)...";
            this.menuItemPack.Click += new System.EventHandler(this.ctrlPack_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelMessage);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnPack);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 425);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 67);
            this.panel3.TabIndex = 2;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(13, 25);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(128, 24);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "APK文件数：0";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(722, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 45);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ctrlExit_Click);
            // 
            // btnPack
            // 
            this.btnPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPack.Enabled = false;
            this.btnPack.Location = new System.Drawing.Point(556, 11);
            this.btnPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(136, 45);
            this.btnPack.TabIndex = 0;
            this.btnPack.Text = "打包(&P)";
            this.btnPack.UseVisualStyleBackColor = true;
            this.btnPack.Click += new System.EventHandler(this.ctrlPack_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "选择文件夹";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.FileName = "*.apk";
            this.openFileDialog1.Filter = "APK文件|*.apk";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "打开APK文件";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItemAddFile,
            this.mainMenuItemAddFolder,
            this.toolStripMenuItem1,
            this.mainMenuItemRemoveSelection,
            this.toolStripSeparator1,
            this.mainMenuItemPack,
            this.toolStripMenuItem2,
            this.mainMenuItemExit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // mainMenuItemAddFile
            // 
            this.mainMenuItemAddFile.Name = "mainMenuItemAddFile";
            this.mainMenuItemAddFile.Size = new System.Drawing.Size(220, 30);
            this.mainMenuItemAddFile.Text = "添加文件(&F)...";
            this.mainMenuItemAddFile.Click += new System.EventHandler(this.ctrlAddFils_Click);
            // 
            // mainMenuItemAddFolder
            // 
            this.mainMenuItemAddFolder.Name = "mainMenuItemAddFolder";
            this.mainMenuItemAddFolder.Size = new System.Drawing.Size(220, 30);
            this.mainMenuItemAddFolder.Text = "添加文件夹(&D)...";
            this.mainMenuItemAddFolder.Click += new System.EventHandler(this.ctrlAddFolder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // mainMenuItemRemoveSelection
            // 
            this.mainMenuItemRemoveSelection.Enabled = false;
            this.mainMenuItemRemoveSelection.Name = "mainMenuItemRemoveSelection";
            this.mainMenuItemRemoveSelection.Size = new System.Drawing.Size(220, 30);
            this.mainMenuItemRemoveSelection.Text = "移除所选项(&R)";
            this.mainMenuItemRemoveSelection.Click += new System.EventHandler(this.ctrlRemoveSelection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // mainMenuItemPack
            // 
            this.mainMenuItemPack.Enabled = false;
            this.mainMenuItemPack.Name = "mainMenuItemPack";
            this.mainMenuItemPack.Size = new System.Drawing.Size(220, 30);
            this.mainMenuItemPack.Text = "打包(&P)...";
            this.mainMenuItemPack.Click += new System.EventHandler(this.ctrlPack_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // mainMenuItemExit
            // 
            this.mainMenuItemExit.Name = "mainMenuItemExit";
            this.mainMenuItemExit.Size = new System.Drawing.Size(220, 30);
            this.mainMenuItemExit.Text = "退出(X)";
            this.mainMenuItemExit.Click += new System.EventHandler(this.ctrlExit_Click);
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.Description = "选择目标文件夹";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(870, 492);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(320, 280);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APK检查工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvApkList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPack;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItemAddFile;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItemAddFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItemExit;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItemRemoveSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddFoloer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuItemRemoveSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemPack;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItemPack;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}

