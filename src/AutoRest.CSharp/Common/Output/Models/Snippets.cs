// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static ValueExpression Default { get; } = new KeywordExpression("default");
        public static ValueExpression Null { get; } = new KeywordExpression("null");
        public static ValueExpression This { get; } = new KeywordExpression("this");

        public static ValueExpression New(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
        public static ValueExpression New(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, Array.Empty<ValueExpression>()) { Properties = properties };

        public static ValueExpression Literal(string? value) => value is null ? Null : new LiteralExpression(value, false);
        public static ValueExpression LiteralU8(string value) => new LiteralExpression(value, true);

        public static ValueExpression StringLengthEqualsZero(ValueExpression str) => new BinaryOperatorExpression("==", new MemberReference(str, nameof(string.Length)), new FormattableStringToExpression($"0"));
        public static ValueExpression IsNull(ValueExpression value) => new BinaryOperatorExpression("==", value, Null);
        public static ValueExpression IsNotNull(ValueExpression value) => new BinaryOperatorExpression("!=", value, Null);
        public static ValueExpression Or(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("||", left, right);
        public static ValueExpression And(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("&&", left, right);

        public static KeywordStatement Continue => new("continue", null);
        public static KeywordStatement Return(ValueExpression expression) => new("return", expression);
    }
}
