using System;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Sheduler.Controller;
using Sheduler.View;

namespace Sheduler {
    public partial class FormDivisionsParam : Form, IView {
        public static String[] statuses = {
            "Не виконано",
            "Не перевірено",
            "Перевірено"
        };
        DataRow dr;
        OleDbConnection dbConnection;
        SynchronizationContext sc;
        UsersUserGroupController usc;
        DataRow drAuthGr;
        public FormDivisionsParam(OleDbConnection dbConnection, DataRow drAuthGr, DataRow drTasks, DataRow dr, bool edit) {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.drAuthGr = drAuthGr;
            this.dr = dr;
            sc = SynchronizationContext.Current;
            comboBoxCheck.Items.AddRange(statuses);
            if (edit) {
                Text = "Редагування розподілу на ";
            }
            else {
                Text = "Новий розподіл на ";
                dr["КодЗавдання"] = (int)drTasks["Код"];
                dr["КодКористувача"] = DBNull.Value;
                dr["ЧастинаЗавдання"] = (String)drTasks["Завдання"];
                dr["Детально"] = (String)drTasks["Детально"];
                dr["ДатаВиконання"] = (DateTime)drTasks["ДатаВиконання"];
                dr["Процент"] = 0;
                dr["СтатусПеревірки"] = 0;
                dr["АрхівЗавдання"] = DBNull.Value;
                dr["АрхівРезультат"] = DBNull.Value;
            }
            Text += " " + drTasks["Завдання"];
            textBoxTask.Text = (String)dr["ЧастинаЗавдання"];
            textBoxDet.Text = (String)dr["Детально"];
            dateTimePickerDone.Value = (DateTime)dr["ДатаВиконання"];
            numericUpDownPers.Value = Convert.ToDecimal((double)dr["Процент"]);
            comboBoxCheck.SelectedIndex = (int)dr["СтатусПеревірки"];
            ShowTaskD();
            ShowResD();
            if (StaticFormMethods.IsIntegrator(drAuthGr)) {
                buttonResU.Enabled = false;
            }
            else {
                textBoxTask.Enabled = false;
                buttonChoice.Enabled = false;
                buttonTaskU.Enabled = false;
                comboBoxCheck.Enabled = false;
                dateTimePickerDone.Enabled = false;
            }
            DefaultController();
        }

        private void DefaultController() {
            if (dr["КодКористувача"] != DBNull.Value) {
                usc = new UsersUserGroupController(dbConnection, this, 0, "[Код]="+dr["КодКористувача"]);
            }
        }

        private void ShowTaskD() {
            int at = Archives.ByteArrayLength(dr,"АрхівЗавдання");
            labelTaskLength.Text = (at > 0)?""+at:"-";
        }

        private void ShowResD() {
            int ar = Archives.ByteArrayLength(dr,"АрхівРезультат");
            labelResLength.Text = (ar > 0)?""+ar:"-";
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (!StaticFormMethods.IsIntegrator(drAuthGr) && ((int)dr["СтатусПеревірки"] == 1)) {
                MessageBox.Show("Зміна параетрів після перевірки неможлива");
                return;
            }
            if (textBoxTask.Text.Length == 0) {
                MessageBox.Show("Назва частини завдання не вказана");
                return;
            }
            if (textBoxDet.Text.Length == 0) {
                MessageBox.Show("Деталі частини завдання не вказана");
                return;
            }
            dr["ЧастинаЗавдання"] = textBoxTask.Text;
            dr["Детально"] = textBoxDet.Text;
            dr["ДатаВиконання"]  = dateTimePickerDone.Value;
            dr["Процент"] = numericUpDownPers.Value;
            dr["СтатусПеревірки"] = comboBoxCheck.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        public SynchronizationContext GetContext() {
            return sc;
        }

        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) {
                labelUserChoice.Text = (String)dt.Rows[0]["ПІБ"];
            }
        }

        private void buttonChoice_Click(object sender, EventArgs e) {
            FormUsers fu = new FormUsers(dbConnection, dr);
            if (fu.ShowDialog() == DialogResult.OK) {
                DefaultController();
            }
        }

        private void buttonTaskU_Click(object sender, EventArgs e) {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Zip Files (*.zip)|*.zip|Rar Files (*.rar)|*.rar";
            if (of.ShowDialog() == DialogResult.OK) {
                try {
                    Archives.ZipToByteArray(dr, "АрхівЗавдання", of.FileName);
                    ShowTaskD();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            comboBoxCheck.SelectedIndex = 0;
        }

        private void buttonTaskD_Click(object sender, EventArgs e) {
            try {
                Archives.ByteArrayToZip(dr, "АрхівЗавдання");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonResU_Click(object sender, EventArgs e) {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Zip Files (*.zip)|*.zip|Rar Files (*.rar)|*.rar";
            if (of.ShowDialog() == DialogResult.OK) {
                try {
                    Archives.ZipToByteArray(dr, "АрхівРезультат", of.FileName);
                    ShowResD();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            comboBoxCheck.SelectedIndex = 0;
        }

        private void buttonResD_Click(object sender, EventArgs e) {
            try {
                Archives.ByteArrayToZip(dr, "АрхівРезультат");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDownPers_ValueChanged(object sender, EventArgs e) {
            comboBoxCheck.SelectedIndex = 0;
        }
    }
}
