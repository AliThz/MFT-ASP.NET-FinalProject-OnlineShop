﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Domain.Contract.Abstracts
{
    public interface IRepository<T_Entity, U_PrimaryKey> where T_Entity : class
    {
        Task InsertAsync(T_Entity entity);
        Task UpdateAsync(T_Entity entity);
        Task DeleteAsync(U_PrimaryKey id);
        Task DeleteAsync(T_Entity entity);
        Task<List<T_Entity>> SelectAsync();
        Task<T_Entity> FindByIdAsync(U_PrimaryKey id);
        Task SaveChanges();
    }
}