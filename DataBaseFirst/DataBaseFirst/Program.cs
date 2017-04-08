using DataBaseFirst.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //read data using IDbConnection interface (DataBase First)
            using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
            using (var cmd = connection.CreateCommand())
            {
                IDbCommand command = new SqlCommand("select * from MyUsers ");
                command.Connection = connection;

                connection.Open();

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(2));
                }
                reader.Close();
                //inserting new element
                cmd.CommandText = "insert into MyUsers(Name, eMail, Password) Values('name', 'email', 'password')";
                cmd.ExecuteNonQuery();

            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


            //read data using Entity (DataBase First)
            using (var context = new UsersEntities())
            {
                var users = context.MyUsers.ToList();
                foreach (var user in users)
                    Console.WriteLine(user.eMail);

                //adding new element
                MyUser myuser = new MyUser();
                myuser.Name = "name";
                myuser.eMail = "email";
                myuser.Password = "password";

                context.MyUsers.Add(myuser);
                context.SaveChanges();

                

            }
            
        }
    }
}
