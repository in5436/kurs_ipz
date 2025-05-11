using System;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using Sheduler.View;
using Sheduler.Controller;

namespace Sheduler {
    public partial class FormAuth : Form, IView {
        OleDbConnection dbConnection;
        AuthorizationController authc;
        SynchronizationContext sc;
        DataTable dtg;
        public DataRow dr;
        public DataRow drg;

        public FormAuth(OleDbConnection dbConnection) {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.sc = SynchronizationContext.Current;
            authc = new AuthorizationController(dbConnection, this);
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            if (textBoxLogin.Text.Length > 0 && textBoxPass.Text.Length > 0) {
                authc.Authenticate(dbConnection, this, textBoxLogin.Text, textBoxPass.Text);
            }
            else {
                MessageBox.Show("Логін або пароль не введені!");
            }
        }
        public SynchronizationContext GetContext() {
            return sc;
        }

        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) {
                switch (model_id) {
                    // Дані від моделі UserGroups
                    case 0:
                        StaticFormMethods.ComboboxDescriptionFill(comboBoxGroup,dtg = dt);
                        comboBoxGroup.SelectedIndex = 0;
                        break;
                    // Дані від моделі Users
                    case 1:
                        if (dt.Rows.Count > 0) {
                            drg = dtg.Rows[comboBoxGroup.SelectedIndex];
                            dr = dt.Rows[0];
                            if ((int)dr["КодГрупи"] <= (int)drg["Код"]) {
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            else {
                                MessageBox.Show("Запитувані права доступу не можуть бути надані!");
                            }
                        }
                        else {
                            MessageBox.Show("Помилка у логіні або паролі!");
                        }
                        break;
                }
            }
        } 
    }
}
