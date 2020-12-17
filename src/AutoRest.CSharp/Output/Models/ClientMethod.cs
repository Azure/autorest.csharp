// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal class ClientMethod
    {
        public ClientMethod(string name, RestClientMethod restClientMethod, string? description, Diagnostic diagnostics)
        {
            Name = name;
            RestClientMethod = restClientMethod;
            Description = description;
            Diagnostics = diagnostics;
        }

        public string Name { get; }
        public RestClientMethod RestClientMethod { get; }
        public string? Description { get; }
        public Diagnostic Diagnostics { get; }
    }
}