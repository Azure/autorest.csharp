﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record StringExpression(ValueExpression Untyped) : TypedValueExpression<string>(Untyped)
    {
        public CharExpression Index(ValueExpression index) => new(new IndexerExpression(this, index));
        public CharExpression Index(int index) => Index(Literal(index));
        public ValueExpression Length => Property(nameof(string.Length));

        public static BoolExpression Equals(StringExpression left, StringExpression right, StringComparison comparisonType)
            => new(InvokeStatic(nameof(string.Equals), new[] { left, right, FrameworkEnumValue(comparisonType) }));

        public static StringExpression Format(StringExpression format, params ValueExpression[] args)
            => new(new InvokeStaticMethodExpression(typeof(string), nameof(string.Format), args.Prepend(format).ToArray()));

        public static BoolExpression IsNullOrWhiteSpace(StringExpression value, params ValueExpression[] args)
            => new(new InvokeStaticMethodExpression(typeof(string), nameof(string.IsNullOrWhiteSpace), args.Prepend(value).ToArray()));

        public static StringExpression Join(ValueExpression separator, ValueExpression values)
            => new(new InvokeStaticMethodExpression(typeof(string), nameof(string.Join), new[] { separator, values }));

        public StringExpression Substring(ValueExpression startIndex)
            => new(new InvokeInstanceMethodExpression(this, nameof(string.Substring), new[] { startIndex }, null, false));
        public BoolExpression StartsWith(StringExpression value)
            => new(new InvokeInstanceMethodExpression(this, nameof(string.StartsWith), new[] {value}, null, false));
        public StringExpression Add(StringExpression value)
            => new(new BinaryOperatorExpression(" + ", this, value));
    }
}
