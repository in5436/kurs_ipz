using System;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class DivisionTask : ModelPage {
        public DivisionTask(OleDbConnection conn, IView view, int model_id, String filter) 
            : base(conn, view, model_id, "SELECT * from [DivisionTask] "+ModelSelect.Filter(filter)+ "ORDER BY [Код]", 20) {
        }
    }
}
