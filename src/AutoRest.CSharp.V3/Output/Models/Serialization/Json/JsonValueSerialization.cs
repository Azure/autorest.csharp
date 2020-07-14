// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonValueSerialization: JsonSerialization
    {
        public JsonValueSerialization(CSharpType type, SerializationFormat format, bool isNullable) : base(isNullable)
        {
            Type = type;
            Format = format;
        }

        public CSharpType Type { get; }
        public SerializationFormat Format { get; }
    }
}
