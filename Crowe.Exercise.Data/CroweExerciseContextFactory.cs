using System.Data.Entity.Infrastructure;

namespace Crowe.Exercise.Data
{
    /// <summary>
    /// CroweExerciseContextFactory Class.
    /// </summary>
    /// <seealso cref="IDbContextFactory{CroweExerciseDbContext}" />
    public class CroweExerciseContextFactory : IDbContextFactory<CroweExerciseDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived <see cref="T:System.Data.Entity.DbContext" /> type.
        /// </summary>
        /// <returns>
        /// An instance of TContext
        /// </returns>
        public CroweExerciseDbContext Create() => new CroweExerciseDbContext("[connectionString]");
    }
}