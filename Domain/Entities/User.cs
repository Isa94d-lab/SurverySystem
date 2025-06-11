using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid id { get; set; }
        public string Email { get; set; }
        public string Password_hash { get; set; }

        public ICollection<user_role> User_roles { get; set; }

    }
}