using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace Sheduler {
    public partial class Form1 : Form {
        OleDbConnection dbConnection;
        DataRow drAuth;
        DataRow drAuthGr;

        public Form1() {
            InitializeComponent();
            String CultureName = Application.CurrentCulture.Name;
            CultureInfo ci = new CultureInfo(CultureName);
            if (ci.NumberFormat.NumberDecimalSeparator != ",") {
                ci.NumberFormat.NumberDecimalSeparator = ",";
                Application.CurrentCulture = ci;
            }

            String Database = "C:/Temp/Sheduler.accdb";

            // Підключення до БД
            try {
                dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Database + ";");
                dbConnection.Open();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e) {
            (new FormAbout()).ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void авторизаціяToolStripMenuItem_Click(object sender, EventArgs e) {
            FormAuth fa = new FormAuth(dbConnection);
            if (fa.ShowDialog() == DialogResult.OK) {
                drAuth = fa.dr;
                drAuthGr = fa.drg;
                toolStripStatusLabel1.Text = "Авторизований як "+drAuth["Користувач"] + " // " + drAuthGr["Опис"];
                menuStrip1.Items.Remove(інтеграторToolStripMenuItem);
                menuStrip1.Items.Remove(виконавецьToolStripMenuItem);
                if (StaticFormMethods.IsIntegrator(drAuthGr)) {
                    menuStrip1.Items.Insert(1,інтеграторToolStripMenuItem);
                }
                else {
                    menuStrip1.Items.Insert(1,виконавецьToolStripMenuItem);
                }
            }
            else if (drAuth == null) {
                Close();
            }
        }

        // При мершому показі форми - авторизація
        private void Form1_Shown(object sender, EventArgs e) {
            авторизаціяToolStripMenuItem_Click(sender, e);
        }

        // Вікно управління користувачами
        private void користувачіToolStripMenuItem_Click(object sender, EventArgs e) {
            (new FormUsers(dbConnection)).ShowDialog();
        }

        // Вікно управління завданнями
        private void завданняToolStripMenuItem_Click(object sender, EventArgs e) {
            (new FormTasks(dbConnection, drAuth, drAuthGr)).ShowDialog();
        }
    }
}
