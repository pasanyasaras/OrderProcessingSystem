using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderProcessingSystem.BL
{
    public class User
    {
        private string username;
        private string email;
        private string password;

        public User(string uname, string em, string pwd)
        {
            this.username = uname;
            this.email = em;
            this.password = pwd;
        }
        
        public string getUsername()
        {
            return username;
        }

        public string getEmail()
        {
            return email;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
