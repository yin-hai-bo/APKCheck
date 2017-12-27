using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace publish_tool {
    public partial class FormPack : Form {

        public String VersionSVN {
            get { return textBoxSVNVersion.Text; }
        }

        private FormPack() {
            InitializeComponent();
        }

        public static FormPack Create(String versionName, String versionCode) {
            FormPack fp = new FormPack();
            fp.textBoxVersionName.Text = versionName;
            fp.textBoxVersionCode.Text = versionCode;
            return fp;
        }

        private void FormPack_Load(object sender, EventArgs e) {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void textBoxSVNVersion_TextChanged(object sender, EventArgs e) {
            btnOk.Enabled = textBoxSVNVersion.Text.Length > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBoxSVNVersion_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = e.KeyChar != 8
                && e.KeyChar != 3
                && e.KeyChar != 24
                && e.KeyChar != 22
                && !Char.IsDigit(e.KeyChar);
        }


    }
}
