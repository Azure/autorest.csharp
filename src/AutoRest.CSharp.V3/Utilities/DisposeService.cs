using System;
using System.Diagnostics.CodeAnalysis;

namespace AutoRest.CSharp.V3.Utilities
{
    //https://stackoverflow.com/a/32406585/294804
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    internal class DisposeService<T> where T : IDisposable
    {
        private readonly T _disposee;
        public Action<T>? ManagedAction { get; set; }
        public Action<T>? UnmanagedAction { get; set; }

        public DisposeService(T disposee, Action<T>? managedAction = null, Action<T>? unmanagedAction = null)
        {
            _disposee = disposee;
            ManagedAction = managedAction;
            UnmanagedAction = unmanagedAction;
        }

        private bool _isDisposed;
        public void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;
            if (isDisposing)
            {
                ManagedAction?.Invoke(_disposee);
            }
            var hasUnmanagedAction = UnmanagedAction != null;
            if (hasUnmanagedAction)
            {
                UnmanagedAction!(_disposee);
            }
            _isDisposed = true;
            if (isDisposing && hasUnmanagedAction)
            {
                // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
                GC.SuppressFinalize(_disposee);
            }
        }
    }
}
