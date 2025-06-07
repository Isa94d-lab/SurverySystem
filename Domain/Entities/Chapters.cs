using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chapters : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int survey_id { get; set; }
        public Surveys? Surveys { get; set; }
        public string? Componenthtml { get; set; }
        public string? Componentreact { get; set; }
        public string? Chapter_number { get; set; }
        public string? Chapter_title { get; set; }
        public ICollection<Questions>? Questions { get; set; }

    }
}