using Crowe.Exercise.Data.Entities;
using System;
using System.Data.Entity;

namespace Crowe.Exercise.Data.Contracts
{
    /// <summary>
    /// IDbContext Class.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        DbSet<MessageEntity> Messages { get; set; }

        /// <summary>
        /// Sets the modified.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void SetModified(object entity);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}