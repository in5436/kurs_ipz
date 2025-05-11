using System;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class TaskAvgController : IPageController {
        ModelPage tavg;

        public TaskAvgController(OleDbConnection conn, IView view, String filter) {
            tavg = new TaskAvg(conn, view, 0, filter);
        }

        public void Refresh() {
            tavg.Fill();
        }

        public void PrevPage() {
            tavg.PrevPage();
        }

        public void NextPage() {
            tavg.NextPage();
        }
    }
}
