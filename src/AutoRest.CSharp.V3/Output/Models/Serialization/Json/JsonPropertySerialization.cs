// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization
    {
        public JsonPropertySerialization(string name, bool required, ObjectTypeProperty? property, JsonSerialization valueSerialization)
        {
            Name = name;
            Property = property;
            ValueSerialization = valueSerialization;
            Required = required;

            if (valueSerialization is JsonObjectSerialization && property != null)
            {
                throw new ArgumentException("Property shouldn't be set when value serialization is an object", nameof(property));
            }
        }

        public string Name { get; }
        public bool Required { get; }
        public ObjectTypeProperty? Property { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
