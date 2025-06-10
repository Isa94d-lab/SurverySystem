using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Sub_questions
{
    public class Sub_questionsDTO
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int Questions_id { get; set; }
        public string? Subquestion_number { get; set; }
        public string? Comment_subquestion { get; set; }
        public string? Subquestiontext { get; set; }
    }
}
