using System;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class DisposeAction : IDisposable
    {
        private readonly DisposeService<DisposeAction> _disposeService;

        public DisposeAction(Action? action)
        {
            _disposeService = new DisposeService<DisposeAction>(this, cb => action?.Invoke());
        }

        public void Dispose() => _disposeService.Dispose(true);
    }
}
