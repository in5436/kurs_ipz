using System;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class DivisionTaskController : IPageController {
        ModelPage divt;

        public DivisionTaskController(OleDbConnection conn, IView view, String filter) {
            divt = new DivisionTask(conn, view, 0, filter);
        }

        public void Refresh() {
            divt.Fill();
        }

        public void PrevPage() {
            divt.PrevPage();
        }

        public void NextPage() {
            divt.NextPage();
        }
    }
}
