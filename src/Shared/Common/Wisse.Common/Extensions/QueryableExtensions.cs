using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wisse.Common.Models;

namespace Wisse.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> AddPagination<TEntity>(
        this IQueryable<TEntity> query,
        Pagination pagination)
    {
        if (pagination is not null)
        {
            return query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize);
        }

        var defaultPagination = new Pagination();
        return query
            .Skip(defaultPagination.Skip)
            .Take(defaultPagination.PageSize);
    }

    public static IQueryable<TEntity> AddIncludes<TEntity>(
        this IQueryable<TEntity> query,
        params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
    {
        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }
}
