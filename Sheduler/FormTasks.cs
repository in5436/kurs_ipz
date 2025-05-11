using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Sheduler.View;
using Sheduler.Controller;
using Sheduler.Utils;

namespace Sheduler {    
    public partial class FormTasks : Form, IView {
        OleDbConnection dbConnection;
        SynchronizationContext sc;
        IWrite2Controller ctc;
        FormPager pager;
        DataTable dtv, dtc;
        DataRow drAuth;
        DataRow drAuthGr;

        public FormTasks(OleDbConnection dbConnection, DataRow drAuth, DataRow drAuthGr) {
            InitializeComponent();
            this.drAuth = drAuth;
            this.drAuthGr = drAuthGr;
            if (!StaticFormMethods.IsIntegrator(drAuthGr)) {
                buttonNew.Enabled = buttonEdit.Enabled = buttonDel.Enabled = false;
            }

            sc = SynchronizationContext.Current;
            this.dbConnection = dbConnection;

            filterReload();
        }

        private void buttonNew_Click(object sender, EventArgs e) {
            DataRow dr = dtc.NewRow();
            FormTasksParam p = new FormTasksParam(dbConnection,dr,false);
            if (p.ShowDialog() == DialogResult.OK) {
                try {
                    ctc.Add(dr);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtc.Rows[dataGridView.SelectedRows[0].Index];
                FormTasksParam p = new FormTasksParam(dbConnection,dr,true);
                if (p.ShowDialog() == DialogResult.OK) {
                    try {
                        ctc.Edit(dr);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtc.Rows[dataGridView.SelectedRows[0].Index];
                if (MessageBox.Show("Будуть видалені усі складові, що пов'язані з даним завданням!", "Увага", MessageBoxButtons.YesNo)
                == DialogResult.Yes) {
                    try {
                        ctc.Delete(dr);
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

        private void textBoxFilter_TextChanged(object sender, EventArgs e) {
            StaticFormMethods.nameFilter = textBoxFilter.Text;
            filterReload();
        }

        private void filterReload() {
            DateTime now = DateTime.Now;
            String cf = null;
            switch (StaticFormMethods.createFilter) {
                case 0: cf = "[ДатаСтворення] >= "+SqlFormer.CDate(now.AddDays(-7)); break;
                case 1: cf = "[ДатаСтворення] >= "+SqlFormer.CDate(now.AddMonths(-1)); break;
                case 2: cf = "[ДатаСтворення] >= "+SqlFormer.CDate(now.AddMonths(-6)); break;
                case 3: cf = "[ДатаСтворення] >= "+SqlFormer.CDate(now.AddYears(-1)); break;
            }
            String df = null;
            switch (StaticFormMethods.doneFilter) {
                case 1: df = "[ДатаВиконання] <= "+SqlFormer.CDate(now); break;
                case 2: df = "[ДатаВиконання] BETWEEN "+SqlFormer.CDate(now) + " AND " + SqlFormer.CDate(now.AddDays(1)); break;
                case 3: df = "[ДатаВиконання] BETWEEN "+SqlFormer.CDate(now) + " AND " + SqlFormer.CDate(now.AddDays(7)); break;
                case 4: df = "[ДатаВиконання] BETWEEN "+SqlFormer.CDate(now) + " AND " + SqlFormer.CDate(now.AddMonths(1)); break;
            }
            String sf = null;
            switch (StaticFormMethods.statusFilter) {
                case 1: sf = "[СтатусПеревірки] = 0"; break;
                case 2: sf = "[СтатусПеревірки] = 1"; break;
                case 3: sf = "([СтатусПеревірки] = 2) AND ([ДатаЗакриття] IS NULL)"; break;
                case 4: sf = "[ДатаЗакриття] IS NOT NULL"; break;
            }
            String filter = SumFormer.Sum(" AND ", new String[] {
                SumFormer.EmptyParam(StaticFormMethods.nameFilter)?null:"([Завдання] like '%"+StaticFormMethods.nameFilter+"%')",
                SumFormer.EmptyParam(cf)?null:"("+cf+")",
                SumFormer.EmptyParam(df)?null:"("+df+")",
                SumFormer.EmptyParam(sf)?null:"("+sf+")",
            });
            ctc = new TasksController(dbConnection, this, filter);
            pager = new FormPager(buttonPrev, buttonCurrent, buttonNext, ctc);            
        }

        private void buttonDivisions_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count > 0) {
                DataRow dr = dtc.Rows[dataGridView.SelectedRows[0].Index];
                FormDivisions fcs = new FormDivisions(dbConnection, drAuth, drAuthGr, dr);
                fcs.ShowDialog();
                filterReload();
            }
        }

        public SynchronizationContext GetContext() {
            return sc;
        }

        public void ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) {
                if (model_id == 1) {
                    dataGridView.SuspendLayout();
                    dataGridView.DataSource = dtv = dt;
                    dataGridView.Columns["Код"].Width = 50;
                    foreach (DataGridViewColumn c in dataGridView.Columns) {
                        c.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    dataGridView.ResumeLayout();
                    ctc.Refresh(dt,"Код");
                }
                else {
                    dtc = dt;
                }
            }
            if (model_id == 1) {
                pager.SetPage(prev_page, next_page, page);
            }
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e) {
            buttonFilter.Enabled = textBoxFilter.Enabled = checkBoxFilter.Checked;
        }

        private void buttonFilter_Click(object sender, EventArgs e) {
            FormTaskFilter fd = new FormTaskFilter(sc, filterReload);
            fd.ShowDialog();
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            int r = e.RowIndex;
            if (r >= dtv.Rows.Count) return;
            DataRow dr = dtv.Rows[r];
            switch (e.ColumnIndex) {
                case 6: 
                    if ((int)dr["Розподіл"] > 0) {
                        if (dr["ДатаЗакриття"] != DBNull.Value) {
                            e.CellStyle.BackColor = Color.LightGray;
                        }
                        else {
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
                        }
                        e.Value += "%";
                    }
                    break;
                case 7:
                    if ((int)dr["Розподіл"] > 0) {
                        e.Value = FormDivisionsParam.statuses[(int)e.Value];
                    }
                    break;
            }
        }
    }
}
