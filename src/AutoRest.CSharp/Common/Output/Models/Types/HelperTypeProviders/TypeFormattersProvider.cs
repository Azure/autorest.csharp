﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using ValidationType = AutoRest.CSharp.Output.Models.Shared.ValidationType;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class TypeFormattersProvider : ExpressionTypeProvider
    {
        //private static readonly Lazy<TypeFormattersProvider> _instance = new(() => new TypeFormattersProvider());
        //public static TypeFormattersProvider Instance => _instance.Value;

        // TODO -- this type provider is temprorarily an inner class therefore it is not singleton yet. We need to change this to singleton when we decide to emit the entire TypeFormatters class.
        internal TypeFormattersProvider(ExpressionTypeProvider declaringTypeProvider) : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Private | TypeSignatureModifiers.Static;
            DeclaringTypeProvider = declaringTypeProvider;
        }

        protected override string DefaultName => "TypeFormatters";

        private readonly FieldDeclaration _roundtripZFormatField = new(FieldModifiers.Private | FieldModifiers.Const, typeof(string), "RoundtripZFormat", Literal("yyyy-MM-ddTHH:mm:ss.fffffffZ"), SerializationFormat.Default);
        private readonly FieldDeclaration _defaultNumberFormatField = new(FieldModifiers.Public | FieldModifiers.Const, typeof(string), "DefaultNumberFormat", Literal("G"), SerializationFormat.Default);

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _roundtripZFormatField;
            yield return _defaultNumberFormatField;
        }

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static;

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var method in BuildToStringMethods())
            {
                yield return method;
            }

            yield return BuildToBase64UrlStringMethod();
            yield return BuildFromBase64UrlString();
            yield return BuildParseDateTimeOffsetMethod();
            yield return BuildParseTimeSpanMethod();
        }

        private const string _toStringMethodName = "ToString";

        private IEnumerable<Method> BuildToStringMethods()
        {
            var boolValueParameter = new Parameter("value", null, typeof(bool), null, ValidationType.None, null);
            var boolSignature = new MethodSignature(
                Name: _toStringMethodName,
                Parameters: new[] { boolValueParameter },
                Modifiers: _methodModifiers,
                ReturnType: typeof(string),
                Summary: null, Description: null, ReturnDescription: null);
            var boolValue = new BoolExpression(boolValueParameter);
            yield return new Method(boolSignature,
                new TernaryConditionalOperator(boolValue, Literal("true"), Literal("false")));

            var dateTimeParameter = boolValueParameter with { Type = typeof(DateTime) };
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var dateTimeSignature = boolSignature with
            {
                Parameters = new[] { dateTimeParameter, formatParameter }
            };
            var dateTimeValue = (ValueExpression)dateTimeParameter;
            var dateTimeValueKind = dateTimeValue.Property(nameof(DateTime.Kind));
            var format = new StringExpression(formatParameter);
            yield return new Method(dateTimeSignature,
                new SwitchExpression(dateTimeValueKind, new SwitchCaseExpression[]
                {
                    new(new MemberExpression(typeof(DateTimeKind), nameof(DateTimeKind.Utc)), ToString(dateTimeValue.CastTo(typeof(DateTimeOffset)), format)),
                    SwitchCaseExpression.Default(ThrowExpression(New.NotSupportedException(new FormattableStringExpression("DateTime {0} has a Kind of {1}. Azure SDK requires it to be UTC. You can call DateTime.SpecifyKind to change Kind property value to DateTimeKind.Utc.", dateTimeValue, dateTimeValueKind))))
                }));

            var dateTimeOffsetParameter = boolValueParameter with { Type = typeof(DateTimeOffset) };
            var dateTimeOffsetSignature = boolSignature with
            {
                Parameters = new[] { dateTimeOffsetParameter, formatParameter }
            };
            var dateTimeOffsetValue = new DateTimeOffsetExpression(dateTimeOffsetParameter);
            var roundtripZFormat = new StringExpression(_roundtripZFormatField);
            var invariantCultureExpression = new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture));
            yield return new Method(dateTimeOffsetSignature,
                new SwitchExpression(format, new SwitchCaseExpression[]
                {
                    new(Literal("D"), dateTimeOffsetValue.InvokeToString(Literal("yyyy-MM-dd"), invariantCultureExpression)),
                    new(Literal("U"), dateTimeOffsetValue.ToUnixTimeSeconds().InvokeToString(invariantCultureExpression)),
                    new(Literal("O"), dateTimeOffsetValue.ToUniversalTime().InvokeToString(roundtripZFormat, invariantCultureExpression)),
                    new(Literal("o"), dateTimeOffsetValue.ToUniversalTime().InvokeToString(roundtripZFormat, invariantCultureExpression)),
                    new(Literal("R"), dateTimeOffsetValue.InvokeToString(Literal("r"), invariantCultureExpression)),
                    SwitchCaseExpression.Default(dateTimeOffsetValue.InvokeToString(format, invariantCultureExpression))
                }));

            var timeSpanParameter = boolValueParameter with { Type = typeof(TimeSpan) };
            var timeSpanSignature = boolSignature with
            {
                Parameters = new[] { timeSpanParameter, formatParameter }
            };
            var timeSpanValue = new TimeSpanExpression(timeSpanParameter);
            yield return new Method(timeSpanSignature,
                new SwitchExpression(format, new SwitchCaseExpression[]
                {
                    new(Literal("P"), new InvokeStaticMethodExpression(typeof(XmlConvert), nameof(XmlConvert.ToString), new[] {timeSpanValue})),
                    SwitchCaseExpression.Default(timeSpanValue.InvokeToString(format, invariantCultureExpression))
                }));

            var byteArrayParameter = boolValueParameter with { Type = typeof(byte[]) };
            var byteArraySignature = boolSignature with
            {
                Parameters = new[] { byteArrayParameter, formatParameter }
            };
            var byteArrayValue = (ValueExpression)byteArrayParameter;
            yield return new Method(byteArraySignature,
                new SwitchExpression(format, new SwitchCaseExpression[]
                {
                    new(Literal("U"), ToBase64UrlString(byteArrayValue)),
                    new(Literal("D"), new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToBase64String), new[] {byteArrayValue})),
                    SwitchCaseExpression.Default(ThrowExpression(New.ArgumentException(format, new FormattableStringExpression("Format is not supported: '{0}'", format))))
                }));
        }

        public StringExpression ToString(BoolExpression value)
            => new(new InvokeStaticMethodExpression(Type, _toStringMethodName, new[] { value }));

        public StringExpression ToString(ValueExpression value, ValueExpression format)
            => new(new InvokeStaticMethodExpression(Type, _toStringMethodName, new[] { value, format }));

        private const string _toBase64UrlStringMethodName = "ToBase64UrlString";

        private Method BuildToBase64UrlStringMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(byte[]), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _toBase64UrlStringMethodName,
                Parameters: new[] { valueParameter },
                ReturnType: typeof(string),
                Modifiers: _methodModifiers,
                Summary: null, Description: null, ReturnDescription: null);

            var value = (ValueExpression)valueParameter;
            var valueLength = new IntExpression(value.Property("Length"));
            var body = new List<MethodBodyStatement>
            {
                Declare("numWholeOrPartialInputBlocks", new IntExpression(new BinaryOperatorExpression("/", new KeywordExpression("checked", new BinaryOperatorExpression("+", valueLength, Int(2))), Int(3))), out var numWholeOrPartialInputBlocks),
                Declare("size", new IntExpression(new KeywordExpression("checked", new BinaryOperatorExpression("*", numWholeOrPartialInputBlocks, Int(4)))), out var size),
            };
            var output = new VariableReference(typeof(char[]), "output");
            body.Add(new MethodBodyStatement[]
            {
                Declare(output, New.Array(typeof(char), size)),
                EmptyLine,
                Declare("numBase64Chars", new IntExpression(new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToBase64CharArray), new[] { value, Int(0), valueLength, output, Int(0) })), out var numBase64Chars),
                EmptyLine,
                Declare("i", Int(0), out var i),
                new ForStatement(null, LessThan(i, numBase64Chars), new UnaryOperatorExpression("++", i, true))
                {
                    Declare("ch", new CharExpression(new IndexerExpression(output, i)), out var ch),
                    new IfElseStatement(new IfStatement(Equal(ch, Literal('+')))
                    {
                        Assign(new IndexerExpression(output, i), Literal('-'))
                    }, new IfElseStatement(new IfStatement(Equal(ch, Literal('/')))
                    {
                        Assign(new IndexerExpression(output, i), Literal('_'))
                    }, new IfStatement(Equal(ch, Literal('=')))
                    {
                        Break
                    }))
                },
                EmptyLine,
                Return(New.Instance(typeof(string), output, Int(0), i))
            });

            return new Method(signature, body);
        }

        public StringExpression ToBase64UrlString(ValueExpression value)
            => new(new InvokeStaticMethodExpression(Type, _toBase64UrlStringMethodName, new[] { value }));

        private const string _fromBase64UrlStringMethodName = "FromBase64UrlString";

        private Method BuildFromBase64UrlString()
        {
            var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromBase64UrlStringMethodName,
                Parameters: new[] { valueParameter },
                Modifiers: _methodModifiers,
                ReturnType: typeof(byte[]),
                Summary: null, Description: null, ReturnDescription: null);
            var value = new StringExpression(valueParameter);

            var body = new List<MethodBodyStatement>
            {
                Declare("paddingCharsToAdd", new IntExpression(new SwitchExpression(new BinaryOperatorExpression("%", value.Length, Literal(4)), new SwitchCaseExpression[]
                {
                    new SwitchCaseExpression(Int(0), Int(0)),
                    new SwitchCaseExpression(Int(2), Int(2)),
                    new SwitchCaseExpression(Int(3), Int(1)),
                    SwitchCaseExpression.Default(ThrowExpression(New.InvalidOperationException(Literal("Malformed input"))))
                })), out var paddingCharsToAdd)
            };
            var output = new VariableReference(typeof(char[]), "output");
            var outputLength = output.Property("Length");
            body.Add(new MethodBodyStatement[]
            {
                Declare(output, New.Array(typeof(char), new BinaryOperatorExpression("+", value.Length, paddingCharsToAdd))),
                Declare("i", Int(0), out var i),
                new ForStatement(null, LessThan(i, value.Length), new UnaryOperatorExpression("++", i, true))
                {
                    Declare("ch", value.Index(i), out var ch),
                    new IfElseStatement(new IfStatement(Equal(ch, Literal('-')))
                    {
                        Assign(new IndexerExpression(output, i), Literal('+'))
                    }, new IfElseStatement(new IfStatement(Equal(ch, Literal('_')))
                    {
                        Assign(new IndexerExpression(output, i), Literal('/'))
                    }, Assign<ValueExpression>(new IndexerExpression(output, i), ch)))
                },
                EmptyLine,
                new ForStatement(null, LessThan(i, outputLength), new UnaryOperatorExpression("++", i, true))
                {
                    Assign(new IndexerExpression(output, i), Literal('='))
                },
                EmptyLine,
                Return(new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.FromBase64CharArray), new[] { output, Int(0), outputLength }))
            });

            return new Method(signature, body);
        }

        public ValueExpression FromBase64UrlString(ValueExpression value)
            => new InvokeStaticMethodExpression(Type, _fromBase64UrlStringMethodName, new[] { value });

        private const string _parseDateTimeOffsetMethodName = "ParseDateTimeOffset";
        private Method BuildParseDateTimeOffsetMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _parseDateTimeOffsetMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter, formatParameter },
                ReturnType: typeof(DateTimeOffset),
                Summary: null, Description: null, ReturnDescription: null);

            var value = new StringExpression(valueParameter);
            var format = new StringExpression(formatParameter);
            var invariantCulture = new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture));
            return new Method(signature,
                new SwitchExpression(format, new SwitchCaseExpression[]
                {
                    new(Literal("U"), DateTimeOffsetExpression.FromUnixTimeSeconds(LongExpression.Parse(value, invariantCulture))),
                    SwitchCaseExpression.Default(DateTimeOffsetExpression.Parse(value, invariantCulture, new MemberExpression(typeof(DateTimeStyles), nameof(DateTimeStyles.AssumeUniversal))))
                }));
        }

        public DateTimeOffsetExpression ParseDateTimeOffset(ValueExpression value, ValueExpression format)
            => new(new InvokeStaticMethodExpression(Type, _parseDateTimeOffsetMethodName, new[] { value, format }));

        private const string _parseTimeSpanMethodName = "ParseTimeSpan";
        private Method BuildParseTimeSpanMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _parseTimeSpanMethodName,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter, formatParameter },
                ReturnType: typeof(TimeSpan),
                Summary: null, Description: null, ReturnDescription: null);

            var value = new StringExpression(valueParameter);
            var format = new StringExpression(formatParameter);
            return new Method(signature,
                new SwitchExpression(format, new SwitchCaseExpression[]
                {
                    new(Literal("P"), new InvokeStaticMethodExpression(typeof(XmlConvert), nameof(XmlConvert.ToTimeSpan), new[]{ value })),
                    SwitchCaseExpression.Default(TimeSpanExpression.ParseExact(value, format, new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture))))
                }));
        }

        public TimeSpanExpression ParseTimeSpan(ValueExpression value, ValueExpression format)
            => new(new InvokeStaticMethodExpression(Type, _parseTimeSpanMethodName, new[] { value, format }));
    }
}
