using System.ComponentModel;

namespace Crowe.Exercise.Common.Utils
{
    /// <summary>
    /// AppSettings Helper Class.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T</returns>
        public static T Get<T>(string value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(value));
        }
    }
}