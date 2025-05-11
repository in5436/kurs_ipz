using System;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class UsersUserGroupController {
        ModelPage users;

        public UsersUserGroupController(OleDbConnection conn, IView view, int model_id, String filter) {
            users = new UsersUserGroup(conn, view, model_id, filter);
        }
    }
}
