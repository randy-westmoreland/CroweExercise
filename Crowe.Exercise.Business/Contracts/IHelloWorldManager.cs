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
        /// <param name="message">The message.</param>
        /// <returns>
        /// int
        /// </returns>
        int AddMessage(MessageDomainModel message);
    }
}