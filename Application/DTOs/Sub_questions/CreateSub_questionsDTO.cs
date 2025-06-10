using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Sub_questions
{
    public class CreateSub_questionsDTO
    {
        public int Questions_id { get; set; }
        public string? Subquestion_number { get; set; }
        public string? Comment_subquestion { get; set; }
        public string? Subquestiontext { get; set; }
    }
}
