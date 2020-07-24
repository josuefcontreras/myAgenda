using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAgenda
{
    class Conexion
    {
       public static SqliteConnection connectar()
       {
            string db = Application.StartupPath + "\\myagenda.db";
            SqliteConnection cn = new SqliteConnection($"Data Source={db}");
            return cn;
       }
    }
}
