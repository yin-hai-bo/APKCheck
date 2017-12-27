using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace publish_tool {
    static class Utils {
        private static char HexToChar(int value) {
            if (value < 10) {
                return (char)('0' + value);
            } else {
                return (char)('A' + value - 10);
            }
        }
        public static string BinaryToHexString(byte[] data) {
            int bytes = data.Length;
            char[] buf = new char[bytes << 1];
            int idx = 0;
            foreach (byte b in data) {
                int low = b & 0x0f;
                int high = (b >> 4) & 0x0f;
                buf[idx++] = HexToChar(high);
                buf[idx++] = HexToChar(low);
            }
            return new String(buf);
        }

        public static string ExtractDirectoryName(string fullpath) {
            String dir = Path.GetDirectoryName(fullpath);
            return AppendDirectorySeparatorChar(dir);
        }

        public static string AppendDirectorySeparatorChar(string dir) {
            if (dir.Length > 0) {
                if (dir[dir.Length - 1] != Path.DirectorySeparatorChar) {
                    return dir + Path.DirectorySeparatorChar;
                }
            }
            return dir;
        }

        public static byte[] CalcMD5(Stream input) {
            using (MD5 md5 = MD5.Create()) {
                return md5.ComputeHash(input); ;
            }
        }

        public static byte[] CalcFileMD5(String filename) {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                return CalcMD5(fs);
            }
        }
    }
}
