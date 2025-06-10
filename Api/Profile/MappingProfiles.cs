using AutoMapper;
using Application.DTOs;
using Domain.Entities; 
using Application.DTOs.Chapters;
using Application.DTOs.Surveys;
using Application.DTOs.Questions;
using Application.DTOs.Options_response;
using Application.DTOs.Categories_catalog;
using Application.DTOs.Sub_questions;



namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Mapeos entre entidades y DTOs

        CreateMap<Surveys, SurveysDTO>().ReverseMap();
        CreateMap<Surveys, CreateSurveysDTO>().ReverseMap();
        CreateMap<Chapters, ChaptersDTO>().ReverseMap();
        CreateMap<Chapters, CreateChaptersDTO>().ReverseMap();
        CreateMap<Questions, QuestionsDTO>().ReverseMap();
        CreateMap<Questions, CreateQuestionsDTO>().ReverseMap();
        CreateMap<Options_response, Options_responseDTO>().ReverseMap();
        CreateMap<Options_response, CreateOptions_responseDTO>().ReverseMap();
        CreateMap<Categories_catalog, Categories_catalogDTO>().ReverseMap();
        CreateMap<Categories_catalog, CreateCategories_catalogDTO>().ReverseMap();
        // Add 
        CreateMap<Sub_questions, Sub_questionsDTO>().ReverseMap();
        CreateMap<Sub_questions, CreateSub_questionsDTO>().ReverseMap();



    }
}
