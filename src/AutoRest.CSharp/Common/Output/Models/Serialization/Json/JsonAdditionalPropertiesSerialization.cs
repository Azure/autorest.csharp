// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonAdditionalPropertiesSerialization : JsonPropertySerialization
    {
        /// <summary>
        /// The implementation type of the additional properties, which should usually be `Dictionary{string, T}`.
        /// This is not the type of the property, which is usually `IDictionary{string, T}`, or `IReadOnlyDictionary{string, T}`.
        /// </summary>
        public CSharpType ImplementationType { get; }

        public JsonAdditionalPropertiesSerialization(ObjectTypeProperty property, JsonSerialization valueSerialization, CSharpType type, bool shouldExcludeInWireSerialization)
            : base(property.Declaration.Name.ToVariableName(), new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type), property.Declaration.Name, property.ValueType, valueSerialization, true, shouldExcludeInWireSerialization, property)
        {
            ImplementationType = type;
        }

        public JsonAdditionalPropertiesSerialization(ObjectTypeProperty property, JsonSerialization valueSerialization, CSharpType type, bool shouldExcludeInWireSerialization, bool shouldExcludeInWireDeserialization)
            : base(property.Declaration.Name.ToVariableName(), new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type), property.Declaration.Name, property.ValueType, valueSerialization, true, shouldExcludeInWireSerialization, shouldExcludeInWireDeserialization, property)
        {
            ImplementationType = type;
        }
    }
}
