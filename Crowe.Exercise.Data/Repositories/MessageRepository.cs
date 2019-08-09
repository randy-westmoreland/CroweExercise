using Crowe.Exercise.Data.Contracts;
using Crowe.Exercise.Data.Entities;
using System;
using System.Linq;

namespace Crowe.Exercise.Data.Repositories
{
    /// <summary>
    /// MessageRepository Class.
    /// </summary>
    /// <seealso cref="IMessageRepository" />
    public class MessageRepository : IMessageRepository
    {
        private CroweExerciseDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MessageRepository(CroweExerciseDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Add(MessageEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete(MessageEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable<MessageEntity></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<MessageEntity> GetAll() => throw new NotImplementedException();

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>MessageEntity</returns>
        /// <exception cref="NotImplementedException"></exception>
        public MessageEntity GetEntity(string key) => throw new NotImplementedException();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>int</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(MessageEntity entity) => throw new NotImplementedException();

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        ~MessageRepository()
        {
            Dispose(false);
        }
    }
}