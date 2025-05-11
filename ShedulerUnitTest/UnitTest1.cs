using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;
using Sheduler.View;
using Sheduler.Controller;


namespace ShedulerUnitTest {
    // Клас завантаження виконаців
    [TestClass]
    class UserView : IView {
        SynchronizationContext sc;
        public UsersUserGroupController wc;
        public DataTable dt;

        public UserView(OleDbConnection dbConnection) {
            sc = new SynchronizationContext();
            wc = new UsersUserGroupController(dbConnection, this, 0, "[Опис] = 'Виконавці'");
        }

        SynchronizationContext IView.GetContext() {
            return sc;
        }

        void IView.ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) { 
                this.dt = dt;
            }            
        }
    }

    // Клас завантаження завдань
    [TestClass]
    class TaskView : IView {
        SynchronizationContext sc;
        public IPageController wc;
        public DataTable dt;

        public TaskView(OleDbConnection dbConnection) {
            sc = new SynchronizationContext();
            wc = new TaskAvgController(dbConnection, this, null);
        }

        SynchronizationContext IView.GetContext() {
            return sc;
        }

        void IView.ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (dt != null) { 
                this.dt = dt;
            }            
        }
    }

    // Клас завантаження деталей завдання
    [TestClass]
    class DivisionView : IView {
        public static int FRARMENT_SIZE = 20;
        SynchronizationContext sc;
        public IWriteController wc;
        public DataTable dt;
        public bool prev_page, next_page;
        public int page;
        public DataRow dr_task;

        public DivisionView(OleDbConnection dbConnection, DataRow dr_task) {
            this.dr_task = dr_task;
            sc = new SynchronizationContext();
            wc = new DivisionsController(dbConnection, this, "[КодЗавдання]="+(int)dr_task["Код"]);
        }

        SynchronizationContext IView.GetContext() {
            return sc;
        }

        void IView.ViewRefresh(int model_id, bool prev_page, bool next_page, int page, DataTable dt) {
            if (model_id == 0) {
                this.prev_page = prev_page;
                this.next_page = next_page;
                this.page = page;
                if (dt != null) this.dt = dt;
            }
        }
    }

    [TestClass]
    public class UnitTest1 {
        String Database = "C:/Temp/Sheduler2.accdb";
        OleDbConnection dbConnection;
        UserView uv;
        TaskView tv;
        DivisionView dv;


        // Метод очікування змін
        public bool Wait(Func<bool> act) {
            for (int i=0;i<100;i++) {
                if (act()) return true;
                Thread.Sleep(10);
            }
            return false;
        }

        // Тестування відкриття бази
        [TestMethod]
        public void TestMethod_01_OpenDatabase() {            
            try {
                dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Database + ";");
                dbConnection.Open();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        // Тестування отримання даних моделей
        [TestMethod]
        public void TestMethod_02_FirstDataModel() {     
            TestMethod_01_OpenDatabase();
            try {
                uv = new UserView(dbConnection);
                Assert.AreNotEqual(uv,null);
                if (!Wait(() => { return (uv.dt != null); })) {
                    Assert.Fail("Дані моделі не отримані за 1 сек");
                }
                Assert.AreEqual("Users", uv.dt.TableName);

                tv = new TaskView(dbConnection);
                Assert.AreNotEqual(tv,null);
                if (!Wait(() => { return (tv.dt != null); })) {
                    Assert.Fail("Дані моделі не отримані за 1 сек");
                }
                Assert.AreEqual("Tasks", tv.dt.TableName);

                dv = new DivisionView(dbConnection, tv.dt.Rows[0]);
                Assert.AreNotEqual(dv,null);
                if (!Wait(() => { return (dv.dt != null); })) {
                    Assert.Fail("Дані моделі не отримані за 1 сек");
                }
                Assert.AreEqual("Divisions", dv.dt.TableName);
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            } 
        }

        // Тестування додавання 100 записів з перехідом на наступну сторінку
        // з рівномірним розподілом між виконавцями
        [TestMethod]
        public void TestMethod_03_Add100() {     
            TestMethod_02_FirstDataModel();
            Assert.AreEqual(0, dv.dt.Rows.Count);
            try {
                for (int i=0;i<DivisionView.FRARMENT_SIZE*5;i++) {
                    DataRow dr = dv.dt.NewRow();
                    dr["КодЗавдання"] = (int)dv.dr_task["Код"];
                    dr["КодКористувача"] = (int)uv.dt.Rows[i % uv.dt.Rows.Count]["Код"];
                    dr["ЧастинаЗавдання"] = "Частина"+i;
                    dr["Детально"] = "Детально"+i;
                    dr["ДатаВиконання"] = ((DateTime)dv.dr_task["ДатаВиконання"]).AddDays(-1);
                    dr["Процент"] = 0;
                    dr["СтатусПеревірки"] = 0;
                    dv.wc.Add(dr);
                    if (!Wait(() => { return (dv.dt.Rows.Count == ((i % DivisionView.FRARMENT_SIZE) + 1)); })) {
                        Assert.Fail("Дані не отримані [додавання]");
                    }
                    if (dv.dt.Rows.Count == DivisionView.FRARMENT_SIZE) {
                        dv.wc.NextPage();
                        if (!Wait(() => { return (dv.dt.Rows.Count == 0); })) {
                            Assert.Fail("Дані не отримані [наступна сторінка]");
                        }
                    }
                }
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            } 
        }

        // Тестування видалення 100 записів з перехідом на попередню сторінку
        [TestMethod]
        public void TestMethod_04_Del100() {     
            TestMethod_02_FirstDataModel();
            Assert.AreEqual(DivisionView.FRARMENT_SIZE, dv.dt.Rows.Count);
            try {
                for (int i=99;i>=0;i--) {
                    dv.wc.Delete(dv.dt.Rows[0]);
                    if (!Wait(() => { return (dv.dt.Rows.Count == ((i > DivisionView.FRARMENT_SIZE)?DivisionView.FRARMENT_SIZE:i)); })) {
                        Assert.Fail("Дані не отримані [видалення]");
                    }
                    if ((dv.dt.Rows.Count == 0) && dv.prev_page) {
                        dv.wc.PrevPage();
                        if (!Wait(() => { return (dv.dt.Rows.Count == DivisionView.FRARMENT_SIZE); })) {
                            Assert.Fail("Дані не отримані [попередня сторінка]");
                        }
                    }
                }
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            } 
        }
    }
}
