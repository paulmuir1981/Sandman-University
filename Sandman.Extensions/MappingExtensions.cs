using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sandman.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sandman.Extensions
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Extension method to project from a queryable to a paged list
        /// </summary>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="queryable">The queryable</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default) where TDestination : class
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);

        /// <summary>
        /// Extension method to project from a queryable to a list using the provided mapping engine
        /// </summary>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="configuration">Mapper configuration</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>Expression to project into</returns>
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(
            this IQueryable queryable, 
            IConfigurationProvider configuration, 
            CancellationToken cancellationToken = default)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync(cancellationToken);
    }
}