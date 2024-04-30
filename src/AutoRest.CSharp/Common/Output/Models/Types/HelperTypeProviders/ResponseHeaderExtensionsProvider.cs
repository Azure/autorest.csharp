// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ResponseHeaderExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ResponseHeaderExtensionsProvider> _instance = new Lazy<ResponseHeaderExtensionsProvider>(() => new ResponseHeaderExtensionsProvider());
        public static ResponseHeaderExtensionsProvider Instance => _instance.Value;
        private class TryGetValueMethodTemplate<T> { }

        private static readonly CSharpType _t = typeof(TryGetValueMethodTemplate<>).GetGenericArguments()[0];

        // TODO -- workaround, to be removed
        private readonly TypeFormattersProvider _typeFormatters;

        private ResponseHeaderExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            DefaultName = $"{Configuration.ApiTypes.ResponseHeadersType.Name}Extensions";
            _typeFormatters = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];

            _knownFormatsField = new FieldDeclaration(
                modifiers: FieldModifiers.Private | FieldModifiers.ReadOnly | FieldModifiers.Static,
                type: typeof(string[]),
                name: "KnownFormats")
            {
                InitializationValue = new ArrayInitializerExpression(
                    new ValueExpression[]
                    {
                        Literal("ddd, d MMM yyyy H:m:s 'GMT'"), // RFC 1123 (r, except it allows both 1 and 01 for date and time)
                        Literal("ddd, d MMM yyyy H:m:s 'UTC'"), // RFC 1123, UTC
                        Literal("ddd, d MMM yyyy H:m:s"), // RFC 1123, no zone - assume GMT
                        Literal("d MMM yyyy H:m:s 'GMT'"), // RFC 1123, no day-of-week
                        Literal("d MMM yyyy H:m:s 'UTC'"), // RFC 1123, UTC, no day-of-week
                        Literal("d MMM yyyy H:m:s"), // RFC 1123, no day-of-week, no zone
                        Literal("ddd, d MMM yy H:m:s 'GMT'"), // RFC 1123, short year
                        Literal("ddd, d MMM yy H:m:s 'UTC'"), // RFC 1123, UTC, short year
                        Literal("ddd, d MMM yy H:m:s"), // RFC 1123, short year, no zone
                        Literal("d MMM yy H:m:s 'GMT'"), // RFC 1123, no day-of-week, short year
                        Literal("d MMM yy H:m:s 'UTC'"), // RFC 1123, UTC, no day-of-week, short year
                        Literal("d MMM yy H:m:s"), // RFC 1123, no day-of-week, short year, no zone
                        Literal("dddd, d'-'MMM'-'yy H:m:s 'GMT'"), // RFC 850
                        Literal("dddd, d'-'MMM'-'yy H:m:s 'UTC'"), // RFC 850, UTC
                        Literal("dddd, d'-'MMM'-'yy H:m:s zzz"), // RFC 850, offset
                        Literal("dddd, d'-'MMM'-'yy H:m:s"), // RFC 850 no zone
                        Literal("ddd MMM d H:m:s yyyy"), // ANSI C's asctime() format
                        Literal("ddd, d MMM yyyy H:m:s zzz"), // RFC 5322
                        Literal("ddd, d MMM yyyy H:m:s"), // RFC 5322 no zone
                        Literal("d MMM yyyy H:m:s zzz"), // RFC 5322 no day-of-week
                        Literal("d MMM yyyy H:m:s"), // RFC 5322 no day-of-week, no zone
                    }, IsInline: false)
            };
        }

        private readonly FieldDeclaration _knownFormatsField;

        protected override string DefaultName { get; }

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _knownFormatsField;
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildTryGetValueMethod(typeof(byte[]), ConvertToByteArray);
            yield return BuildTryGetValueMethod(typeof(TimeSpan?), ConvertToTimeSpan);
            yield return BuildTryGetValueMethod(typeof(DateTimeOffset?), ConvertToDateTimeOffset);
            yield return BuildTryGetValueMethod(_t.WithNullable(true), ConvertToT, _t, new WhereExpression(_t, new KeywordExpression("struct", null)));
            yield return BuildTryGetValueMethod(_t, ConvertToT, _t, new WhereExpression(_t, new KeywordExpression("class", null)));
            yield return BuildTryGetValueDictionaryMethod();
        }

        private readonly Parameter _headersParameter = new Parameter("headers", null, Configuration.ApiTypes.ResponseHeadersType, null, ValidationType.None, null);
        private readonly Parameter _nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);

        private const string _tryGetValue = "TryGetValue";

        /// <summary>
        /// Build a TryGetValue method.
        /// The conversionFunc consumes the ValueExpression value (the out parameter on signature) and the VariableReference variable (the out string value of calling TryGetValue on the headers), and produces a MethodBodyStatement that converts the string value to the value with specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conversionFunc"></param>
        /// <returns></returns>
        private Method BuildTryGetValueMethod(CSharpType type, Func<ValueExpression, VariableReference, MethodBodyStatement> conversionFunc, CSharpType? argument = null, WhereExpression? constrait = null)
        {
            var valueParameter = new Parameter("value", null, type, null, ValidationType.None, null, IsOut: true);
            var signature = new MethodSignature(
                Name: _tryGetValue,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: typeof(bool),
                Parameters: new[] { _headersParameter, _nameParameter, valueParameter },
                GenericArguments: argument != null ? new[] { argument } : null,
                GenericParameterConstraints: constrait != null ? new[] { constrait } : null,
                Summary: null, Description: null, ReturnDescription: null);

            var value = (ValueExpression)valueParameter;
            var headers = (ValueExpression)_headersParameter;
            var body = new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(headers.Invoke(_tryGetValue, _nameParameter, new DeclarationExpression(typeof(string), "stringValue", out var stringValue, isOut: true))))
                {
                    conversionFunc(value, stringValue),
                    Return(True)
                },
                EmptyLine,
                Assign(value, Null),
                Return(False)
            };

            return new(signature, body);
        }

        private static MethodBodyStatement ConvertToByteArray(ValueExpression value, VariableReference stringValue)
        {
            return Assign(value, InvokeConvert.FromBase64String(stringValue));
        }

        private static MethodBodyStatement ConvertToTimeSpan(ValueExpression value, VariableReference stringValue)
        {
            return Assign(value, InvokeConvert.ToTimeSpan(stringValue));
        }

        // TODO -- change to static when we make typeformattersprovider static
        private MethodBodyStatement ConvertToDateTimeOffset(ValueExpression value, VariableReference stringValue)
        {
            var invariantFormatInfo = new MemberExpression(typeof(DateTimeFormatInfo), nameof(DateTimeFormatInfo.InvariantInfo));
            return new IfElseStatement(
                Or(
                    DateTimeOffsetExpression.TryParseExact(stringValue, Literal("r"), invariantFormatInfo, FrameworkEnumValue(DateTimeStyles.None), new DeclarationExpression(typeof(DateTimeOffset), "dto", out var dto, isOut: true)),
                    DateTimeOffsetExpression.TryParseExact(stringValue, _knownFormatsField, invariantFormatInfo, new BinaryOperatorExpression("|", FrameworkEnumValue(DateTimeStyles.AllowInnerWhite), FrameworkEnumValue(DateTimeStyles.AssumeUniversal)), new KeywordExpression("out", dto))
                ),
                Assign(value, dto),
                Assign(value, _typeFormatters.ParseDateTimeOffset(stringValue, Literal("")))
            );
        }

        private static MethodBodyStatement ConvertToT(ValueExpression value, VariableReference stringValue)
        {
            return Assign(value, InvokeConvert.ChangeType(stringValue, Typeof(_t), new MemberExpression(typeof(CultureInfo), nameof(CultureInfo.InvariantCulture))).CastTo(_t));
        }

        private Method BuildTryGetValueDictionaryMethod()
        {
            var prefixParameter = new Parameter("prefix", null, typeof(string), null, ValidationType.None, null);
            var valueParameter = new Parameter("value", null, typeof(IDictionary<string, string>), null, ValidationType.None, null, IsOut: true);
            var signature = new MethodSignature(
                Name: _tryGetValue,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: typeof(bool),
                Parameters: new[] { _headersParameter, prefixParameter, valueParameter },
                Summary: null, Description: null, ReturnDescription: null);

            var prefix = new StringExpression(prefixParameter);
            var value = new DictionaryExpression(typeof(string), typeof(string), valueParameter);
            var headers = new EnumerableExpression(typeof(HttpHeader), _headersParameter);
            var body = new MethodBodyStatement[]
            {
                Assign(value, New.Instance(typeof(Dictionary<string, string>), new MemberExpression(typeof(StringComparer), nameof(StringComparer.OrdinalIgnoreCase)))),
                EmptyLine,
                new ForeachStatement("item", headers, false, out var item)
                {
                    new IfStatement(new BoolExpression(item.Property(nameof(HttpHeader.Name)).Invoke(nameof(string.StartsWith), prefix, FrameworkEnumValue(StringComparison.OrdinalIgnoreCase))))
                    {
                        value.Add(item.Property(nameof(HttpHeader.Name)).Invoke(nameof(string.Substring), prefix.Length), item.Property(nameof(HttpHeader.Value)))
                    }
                },
                EmptyLine,
                Return(True)
            };

            return new(signature, body);
        }
    }
}
