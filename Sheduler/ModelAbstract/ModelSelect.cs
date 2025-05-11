using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public abstract class ModelSelect {
        protected IView view;
        protected OleDbDataAdapter ad;
        protected DataTable dt = new DataTable();
        protected int model_id;
        protected int maxRows;

        public ModelSelect(OleDbConnection conn, IView view, int model_id, String selectCommand, int maxRows = 0) {
            this.view = view;
            this.model_id = model_id;
            this.maxRows = maxRows;
            ad = new OleDbDataAdapter(selectCommand, conn);
            ad.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            Fill(dt);
        }

        public virtual void Fill(DataTable dtn = null) {
            dt.Rows.Clear();
            ad.Fill(dt);
            Notify(dtn);    
        }

        protected virtual void Notify(DataTable dt) {
            view.GetContext().Post((d) => view.ViewRefresh(model_id, false, false, 0, dt), null);
        }

        protected static String Filter(String filter) {
            if (filter != null) return "WHERE "+filter+" ";
            return "";
        }
    }
}
