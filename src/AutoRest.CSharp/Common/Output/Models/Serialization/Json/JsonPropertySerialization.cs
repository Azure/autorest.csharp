﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization : PropertySerialization
    {
        public JsonPropertySerialization(
            string parameterName,
            TypedValueExpression value,
            string serializedName,
            CSharpType? serializedType,
            JsonSerialization valueSerialization,
            bool isRequired,
            bool shouldExcludeInWireSerialization,
            ObjectTypeProperty property,
            CustomSerializationHooks? serializationHooks = null,
            TypedValueExpression? enumerableExpression = null)
            : this(parameterName, value, serializedName, serializedType, valueSerialization, isRequired, shouldExcludeInWireSerialization, shouldExcludeInWireSerialization, property, serializationHooks, enumerableExpression)
        { }

        public JsonPropertySerialization(
            string parameterName,
            TypedValueExpression value,
            string serializedName,
            CSharpType? serializedType,
            JsonSerialization valueSerialization,
            bool isRequired,
            bool shouldExcludeInWireSerialization,
            bool shouldExcludeInWireDeserialization,
            ObjectTypeProperty property,
            CustomSerializationHooks? serializationHooks = null,
            TypedValueExpression? enumerableExpression = null)
            : base(parameterName, value, serializedName, serializedType, isRequired, shouldExcludeInWireSerialization, shouldExcludeInWireDeserialization, property, enumerableExpression, serializationHooks)
        {
            ValueSerialization = valueSerialization;
            CustomSerializationMethodName = serializationHooks?.JsonSerializationMethodName;
            CustomDeserializationMethodName = serializationHooks?.JsonDeserializationMethodName;
            DeserializeEmptyStringAsNull = property.InputModelProperty?.ShouldDeserializeEmptyStringAsNull() ?? false;
        }

        public JsonPropertySerialization(string serializedName, JsonPropertySerialization[] propertySerializations)
            : base(string.Empty, new TypedMemberExpression(null, serializedName, typeof(object)), serializedName, null, false, false, null)
        {
            PropertySerializations = propertySerializations;
        }

        public JsonSerialization? ValueSerialization { get; }
        /// <summary>
        /// This is not null when the property is flattened in generated client SDK `x-ms-client-flatten: true`
        /// </summary>
        public JsonPropertySerialization[]? PropertySerializations { get; }

        public string? CustomSerializationMethodName { get; }

        public string? CustomDeserializationMethodName { get; }

        public bool DeserializeEmptyStringAsNull { get; }
    }
}
