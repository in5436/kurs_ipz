using System;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Model;
using Sheduler.Utils;

namespace Sheduler.Controller {
    public class TasksController : IWrite2Controller {
        ModelWrite tasks;
        ModelPage taskavg;
        OleDbConnection conn;
        IView view;

        public TasksController(OleDbConnection conn, IView view, String filter = null) {
            this.conn = conn;
            this.view = view;
            taskavg = new TaskAvg(conn, view, 1, SumFormer.EmptyParam(filter)?null:filter);
        }

        public void Refresh() {
            taskavg.Fill();
        }

        public void Refresh(DataTable dt, String link_id) {
            tasks = new Tasks(conn, view, 0, "[Код] IN ("+ SqlFormer.IDs(dt, link_id)+")");
        }

        public void Add(DataRow dr) {
            tasks.Add(dr);
            Refresh();
        }

        public void Edit(DataRow dr) {
            tasks.Update();
            Refresh();
        }

        public void Delete(DataRow dr) {
            tasks.Delete(dr);
            Refresh();
        }

        public void PrevPage() {
            taskavg.PrevPage();
        }

        public void NextPage() {
            taskavg.NextPage();
        }
    }
}
