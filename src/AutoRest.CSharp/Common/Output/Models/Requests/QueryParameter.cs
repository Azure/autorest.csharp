// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal record QueryParameter(string Name, ReferenceOrConstant Value, string? Delimiter, bool Escape, SerializationFormat SerializationFormat, bool Explode)
    {
        // see https://github.com/Azure/autorest/blob/ca75e7a8a3caf6ce649fafdded832449c6250efb/packages/extensions/modelerfour/src/modeler/interpretations.ts#L77
        private static readonly HashSet<string> APIVersionParameterNames = new(StringComparer.OrdinalIgnoreCase)
        {
            "api-version",
            "apiversion",
            "x-ms-api-version",
            "x-ms-version"
        };

        public bool IsApiVersion => APIVersionParameterNames.Contains(Name);
    }

}
