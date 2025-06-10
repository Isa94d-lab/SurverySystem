using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Category_options
{
    public class Category_optionsDTO
    {
        public int Id { get; set; }
        public int Catalogoptions_id { get; set; }
        public int Categoriesoptions_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
