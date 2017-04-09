using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirst
{
    public class User
    {
        public int ID { get; set; }
        public string username { get; set; }
    }
    public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UsersContext())
            {
                var user = new User { username = "name" };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
