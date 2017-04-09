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


            //Entity (DataBase First)
            using (var context = new UsersEntities())
            {
                //read data using Entity 
                var users = context.MyUsers.ToList();
                foreach (var user in users)
                    Console.WriteLine(user.eMail);

                //adding new element
                MyUser myuser = new MyUser();
                myuser.Name = "name";
                myuser.eMail = "email";
                myuser.Password = "password";

                context.MyUsers.Add(myuser);

                //removing elements
                var delete_users = from b in context.MyUsers
                                   where b.Name == "name"
                                   select b;
                foreach (var m in delete_users)
                    context.MyUsers.Remove(m);

                //you can also write SQL command and execute like this
                context.Database.ExecuteSqlCommand("insert into MyUsers(Name, eMail, Password) Values('name', 'email', 'password')");

                context.SaveChanges();

                // some needful commands in SQL
                //
                // for adding new element
                // insert into Table_Name(Column_1, Column_2, ...) Values('value_1', 'value_2', ...)
                //
                // for deleting element(s)
                // delete from Table_Name where Column_name='value'
                //
                // to change something with given value
                // update Table_Name set column_name='new value' where column_name='given_value' (or another_column_name='value')

            }

        }
    }
}
