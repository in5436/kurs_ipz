using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class UsersController : IWriteController {
        ModelWrite users;
        ModelPage usersg;

        public UsersController(OleDbConnection conn, IView view, String filter) {
            users = new Users(conn, view, 0, filter);
            usersg = new UsersUserGroup(conn, view, 1, filter);
        }

        public void Refresh() {
            users.Fill();
            usersg.Fill();
        }

        public void Add(DataRow dr) {
            users.Add(dr);
            Refresh();
        }

        public void Edit(DataRow dr) {
            users.Update();
            Refresh();
        }

        public void Delete(DataRow dr) {
            users.Delete(dr);
            Refresh();
        }

        public void PrevPage() {
            users.PrevPage();
            usersg.PrevPage();
        }

        public void NextPage() {
            users.NextPage();
            usersg.NextPage();
        }
    }
}
