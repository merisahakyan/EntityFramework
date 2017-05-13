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
            constr.IntegratedSecurity = true;

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = constr.ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM MyUsers", connection);
                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {

                    for (i = 0; i < reader.FieldCount; i++)
                        Console.WriteLine(reader.GetName(i) + ":" + reader[reader.GetName(i)]);
                }
            }
            Console.ReadLine();
        }
    }
}
