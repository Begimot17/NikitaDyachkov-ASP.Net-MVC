using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public User()
        {
        }
        public User(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Pass = pass;
        }
    }
}
