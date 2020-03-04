// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.Requests;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class ClientMethod
    {
        public ClientMethod(string name, RestClientMethod restClientMethod, string? description)
        {
            Name = name;
            RestClientMethod = restClientMethod;
            Description = description;
        }

        public string Name { get; }
        public RestClientMethod RestClientMethod { get; }
        public string? Description { get; }
    }
}