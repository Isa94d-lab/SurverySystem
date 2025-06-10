using AutoMapper;
using Application.DTOs;
using Domain.Entities; 
using Application.DTOs.Chapters;
using Application.DTOs.Surveys;



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
    }
}
