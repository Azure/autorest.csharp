// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Input;
using Azure.Core;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class AzureCoreExtensions
    {
        public static string ToRequestMethodName(this RequestMethod method) => method.ToString() switch
        {
            "GET" => nameof(RequestMethodAdditional.Get),
            "POST" => nameof(RequestMethodAdditional.Post),
            "PUT" => nameof(RequestMethodAdditional.Put),
            "PATCH" => nameof(RequestMethodAdditional.Patch),
            "DELETE" => nameof(RequestMethodAdditional.Delete),
            "HEAD" => nameof(RequestMethodAdditional.Head),
            "OPTIONS" => nameof(RequestMethodAdditional.Options),
            "TRACE" => nameof(RequestMethodAdditional.Trace),
            _ => String.Empty
        };

        public static RequestMethod? ToCoreRequestMethod(this HttpMethod method) => method switch
        {
            HttpMethod.Delete => RequestMethodAdditional.Delete,
            HttpMethod.Get => RequestMethodAdditional.Get,
            HttpMethod.Head => RequestMethodAdditional.Head,
            HttpMethod.Options => RequestMethodAdditional.Options,
            HttpMethod.Patch => RequestMethodAdditional.Patch,
            HttpMethod.Post => RequestMethodAdditional.Post,
            HttpMethod.Put => RequestMethodAdditional.Put,
            HttpMethod.Trace => RequestMethodAdditional.Trace,
            _ => (RequestMethod?)null
        };
    }
}
