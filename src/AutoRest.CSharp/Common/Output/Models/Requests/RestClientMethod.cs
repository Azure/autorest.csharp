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
        public RestClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, Operation operation)
        {
            Name = name;
            Request = request;
            Responses = responses;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
            BufferResponse = bufferResponse;
            Accessibility = accessibility;
            Operation = operation;

            PathParameters = getPathParameters(parameters);
            NonPathParameters = getNonPathParameters(parameters);

            Parameters = SortParameters(parameters, new Queue<Parameter>(PathParameters));
        }

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public List<Parameter> Parameters { get; }
        public Response[] Responses { get; }
        public DataPlaneResponseHeaderGroupType? HeaderModel { get; }
        public bool BufferResponse { get; }
        public CSharpType? ReturnType { get; }
        public string Accessibility { get; }
        public Operation Operation { get; }

        public List<Parameter> PathParameters { get; }

        public List<Parameter> NonPathParameters { get; }

        private List<Parameter> getPathParameters(Parameter[] parameters)
        {
            List<Parameter> pathParameters = new();
            // Path segments are ordered from left to right, so iterate segments first will keep the sequence of
            // path parameters in URL path
            Request.PathParameterSegments.ForEach(pathSegment => {
                var parameter = parameters.FirstOrDefault(p => pathSegment.Value.Reference.Type.Name == p.Type.Name &&
                    pathSegment.Value.Reference.Name == p.Name);
                if (parameter != null)
                {
                    pathParameters.Add(parameter);
                }
            });

            return pathParameters;
        }

        private List<Parameter> getNonPathParameters(Parameter[] parameters)
        {
            return parameters.Where(p => !IsPathParameter(p)).ToList();
        }

        private bool IsPathParameter(Parameter parameter)
        {
            return this.Request.PathParameterSegments.Any(
                pathSegment => pathSegment.Value.Reference.Type.Name == parameter.Type.Name &&
                pathSegment.Value.Reference.Name == parameter.Name
            );
        }

        private List<Parameter> SortParameters(Parameter[] parameters, Queue<Parameter> pathParameters)
        {
            var sortedParameters = new List<Parameter>();

            foreach (var parameter in parameters)
            {
                // sort only path parameters in the whole parameter list
                if (IsPathParameter(parameter))
                {
                    sortedParameters.Add(pathParameters.Dequeue());
                }
                else
                {
                    sortedParameters.Add(parameter);
                }
            }

            return sortedParameters;
        }
    }
}
