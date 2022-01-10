// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class RequestPathExtensions
    {
        public static string Minus(this RequestPath requestPath, RequestPath other)
        {
            if (requestPath == other)
                return RequestPath.Tenant;

            if (requestPath.IsAncestorOf(other))
                return $"-{requestPath.TrimAncestorFrom(other)}";

            if (other.IsAncestorOf(requestPath))
                return other.TrimAncestorFrom(requestPath);

            return requestPath;
        }
    }
}
