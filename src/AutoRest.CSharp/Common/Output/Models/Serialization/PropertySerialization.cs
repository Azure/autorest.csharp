// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization
{
    internal abstract class PropertySerialization
    {
        public string PropertyName { get; }
        public string SerializedName { get; }
        public CSharpType PropertyType { get; }
        public CSharpType? ValueType { get; }
        public bool IsRequired { get; }
        public bool ShouldSkipSerialization { get; }

        protected PropertySerialization(string propertyName, string serializedName, CSharpType propertyType, CSharpType? valueType, bool isRequired, bool shouldSkipSerialization)
        {
            PropertyName = propertyName;
            SerializedName = serializedName;
            PropertyType = propertyType;
            ValueType = valueType;
            IsRequired = isRequired;
            ShouldSkipSerialization = shouldSkipSerialization;
        }
    }
}
