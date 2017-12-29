using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace publish_tool {
    class Config {

        private static readonly Config instance = new Config();

        public static Config Instance { get { return instance; } }

        public String ExpectedSignMD5 { get; private set; }

        public String ExpectedUMengKey { get; private set; }

        public String ExpectedJPushKey { get; private set; }

        private Config() {
            try {
                loadFromFile();
            } catch (IOException e) {
                Console.Error.WriteLine(e.Message);
            }
        }

        private void loadFromFile() {
            using (XmlTextReader reader = new XmlTextReader("config.xml")) {
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        switch (reader.Name.ToLower()) {
                        case "expectedsignmd5":
                            this.ExpectedSignMD5 = reader.ReadElementContentAsString();
                            break;
                        case "expectedumengkey":
                            this.ExpectedUMengKey = reader.ReadElementContentAsString();
                            break;
                        case "expectedjpushkey":
                            this.ExpectedJPushKey = reader.ReadElementContentAsString();
                            break;
                        }
                    }
                }
            }
        }
    }
}
