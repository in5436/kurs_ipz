using System;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class DivisionUser : ModelPage {
        public DivisionUser(OleDbConnection conn, IView view, int model_id, String filter)
            : base(conn, view, model_id, "SELECT * from [DivisionUser] "+ModelSelect.Filter(filter)+ "ORDER BY [Код]", 20) {
        }
    }
}
