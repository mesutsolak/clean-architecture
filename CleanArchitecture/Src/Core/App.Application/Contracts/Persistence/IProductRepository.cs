﻿namespace App.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product, int>
{
    Task<List<Product>> GetTopPriceProductsAsync(int count);
}
