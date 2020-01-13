// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class Diagnostic
    {
        public Diagnostic(string scopeName, DiagnosticAttribute[] attributes)
        {
            ScopeName = scopeName;
            Attributes = attributes;
        }

        public string ScopeName { get; }
        public DiagnosticAttribute[] Attributes { get; }
    }
}
