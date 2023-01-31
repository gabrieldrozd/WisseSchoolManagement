using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wisse.Common.Domain.Primitives;
using Wisse.Common.Models.Pagination;

namespace Wisse.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> AddPagination<TEntity>(
        this IQueryable<TEntity> query,
        Pagination pagination)
    where TEntity : Entity
    {
        if (pagination is not null)
        {
            return query
                .OrderBy(x => x.Id, pagination.IsAscending)
                .Skip(pagination.Skip)
                .Take(pagination.PageSize);
        }

        var defaultPagination = new Pagination();
        return query
            .OrderBy(x => x.Id, defaultPagination.IsAscending)
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

    public static IQueryable<TEntity> OrderBy<TEntity>(
        this IQueryable<TEntity> query,
        Expression<Func<TEntity, object>> keySelector,
        bool isAscending)
        where TEntity : class
    {
        return isAscending
            ? query.OrderBy(keySelector)
            : query.OrderByDescending(keySelector);
    }
}