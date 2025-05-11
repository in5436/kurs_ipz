using System;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;
using Sheduler.Utils;

namespace Sheduler.Controller {
    public class AuthorizationController : UsersGroupController {
        ModelSelect users;

        public AuthorizationController(OleDbConnection conn, IView view) : base(conn, view, 0) {
        }

        public void Authenticate(OleDbConnection conn, IView view, String username, String pass) {
            users = new Users(conn, view, 1, SumFormer.Sum(" AND ", new String[] {
                "[Користувач]='"+username+"'",
                "[Пароль]='"+pass+"'"
            }));
        }
    }
}
