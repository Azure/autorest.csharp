// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonValueSerialization : JsonSerialization
    {
        public JsonValueSerialization(CSharpType type, SerializationFormat format, bool isNullable, JsonSerializationOptions options = JsonSerializationOptions.None) : base(isNullable, options)
        {
            Type = type;
            Format = format;
        }

        public CSharpType Type { get; }
        public SerializationFormat Format { get; }
    }
}
