using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sumaryoptions : BaseEntity
    {
        public int Id { get; set; }
        public int Id_survey { get; set; }
        public Surveys? Surveys { get; set; }
        public string? Code_number { get; set; }
        public int Idquestion { get; set; }
        public string? Valuerta { get; set; }
    }
}