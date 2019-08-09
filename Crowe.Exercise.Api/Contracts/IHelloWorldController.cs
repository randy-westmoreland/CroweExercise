using Crowe.Exercise.Model.Api;
using Microsoft.AspNetCore.Mvc;

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
        IActionResult Message();

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>IActionResult</returns>
        IActionResult Message(MessageApiModel message);
    }
}