// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingMethod
    {
        public PagingMethod(RestClientMethod method, RestClientMethod? nextPageMethod, string name, Diagnostic diagnostics, PagingResponseInfo pagingResponse)
        {
            Method = method;
            NextPageMethod = nextPageMethod;
            Name = name;
            Diagnostics = diagnostics;
            PagingResponse = pagingResponse;
        }

        public string Name { get; }
        public RestClientMethod Method { get; }
        public RestClientMethod? NextPageMethod { get; }
        public PagingResponseInfo PagingResponse { get; }
        public Diagnostic Diagnostics { get; }
        public string Accessibility => "public";

        /// <summary>
        /// Service domain parameters are:
        /// 1. not in URL path
        /// 2. not defined for Azure platform features, like pagination
        /// </summary>
        public List<Parameter> NonPathDomainParameters
        {
            get
            {
                return Method.NonPathParameters.Where(p => !IsPageSizeParameter(p)).ToList();
            }
        }

        public static bool IsPageSizeParameter(Parameter p)
        {
            var name = p.Name.ToLower();
            return (name.EndsWith("pagesize") || name.EndsWith("page_size")) &&
                // check TypeFactory.ToFrameworkNumericType() for all the numeric types we support
                Type.GetTypeCode(p.Type.FrameworkType) switch
                {
                    TypeCode.Single => true,
                    TypeCode.Double => true,
                    TypeCode.Decimal => true,
                    TypeCode.Int64 => true,
                    TypeCode.Int32 => true,
                    TypeCode.String => true,
                    _ => false
                };
        }
    }
}
