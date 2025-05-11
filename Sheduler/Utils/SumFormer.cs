using System;
using System.Data;

namespace Sheduler.Utils {
    public class SumFormer {
        public static bool EmptyParam(String param) {
            return (param == null) || (param.Length == 0) || param.Equals("null");
        }

        public static String Sum(String divider, Object[] list) {
            String St = "";
            foreach (Object l in list) {
                if (l != null) {
                    if (St.Length != 0) St += divider;
                    St += l.ToString();
                }
            }
            return (St.Length != 0) ? St : null;
        }

        public static String SumE(String divider, Object[] list) {
            String St = "";
            int i = 0;
            foreach (Object l in list) {
                if (l != null) {
                    if (l != null) {
                        if (i > 0) St += divider;
                        St += l.ToString();
                        i++;
                    }
                }
            }
            return (St.Length != 0) ? St : null;
        }
    }
}
