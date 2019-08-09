using Crowe.Exercise.Data.Contracts;
using System;

namespace Crowe.Exercise.Data.Entities
{
    /// <summary>
    /// MessageEntity Class.
    /// </summary>
    /// <seealso cref="IEntity" />
    public class MessageEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}