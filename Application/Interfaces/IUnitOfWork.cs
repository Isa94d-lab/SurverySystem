using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    ICategories_catalogRepository Categories_catalogs { get; }
    ICategory_optionsRepository Category_options { get; }
    // Add
    IChaptersRepository Chapters { get; }   
    // ---
    Task<int> SaveAsync();
}
