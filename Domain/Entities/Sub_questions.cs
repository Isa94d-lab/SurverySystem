using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sub_questions
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int Subquestion_id { get; set; }
        public string? Subquestion_number { get; set; }
        public string? Comment_subquestion { get; set; }
        public string Subquestiontext { get; set;}
    }
}