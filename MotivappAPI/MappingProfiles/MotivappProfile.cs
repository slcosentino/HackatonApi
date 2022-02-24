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
        }

        private int GetTotalPoints(MotivappData.Models.User user)
        {
            return user.Milestones.Sum(x => x.EarnedPoints);
        }

        private List<Category> GetCategories(MotivappData.Models.User user)
        {
            var categories = new List<Category>();
            var milestonesByCategory = user.Milestones.GroupBy(x => x.Category.Id).ToList();
            
            foreach(var category in milestonesByCategory)
            {
                categories.Add(new Category()
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
