using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Authentication
{
    public class Connection
    {
        // Connection Secara Global
        public static string connectionString = "Data Source=LAPTOP-8IGJNOSS;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        public static SqlConnection connection = new SqlConnection(connectionString);
    }
}