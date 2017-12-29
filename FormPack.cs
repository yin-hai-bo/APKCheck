using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APKCheck {
    public partial class FormPack : Form {

        public String CommitID {
            get { return TextBoxCommitID.Text; }
        }

        private FormPack() {
            InitializeComponent();
        }

        public static FormPack Create(String versionName, String versionCode, String commitId) {
            FormPack fp = new FormPack();
            fp.textBoxVersionName.Text = versionName;
            fp.textBoxVersionCode.Text = versionCode;
            fp.TextBoxCommitID.Text = commitId;
            return fp;
        }

        private void FormPack_Load(object sender, EventArgs e) {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TextBoxCommitID_TextChanged(object sender, EventArgs e) {
            this.btnOk.Enabled = TextBoxCommitID.Text.Length > 0;
        }

        private void TextBoxCommitID_KeyPress(object sender, KeyPressEventArgs e) {
            var keyChar = e.KeyChar;
            e.Handled = keyChar != 8
                && keyChar != 3
                && keyChar != 24
                && keyChar != 22
                && !Char.IsDigit(keyChar)
                && !Char.IsLetter(keyChar);
        }
    }
}
