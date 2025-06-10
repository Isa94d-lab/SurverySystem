using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    ICategories_catalogRepository Categories_catalog { get; }
    ICategory_optionsRepository Category_options { get; }
    IChaptersRepository Chapters { get; }
    ISurveysRepository Surveys { get; }
    IOptions_responseRepository Options_response { get; }
    IQuestionsRepository Questions { get; }
    ISub_questionsRepository Sub_questions { get; }
    IOption_questionsRepository Option_questions { get; }
    
    // Add
    ISumaryoptionsRepository Sumaryoptions { get; }
    // ---

    Task<int> SaveAsync();
}
