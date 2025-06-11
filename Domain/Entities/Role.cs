using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public ICollection<user_role> user_roles { get; set; }
        
    }
}