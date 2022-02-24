using AutoMapper;
using MotivappAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DaimlerHub.Api.MappingProfiles
{
    public class MotivappProfile : Profile
    {
        public MotivappProfile()
        {
            CreateMap<MotivappData.Models.User, UserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.AvatarURL, opt => opt.MapFrom(src => src.AvatarURL))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => GetCategories(src)))            
                .ForMember(dest => dest.TotalPoints, opt => opt.MapFrom(src => GetTotalPoints(src)));

            CreateMap<MotivappData.Models.Milestone, Milestone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.EarnedAt, opt => opt.MapFrom(src => src.EarnedAt))
                .ForMember(dest => dest.EarnedPoints, opt => opt.MapFrom(src => src.EarnedPoints));

            CreateMap<MotivappData.Models.Category, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AvatarURL, opt => opt.MapFrom(src => src.AvatarURL))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));

            CreateMap<MotivappData.Models.User, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.AvatarURL, opt => opt.MapFrom(src => src.AvatarURL));
        }

        private int GetTotalPoints(MotivappData.Models.User user)
        {
            return user.Milestones.Sum(x => x.EarnedPoints);
        }

        private List<UserCategory> GetCategories(MotivappData.Models.User user)
        {
            var categories = new List<UserCategory>();
            var milestonesByCategory = user.Milestones.GroupBy(x => x.Category.Id).ToList();
            
            foreach(var category in milestonesByCategory)
            {
                categories.Add(new UserCategory()
                {
                    Id = category.Key,
                    AvatarURL = category.First().Category.AvatarURL ,
                    EarnedPoints = category.Sum(x => x.EarnedPoints),
                    NeededPoints = category.First().Category.NeededPoints,
                    Name = category.First().Category.CategoryName
                });
            };

            return categories;
        }
    }
}
