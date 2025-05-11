using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sheduler {
    public partial class FormTaskFilter : Form {
        SynchronizationContext sc;
        Action filterReload;
        public FormTaskFilter(SynchronizationContext sc, Action filterReload) {
            InitializeComponent();
            this.sc = sc;
            this.filterReload = filterReload;

            switch (StaticFormMethods.createFilter) {
                case 0: rCreateWeek.Checked = true; break;
                case 1: rCreateMonth.Checked = true; break;
                case 2: rCreateHalfYear.Checked = true; break;
                case 3: rCreateYear.Checked = true; break;
                case 4: rCreateNone.Checked = true; break;
            }
            foreach (RadioButton r in groupBoxCreate.Controls) {
                r.CheckedChanged += radioGroupCreate_checkedChanged;
            }

            switch (StaticFormMethods.doneFilter) {
                case 0: rDoneNone.Checked = true; break;
                case 1: rDoneOver.Checked = true; break;
                case 2: rDoneDay.Checked = true; break;
                case 3: rDoneWeek.Checked = true; break;
                case 4: rDoneMonth.Checked = true; break;
            }
            foreach (RadioButton r in groupBoxDone.Controls) {
                r.CheckedChanged += radioGroupDone_checkedChanged;
            }

            switch (StaticFormMethods.statusFilter) {
                case 0: rStatusNone.Checked = true; break;
                case 1: rStatusNotWork.Checked = true; break;
                case 2: rStatusNotCheck.Checked = true; break;
                case 3: rStatusCheck.Checked = true; break;
                case 4: rStatusClose.Checked = true; break;
            }
            foreach (RadioButton r in groupBoxStatus.Controls) {
                r.CheckedChanged += radioGroupStatus_checkedChanged;
            }

            textBoxName.Text = StaticFormMethods.nameFilter;
        }

        private void Reload() {
            sc.Post((d) => { filterReload(); }, null);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e) {
            StaticFormMethods.nameFilter = textBoxName.Text;
            Reload();
        }

        private void radioGroupCreate_checkedChanged(object sender, EventArgs e) {
            int p = 0;
            foreach (RadioButton r in groupBoxCreate.Controls) {
                if (r.Checked) {
                    StaticFormMethods.createFilter = r.TabIndex;
                    p++;
                }
            }
            if (p == 1) Reload();
        }
        private void radioGroupDone_checkedChanged(object sender, EventArgs e) {
            int p = 0;
            foreach (RadioButton r in groupBoxDone.Controls) {
                if (r.Checked) {
                    StaticFormMethods.doneFilter = r.TabIndex;
                    p++;
                }
            }
            if (p == 1) Reload();
        }
        private void radioGroupStatus_checkedChanged(object sender, EventArgs e) {
            int p = 0;
            foreach (RadioButton r in groupBoxStatus.Controls) {
                if (r.Checked) {
                    StaticFormMethods.statusFilter = r.TabIndex;
                    p++;
                }
            }
            if (p == 1) Reload();
        }
    }
}
