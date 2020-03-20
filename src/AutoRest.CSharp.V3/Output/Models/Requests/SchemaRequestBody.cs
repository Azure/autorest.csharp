// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Output.Models.Serialization;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class SchemaRequestBody : RequestBody
    {
        public ObjectSerialization Serialization { get; }
        public ParameterOrConstant Value { get; }

        public SchemaRequestBody(ParameterOrConstant value, ObjectSerialization serialization)
        {
            Value = value;
            Serialization = serialization;
        }
    }
}
