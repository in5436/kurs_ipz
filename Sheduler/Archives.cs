using System;
using System.Drawing;
using System.IO;
using System.Data;
using System.Net;

namespace Sheduler {
    public class Archives {
        public static int ByteArrayLength(DataRow dr, String field) {
            if (dr[field] != DBNull.Value) {
                byte[] b = (byte[])dr[field];
                return b.Length;
            }
            return 0;
        }

        // Метод перетворення збереженого у таблиці об'єкта OLE у ZIP-файл зі старом процесу
        public static void ByteArrayToZip(DataRow dr, String field) {
            if (dr[field] != DBNull.Value) {
                String fileName = Path.ChangeExtension(Path.GetTempFileName(), "zip");
                FileStream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write);
                byte[] b = (byte[])dr[field];
                fs.Write(b,0,b.Length);
                fs.Close();
                System.Diagnostics.Process.Start(fileName);
            }
        }

        // Метод перетворення ZIP-Файлу у об'єкт OLE
        public static void ZipToByteArray(DataRow dr, String field, String fileName) {
            if (fileName != null) {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] b = new byte[(int)(fs.Length)];
                fs.Read(b,0,b.Length);
                dr[field] = b;
                fs.Close();
            }
        }
    }
}
