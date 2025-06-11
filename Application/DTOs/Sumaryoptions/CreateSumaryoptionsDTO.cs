using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Sumaryoptions
{
    public class CreateSumaryoptionsDTO
    {
        public int Id_survey { get; set; }
        public string? Code_number { get; set; }
        public int Idquestion { get; set; }
        public string? Valuerta { get; set; }
    }
}