using AutoMapper;
using Application.DTOs;
using Domain.Entities; 
using Application.DTOs.Chapters;
using Application.DTOs.Surveys;
using Application.DTOs.Questions;




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
    }
}
