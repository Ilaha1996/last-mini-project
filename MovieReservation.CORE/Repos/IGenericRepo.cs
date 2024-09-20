﻿using MovieReservation.CORE.Entities;
using System.Linq.Expressions;

namespace MovieReservation.CORE.Repos;

public interface IGenericRepo<TEntity> where TEntity : BaseEntity, new()
{
    //public DbSet<TEntity> Table { get; }
    Task CreateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
    IQueryable<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
    Task<TEntity> GetByIdAsync(int id);
    Task<int> CommitAsync();
}
