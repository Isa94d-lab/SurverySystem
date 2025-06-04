using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Option_questions
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public int Option_id { get; set; }
        public Options_response Options_Response { get; set; }
        public int Optioncatalog_id { get; set; }
        public Categories_catalog Categories_Catalog { get; set; }
        public int Optionquestions_id { get; set; }
        public Option_questions Option_Questions { get; set; }
        public int Subquestion_id { get; set; }
        public Sub_questions Sub_Questions { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Comment_optionres { get; set; }
        public string? Numberoption { get; set; }
    }
}