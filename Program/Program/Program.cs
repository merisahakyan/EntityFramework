using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UserModelContainer())
            {
                var user = new User { username = "name" };
                context.Users.Add(user);
                context.SaveChanges();

            }
        }
    }
}
