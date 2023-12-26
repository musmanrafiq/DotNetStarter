using AutoMapper;
using TM.Business.Models;
using TM.Data.Models;


namespace TM.Business.DataServices
{
    public class BusinessEntityMappings : Profile
    {
        public BusinessEntityMappings()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<StoreModel, Store>().ReverseMap();
        }
    }
}
