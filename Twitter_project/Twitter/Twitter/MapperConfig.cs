using AutoMapper;
using Twitter.Models;

namespace Twitter
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User_entity, SaveUserModel>().ReverseMap();
            CreateMap<Tweet_entity, SaveTweetModel>().ReverseMap();
        }
    }
}
