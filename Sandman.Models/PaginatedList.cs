using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sandman.Models
{
    /// <summary>
    /// Class for Paged data
    /// </summary>
    /// <typeparam name="TModel"> Model type</typeparam>
    public class PaginatedList<TModel> : List<TModel> where TModel : class
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(
            List<TModel> items, 
            int count, 
            int pageIndex, 
            int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }
        /// <summary>
        /// Async creates a paginated list given a quaryable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<PaginatedList<TModel>> CreateAsync(
            IQueryable<TModel> source, 
            int pageIndex, 
            int pageSize, 
            CancellationToken token = default)
        {
            var count = await source.CountAsync(token);
            var items = await source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(token);
            return new PaginatedList<TModel>(
                items, 
                count, 
                pageIndex, 
                pageSize);
        }
    }
}