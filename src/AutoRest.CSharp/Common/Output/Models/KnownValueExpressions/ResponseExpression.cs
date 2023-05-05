// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record ResponseExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Response), Untyped)
    {
        public ValueExpression Status => new MemberReference(Untyped, nameof(Response.Status));
        public BinaryDataExpression Content => new(new MemberReference(Untyped, nameof(Response.Content)));
        public ValueExpression ContentStream => new MemberReference(Untyped, nameof(Response.ContentStream));

        public static ResponseExpression<SerializableObjectTypeExpression> FromValue(SerializableObjectTypeExpression value, ResponseExpression response)
            => FromValue(m => new SerializableObjectTypeExpression(value.ObjectType, m), value, response);

        public static ResponseExpression<FrameworkTypeExpression> FromValue(FrameworkTypeExpression value, ResponseExpression response)
            => FromValue(m => new FrameworkTypeExpression(value.ReturnType, m), value, response);

        private static ResponseExpression<T> FromValue<T>(Func<MemberReference, T> valueExpressionFactory, T value, ResponseExpression response) where T : TypedValueExpression
            => new(valueExpressionFactory, new InvokeStaticMethodExpression(typeof(Response), nameof(Response.FromValue), new ValueExpression[]{ value, response }));
    }
}
