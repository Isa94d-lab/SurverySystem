using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Surveys
{
    public class CreateSurveysDTO
    {
        public string? Componentreact { get; set; }
        public string? Componenthtml { get; set; }
        public string? Description { get; set; }
        public string? Instruction { get; set; }
        public string? Name { get; set; }
        
    }
}