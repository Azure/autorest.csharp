// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RestClientMethod
    {
        public RestClientMethod(string name, string? summary, string? description, CSharpType? returnType, Request request, IReadOnlyList<Parameter> parameters, Response[] responses, DataPlaneResponseHeaderGroupType? headerModel, bool bufferResponse, string accessibility, InputOperation operation, IReadOnlyList<Parameter>? originalParameters = null)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Responses = responses;
            Summary = summary;
            Description = description;
            ReturnType = returnType;
            HeaderModel = headerModel;
            BufferResponse = bufferResponse;
            Accessibility = GetAccessibility(accessibility);
            Operation = operation;
            OriginalParameters = originalParameters ?? parameters;
            IsPropertyBagMethod = originalParameters == null ? false : true;
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
        public string? Summary { get; }
        public string? Description { get; }
        public string? SummaryText => Summary.IsNullOrEmpty() ? Description : Summary;
        public string? DescriptionText => Summary.IsNullOrEmpty() || Description == Summary ? string.Empty : Description;
        public Request Request { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public Response[] Responses { get; }
        public DataPlaneResponseHeaderGroupType? HeaderModel { get; }
        public bool BufferResponse { get; }
        public CSharpType? ReturnType { get; }
        public MethodSignatureModifiers Accessibility { get; }
        public InputOperation Operation { get; }
        /// <summary>
        /// This property contains the original parameters as <see cref="RestClientMethod.Parameters"/> might be updated once we implement property bag feature.
        /// </summary>
        public IReadOnlyList<Parameter> OriginalParameters { get; }
        /// <summary>
        /// This property indicates whether the current method is a method affected by property bag.
        /// </summary>
        public bool IsPropertyBagMethod { get; }
    }
}
