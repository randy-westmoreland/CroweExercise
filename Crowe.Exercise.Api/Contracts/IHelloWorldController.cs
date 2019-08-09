using Crowe.Exercise.Model.Api;
using System.Threading.Tasks;

namespace Crowe.Exercise.Api.Contracts
{
    /// <summary>
    /// IHelloWorldController Interface.
    /// </summary>
    public interface IHelloWorldController
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>MessageApiModel</returns>
        MessageApiModel Message();
    }
}