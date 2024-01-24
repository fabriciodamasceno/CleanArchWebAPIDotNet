﻿using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Product>> GetCategories();
        Task<Product> GetById(int id);

        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Remove(Product category);
    }
}
