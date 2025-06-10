using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Chapters
{
    public class CreateChaptersDTO
    {
        public int Survey_id { get; set; }
        public string? Componenthtml { get; set; }
        public string? Componentreact { get; set; }
        public string? Chapter_number { get; set; }
        public string? Chapter_title { get; set; }
    }


}