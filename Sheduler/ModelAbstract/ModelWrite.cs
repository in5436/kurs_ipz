using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public abstract class ModelWrite : ModelPage {
        private OleDbCommandBuilder bs;

        public ModelWrite(OleDbConnection conn, IView view, int model_id, String selectCommand, int maxRows)
            : base(conn, view, model_id, selectCommand, maxRows) {
            bs = new OleDbCommandBuilder(ad);
            bs.GetUpdateCommand();
            bs.GetInsertCommand();
            bs.GetDeleteCommand();            
        }

        public void Add(DataRow dr) {
            dt.Rows.Add(dr);
            Update();
        }

        public void Update() {
            ad.Update(dt);
            Notify(null);
        }

        public void Delete(DataRow dr) {
            dr.Delete();
            Update();
        }
    }
}
