﻿using AutoMapper;
using TM.Business.Interfaces;
using TM.Business.Models;
using TM.Data;
using TM.Data.Interfaces;
using TM.Data.Models;

namespace TM.Business.DataServices
{
    public class ProductService : GenericService<ProductModel, Product>, IProductService
    {
        private readonly IRepository<Product> _repositry;

        public ProductService(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
            _repositry = repository;
        }

        public List<ProductModel> ProductsForStore(int storeId, string? searchTerm)
        {
            var productsQurable = _repositry.Get(x => x.StoreId == storeId);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                productsQurable = productsQurable.Where(x => x.Name.ToLower()
                    .Contains(searchTerm) || x.Description.ToLower()
                    .Contains(searchTerm));
            }
            var productModels = productsQurable.Select(x => new ProductModel
            { Id = x.Id, Name = x.Name, Description = x.Description, StoreId = x.StoreId }).ToList();
            return productModels;
        }

        public List<ProductModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allProducts = _repositry.Get(x => x.Name.ToLower()
                .Contains(searchTerm) || x.Description.ToLower()
                .Contains(searchTerm)).ToList();

            var productModels = allProducts.Select(x => new ProductModel
            { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            return productModels;
        }

    }
}