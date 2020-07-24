using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                string query = $"INSERT INTO directorio(nombre, telefono) VALUES('{nombre}', '{telefono}')";
                cn = Conexion.connectar();
                cn.Open();
                cmd = new SqliteCommand(query, cn);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if(cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
            return false;
        }
        public DataTable consultar ()
        {
            try
            {
                string query = "SELECT * FROM Directorio";
                cn = Conexion.connectar();
                cn.Open();
                cmd = new SqliteCommand(query, cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(new object[] { reader["id"], reader["nombre"], reader["telefono"] });
                }
                reader.Close();
                cn.Close();
                return table;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if(cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return table;
        }
        public bool eliminar(int id)
        {
            try
            {
                string query = $"DELETE FROM directorio WHERE id = '{id}'";
                cn = Conexion.connectar();
                cn.Open();
                cmd = new SqliteCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
            return false;
        }
        public DataTable filtrar(string filtro)
        {
            return new DataTable();
        }
        public bool actualizar(int id, string nombre, string telefono)
        {
            try
            {
                string query = $"UPDATE directorio SET nombre='{nombre}', telefono='{telefono}' WHERE id = '{id}'";
                cn = Conexion.connectar();
                cn.Open();
                cmd = new SqliteCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }

        private void nombresColumnas()
        {
            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Nombre");
            table.Columns.Add("Telefono");
        }
    }
}
