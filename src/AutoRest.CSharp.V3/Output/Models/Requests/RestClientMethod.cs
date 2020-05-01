// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class RestClientMethod
    {
        public RestClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responseType, ResponseHeaderGroupType? headerModel)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Responses = responseType;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
        }

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public Parameter[] Parameters { get; }
        public Response[] Responses { get; }
        public ResponseHeaderGroupType? HeaderModel { get; }
        public CSharpType? ReturnType { get; }
    }
}
