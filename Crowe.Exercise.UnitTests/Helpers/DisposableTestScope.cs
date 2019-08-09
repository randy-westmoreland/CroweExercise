namespace Crowe.Exercise.UnitTests.Helpers
{
    /// <summary>
    /// DisposableTestScope<typeparamref name="T"/> Class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Disposable" />
    public class DisposableTestScope<T> : Disposable where T : class
    {
        public T InstanceUnderTest { get; protected set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
