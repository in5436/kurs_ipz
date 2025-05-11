using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class UsersGroupController {
        ModelSelect usersg;

        public UsersGroupController(OleDbConnection conn, IView view, int model_id) {
            usersg = new UserGroups(conn, view, model_id);
        }
    }
}
