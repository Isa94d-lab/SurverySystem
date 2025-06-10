using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Option_questions
{
    public class Option_questionsDTO
    {
        public int Id { get; set; }
        public int Option_id { get; set; }
        public int Optioncatalog_id { get; set; }
        public int Optionquestions_id { get; set; }
        public int Subquestion_id { get; set; }
        public string? Comment_optionres { get; set; }
        public string? Numberoption { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
