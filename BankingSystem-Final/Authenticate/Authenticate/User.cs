
namespace Authenticate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // User class to store User login details
    public class User
    {
        // User Name
        public string name;

        // User Password 
        public string password;

        // User Type
        public string type;

        public User()
        { }
        public User(string n, string p, string t)
        {
            this.name = n;
            this.password = p;
            this.type = t;
        }
    }
}
