using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Option_questions : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public int Option_id { get; set; }
        public Options_response? Options_response { get; set; }

        public int Optioncatalog_id { get; set; }
        public Categories_catalog? Categories_catalog { get; set; }

        public int Optionquestions_id { get; set; } 
        public Questions? Questions { get; set; }

        // 🔁 Aquí está la propiedad que faltaba
        public Option_questions? Parent_option_question { get; set; }

        public ICollection<Option_questions>? Inverse_option_questions { get; set; }

        public int Subquestion_id { get; set; }
        public Sub_questions? Sub_questions { get; set; }

        public string? Comment_optionres { get; set; }
        public string? Numberoption { get; set; }
    }
}
