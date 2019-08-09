using Crowe.Exercise.Data.Entities;
using Crowe.Exercise.Model.Domain;

namespace Crowe.Exercise.Business.Contracts
{
    /// <summary>
    /// IHelloWorldManager Class.
    /// </summary>
    public interface IHelloWorldManager
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>MessageDomainModel</returns>
        MessageDomainModel GetMessage();

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        int AddMessage(MessageEntity entity);
    }
}