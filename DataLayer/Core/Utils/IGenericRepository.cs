﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Utils
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T?> GetById(int? Id);
        Task<bool> Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
