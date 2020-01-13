// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class Method
    {
        public Method(string name, string? description, Request request, Parameter[] parameters, Response responseType, Diagnostic diagnostics, Paging? paging)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Response = responseType;
            Description = description;
            Diagnostics = diagnostics;
            Paging = paging;
        }

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public Parameter[] Parameters { get; }
        public Response Response { get; }
        public Diagnostic Diagnostics { get; }
        public Paging? Paging { get; }
    }
}
