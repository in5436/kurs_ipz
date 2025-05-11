using System;
using System.Windows.Forms;
using Sheduler.Controller;

namespace Sheduler {
    public class FormPager {
        IPageController pagec;
        Button bprev, bnext, bcurr;
        public FormPager(Button bprev, Button bcurr, Button bnext, IPageController pagec) {
            this.pagec = pagec;
            this.bprev = bprev;
            this.bcurr = bcurr;
            this.bnext = bnext;
            bprev.Click += new System.EventHandler(this.buttonPrev_Click);
            bcurr.Click += new System.EventHandler(this.buttonCurr_Click);
            bnext.Click += new System.EventHandler(this.buttonNext_Click);
        }

        public void SetPage(bool prev_page, bool next_page, int page) {
            bprev.Enabled = prev_page;
            bnext.Enabled = next_page;
            bcurr.Text = ""+page;
        }

        private void buttonCurr_Click(object sender, EventArgs e) {
            pagec.Refresh();
        }

        private void buttonPrev_Click(object sender, EventArgs e) {
            pagec.PrevPage();
        }

        private void buttonNext_Click(object sender, EventArgs e) {
            pagec.NextPage();
        }
    }
}
