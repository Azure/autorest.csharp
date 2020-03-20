// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonAdditionalPropertiesSerialization
    {
        public ObjectTypeProperty Property { get; }
        public JsonDictionarySerialization Serialization { get; }

        public JsonAdditionalPropertiesSerialization(ObjectTypeProperty property, JsonDictionarySerialization serialization)
        {
            Property = property;
            Serialization = serialization;
        }
    }
}