using TM.Data.Interfaces;
using TM.Data.Models;


namespace TM.Data
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(StoreManagementDbContext context): base(context)
        {

        }
    }
}
