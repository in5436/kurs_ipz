using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public abstract class ModelPage : ModelSelect {
        private int page = 0;

        public ModelPage(OleDbConnection conn, IView view, int model_id, String selectCommand, int maxRows)
            : base(conn, view, model_id, selectCommand, maxRows) {
        }

        public override void Fill(DataTable dtn = null) {
            if (maxRows == 0) {
                base.Fill(dtn);
            }
            else {
                dt.Rows.Clear();
                ad.Fill(page*maxRows, maxRows, new DataTable[] { dt });
                Notify(dtn);
            }
        }

        protected override void Notify(DataTable dtn) {
            if (maxRows == 0) { 
                base.Notify(dtn);
            }
            else {
                bool prev_page = page > 0;
                bool next_page = dt.Rows.Count == maxRows;
                view.GetContext().Post((d) => view.ViewRefresh(model_id, prev_page, next_page, page, dtn), null);
            }
        }

        public void PrevPage() {
            if (page > 0) {
                page--;
                Fill();
            }
        }
        public void NextPage() {
            if (dt.Rows.Count > 0) {
                page++;
                Fill();
            }
        }
    }
}
