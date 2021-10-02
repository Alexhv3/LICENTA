using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHarmony.Globals
{
    class SQLiteConnection
    {
        /*private static SQLiteConnection _inst = null;
        private SQLiteConnection _conn = null;

        private SQLiteConnection()
        {
            if (!File.Exists("appdb.sqlite3"))
            {
                SQLiteConnection.CreateFile("appdb.sqlite3");
            }
            try
            {
                open();
                string sql = "CREATE TABLE IF NOT EXISTS system(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, property TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, _conn);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void open()
        {
            if (_conn == null)
            {
                _conn = new SQLiteConnection("Data Source=appdb.sqlite3");
                _conn.Open();
            }
        }

        private void close()
        {
            if (null != _conn)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        public static SQLiteConnection Instance
        {
            get
            {
                if (_inst != null)
                {
                    return _inst;
                }
                return null;
            }
        }

        public static dynamic InstanceInit
        {
            set
            {
                if (_inst == null)
                {
                    _inst = new SQLiteConnection();
                }
            }
        }*/
    }
}
