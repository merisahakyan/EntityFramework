using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var connection = new SqlConnection("Data Source=.\\SQLEXPRESS ; Initial Catalog=Users; Integrated Security= true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                string password = "aniani";
                command.CommandText = $"Insert into MyUsers (Name,eMail,Password) values('Ani','Barseghyan','{password.GetHashCode()}')";
                command.Transaction = connection.BeginTransaction();
                command.ExecuteNonQuery();
            }
        }
    }
}
