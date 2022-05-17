namespace Authenticate
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Class to  authenticate user logic  details 
    public class UserVerification : User
    {
        // Store all Users data
        private List<User> users = new List<User>();

        public UserVerification(string path)
        {
            this.readFile(path);
        }

        // Read the users from db
        public void readFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Read and store all records from the file.
                string line = "";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] portion = line.Split();
                        this.users.Add(new User(portion[0], portion[1], portion[2]));
                    }
                }
            }
        }

        // Search the user with name,password and type
        public bool find(string name, string pass, string type)
        {
            foreach(User i in users)
            {
                if (i.name == name && i.password == pass && i.type == type)
                    return true;
            }
            return false;
        }
    }
}
