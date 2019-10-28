using System;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class EndBlock : IDisposable
    {
        private readonly DisposeService<EndBlock> _disposeService;
        public readonly Action? EndAction;

        public EndBlock(Action? endAction)
        {
            _disposeService = new DisposeService<EndBlock>(this, cb => EndAction?.Invoke());
            EndAction = endAction;
        }

        public void Dispose() => _disposeService.Dispose(true);
    }
}
