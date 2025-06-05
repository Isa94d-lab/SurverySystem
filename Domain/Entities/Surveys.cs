using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Surveys
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Componentreact { get; set; }
        public string? Componenthtml { get; set; }
        public string description { get; set; }
        public string? instruction { get; set; }
        public string name { get; set; }
        public ICollection<Chapters> Chapters { get; set; }

    }
}