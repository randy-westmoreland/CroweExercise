using Crowe.Exercise.Data.Entities;

namespace Crowe.Exercise.Data.Contracts
{
    public interface IMessageRepository : IObjectRepository<MessageEntity>
    {
        // Custom Repository methods specific to MessageRepository.
    }
}