using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;

namespace Sheduler.Controller {
    public class DivisionsController : IWriteController {
        ModelWrite divs;
        ModelPage divsu;

        public DivisionsController(OleDbConnection conn, IView view, String filter) {
            divs = new Divisions(conn, view, 0, filter);
            divsu = new DivisionUser(conn, view, 1, filter);
        }

        public void Refresh() {
            divs.Fill();
            divsu.Fill();
        }

        public void Add(DataRow dr) {
            divs.Add(dr);
            Refresh();
        }

        public void Edit(DataRow dr) {
            divs.Update();
            Refresh();
        }

        public void Delete(DataRow dr) {
            divs.Delete(dr);
            Refresh();
        }

        public void PrevPage() {
            divs.PrevPage();
            divsu.PrevPage();
        }

        public void NextPage() {
            divs.NextPage();
            divsu.NextPage();
        }
    }
}
