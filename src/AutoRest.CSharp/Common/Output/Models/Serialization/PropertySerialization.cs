// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal abstract class PropertySerialization
    {
        /// <summary>
        /// Name of the parameter in serialization constructor. Used in deserialization logic only
        /// </summary>
        public string SerializationConstructorParameterName { get;  }

        /// <summary>
        /// Value expression to be serialized. Used in serialization logic only.
        /// </summary>
        public ValueExpression Value { get; }
        /// <summary>
        /// Type of the value to be serialized
        /// </summary>
        public CSharpType ValueType { get; }

        /// <summary>
        /// Name of the property in serialized string
        /// </summary>
        public string SerializedName { get; }
        /// <summary>
        /// 'Original' type of the serialized value
        /// </summary>
        public CSharpType? SerializedType { get; }

        public bool IsRequired { get; }
        public bool ShouldSkipSerialization { get; }
        public bool ShouldSkipDeserialization { get; }

        protected PropertySerialization(string parameterName, ValueExpression value, string serializedName, CSharpType valueType, CSharpType? serializedType, bool isRequired, bool shouldSkipSerialization) :
            this(parameterName, value, serializedName, valueType, serializedType, isRequired, shouldSkipSerialization, false)
        {
        }

        protected PropertySerialization(string parameterName, ValueExpression value, string serializedName, CSharpType valueType, CSharpType? serializedType, bool isRequired, bool shouldSkipSerialization, bool shouldSkipDeserialization)
        {
            SerializationConstructorParameterName = parameterName;
            Value = value;
            SerializedName = serializedName;
            ValueType = valueType;
            SerializedType = serializedType;
            IsRequired = isRequired;
            ShouldSkipSerialization = shouldSkipSerialization;
            ShouldSkipDeserialization = shouldSkipDeserialization;
        }
    }
}
