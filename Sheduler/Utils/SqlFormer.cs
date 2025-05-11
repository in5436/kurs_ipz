using System;
using System.Data;

namespace Sheduler.Utils {
    class SqlFormer {
        // Формування частини SQL-запиту з локальною датою
        public static String CDate(DateTime dt) {
            return "CDATE ('"+dt+"')";
        }

        // Формування списку ідентифікаторів конструкції IN (,,)
        public static String IDs(DataTable dt, String field) {
            if (dt.Rows.Count > 0) {
                String st = null;
                foreach (DataRow dr in dt.Rows) {
                    st = SumFormer.Sum(",", new Object[] { st, (int)dr[field] });
                }
                return st;
            }
            return "NULL";
        }
    }
}
