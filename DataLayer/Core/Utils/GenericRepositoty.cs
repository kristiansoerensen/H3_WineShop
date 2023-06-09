﻿using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Utils
{
    public abstract class GenericRepositoty<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> _dbContext;
        //protected ILogger _logger;

        public GenericRepositoty(
            AppDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<T>();
        }

        // With Logger
        //public GenericRepositoty(
        //    WineStoreContext context,
        //    ILogger logger)
        //{
        //    _context = context;
        //    _logger = logger;
        //    this._dbSet = _context.Set<T>();
        //}

        public virtual async Task<bool> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            _dbContext.Remove(entity);
            return true;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.AsNoTracking();
        }

        public virtual async Task<T?> GetById(int Id)
        {
            return await _dbContext.FindAsync(Id);
        }

        public virtual bool Update(T entity)
        {
            _dbContext.Update(entity);
            return true;
        }
    }
}
