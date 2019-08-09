using Crowe.Exercise.Data.Config;
using Crowe.Exercise.Data.Contracts;
using Crowe.Exercise.Data.Entities;
using System;
using System.Data.Entity;

namespace Crowe.Exercise.Data
{
    /// <summary>
    /// CrowExerciseDbContext Class.
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="IDbContext" />
    public class CroweExerciseDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CroweExerciseDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public CroweExerciseDbContext(string connectionString) : base(connectionString)
        {
            // ...
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public DbSet<MessageEntity> Messages { get; set; }

        /// <summary>
        /// Sets the modified.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetModified(object entity) => throw new NotImplementedException();

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder?.Configurations.Add(new CroweExerciseMessagesConfig());
        }
    }
}