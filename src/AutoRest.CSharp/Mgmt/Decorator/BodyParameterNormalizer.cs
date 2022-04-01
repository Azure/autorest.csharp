// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class BodyParameterNormalizer
    {
        internal static void Update(HttpMethod method, RequestParameter bodyParameter, string resourceName)
        {
            switch (method)
            {
                case HttpMethod.Put:
                    UpdateRequestParameter(bodyParameter, "info", $"{resourceName}CreateOrUpdateInfo");
                    break;
                case HttpMethod.Patch:
                    UpdateRequestParameter(bodyParameter, "data", $"Patchable{resourceName}Data");
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
