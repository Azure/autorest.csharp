// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization : PropertySerialization
    {
        public JsonPropertySerialization(string parameterName, ValueExpression value, string serializedName, CSharpType valueType, CSharpType? serializedType, JsonSerialization valueSerialization, bool isRequired, bool shouldSkipSerialization, bool shouldSkipDeserialization)
            : base(parameterName, value, serializedName, valueType, serializedType, isRequired, shouldSkipSerialization, shouldSkipDeserialization)
        {
            ValueSerialization = valueSerialization;
        }

        public JsonPropertySerialization(string serializedName, JsonPropertySerialization[] propertySerializations)
            : base(string.Empty, new MemberExpression(null, serializedName), serializedName, typeof(object), null, false, false)
        {
            PropertySerializations = propertySerializations;
        }

        public JsonSerialization? ValueSerialization { get; }
        /// <summary>
        /// This is not null when the property is flattened in generated client SDK `x-ms-client-flatten: true`
        /// </summary>
        public JsonPropertySerialization[]? PropertySerializations { get; }
    }
}
