// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParameterExtensions
    {
        public static bool IsInPathOf(this Parameter parameter, RestClientMethod method)
        {
            return method.PathParameters.Contains(parameter);
        }

        public static bool IsMandatory(this Parameter parameter) => parameter.DefaultValue is null;
    }
}
