using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User_role
    {
        public Guid User_id { get; set; }
        public User User { get; set; }

        public Guid Role_id { get; set; }
        public Role Role { get; set; }
    }
}