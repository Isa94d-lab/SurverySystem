using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category_options
    {
        public int Id { get; set; }
        public int Catalogoptions_id { get; set; }
        public Categories_catalog Categories_Catalog { get; set; }
        public int Categoriesoptions_id { get; set; }
        public Options_response Options_Response { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        
    }
}