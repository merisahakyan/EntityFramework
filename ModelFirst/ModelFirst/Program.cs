using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UserContainer())
            {
                var user = new User { username = "name" };
                context.Users.Add(user);
                
                context.SaveChanges();
            }
        }
    }
}
