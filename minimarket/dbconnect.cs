using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace minimarket
{
    internal class dbconnect
    {

        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zakin\Documents\minimarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        public SqlConnection GetCon()
        {
            return connection;
        }
        public void opencon()
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
    
        }
        public void closecon()
        {
            if(connection.State==System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }

}
