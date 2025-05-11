using System;
using System.Data;
using System.Windows.Forms;

namespace Sheduler {
    class StaticFormMethods {
        public static int createFilter = 2;
        public static int doneFilter = 0;
        public static int statusFilter = 0;
        public static String nameFilter = "";

        public static bool IsIntegrator(DataRow dr) {
            return (int)dr["Код"] == 1;
        }

        public static void ComboboxDescriptionFill(ComboBox cb, DataTable dt) {
            cb.Items.Clear();
            foreach (DataRow dr in dt.Rows) {
                cb.Items.Add(dr["Опис"]);
            }
        }
    }
}
