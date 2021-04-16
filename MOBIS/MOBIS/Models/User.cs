using System;
using System.Collections.Generic;
using System.Text;

namespace MOBIS.Models
{
    public class User
    {
        public int Id { get; set; }

        public bool Exists { get; set; }

        public string Key { get; set; }

        public string Email { get; set; }

        private string Password { get; set; }

        public User()
        {

        }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
