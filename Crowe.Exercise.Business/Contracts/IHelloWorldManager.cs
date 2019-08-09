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
    }
}