using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace publish_tool {
    static class SignParser {

        public static string execute(string apkFilename) {

            String dir = Utils.ExtractDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            using (Process process = new Process()) {
                ProcessStartInfo psi = process.StartInfo;
                psi.CreateNoWindow = true;
                psi.FileName = dir + "keytool-exe";
                psi.Arguments = String.Format("-printcert -jarfile \"{0}\"", apkFilename);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                if (!process.Start()) {
                    return null;
                }
                while (true) {
                    string line = process.StandardOutput.ReadLine();
                    if (line == null) {
                        break;
                    }
                    line = line.Trim();
                    if (String.Compare(line, 0, "MD5: ", 0, 5) == 0) {
                        return line.Substring(5).Trim();
                    }
                }
                return null;
            }

        }
    }
}
