using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Sheduler.View;
using Sheduler.Controller;
using Sheduler.Utils;

namespace Sheduler {
    public partial class FormDivisions : Form, IView {
        OleDbConnection dbConnection;
        SynchronizationContext sc;
        IWriteController cts;
        FormPager pager;
        DataTable dts;
        DataRow drAuth;
        DataRow drAuthGr;
        DataRow drTasks;

        public FormDivisions(OleDbConnection dbConnection, DataRow drAuth, DataRow drAuthGr, DataRow drTasks) {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.drAuth = drAuth;
            this.drAuthGr = drAuthGr;
            this.drTasks = drTasks;

            if (drTasks != null) {
                Text += " // " + (String)drTasks["Завдання"];
            }
            else {
                Text += " // Усі поточні завдання користувача "+drAuth["ПІБ"]; 
            }
            if (drTasks == null) {
                buttonNew.Enabled = buttonEdit.Enabled = buttonDel.Enabled = false;
            }
            else if (!StaticFormMethods.IsIntegrator(drAuthGr)) {
                buttonNew.Enabled = buttonDel.Enabled = false;
            }

            sc = SynchronizationContext.Current;
            DefaultControllerAndPager();
        }

        // Метод створення контролера та пейджера
        private void DefaultControllerAndPager() {
            String filter = SumFormer.Sum(" AND ", new String[] {
                (drTasks == null)?"([КодКористувача]="+(int)drAuth["Код"]+")":null,
                (drTasks == null)?"([СтатусПеревірки] < 2)":null,
                (drTasks != null)?"[КодЗавдання]="+(int)drTasks["Код"]:null
            });

            cts = new DivisionsController(dbConnection, this, filter);
            pager = new FormPager(buttonPrev, buttonCurrent, buttonNext, cts);
        }

        // Метод додавання товару
        private void buttonNew_Click(object sender, EventArgs e) {
            DataRow dr = dts.NewRow();
            FormDivisionsParam p = new FormDivisionsParam(dbConnection, drAuthGr, drTasks, dr, false);
            if (p.ShowDialog() == DialogResult.OK) {
                try {
                    cts.Add(dr);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Метод редагування товару
        private void buttonEdit_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dts.Rows[dataGridView.SelectedRows[0].Index];
                if (StaticFormMethods.IsIntegrator(drAuthGr) || ((int)dr["КодКористувача"] == (int)drAuth["Код"])) {
                    FormDivisionsParam p = new FormDivisionsParam(dbConnection, drAuthGr, drTasks, dr, true);
                    if (p.ShowDialog() == DialogResult.OK) {
                        try {
                            cts.Edit(dr);
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else {
                        try {
                            dr.RejectChanges();
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else {
                    MessageBox.Show("Складова завдання вам не належить!");
                }
            }
        }

        // Метод видалення товару
        private void buttonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dts.Rows[dataGridView.SelectedRows[0].Index];
                if (MessageBox.Show("Буде видалена складова завдання "+dr["ЧастинаЗавдання"]+"!", "Увага", MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.Yes) {
                    try {
                        cts.Delete(dr);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            buttonEdit_Click(sender,e);
        }

        // Контекст синхронізації
        public SynchronizationContext GetContext() {
            return sc;
        }

        // Оновлення даних
        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) {
                switch (model_id) { 
                    case 0:
                        dts = dt;
                        break;
                    case 1:                
                        dataGridView.SuspendLayout();
                        dataGridView.DataSource = dt;
                        dataGridView.Columns["Код"].Width = 50;
                        dataGridView.Columns["КодЗавдання"].Visible = 
                        dataGridView.Columns["КодКористувача"].Visible = 
                        dataGridView.Columns["АрхівЗавдання"].Visible =
                        dataGridView.Columns["АрхівРезультат"].Visible = false;
                        dataGridView.Columns["ПІБ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        foreach (DataGridViewColumn c in dataGridView.Columns) {
                            c.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        dataGridView.ResumeLayout();
                        break;
                }
            }
            if (model_id == 1) {
                pager.SetPage(prev_page, next_page, page);
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            int r = e.RowIndex;
			if (r >= dts.Rows.Count) return;
			DataRow dr = dts.Rows[r];
            switch (e.ColumnIndex) {
                case 5:
                    DateTime dtDone = (DateTime)dr["ДатаВиконання"];
					if (dtDone <= DateTime.Now.AddDays(3)) {
						double pers = (double)dr["Процент"];
						int stp = (int)dr["СтатусПеревірки"];
						Color color;
						if ((pers >= 99.99) && (stp == 2)) {
							color = Color.Green;
						}
						else if (pers >= 75) {
							color = Color.Yellow;
						}
						else {
							color = Color.Red;
						}
						e.CellStyle.BackColor = color;
					}
                    e.Value += "%";
                    break;
                case 6:
                    e.Value = FormDivisionsParam.statuses[(int)e.Value];
                    break;
            }
        }
    }
}
