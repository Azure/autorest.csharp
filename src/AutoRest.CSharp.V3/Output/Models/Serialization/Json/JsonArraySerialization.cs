﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonArraySerialization: JsonSerialization
    {
        public JsonArraySerialization(TypeReference type, JsonSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override TypeReference Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
