﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(
            Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> include = null);
        Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task HardDeleteAsync(TEntity entity);
        Task<int> GetCountAsync(
            Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> include = null
        );
    }
}
