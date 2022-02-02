using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class DbHelper
    {
        Connection conn = new Connection();

        public int execute(string query, bool addDate = false, string paramName = "")
        {

            SqlConnection cnn = conn.getConnection();
            conn.openConn();
            SqlCommand cmd = new SqlCommand(query, conn.getConnection());
            if (addDate)
            {
                cmd.Parameters.AddWithValue(paramName, DateTime.Now);
            }
            int res = cmd.ExecuteNonQuery();
            conn.closeConn();
            return res;
        }

        public int executeSqlCommand(SqlCommand cmd)
        {
            conn.openConn();
            cmd.Connection = conn.getConnection();
            int res = cmd.ExecuteNonQuery();
            conn.closeConn();
            return res;
        }
        public DataTable tableFromCommand(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            conn.openConn();
            cmd.Connection = conn.getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.closeConn();
            return dt;
        }
        
        public object executeScalar(string query, bool addDate = false, string paramName = "")
        {

            SqlConnection cnn = conn.getConnection();
            conn.openConn();
            SqlCommand cmd = new SqlCommand(query, conn.getConnection());
            if (addDate)
            {
                cmd.Parameters.AddWithValue(paramName, DateTime.Now);
            }
            var res = cmd.ExecuteScalar();
            conn.closeConn();
            return res;
        }

        public SqlDataReader read(string query)
        {
            conn.openConn();
            SqlConnection cnn = conn.getConnection();
            SqlCommand cmd = new SqlCommand(query, cnn);
           
            SqlDataReader res = cmd.ExecuteReader();
            
            return res;
        }

        public DataTable getTable(string query)
        {
            conn.openConn();
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            conn.closeConn();
            return table;
        }

        public string getRandomID(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
