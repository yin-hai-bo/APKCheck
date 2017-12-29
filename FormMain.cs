using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace publish_tool {
    public partial class FormMain : Form {

        private readonly ApkList apkList = new ApkList();

        private String currentVersionName, currentVersionCode;

        public FormMain() {
            InitializeComponent();
        }

        private void RefreshCtrls() {
            bool noerror = RefreshListView();
            btnPack.Enabled = mainMenuItemPack.Enabled = menuItemPack.Enabled = (noerror && !apkList.IsEmpty);
            labelMessage.Text = String.Format("APK文件数：{0}", apkList.Count);
            //
            HashSet<string> channels = new HashSet<string>();
            HashSet<string> duplicate = new HashSet<string>();
            foreach (ApkList.Entry ae in this.apkList) {
                if (!channels.Add(ae.AndriodManifest.UmengChannel)) {
                    duplicate.Add(ae.AndriodManifest.UmengChannel);
                }
            }
            if (duplicate.Count > 0) {
                StringBuilder sb = new StringBuilder("发现重复渠道名：\r\n");
                foreach (string s in duplicate) {
                    sb.Append("    ");
                    sb.AppendLine(s);
                }
                MessageBox.Show(this, sb.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool RefreshListView() {
            bool noerror = true;
            currentVersionName = currentVersionCode = null;
            lvApkList.BeginUpdate();
            try {
                lvApkList.Items.Clear();
                ApkList.Entry firstEntry = null;
                foreach (ApkList.Entry entry in apkList) {
                    var lvItem = lvApkList.Items.Add(entry.Basename);
                    lvItem.Tag = entry;
                    lvItem.UseItemStyleForSubItems = false;
                    lvItem.SubItems.Add(entry.Directory);
                    lvItem.SubItems.Add((entry.FileSize / 1048576f).ToString("0.00 M"));
                    lvItem.SubItems.Add(entry.SignMD5);
                    lvItem.SubItems.Add(entry.MD5Hash);
                    lvItem.SubItems.Add(entry.AndriodManifest.VersionName);
                    lvItem.SubItems.Add(entry.AndriodManifest.VersionCode);
                    lvItem.SubItems.Add(entry.AndriodManifest.UmengChannel);
                    lvItem.SubItems.Add(entry.AndriodManifest.UmengKey);
                    lvItem.SubItems.Add(entry.AndriodManifest.JPushKey);
                    //
                    if (firstEntry == null) {
                        firstEntry = entry;
                        currentVersionName = entry.AndriodManifest.VersionName;
                        currentVersionCode = entry.AndriodManifest.VersionCode;
                    } else {
                        if (entry.SignMD5 != firstEntry.SignMD5) {
                            highLightListViewSubItem(lvItem, 3);
                            noerror = false;
                        }
                        if (entry.AndriodManifest.VersionName != firstEntry.AndriodManifest.VersionName) {
                            highLightListViewSubItem(lvItem, 5);
                            noerror = false;
                        }
                        if (entry.AndriodManifest.VersionCode != firstEntry.AndriodManifest.VersionCode) {
                            highLightListViewSubItem(lvItem, 6);
                            noerror = false;
                        }
                        if (entry.AndriodManifest.UmengKey != firstEntry.AndriodManifest.UmengKey) {
                            highLightListViewSubItem(lvItem, 8);
                            noerror = false;
                        }
                    }
                    if (entry.AndriodManifest.UmengChannel == null || !entry.Basename.Contains(entry.AndriodManifest.UmengChannel) ) {
                        lvItem.ForeColor = Color.Red;
                        noerror = false;
                    }
                }
            } finally {
                lvApkList.EndUpdate();
            }
            return noerror;
        }

        private static void highLightListViewSubItem(ListViewItem lvi, int index) {
            lvi.SubItems[index].ForeColor = Color.Red;
        }

        private void lvApkList_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvApkList_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] fileNameList = (string[])e.Data.GetData(DataFormats.FileDrop);
                addFilenameList(fileNameList);
            }
        }

        private void addFilenameList(IEnumerable<string> fileNameList) {
            bool updated = false;
            Cursor cursorOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try {
                foreach (string filename in fileNameList) {
                    if (apkList.Add(filename)) {
                        updated = true;
                    }
                }
                if (updated) {
                    RefreshCtrls();
                }
            } finally {
                this.Cursor = cursorOld;
            }
        }

        private static class TargetBuilder {

            public static void execute(FormMain formMain, String versionName, String versionCode, String versionSVN) {
                try {
                    String dir = CreateDir(formMain);
                    if (dir == null) {
                        return;
                    }
                    CopyAndMakeMD5(formMain, dir, versionName, versionCode, versionSVN);
                    MessageBox.Show(formMain, "打包完毕。\n（点击确定将打开目标文件夹）", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NativeMethods.ShellExecute(IntPtr.Zero, null, dir, null, null, 1);
                } catch (Exception ex) {
                    MessageBox.Show(formMain, ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private static String CreateDir(FormMain formMain) {
                if (DialogResult.OK != formMain.folderBrowserDialog2.ShowDialog(formMain)) {
                    return null;
                }
                String dir = Utils.AppendDirectorySeparatorChar(formMain.folderBrowserDialog2.SelectedPath);
                DateTime now = DateTime.Now;
                dir += String.Format("{0:D04}{1:D02}{2:D02}-{3:D02}{4:D02}{5:D02}-{6:D03}{7}",
                    now.Year, now.Month, now.Day,
                    now.Hour, now.Minute, now.Second, now.Millisecond,
                    Path.DirectorySeparatorChar);
                Directory.CreateDirectory(dir);
                return dir;
            }

            private static void CopyAndMakeMD5(FormMain formMain, String dir, String versionName, String versionCode, String versionSVN) {
                foreach (ApkList.Entry ae in formMain.apkList) {
                    String destFilename = dir + ae.Basename;
                    File.Copy(ae.Fullname, destFilename);
                    string md5filename = destFilename + ".MD5";
                    using (FileStream fs = new FileStream(md5filename, FileMode.Create, FileAccess.Write, FileShare.Read)) {
                        byte[] data = Encoding.UTF8.GetBytes(ae.MD5Hash);
                        fs.Write(data, 0, data.Length);
                        fs.SetLength(data.Length);
                    }
                }
                //
                String tempFile = Path.GetTempFileName();
                try {
                    File.Delete(tempFile);
                    ZipFile.CreateFromDirectory(dir, tempFile, CompressionLevel.NoCompression, false, Encoding.UTF8);
                    String destZipFilename = String.Format("{0}apk_{1}_vc{2}_svn{3}.zip",
                        dir,
                        versionName,
                        versionCode,
                        versionSVN);
                    File.Copy(tempFile, destZipFilename);
                    //
                    byte[] md5 = Utils.CalcFileMD5(destZipFilename);
                    using (FileStream fs = new FileStream(destZipFilename + ".MD5", FileMode.Create, FileAccess.Write, FileShare.Read)) {
                        byte[] md5hex_str = Encoding.UTF8.GetBytes(Utils.BinaryToHexString(md5));
                        fs.Write(md5hex_str, 0, md5hex_str.Length);
                    }
                } finally {
                    File.Delete(tempFile);
                }
                //

            }

        }

        private void ctrlExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void ctrlPack_Click(object sender, EventArgs e) {
            using (FormPack fp = FormPack.Create(currentVersionName, currentVersionCode)) {
                if (fp.ShowDialog(this) == DialogResult.OK) {
                    TargetBuilder.execute(this, currentVersionName, currentVersionCode, fp.VersionSVN);
                }
            }
        }

        private void ctrlAddFils_Click(object sender, EventArgs e) {
            if (DialogResult.OK == openFileDialog1.ShowDialog(this)) {
                addFilenameList(openFileDialog1.FileNames);
            }
        }

        private void ctrlAddFolder_Click(object sender, EventArgs e) {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog(this)) {
                addFilenameList(new string[] { folderBrowserDialog1.SelectedPath });
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void ctrlRemoveSelection_Click(object sender, EventArgs e) {
            if (lvApkList.SelectedItems.Count == 0) {
                return;
            }
            if (DialogResult.OK != MessageBox.Show(this, "确定要移除所选项吗？", "移除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
                return;
            }
            foreach (ListViewItem lvi in lvApkList.SelectedItems) {
                ApkList.Entry ae = (ApkList.Entry)lvi.Tag;
                apkList.Remove(ae);
            }
            RefreshCtrls();
        }

        private void lvApkList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            mainMenuItemRemoveSelection.Enabled = menuItemRemoveSelection.Enabled = lvApkList.SelectedItems.Count > 0;
        }

        private static class NativeMethods {
            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr ShellExecute(
                IntPtr hwnd,
                string lpOperation,
                string lpFile,
                string lpParameters,
                string lpDirectory,
                int nShowCmd);
        }
    }


}
