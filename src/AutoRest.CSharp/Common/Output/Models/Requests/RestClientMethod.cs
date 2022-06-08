// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RestClientMethod
    {
        public RestClientMethod(string name, string? description, CSharpType? returnType, Request request, Parameter[] parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, Operation operation, RequestConditionHeaders conditionRequestFlag = RequestConditionHeaders.None, string docurl = "")
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Responses = responses;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
            BufferResponse = bufferResponse;
            Accessibility = GetAccessibility(accessibility);
            Operation = operation;
            ConditionHeaderFlag = conditionRequestFlag;
            DocUrl = docurl;
        }

        private static MethodSignatureModifiers GetAccessibility(string accessibility) =>
            accessibility switch
            {
                "public" => MethodSignatureModifiers.Public,
                "internal" => MethodSignatureModifiers.Internal,
                "protected" => MethodSignatureModifiers.Protected,
                "private" => MethodSignatureModifiers.Private,
                _ => throw new NotSupportedException()
            };

        public string Name { get; }
        public string? Description { get; }
        public Request Request { get; }
        public Parameter[] Parameters { get; }
        public Response[] Responses { get; }
        public DataPlaneResponseHeaderGroupType? HeaderModel { get; }
        public bool BufferResponse { get; }
        public CSharpType? ReturnType { get; }
        public MethodSignatureModifiers Accessibility { get; }
        public Operation Operation { get; }
        public RequestConditionHeaders ConditionHeaderFlag { get; set; }
        public string DocUrl { get; }
    }
}
