using TM.Business.Models;

namespace TM.Business.Interfaces
{
    public interface IProductService : IGenericService<ProductModel>
    {
        public List<ProductModel> Search(string searchTerm);
        public List<ProductModel> ProductsForStore(int storeId, string? searchTerm);
    }
}
