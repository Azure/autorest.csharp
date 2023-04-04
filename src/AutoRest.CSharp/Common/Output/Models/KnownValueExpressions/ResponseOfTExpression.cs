// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
#pragma warning disable SA1649
    internal sealed record ResponseExpression<T>(Func<MemberReference, T> ValueFactory, ValueExpression Untyped) : TypedValueExpression(new CSharpType(typeof(Azure.Response<>), GetValueType(ValueFactory)), Untyped) where T : TypedValueExpression
#pragma warning restore SA1649
    {
        public T Value => ValueFactory(new MemberReference(Untyped, nameof(Azure.Response<T>.Value)));

        private static CSharpType GetValueType(Func<MemberReference, T> valueFactory) => valueFactory(new MemberReference(null, nameof(Azure.Response<T>.Value))).Type;
    }
}
