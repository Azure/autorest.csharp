// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodDiagnostics
    {
        public ClientMethodDiagnostics(string scopeName, DiagnosticScopeAttributes[] attributes)
        {
            ScopeName = scopeName;
            Attributes = attributes;
        }

        public string ScopeName { get; }
        public DiagnosticScopeAttributes[] Attributes { get; }
    }
}
