// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static MethodBodyStatement AsStatement(this IEnumerable<MethodBodyStatement> statements) => statements.ToArray();

        public static ValueExpression Dash { get; } = new KeywordExpression("_", null);
        public static ValueExpression Default { get; } = new KeywordExpression("default", null);
        public static ValueExpression Null { get; } = new KeywordExpression("null", null);
        public static ValueExpression This { get; } = new KeywordExpression("this", null);
        public static BoolExpression True { get; } = new(new KeywordExpression("true", null));
        public static BoolExpression False { get; } = new(new KeywordExpression("false", null));

        public static BoolExpression Bool(bool value) => value ? True : False;
        public static ValueExpression Int(int value) => new FormattableStringToExpression($"{value}");

        public static ValueExpression Nameof(ValueExpression expression) => new InvokeInstanceMethodExpression(null, "nameof", expression);
        public static ValueExpression ThrowExpression(ValueExpression expression) => new KeywordExpression("throw", expression);

        public static ValueExpression NullConditional(Parameter parameter) => new ParameterReference(parameter).NullConditional(parameter.Type);
        public static ValueExpression NullCoalescing(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("??", left, right);
        public static ValueExpression EnumValue(EnumType type, EnumTypeValue value) => new MemberReference(new TypeReference(type.Type), value.Declaration.Name);
        public static ValueExpression FrameworkEnumValue<TEnum>(TEnum value) where TEnum : struct, Enum => new MemberReference(new TypeReference(typeof(TEnum)), Enum.GetName(value)!);

        public static ValueExpression RemoveAllNullConditional(ValueExpression expression)
            => expression is MemberReference { Inner: NullConditionalExpression { Inner: {} inner }, MemberName: {} memberName }
                ? new MemberReference(RemoveAllNullConditional(inner), memberName)
                : expression;

        public static ValueExpression New(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
        public static ValueExpression New(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, Array.Empty<ValueExpression>()) { Properties = properties };

        public static ValueExpression Literal(string? value) => value is null ? Null : new LiteralExpression(value, false);
        public static ValueExpression LiteralU8(string value) => new LiteralExpression(value, true);

        public static BoolExpression Equal(ValueExpression left, ValueExpression right) => new(new BinaryOperatorExpression("==", left, right));
        public static BoolExpression IsNull(ValueExpression value) => new(new BinaryOperatorExpression("==", value, Null));
        public static BoolExpression IsNotNull(ValueExpression value) => new(new BinaryOperatorExpression("!=", value, Null));
        public static BoolExpression Or(BoolExpression left, BoolExpression right) => new(new BinaryOperatorExpression("||", left.Untyped, right.Untyped));
        public static BoolExpression And(BoolExpression left, BoolExpression right) => new(new BinaryOperatorExpression("&&", left.Untyped, right.Untyped));

        public static KeywordStatement Continue => new("continue", null);
        public static KeywordStatement Return(ValueExpression expression) => new("return", expression);
        public static KeywordStatement Throw(ValueExpression expression) => new("throw", expression);
        public static ValueExpression InvokeToEnum(CSharpType enumType, ValueExpression stringValue) => new InvokeStaticMethodExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{stringValue}, null, true);

        public static MethodBodyStatement Assign<T>(T variable, T expression) where T : ValueExpression
            => new AssignValueStatement(variable, expression);

        public static MethodBodyStatement AssignOrReturn<T>(T? variable, T expression) where T : ValueExpression
            => variable != null ? new AssignValueStatement(variable, expression) : Return(expression);
    }
}
