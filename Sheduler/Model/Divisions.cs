using System;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class Divisions : ModelWrite {
        public Divisions(OleDbConnection conn, IView view, int model_id, String filter) 
            : base(conn, view, model_id, "SELECT * from [Divisions] "+ModelSelect.Filter(filter)+ "ORDER BY [Код]", 20) {
        }
    }
}
