// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Writers;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization
    {
        public JsonPropertySerialization(string name, string? memberName, JsonSerialization valueSerialization)
        {
            Name = name;
            MemberName = memberName;
            ValueSerialization = valueSerialization;
        }

        public string Name { get; }
        public string? MemberName { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
