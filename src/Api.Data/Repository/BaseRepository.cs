using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryOptions;
using Domain.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        private string _table;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();

            var entityType = _context.Model.FindEntityType(typeof(T));
            var schema = entityType.GetSchema();
            _table = entityType.GetTableName();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryOptions> SelectAsync(IQueryOptions query)
        {
            try
            {
                int skip = query.Pagination.PageSize * (query.Pagination.Page - 1);
                

                // var exp = ExpressionUtils.BuildPredicate<T>("slug", "Contains", "insert");

                // var r = await _dataset.Where(ExpressionUtils.BuildPredicate<T>("name", "Contains", "Usu")).Skip(skip).Take(query.Pagination.PageSize).ToListAsync();
                // var r = await _dataset.Where("Name.Contains(@0)", "Inse").OrderBy(query.OrderBy.Field).Skip(skip).Take(query.Pagination.PageSize).ToListAsync();


                var ord  = query.OrderBy.GetOrderString();

                var querys = query.Query.GetQueryString();

                var _dataset1 = _dataset.AsTracking();


                if (!string.IsNullOrEmpty(ord))
                    _dataset1 = _dataset.OrderBy(ord);
                
                _dataset1 = _dataset1.Skip(skip).Take(query.Pagination.PageSize);


                // dynamic r = null;
                // dynamic filtro = null;
                // if ((order_ != null) && (filtro != null))
                //     r = await f.Skip(skip).Take(query.Pagination.PageSize).ToListAsync();
                // else
                //     r = await _dataset.OrderBy(ord).Skip(skip).Take(query.Pagination.PageSize).ToListAsync();

                // IQueryable<T> a = await _dataset.OrderBy(query.OrderBy.Field).Skip(skip);.Take(query.Pagination.PageSize);

                // if (!String.IsNullOrWhiteSpace(query.OrderBy.Field))
                //     var r = await _dataset.OrderBy(query.OrderBy.Field).Skip(skip);.Take(query.Pagination.PageSize).ToListAsync();
                // else
                //     var r = await _dataset.Skip(skip).Take(query.Pagination.PageSize).ToListAsync();

                query.Pagination.Records = _dataset.Count();

                query.Rows = await _dataset1.ToListAsync();
                return query;

                //var skip = (query.Pagination.PageSize * (query.Pagination.Page - 1));
                //string limit = $"LIMIT {query.Pagination.PageSize} OFFSET {skip}";

                //var _query = "";
                //if (query.IsQuery())
                //{
                //    _query = query.Query.GetQueryString();
                //    if (!string.IsNullOrEmpty(_query))
                //        _query = $" WHERE {_query} ";
                //}

                //var sql = $"SELECT * FROM {_table} {_query} {query.GetOrder()} {limit} ";
                //var qtd = await _context.Database.ExecuteSqlRawAsync($"SELECT * FROM {_table} {_query}");
                //// query.Pagination.Records = qtd. .Count;
                //query.Rows = await _dataset.FromSqlRaw(sql).ToListAsync();
                //return query;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
