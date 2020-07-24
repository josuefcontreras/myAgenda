using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Agenda
    {
        private SqliteConnection cn = null; // Para 
        private SqliteCommand cmd = null; // Para 
        private SqliteDataReader reader = null; // Para 
        private DataTable table = null; // Para

        public bool insertar(string nombre, string telefono)
        {
            return false;
        }
        public DataTable consultar ()
        {
            return new DataTable();
        }
        public bool eliminar(int id)
        {
            return false;
        }
        public DataTable filtrar(string filtro)
        {
            return new DataTable();
        }
        public bool actualizar(int id, string nombre, string telefono)
        {
            return false;
        }

        private void nombresColumnas()
        {

        }
    }
}
