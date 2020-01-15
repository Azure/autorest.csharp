// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class DiagnosticAttribute
    {
        public DiagnosticAttribute(string name, RequestParameterOrConstant value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public RequestParameterOrConstant Value { get; }
    }
}
