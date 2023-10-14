// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core.Serialization;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal record ModelSerializerOptionsExpression(ValueExpression Untyped) : TypedValueExpression<ModelSerializerOptions>(Untyped)
    {
        public static ModelSerializerOptionsExpression DefaultWireOptions => new(new TypeReference(typeof(ModelSerializerOptions)).Property(nameof(ModelSerializerOptions.DefaultWireOptions)));
    }
}
