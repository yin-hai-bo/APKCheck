using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;

namespace publish_tool {
    static class SignParser {

        public static string Execute(ZipArchive zip) {
            String result = null;
            try {
                foreach (ZipArchiveEntry entry in zip.Entries) {
                    if (entry.FullName.StartsWith("META-INF/")) {
                        if (entry.Name.EndsWith(".RSA")) {
                            String tempFileName = Path.GetTempFileName();
                            try {
                                entry.ExtractToFile(tempFileName, true);
                                result = Execute(tempFileName);
                            } finally {
                                File.Delete(tempFileName);
                            }
                            break;
                        }
                    }
                }
            } catch (IOException e) {
                Console.Error.WriteLine(e.Message);
            }
            return result;
        }

        private static String Execute(String rsaFilename) {
            String result = null;
            String dir = Utils.ExtractDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            using (Process process = new Process()) {
                ProcessStartInfo psi = process.StartInfo;
                psi.CreateNoWindow = true;
                psi.FileName = dir + "keytool-exe";
                psi.Arguments = String.Format("-printcert -file \"{0}\"", rsaFilename);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                if (process.Start()) {
                    try {
                        while (true) {
                            string line = process.StandardOutput.ReadLine();
                            if (line == null) {
                                break;
                            }
                            line = line.Trim();
                            if (String.Compare(line, 0, "MD5: ", 0, 5) == 0) {
                                result = line.Substring(5).Trim();
                                break;
                            }
                        }
                    } finally {
                        process.Close();
                    }
                }
            }
            return result;

        }
    }
}
