using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categories_catalog : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? Name { get; set; }

        // Relaciones
        public List<Category_options> Category_options { get; set; } = new();
        public List<Option_questions> Option_questions { get; set; } = new();
    }
}