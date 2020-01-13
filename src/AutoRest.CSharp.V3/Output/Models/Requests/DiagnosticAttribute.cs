// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class DiagnosticAttribute
    {
        public DiagnosticAttribute(string name, RequestParameter value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public RequestParameter Value { get; }
    }
}
