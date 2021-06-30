// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RestClientMethod
    {
        public RestClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, Operation? operation = null)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Responses = responses;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
            BufferResponse = bufferResponse;
            Accessibility = accessibility;
            Operation = operation;
        }

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public Parameter[] Parameters { get; }
        public Response[] Responses { get; }
        public DataPlaneResponseHeaderGroupType? HeaderModel { get; }
        public bool BufferResponse { get; }
        public CSharpType? ReturnType { get; }
        public string Accessibility { get; }
        public Operation? Operation { get; }

        public List<Parameter> NonPathParameters
        {
            get
            {
                var pathSegments = this.Request.PathParameterSegments;

                return this.Parameters.Where(parameter => !pathSegments.Any(
                    pathSegment => pathSegment.Value.Reference.Type.Name == parameter.Type.Name &&
                    pathSegment.Value.Reference.Name == parameter.Name)
                ).ToList();
            }
        }

        public List<Parameter> PathParameters
        {
            get
            {
                var pathSegments = this.Request.PathParameterSegments;

                return this.Parameters.Where(parameter => pathSegments.Any(
                    pathSegment => pathSegment.Value.Reference.Type.Name == parameter.Type.Name &&
                    pathSegment.Value.Reference.Name == parameter.Name)
                ).ToList();
            }
        }
    }
}
