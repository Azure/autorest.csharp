// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class BodyParameterNormalizer
    {
        internal static void Update(HttpMethod method, string methodName, RequestParameter bodyParameter, string resourceName)
        {
            switch (method)
            {
                case HttpMethod.Put:
                    UpdateRequestParameter(bodyParameter, "content", $"{resourceName}CreateOrUpdateContent");
                    break;
                case HttpMethod.Post:
                    UpdateRequestParameter(bodyParameter, "content", $"{resourceName}{methodName}Content");
                    break;
                case HttpMethod.Patch:
                    UpdateRequestParameter(bodyParameter, "patch", $"{resourceName}Patch");
                    break;
                default:
                    throw new InvalidOperationException($"unhandled HttpMethod {method} for resource {resourceName}");
            }
        }

        private static void UpdateRequestParameter(RequestParameter parameter, string parameterName, string schemaName)
        {
            parameter.Language.Default.Name = parameterName;
            parameter.Schema.Language.Default.Name = schemaName;
        }
    }
}
