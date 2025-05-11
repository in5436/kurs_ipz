using System;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using Sheduler.Controller;
using Sheduler.View;

namespace Sheduler {
   public partial class FormUsersParam : Form, IView {
        OleDbConnection dbConnection;
        DataRow dr;
        bool edit;
        UsersGroupController ugc;
        UsersUserGroupController uuc;
        SynchronizationContext sc;

        public FormUsersParam(OleDbConnection dbConnection, DataRow dr, bool edit) {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.dr = dr;
            sc = SynchronizationContext.Current;
            ugc = new UsersGroupController(dbConnection, this, 0);

            if (this.edit = edit) {
                Text = "Корегування користувача";
            }
            else {
                Text = "Новий користувач";
                dr["КодГрупи"] = 1;
                dr["ПІБ"] = "";
                dr["Користувач"] = "";
                dr["Пароль"] = "";
                dr["ДатаСтворення"] = DateTime.Now;
                dr["Телефон"] = "";
                dr["Email"] = "";
                dr["Блокування"] = 0;
            }
            textBoxPib.Text = (String)dr["ПІБ"];
            textBoxUser.Text = (String)dr["Користувач"];
            textBoxPass.Text = (String)dr["Пароль"];
            textBoxPhone.Text = (String)dr["Телефон"];
            textBoxEmail.Text = (String)dr["Email"];
            comboBoxBlock.SelectedIndex = (int)dr["Блокування"];
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (textBoxUser.Text.Length > 0 && textBoxPass.Text.Length > 0) {
                uuc = new UsersUserGroupController(dbConnection, this, 1, "[Користувач]='"+textBoxUser.Text+"'");
            }
            else {
                MessageBox.Show("Логін або пароль користувача не вказані");
            }
        }

        public SynchronizationContext GetContext() {
            return sc;
        }

        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) {
                switch (model_id) {
                    // Завантаження груп користувачів
                    case 0:
                        StaticFormMethods.ComboboxDescriptionFill(comboBoxGroup,dt);
                        comboBoxGroup.SelectedIndex = (int)dr["КодГрупи"]-1;
                        break;
                    // Завантаження по імені користувача
                    case 1:
                        if ((dt.Rows.Count == 0) || (edit && ((int)dt.Rows[0]["Код"] == (int)dr["Код"]))) {
                            dr["КодГрупи"] = comboBoxGroup.SelectedIndex+1;
                            dr["ПІБ"] = textBoxPib.Text;
                            dr["Користувач"] = textBoxUser.Text;
                            dr["Пароль"] = textBoxPass.Text;
                            dr["Телефон"] = textBoxPhone.Text;
                            dr["Email"] = textBoxEmail.Text;
                            dr["Блокування"] = comboBoxBlock.SelectedIndex;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else {
                            MessageBox.Show("Користувач вже існує у групі "+(String)dt.Rows[0]["Опис"]);
                        }
                        break;
                }
            }
        }
    }
}
