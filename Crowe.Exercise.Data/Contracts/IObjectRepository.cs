using System;
using System.Linq;

namespace Crowe.Exercise.Data.Contracts
{
    /// <summary>
    /// IObjectRepository Class.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <seealso cref="IDisposable" />
    public interface IObjectRepository<TSource> : IDisposable where TSource : IEntity
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable<TSource></returns>
        IQueryable<TSource> GetAll();

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>TSource</returns>
        TSource GetEntity(string key);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        int Add(TSource entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        int Update(TSource entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        int Delete(TSource entity);
    }
}