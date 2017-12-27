namespace publish_tool {
    partial class FormPack {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVersionName = new System.Windows.Forms.TextBox();
            this.textBoxVersionCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSVNVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "版本号(&V)";
            // 
            // textBoxVersionName
            // 
            this.textBoxVersionName.Location = new System.Drawing.Point(166, 28);
            this.textBoxVersionName.Name = "textBoxVersionName";
            this.textBoxVersionName.ReadOnly = true;
            this.textBoxVersionName.Size = new System.Drawing.Size(191, 21);
            this.textBoxVersionName.TabIndex = 4;
            // 
            // textBoxVersionCode
            // 
            this.textBoxVersionCode.Location = new System.Drawing.Point(166, 65);
            this.textBoxVersionCode.Name = "textBoxVersionCode";
            this.textBoxVersionCode.ReadOnly = true;
            this.textBoxVersionCode.Size = new System.Drawing.Size(191, 21);
            this.textBoxVersionCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version Code(&D)";
            // 
            // textBoxSVNVersion
            // 
            this.textBoxSVNVersion.Location = new System.Drawing.Point(166, 102);
            this.textBoxSVNVersion.MaxLength = 6;
            this.textBoxSVNVersion.Name = "textBoxSVNVersion";
            this.textBoxSVNVersion.Size = new System.Drawing.Size(191, 21);
            this.textBoxSVNVersion.TabIndex = 0;
            this.textBoxSVNVersion.TextChanged += new System.EventHandler(this.textBoxSVNVersion_TextChanged);
            this.textBoxSVNVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSVNVersion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "SVN 版本号(&S)";
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(117, 150);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 187);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBoxSVNVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxVersionCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxVersionName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPack";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打包渠道包并生成MD5";
            this.Load += new System.EventHandler(this.FormPack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVersionName;
        private System.Windows.Forms.TextBox textBoxVersionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSVNVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}