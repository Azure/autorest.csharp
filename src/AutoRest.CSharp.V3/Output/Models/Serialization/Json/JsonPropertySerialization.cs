﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization
    {
        public JsonPropertySerialization(string name, ObjectTypeProperty? property, JsonSerialization valueSerialization)
        {
            Name = name;
            ObjectProperty = property;
            ValueSerialization = valueSerialization;
        }

        public string Name { get; }
        public ObjectTypeProperty? ObjectProperty { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
