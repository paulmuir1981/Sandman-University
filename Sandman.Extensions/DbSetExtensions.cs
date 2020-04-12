using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Sandman.Extensions
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Finds an entity with the given primary key value. If an entity with 
        /// the given primary key value is being tracked by the context, then it 
        /// is returned immediately without making a request to the database. 
        /// Otherwise,  query is made to the database for an entity with the 
        /// given primary key value and this entity, if found, is attached to 
        /// the context and returned. If no entity is found, then null is 
        /// returned.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="set">The DbSet of entities</param>
        /// <param name="keyValue">The primary key value</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>If found the entity, otherwise null</returns>
        public static ValueTask<TEntity> FindByKeyValueAsync<TEntity>(
            this DbSet<TEntity> set, 
            object keyValue, 
            CancellationToken cancellationToken = default) where TEntity : class
        {
            return set.FindAsync(new object[] { keyValue }, cancellationToken);
        }
    }
}