using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Questions
{
    public class CreateQuestionsDTO
    {
        public int Chapter_id { get; set; }
        public string? Question_number { get; set; }
        public string? Response_type { get; set; }
        public string? Comment_question { get; set; }
        public string? Question_text { get; set; }
    }
}
