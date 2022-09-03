using AutoMapper;

namespace RatingAPI.Mapper
{
    public class BillsProfile : Profile
    {
        public BillsProfile()
        {
            CreateMap<Entities.Bills, Models.BillsDto>();
            CreateMap<Models.BillsDto, Entities.Bills>();
            CreateMap<Models.PostBillsDto, Entities.Bills>();
            CreateMap<Models.PutBillsDto, Entities.Bills>();
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserDto, Entities.User > ();
            CreateMap<Models.PostUserDto, Entities.User>();
        }
    }
}
