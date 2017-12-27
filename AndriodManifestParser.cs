using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android.content.res;
using org.xmlpull.v1;
using android.util;

namespace publish_tool {
    class AndriodManifestParser {
        public String VersionName { get; private set; }
        public String VersionCode { get; private set; }
        public String PackageName { get; private set; }
        public String UmengKey { get; private set; }
        public String UmengChannel { get; private set; }

        public AndriodManifestParser(byte[] data) {
            if (data == null || data.Length == 0) {
                return;
            }
            java.io.InputStream input = new java.io.ByteArrayInputStream(data);
            try {
                AXmlResourceParser parser = new AXmlResourceParser();
                parser.open(input);
                while (true) {
                    int type = parser.next();
                    if (type == XmlPullParser.__Fields.END_DOCUMENT) {
                        break;
                    }
                    if (type == XmlPullParser.__Fields.START_TAG) {
                        switch (parser.getDepth()) {
                        case 1:
                            if ("manifest" == parser.getName()) {
                                parseRootElement(parser);
                            }
                            break;
                        case 3:
                            if ("meta-data" == parser.getName()) {
                                parseMetaDataElement(parser);
                            }
                            break;
                        }
                    }
                }
            } finally {
                input.close();
            }
        }

        private void parseRootElement(AXmlResourceParser parser) {
            for (int i = parser.getAttributeCount() - 1; i >= 0; --i) {
                switch (parser.getAttributeName(i)) {
                case "versionName":
                    this.VersionName = parser.getAttributeValue(i);
                    break;
                case "versionCode":
                    this.VersionCode = parser.getAttributeValueData(i).ToString();
                    break;
                case "package":
                    this.PackageName = parser.getAttributeValue(i);
                    break;
                }
            }
        }

        private void parseMetaDataElement(AXmlResourceParser parser) {
            String name = null;
            String value = null;
            for (int i = parser.getAttributeCount() - 1; i >= 0; --i) {
                string s = parser.getAttributeName(i);
                switch (s) {
                case "name":
                    name = parser.getAttributeValue(i);
                    break;
                case "value":
                    value = parser.getAttributeValue(i);
                    break;
                }
            }
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(value)) {
                return;
            }
            switch (name) {
            case "UMENG_APPKEY":
                this.UmengKey = value;
                break;
            case "UMENG_CHANNEL":
                this.UmengChannel = value;
                break;
            }
        }

        //private static String getAttributeValue(AXmlResourceParser parser, int index) {
        //    int type = parser.getAttributeValueType(index);
        //    int data = parser.getAttributeValueData(index);
        //    switch (type) {
        //    case TypedValue.TYPE_STRING:
        //        return parser.getAttributeValue(index);
        //    case TypedValue.TYPE_ATTRIBUTE:
        //        return String.Format("?%s%08X", getPackage(data), data);
        //    case TypedValue.TYPE_REFERENCE:
        //        return String.Format("@%s%08X", getPackage(data), data);
        //    case TypedValue.TYPE_FLOAT:
        //        return  String.valueOf(Float.intBitsToFloat(data));
        //    case TypedValue.TYPE_INT_HEX) {
        //        return String.format("0x%08X", data);
        //    case TypedValue.TYPE_INT_BOOLEAN) {
        //        return data != 0 ? "true" : "false";
        //    case  TypedValue.TYPE_DIMENSION) {
        //        return Float.toString(complexToFloat(data)) +
        //            DIMENSION_UNITS[data & TypedValue.COMPLEX_UNIT_MASK];
        //    case TypedValue.TYPE_FRACTION) {
        //        return Float.toString(complexToFloat(data)) +
        //            FRACTION_UNITS[data & TypedValue.COMPLEX_UNIT_MASK];
        //        default:
        //    if (type >= TypedValue.TYPE_FIRST_COLOR_INT && type <= TypedValue.TYPE_LAST_COLOR_INT) {
        //        return String.format("#%08X", data);
        //    }
        //    if (type >= TypedValue.TYPE_FIRST_INT && type <= TypedValue.TYPE_LAST_INT) {
        //        return String.valueOf(data);
        //    }
        //    return String.format("<0x%X, type 0x%02X>", data, type);
        //}

        //private static String getPackage(int id) {
        //    if ((id >> 24) == 1) {
        //        return "android:";
        //    } else {
        //        return String.Empty;
        //    }
        //}

    }
}
