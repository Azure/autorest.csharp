// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class ConstructedSchemaRequestBody : RequestBody
    {
        public ReferenceOrConstant[] Parameters { get; }
        public ValueSerialization Serialization { get; }

        public ConstructedSchemaRequestBody(ReferenceOrConstant[] parameters, ValueSerialization serialization)
        {
            Parameters = parameters;
            Serialization = serialization;
        }
    }
}
