// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
