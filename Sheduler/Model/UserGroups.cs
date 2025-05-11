using System.Data.OleDb;
using Sheduler.View;

namespace Sheduler.Model {
    public class UserGroups : ModelSelect {
        public UserGroups(OleDbConnection conn, IView view, int model_id) : base(conn, view, model_id, "SELECT * from [UserGroups] ORDER BY [Код]") {
        }
    }
}
