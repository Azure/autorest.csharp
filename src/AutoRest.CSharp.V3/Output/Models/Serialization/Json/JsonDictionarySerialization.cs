// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonDictionarySerialization : JsonSerialization
    {
        public JsonDictionarySerialization(CSharpType type, JsonSerialization valueSerialization, bool isNullable) : base(isNullable)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public CSharpType Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
