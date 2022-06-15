using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desu
{
    internal class User
    {
        public int id
        {
            get; set;
        }

        private string login;
        private string password;
        private string email;
        private int role;

        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Role { get { return role; } set { role = value; } }

        public User() { }

        public User(string login, string password, string email, int role)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.role = role;
        }

    }
}
