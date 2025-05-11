using System;
using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class UsersUserGroup : ModelPage {
        public UsersUserGroup(OleDbConnection conn, IView view, int model_id, String filter) 
            : base(conn, view, model_id, "SELECT * from [UsersUserGroup] "+ModelSelect.Filter(filter)+ "ORDER BY [Код]", 15) {
        }
    }
}
