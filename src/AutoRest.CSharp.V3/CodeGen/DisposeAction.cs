// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class DisposeAction : IDisposable
    {
        private readonly DisposeService<DisposeAction> _disposeService;

        public DisposeAction(Action? action = null)
        {
            _disposeService = new DisposeService<DisposeAction>(this, cb => action?.Invoke());
        }

        public void Dispose() => _disposeService.Dispose(true);
    }
}
