using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    ICategories_catalogRepository Categories_catalogs { get; }
    ICategory_optionsRepository Category_options { get; }
    IChaptersRepository Chapters { get; }
    ISurveysRepository Surveys { get; }
    IOptions_responseRepository Options_response { get; }

    // Add
    IQuestionsRepository Questions { get; }
    // ---
    Task<int> SaveAsync();
}
