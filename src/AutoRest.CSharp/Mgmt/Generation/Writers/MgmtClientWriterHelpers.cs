// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class MgmtClientWriterHelpers
    {
        public static bool IsEndpointParameter(Parameter parameter) => string.Equals(parameter.Name, "endpoint", StringComparison.InvariantCultureIgnoreCase);
        public static bool IsApiVersionParameter(Parameter parameter) => string.Equals(parameter.Name, "apiVersion", StringComparison.InvariantCultureIgnoreCase);
    }
}