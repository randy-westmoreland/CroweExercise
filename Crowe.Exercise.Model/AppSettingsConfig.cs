namespace Crowe.Exercise.Model.View
{
    /// <summary>
    /// AppSettingsConfig Class.
    /// </summary>
    public class AppSettingsConfig
    {
        /// <summary>
        /// Gets and Sets the WriteToConsole AppSettings setting.
        /// </summary>
        /// <value>
        /// The write to console.
        /// </value>
        public string WriteToConsole { get; set; }

        /// <summary>
        /// Gets or sets the message to send.
        /// </summary>
        /// <value>
        /// The message to send.
        /// </value>
        public string MessageToSend { get; set; }

        /// <summary>
        /// Gets or sets the get message endpoint.
        /// </summary>
        /// <value>
        /// The get message endpoint.
        /// </value>
        public string GetMessageEndpoint { get; set; }
    }
}