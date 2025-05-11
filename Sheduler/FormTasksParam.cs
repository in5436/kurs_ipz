using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sheduler {
    public partial class FormTasksParam : Form {
        DataRow dr;        

        public FormTasksParam(OleDbConnection dbConnection, DataRow dr, bool edit) {
            InitializeComponent();
            this.dr = dr;
            if (edit) {
                Text = "Редагування завдання";
            }
            else {
                Text = "Нове завдання";
                dr["Завдання"] = "";
                dr["Детально"] = "";
                dr["ДатаСтворення"] = DateTime.Now;
                dr["ДатаВиконання"] = DateTime.Now.AddMonths(1);
                dr["ДатаЗакриття"] = DBNull.Value;
            }
            textBoxTask.Text = (String)dr["Завдання"];
            textBoxDet.Text = (dr["Детально"] == DBNull.Value)?"":(String)dr["Детально"];
            dateTimePickerCreate.Value = (DateTime)dr["ДатаСтворення"];
            dateTimePickerDone.Value = (DateTime)dr["ДатаВиконання"];
            if (dateTimePickerClose.Visible = dr["ДатаЗакриття"] != DBNull.Value) {
                dateTimePickerClose.Value = (DateTime)dr["ДатаЗакриття"];
            }
            ShowClose();
        }

        private void ShowClose() {
            if (dateTimePickerClose.Visible) {
                buttonClose.Text = "Відмінити виконання";
            }
            else {
                buttonClose.Text = "Закрити завдання";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (textBoxTask.Text.Length == 0) {
                MessageBox.Show("Завдання не вказане");
                return;
            }
            dr["Завдання"] = textBoxTask.Text;
            dr["Детально"] = textBoxDet.Text;
            dr["ДатаСтворення"] = dateTimePickerCreate.Value;
            dr["ДатаВиконання"] = dateTimePickerDone.Value;
            if (dateTimePickerClose.Visible) {
                dr["ДатаЗакриття"] = dateTimePickerClose.Value;
            }
            else {
                dr["ДатаЗакриття"] = DBNull.Value;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            if (dateTimePickerClose.Visible ^= true) {
                dateTimePickerClose.Value = DateTime.Now;
            }
            ShowClose();
        }
    }
}
