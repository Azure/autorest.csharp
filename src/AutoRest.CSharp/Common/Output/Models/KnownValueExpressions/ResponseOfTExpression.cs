// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
#pragma warning disable SA1649
    internal sealed record ResponseExpression<T>(ValueExpression Untyped) : TypedValueExpression(typeof(Response<>), Untyped) where T : TypedValueExpression
#pragma warning restore SA1649
    {
        public T Value { get; } = Factory(new MemberReference(Untyped, nameof(Response<object>.Value)));

        private static readonly Func<ValueExpression, T> Factory = CreateFactory();

        private static Func<ValueExpression, T> CreateFactory()
        {
            var untyped = Expression.Parameter(typeof(ValueExpression));
            var ctor = typeof(T).GetConstructor(new[] {typeof(ValueExpression)});
            var exp = Expression.New(ctor!, untyped);
            return Expression.Lambda<Func<ValueExpression, T>>(exp, untyped).Compile();
        }
    }
}
