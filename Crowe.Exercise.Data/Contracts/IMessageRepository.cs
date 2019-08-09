using Crowe.Exercise.Data.Entities;

namespace Crowe.Exercise.Data.Contracts
{
    /// <summary>
    /// IMessageRepository Interface.
    /// </summary>
    /// <seealso cref="IObjectRepository{MessageEntity}" />
    public interface IMessageRepository : IObjectRepository<MessageEntity>
    {
        // Custom Repository methods specific to MessageRepository.
    }
}