using AutoMapper;
using Application.DTOs;

namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Mapeos entre entidades y DTOs


        CreateMap<Surveys, SurveysDTO>().ReverseMap();
        CreateMap<Sub_questions, Sub_questionsDTO>().ReverseMap();
        CreateMap<Questions, QuestionsDTO>().ReverseMap();
        CreateMap<Option_response, Option_responseDTO>().ReverseMap();
        CreateMap<Option_questions, Option_questionsDTO>().ReverseMap();
        CreateMap<Category_options, Category_optionsDTO>().ReverseMap();
        CreateMap<Category_catalog, Category_catalogDTO>().ReverseMap();

        
    }
}