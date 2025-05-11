using System;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;
using Sheduler.Controller;
using Sheduler.View;

namespace Sheduler {
     public partial class FormUsers : Form, IView {
        OleDbConnection dbConnection;    // Екземпляр підключення до БД
        SynchronizationContext sc;       // Контекст синхронізації
        IWriteController usc;            // Контроллер моделей
        FormPager pager;                 // Допоміжний клас управління сторінками
        DataTable dtu;                   // Отриманий набір даних моделі, пов'язаною з таблицею
        DataRow drChoice;                // Запис для вибору користувача

        public FormUsers(OleDbConnection dbConnection, DataRow drChoice = null) {
            InitializeComponent();
            sc = SynchronizationContext.Current;
            this.dbConnection = dbConnection;
            usc = new UsersController(dbConnection, this, null);
            pager = new FormPager(buttonPrev, buttonCurrent, buttonNext, usc);
            if ((this.drChoice = drChoice) != null) {
                this.Text += " // Режим вибору";
                this.buttonDel.Enabled = this.buttonEdit.Enabled = this.buttonNew.Enabled = false;
            }
        }

        // Метод додавання запису
        private void buttonNew_Click(object sender, EventArgs e) {
            DataRow dr = dtu.NewRow();
            // Ввід даних користувачем
            FormUsersParam p = new FormUsersParam(dbConnection,dr,false);
            if (p.ShowDialog() == DialogResult.OK) {
                try {
                    // Зміна даних з оновленням
                    usc.Add(dr);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Метод редагування запису
        private void buttonEdit_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtu.Rows[dataGridView.SelectedRows[0].Index];
                // Оновлення даних
                FormUsersParam p = new FormUsersParam(dbConnection,dr,true);
                if (p.ShowDialog() == DialogResult.OK) {
                    try {
                        // Зміна даних з оновленням
                        usc.Edit(dr);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (drChoice != null) {
                if (dataGridView.SelectedRows.Count > 0) {
                    DataRow dr = dtu.Rows[dataGridView.SelectedRows[0].Index];
                    drChoice["КодКористувача"] = dr["Код"];
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else {
                buttonEdit_Click(sender,e);
            }
        }

        // Метод видалення запису
        private void buttonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtu.Rows[dataGridView.SelectedRows[0].Index];
                if (
                    MessageBox.Show("Видалення користувача приведе до видалення усіх складових завдань, де є даний користувач.\r\nВидалити?", "Увага!",
                    MessageBoxButtons.YesNo) == DialogResult.Yes
                ) {
                    try {
                        // Видалення даних з оновленням
                        usc.Delete(dr);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Метод передачі контексту синхронізації форми
        public SynchronizationContext GetContext() {
            return sc;
        }

        // Оновлення даних
        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            // Перший виклик для коду моделі
            if (dt != null) {
                switch (model_id) {
                    // Збереження фрагменту даних, пов'язаною з ТАБЛИЦЕЮ БД
                    case 0:
                        dtu = dt;
                        break;
                    // Представлення фрагменту даних, пов'язаною з ЗАПИТОМ БД
                    case 1:                
                        dataGridView.SuspendLayout();
                        dataGridView.DataSource = dt;
                        dataGridView.Columns["Код"].Width = 50;
                        dataGridView.Columns["ПІБ"].Width = 300;
                        foreach (DataGridViewColumn c in dataGridView.Columns) {
                            c.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        dataGridView.ResumeLayout();
                        break;
                }
            }
            // Якщо робота з ЗАПИТОМ - оновлення інформації про сторінку
            if (model_id == 1) {
                pager.SetPage(prev_page, next_page, page);
            }
        }

        private void buttonActual_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtu.Rows[dataGridView.SelectedRows[0].Index];
                FormDivisions fd = new FormDivisions(dbConnection, dr, null, null);
                fd.ShowDialog();
            }
        }
    }
}
