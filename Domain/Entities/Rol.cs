using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Rol : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<MemberRols> MemberRols { get; set; } = new HashSet<MemberRols>();
    }
}