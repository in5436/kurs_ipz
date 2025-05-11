using System;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class Tasks : ModelWrite {
        public Tasks(OleDbConnection conn, IView view, int model_id, String filter) 
            : base(conn, view, model_id, "SELECT * from [Tasks] "+ModelSelect.Filter(filter)+ "ORDER BY [Код]", 15) {
        }
    }
}
