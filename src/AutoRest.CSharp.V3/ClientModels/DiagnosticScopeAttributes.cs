// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class DiagnosticScopeAttributes
    {
        public DiagnosticScopeAttributes(string name, ConstantOrParameter value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public ConstantOrParameter Value { get; }
    }
}
