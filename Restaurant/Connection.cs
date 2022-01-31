using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Restaurant
{
     
    internal class Connection
    {
        public SqlConnection cnn;
        public Connection()
        {
            string connectionString = @"Data Source=DESKTOP-7FQB5RK\SQLEXPRESS;Initial Catalog=Restaurant;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
        }

        public SqlConnection getConnection() { return cnn; }

        public void openConn() { 
            if(cnn.State == System.Data.ConnectionState.Closed) { 
                cnn.Open(); 
            }
        }
        public void closeConn() { 
            if(cnn.State == System.Data.ConnectionState.Open) { 
                cnn.Close(); 
            }
        }
    }    
}
