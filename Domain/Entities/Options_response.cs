using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Options_response : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Optiontext { get; set; }
         public ICollection<Option_questions>? Option_Questions { get; set; }
    }
}