using Crowe.Exercise.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Crowe.Exercise.Data.Config
{
    /// <summary>
    /// CrowExerciseMessagesConfi Class.
    /// </summary>
    /// <seealso cref="EntityTypeConfiguration{MessageEntity}" />
    public class CroweExerciseMessagesConfig : EntityTypeConfiguration<MessageEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CroweExerciseMessagesConfig"/> class.
        /// </summary>
        public CroweExerciseMessagesConfig()
        {
            ToTable("[TableName]").HasKey(x => x.MessageId);
        }
    }
}