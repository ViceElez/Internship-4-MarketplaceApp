using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Users
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            ID = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
