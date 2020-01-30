// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization
    {
        public JsonPropertySerialization(string name, string? memberName, JsonSerialization valueSerialization, CSharpType? initializeType)
        {
            Name = name;
            MemberName = memberName;
            ValueSerialization = valueSerialization;
            InitializeType = initializeType;
            if ((MemberName == null) != (ValueSerialization.Type == null))
            {
                throw new InvalidOperationException($"Invalid serialization. {nameof(MemberName)} and {nameof(ValueSerialization.Type)} must either be both populated or both null.");
            }
        }

        public string Name { get; }
        public string? MemberName { get; }
        public JsonSerialization ValueSerialization { get; }
        public CSharpType? InitializeType { get; }
    }
}
