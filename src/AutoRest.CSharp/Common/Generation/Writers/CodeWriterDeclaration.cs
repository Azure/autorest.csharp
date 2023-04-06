// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class CodeWriterDeclaration
    {
        private string? _actualName;
        private string? _debuggerName;

        public CodeWriterDeclaration(string name)
        {
            RequestedName = name;
        }

        public string RequestedName { get; }

        public string ActualName => _actualName ?? _debuggerName ?? throw new InvalidOperationException("Declaration not initialized");

        internal void SetActualName(string actualName)
        {
            if (_actualName != null)
            {
                throw new InvalidOperationException($"Declaration {_actualName} already initialized");
            }

            _actualName = actualName;
        }

        internal void SetDebuggerName(string? debuggerName)
        {
            if (_actualName != null)
            {
                throw new InvalidOperationException($"Declaration {_actualName} already initialized, can't set debugger.");
            }

            _debuggerName = debuggerName;
        }
    }
}
