using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using android.content.res;
using org.xmlpull.v1;

namespace publish_tool {
    class ApkList : IEnumerable<ApkList.Entry> {

        public class Entry {

            public string Fullname { get; private set; }

            public string Directory { get; private set; }

            public long FileSize { get; private set; }

            public string SignMD5 { get; private set; }

            public string MD5Hash { get; private set; }

            public string Basename { get; private set; }

            public AndriodManifest AndriodManifest { get; private set; }

            public Entry(string fullname) {
                this.Fullname = fullname;
                this.Directory = Utils.ExtractDirectoryName(this.Fullname);
                this.Basename = Path.GetFileName(this.Fullname);
                //
                using (Stream input = new FileStream(Fullname, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    this.FileSize = input.Seek(0, SeekOrigin.End);
                    input.Seek(0, SeekOrigin.Begin);
                    this.MD5Hash = CalcMD5(input);
                    //
                    input.Seek(0, SeekOrigin.Begin);
                    using (ZipArchive zip = new ZipArchive(input, ZipArchiveMode.Read)) {
                        this.SignMD5 = SignParser.Execute(zip);
                        this.AndriodManifest = ExtractAndroidManifest(zip);
                    }
                }
            }

            private static String CalcMD5(Stream input) {
                return Utils.BinaryToHexString(Utils.CalcMD5(input));
            }

            /**
             * 将指定的ZipArchiveEntry解压到内存中
             */
            private static byte[] ExtractZipArchive(ZipArchiveEntry zae) {
                if (zae == null) {
                    return null;
                }
                byte[] buf = new byte[1024 * 1024];
                using (MemoryStream output = new MemoryStream(1024 * 1024)) {
                    using (Stream s = zae.Open()) {
                        while (true) {
                            int readBytes = s.Read(buf, 0, buf.Length);
                            if (readBytes <= 0) {
                                break;
                            }
                            output.Write(buf, 0, readBytes);
                        }
                    }
                    return output.ToArray();
                }
            }

            private static AndriodManifest ExtractAndroidManifest(ZipArchive zip) {
                ZipArchiveEntry zae = zip.GetEntry("AndroidManifest.xml");
                byte[] content = ExtractZipArchive(zae);
                return new AndriodManifest(content);
            }
        }

        private int BinarySearch(String fullname) {
            int lo = 0;
            int hi = list.Count - 1;
            while (lo <= hi) {
                int mid = (lo + hi) >> 1;
                int midValCmp = String.Compare(list[mid].Fullname, fullname, true);
                if (midValCmp < 0) {
                    lo = mid + 1;
                } else if (midValCmp > 0) {
                    hi = mid - 1;
                } else {
                    return mid;
                }
            }
            return ~lo;
        }

        private readonly List<Entry> list = new List<Entry>();

        public static bool IsFilenameAPK(string filename) {
            return 0 == String.Compare(".apk", Path.GetExtension(filename), true);
        }

        public void Remove(Entry e) {
            list.Remove(e);
        }

        public bool Add(string fileOrDirectoryName) {
            if (File.Exists(fileOrDirectoryName) && IsFilenameAPK(fileOrDirectoryName)) {
                return AddFile(fileOrDirectoryName);
            }
            if (!Directory.Exists(fileOrDirectoryName)) {
                return false;
            }
            IEnumerable<string> files = Directory.EnumerateFiles(fileOrDirectoryName, "*.apk", SearchOption.TopDirectoryOnly);
            bool add_ok = false;
            foreach (String filename in files) {
                if (AddFile(filename)) {
                    add_ok = true;
                }
            }
            return add_ok;
        }

        private bool AddFile(string filename) {
            int idx = BinarySearch(filename);
            if (idx < 0) {
                idx = ~idx;
            } else if (idx < list.Count) {
                return false;
            }
            list.Insert(idx, new Entry(filename));
            return true;
        }

        public int Count {
            get { return list.Count; }
        }
        public bool IsEmpty {
            get { return list.Count == 0; }
        }

        public IEnumerator<Entry> GetEnumerator() {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

    }
}
