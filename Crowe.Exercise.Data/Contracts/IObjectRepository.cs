using System;
using System.Collections.Generic;

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
        /// <returns></returns>
        IList<TSource> GetAll();

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TSource GetEntity(string key);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        int Add(TSource entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        int Update(TSource entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        int Delete(TSource entity);
    }
}