// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class ManagementClientWriterHelpers
    {
        public static bool IsHostParameter(Parameter parameter) => string.Equals(parameter.Name, "host", StringComparison.InvariantCultureIgnoreCase);
        public static bool IsApiVersionParameter(Parameter parameter) => string.Equals(parameter.Name, "apiVersion", StringComparison.InvariantCultureIgnoreCase);
    }
}