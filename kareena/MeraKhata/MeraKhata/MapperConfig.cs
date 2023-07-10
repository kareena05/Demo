
using MeraKhata.Models;
using AutoMapper;
using MeraKhata.Model;

namespace MeraKhata
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity,UserModel>().ReverseMap();
            CreateMap<BackUpEntity, BackUpModel>().ReverseMap();

        }
    }
}
