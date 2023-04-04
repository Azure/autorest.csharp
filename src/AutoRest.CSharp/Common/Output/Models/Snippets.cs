// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static MethodBodyStatement AsStatement(this IEnumerable<MethodBodyStatement> statements) => statements.ToArray();

        public static ValueExpression Default { get; } = new KeywordExpression("default");
        public static ValueExpression Null { get; } = new KeywordExpression("null");
        public static ValueExpression This { get; } = new KeywordExpression("this");

        public static ValueExpression FrameworkEnumValue<TEnum>(TEnum value) where TEnum : struct, Enum => new MemberReference(new TypeReference(typeof(TEnum)), Enum.GetName(value)!);

        public static ValueExpression New(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
        public static ValueExpression New(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, Array.Empty<ValueExpression>()) { Properties = properties };

        public static ValueExpression Literal(string? value) => value is null ? Null : new LiteralExpression(value, false);
        public static ValueExpression LiteralU8(string value) => new LiteralExpression(value, true);

        public static ValueExpression Equal(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("==", left, right);
        public static ValueExpression IsNull(ValueExpression value) => new BinaryOperatorExpression("==", value, Null);
        public static ValueExpression IsNotNull(ValueExpression value) => new BinaryOperatorExpression("!=", value, Null);
        public static ValueExpression Or(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("||", left, right);
        public static ValueExpression And(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("&&", left, right);

        public static KeywordStatement Continue => new("continue", null);
        public static KeywordStatement Return(ValueExpression expression) => new("return", expression);
        public static ValueExpression InvokeToEnum(CSharpType enumType, ValueExpression stringValue) => new InvokeStaticMethodExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{stringValue}, null, true);

        public static MethodBodyStatement Assign<T>(T variable, T expression) where T : ValueExpression
            => new AssignValueStatement(variable, expression);

        public static MethodBodyStatement AssignOrReturn<T>(T? variable, T expression) where T : ValueExpression
            => variable != null ? new AssignValueStatement(variable, expression) : Return(expression);
    }
}
