// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal record BicepPropertySerialization : PropertySerialization
    {
        public BicepPropertySerialization(ObjectTypeProperty property, BicepSerialization valueSerialization)
            : base(
                property.Declaration.Name.ToVariableName(),
                new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type),
                property.SerializedName,
                property.ValueType,
                property.IsRequired,
                // property.SchemaProperty?.Required ?? property.InputModelProperty?.IsRequired ?? false,
                property.IsReadOnly)
                // property.SchemaProperty?.ReadOnly ?? property.InputModelProperty?.IsReadOnly ?? false)
        {
            ValueSerialization = valueSerialization;
        }

        public BicepSerialization ValueSerialization { get; }
    }
}
