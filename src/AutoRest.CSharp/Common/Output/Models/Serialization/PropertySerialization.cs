// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal abstract class PropertySerialization
    {
        /// <summary>
        /// Name of the parameter in serialization constructor. Used in deserialization logic only
        /// </summary>
        public string SerializationConstructorParameterName { get; }

        /// <summary>
        /// Value expression to be serialized. Used in serialization logic only.
        /// </summary>
        public TypedValueExpression Value { get; }

        /// <summary>
        /// Value expression to be enumerated over. Used in serialization logic only.
        /// </summary>
        public TypedValueExpression? EnumerableValue { get; }

        /// <summary>
        /// Name of the property in serialized string
        /// </summary>
        public string SerializedName { get; }
        /// <summary>
        /// 'Original' type of the serialized value
        /// </summary>
        public CSharpType? SerializedType { get; }

        public bool IsRequired { get; }

        /// <summary>
        /// Should this property be excluded in wire serialization
        /// </summary>
        public bool ShouldExcludeInWireSerialization { get; }

        /// <summary>
        /// Should this property be excluded in wire deserialization
        /// </summary>
        public bool ShouldExcludeInWireDeserialization { get; }

        public CustomSerializationHooks? SerializationHooks { get; }

        public ObjectTypeProperty? Property { get; }

        protected PropertySerialization(string parameterName, TypedValueExpression value, string serializedName, CSharpType? serializedType, bool isRequired, bool shouldExcludeInWireSerialization, ObjectTypeProperty? property, TypedValueExpression? enumerableValue = null, CustomSerializationHooks? serializationHooks = null) : this(parameterName, value, serializedName, serializedType, isRequired, shouldExcludeInWireSerialization, shouldExcludeInWireSerialization, property, enumerableValue, serializationHooks)
        { }

        protected PropertySerialization(string parameterName, TypedValueExpression value, string serializedName, CSharpType? serializedType, bool isRequired, bool shouldExcludeInWireSerialization, bool shouldExcludeInWireDeserialization, ObjectTypeProperty? property, TypedValueExpression? enumerableValue = null, CustomSerializationHooks? serializationHooks = null)
        {
            SerializationConstructorParameterName = parameterName;
            Value = value;
            SerializedName = serializedName;
            SerializedType = serializedType;
            IsRequired = isRequired;
            ShouldExcludeInWireSerialization = shouldExcludeInWireSerialization;
            ShouldExcludeInWireDeserialization = shouldExcludeInWireDeserialization;
            EnumerableValue = enumerableValue;
            SerializationHooks = serializationHooks;
            Property = property;
        }
    }
}
