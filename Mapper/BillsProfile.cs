using AutoMapper;

namespace RatingAPI.Mapper
{
    public class BillsProfile : Profile
    {
        public BillsProfile()
        {
            CreateMap<Entities.Bills, Models.BillsDto>(); //DTOs no me funciona
            CreateMap<Models.BillsDto, Entities.Bills>();
            CreateMap<Models.PostBillsDto, Entities.Bills>();
            CreateMap<Models.PutBillsDto, Entities.Bills>();
        }
    }
}
