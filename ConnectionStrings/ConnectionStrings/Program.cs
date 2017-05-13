using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder();
            constr.DataSource = ".\\SQLEXPRESS";
            constr.InitialCatalog = "Users";
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = constr.ConnectionString;
                connection.Open();

            }
            
        }
    }
}
