// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
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
        public static ValueExpression Long(long value) => new FormattableStringToExpression($"{value}L");
        public static ValueExpression Float(float value) => new FormattableStringToExpression($"{value}f");
        public static ValueExpression Double(double value) => new FormattableStringToExpression($"{value}d");

        public static ValueExpression Nameof(ValueExpression expression) => new InvokeInstanceMethodExpression(null, "nameof", expression);
        public static ValueExpression ThrowExpression(ValueExpression expression) => new KeywordExpression("throw", expression);

        public static ValueExpression NullConditional(Parameter parameter) => new ParameterReference(parameter).NullConditional(parameter.Type);
        public static ValueExpression NullCoalescing(ValueExpression left, ValueExpression right) => new BinaryOperatorExpression("??", left, right);
        public static ValueExpression EnumValue(EnumType type, EnumTypeValue value) => new MemberExpression(new TypeReference(type.Type), value.Declaration.Name);
        public static ValueExpression FrameworkEnumValue<TEnum>(TEnum value) where TEnum : struct, Enum => new MemberExpression(new TypeReference(typeof(TEnum)), Enum.GetName(value)!);

        public static ValueExpression RemoveAllNullConditional(ValueExpression expression)
            => expression is MemberExpression { Inner: NullConditionalExpression { Inner: {} inner }, MemberName: {} memberName }
                ? new MemberExpression(RemoveAllNullConditional(inner), memberName)
                : expression;

        public static ValueExpression Literal(string? value) => value is null ? Null : new LiteralExpression(value, false);
        public static ValueExpression LiteralU8(string value) => new LiteralExpression(value, true);

        public static BoolExpression Equal(ValueExpression left, ValueExpression right) => new(new BinaryOperatorExpression("==", left, right));
        public static BoolExpression NotEqual(ValueExpression left, ValueExpression right) => new(new BinaryOperatorExpression("!=", left, right));
        public static BoolExpression Is(ValueExpression value, CSharpType type) => new(new BinaryOperatorExpression("is", value, type));

        public static BoolExpression Is(XElementExpression value, string name, out XElementExpression xElement)
            => Is<XElementExpression>(value, name, d => new XElementExpression(d), out xElement);
        public static BoolExpression Is(XAttributeExpression value, string name, out XAttributeExpression xAttribute)
            => Is<XAttributeExpression>(value, name, d => new XAttributeExpression(d), out xAttribute);

        public static BoolExpression Or(BoolExpression left, BoolExpression right) => new(new BinaryOperatorExpression("||", left.Untyped, right.Untyped));
        public static BoolExpression And(BoolExpression left, BoolExpression right) => new(new BinaryOperatorExpression("&&", left.Untyped, right.Untyped));

        public static MethodBodyStatement EmptyLine => new EmptyLineStatement();
        public static KeywordStatement Continue => new("continue", null);
        public static KeywordStatement Return(ValueExpression expression) => new("return", expression);
        public static KeywordStatement Throw(ValueExpression expression) => new("throw", expression);

        public static ValueExpression InvokeToEnum(CSharpType enumType, ValueExpression stringValue)
            => new InvokeStaticMethodExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{stringValue}, null, true);

        public static InvokeStaticMethodExpression InvokeDateTimeOffsetFromUnixTimeSeconds(ValueExpression expression)
            => new InvokeStaticMethodExpression(typeof(DateTimeOffset), nameof(DateTimeOffset.FromUnixTimeSeconds), new[]{expression});
        public static ValueExpression InvokeFileOpenRead(ValueExpression expression)
            => new InvokeStaticMethodExpression(typeof(System.IO.File), nameof(System.IO.File.OpenRead), new[]{expression});
        public static ValueExpression InvokeFileOpenWrite(ValueExpression expression)
            => new InvokeStaticMethodExpression(typeof(System.IO.File), nameof(System.IO.File.OpenWrite), new[]{expression});

        // Expected signature: MethodName(Utf8JsonWriter writer);
        public static MethodBodyStatement InvokeCustomSerializationMethod(string methodName, Utf8JsonWriterExpression utf8JsonWriter)
            => new InvokeInstanceMethodStatement(null, methodName, utf8JsonWriter);

        // Expected signature: MethodName(JsonProperty property, ref Optional<T> optional)
        public static MethodBodyStatement InvokeCustomDeserializationMethod(string methodName, JsonPropertyExpression jsonProperty, CodeWriterDeclaration variable)
            => new InvokeStaticMethodStatement(null, methodName, new ValueExpression[]{jsonProperty, new FormattableStringToExpression($"ref {variable}")});

        public static AssignValueStatement Assign<T>(T variable, T expression) where T : ValueExpression => new(variable, expression);

        public static MethodBodyStatement AssignOrReturn<T>(T? variable, T expression) where T : ValueExpression
            => variable != null ? new AssignValueStatement(variable, expression) : Return(expression);

        public static MethodBodyStatement InvokeConsoleWriteLine(ValueExpression expression)
            => new InvokeStaticMethodStatement(typeof(Console), nameof(Console.WriteLine), expression);

        private static BoolExpression Is<T>(T value, string name, Func<CodeWriterDeclaration, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(declaration);
            return new(new BinaryOperatorExpression("is", value, new FormattableStringToExpression($"{value.ReturnType} {declaration:D}")));
        }
    }
}
