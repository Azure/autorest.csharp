// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RestClientMethod
    {
        public RestClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, ResponseHeaderGroupType? headerModel, bool bufferResponse, bool isVisible)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Responses = responses;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
            BufferResponse = bufferResponse;
            IsVisible = isVisible;
        }

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public Parameter[] Parameters { get; }
        public Response[] Responses { get; }
        public ResponseHeaderGroupType? HeaderModel { get; }
        public bool BufferResponse { get; }
        public CSharpType? ReturnType { get; }
        public bool IsVisible { get; }
    }
}
