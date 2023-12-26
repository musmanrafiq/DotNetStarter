using TM.Data.Interfaces;
using TM.Data.Models;

namespace TM.Data
{
    public class StoreRepository : Repository<Store>,IStoreRepository
    {
        public StoreRepository(StoreManagementDbContext context): base(context)
        {
        }
    }
}
