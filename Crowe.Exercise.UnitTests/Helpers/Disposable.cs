using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Crowe.Exercise.UnitTests.Helpers
{
    /// <summary>
    /// Disposable Class.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public abstract class Disposable : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Checks the is disposed.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Operations are not allowed on a disposed object.</exception>
        protected void CheckIsDisposed()
        {
            var stringManager = new ResourceManager("en-US", Assembly.GetExecutingAssembly());

            if (_isDisposed)
            {
                throw new ObjectDisposedException($"{GetType().FullName}:{GetHashCode()}",
                   stringManager.GetString("Operations are not allowed on a disposed object.", CultureInfo.CurrentUICulture));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            _isDisposed |= !disposing;
        }
    }
}