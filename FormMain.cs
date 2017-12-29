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
using System.Text.RegularExpressions;

namespace APKCheck {
    public partial class FormMain : Form {

        private readonly ApkList apkList = new ApkList();

        private String currentVersionName, currentVersionCode;

        public FormMain() {
            InitializeComponent();
        }

        private void RefreshCtrls() {
            bool ok = RefreshListView();
            btnPack.Enabled = mainMenuItemPack.Enabled = menuItemPack.Enabled = (ok && !apkList.IsEmpty);
            labelMessage.Text = String.Format("APK文件数：{0}", apkList.Count);
            //
            HashSet<string> channels = new HashSet<string>();
            HashSet<string> duplicate = new HashSet<string>();
            foreach (ApkList.Entry ae in this.apkList) {
                string channel = ae.AndriodManifest.UmengChannel;
                if (!channels.Add(channel)) {
                    duplicate.Add(channel);
                }
            }
            if (duplicate.Count > 0) {
                StringBuilder sb = new StringBuilder("发现重复渠道名：\r\n");
                foreach (string s in duplicate) {
                    sb.Append('"').Append(s).AppendLine("\"");
                }
                MessageBox.Show(this, sb.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool RefreshListView() {
            bool ok = true;
            lvApkList.BeginUpdate();
            try {
                lvApkList.Items.Clear();
                this.currentVersionCode = this.currentVersionName = null;
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
                        this.currentVersionName = entry.AndriodManifest.VersionName;
                        this.currentVersionCode = entry.AndriodManifest.VersionCode;
                    }
                    if (IsEntryValid(firstEntry, entry, lvItem)) {
                        lvItem.ForeColor = Color.Green;
                    } else {
                        ok = false;
                    }
                }
            } finally {
                lvApkList.EndUpdate();
            }
            return ok;
        }

        private static bool IsEntryValid(ApkList.Entry firstEntry, ApkList.Entry entry, ListViewItem lvItem) {
            bool result = true;
            //
            string signMD5 = entry.SignMD5;
            if (signMD5 == null || signMD5 != firstEntry.SignMD5 || !CheckEqualIfRequired(Config.Instance.ExpectedSignMD5, signMD5)) {
                HighLightListViewSubItem(lvItem, 3);
                result = false;
            }
            string channel = entry.AndriodManifest.UmengChannel;
            if (channel == null) {
                HighLightListViewSubItem(lvItem, 7);
                result = false;
            } else if (!entry.Basename.Contains(channel)) {
                lvItem.ForeColor = Color.Red;
                result = false;
            }
            string versionName = entry.AndriodManifest.VersionName;
            if (versionName == null || versionName != firstEntry.AndriodManifest.VersionName) {
                HighLightListViewSubItem(lvItem, 5);
                result = false;
            }
            if (versionName != null && !entry.Basename.Contains(versionName)) {
                lvItem.ForeColor = Color.Red;
                result = false;
            }
            string versionCode = entry.AndriodManifest.VersionCode;
            if (versionCode == null || versionCode != firstEntry.AndriodManifest.VersionCode) {
                HighLightListViewSubItem(lvItem, 6);
                result = false;
            }
            if (versionCode != null && !entry.Basename.Contains(versionCode)) {
                lvItem.ForeColor = Color.Red;
                result = false;
            }
            string umengKey = entry.AndriodManifest.UmengKey;
            if (umengKey == null || umengKey != firstEntry.AndriodManifest.UmengKey || !CheckEqualIfRequired(Config.Instance.ExpectedUMengKey, umengKey)) {
                HighLightListViewSubItem(lvItem, 8);
                result = false;
            }
            string jpushKey = entry.AndriodManifest.JPushKey;
            if (jpushKey == null || jpushKey != firstEntry.AndriodManifest.JPushKey || !CheckEqualIfRequired(Config.Instance.ExpectedJPushKey, jpushKey)) {
                HighLightListViewSubItem(lvItem, 9);
                result = false;
            }
            return result;
        }

        private static bool CheckEqualIfRequired(String expectedValue, String actualValue) {
            return String.IsNullOrEmpty(expectedValue) || actualValue == expectedValue;
        }

        private static void HighLightListViewSubItem(ListViewItem lvi, int index) {
            var item = lvi.SubItems[index];
            item.BackColor = Color.Red;
            item.ForeColor = Color.Yellow;
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

            public static void Execute(FormMain formMain, String versionName, String versionCode, String commitID) {
                try {
                    String dir = CreateDir(formMain);
                    if (dir == null) {
                        return;
                    }
                    CopyAndMakeMD5(formMain, dir, versionName, versionCode, commitID);
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

            private static void CopyAndMakeMD5(FormMain formMain, String dir, String versionName, String versionCode, String commitID) {
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
                    String destZipFilename = String.Format("{0}apk_{1}_vc{2}_{3}.zip",
                        dir,
                        versionName,
                        versionCode,
                        commitID);
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
            String filename = this.apkList[0].Fullname;
            Regex regex = new Regex(@"_(\w+)_g_\w+.apk$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match match = regex.Match(filename);
            String commitID;
            if (match.Success) {
                commitID = match.Groups[1].Value;
            } else {
                commitID = String.Empty;
            }
            using (FormPack fp = FormPack.Create(currentVersionName, currentVersionCode, commitID)) {
                if (fp.ShowDialog(this) == DialogResult.OK) {
                    TargetBuilder.Execute(this, currentVersionName, currentVersionCode, fp.CommitID);
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
