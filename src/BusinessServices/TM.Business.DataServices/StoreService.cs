using AutoMapper;
using TM.Business.Interfaces;
using TM.Business.Models;
using TM.Data.Interfaces;
using TM.Data.Models;

namespace TM.Business.DataServices
{
    public class StoreService : GenericService<StoreModel, Store>, IStoreService
    {
        public StoreService(IRepository<Store> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}