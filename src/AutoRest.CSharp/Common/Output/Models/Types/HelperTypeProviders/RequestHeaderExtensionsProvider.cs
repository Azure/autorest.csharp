// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class RequestHeaderExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<RequestHeaderExtensionsProvider> _instance = new Lazy<RequestHeaderExtensionsProvider>(() => new RequestHeaderExtensionsProvider());
        public static RequestHeaderExtensionsProvider Instance => _instance.Value;

        // TODO -- workaround, to be removed
        private readonly TypeFormattersProvider _typeFormatters;

        private RequestHeaderExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Static;
            DefaultName = $"RequestHeaderExtensions";
            _typeFormatters = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
        }

        protected override string DefaultName { get; }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildAddMethod<bool>(false);
            yield return BuildAddMethod<float>(false);
            yield return BuildAddMethod<double>(false);
            yield return BuildAddMethod<int>(false);
            yield return BuildAddMethod<long>(false);
            yield return BuildAddMethod<DateTimeOffset>(true);
            yield return BuildAddMethod<TimeSpan>(true);
            yield return BuildAddMethod<Guid>(false);
            yield return BuildAddMethod<byte[]>(true);
            yield return BuildAddMethod<BinaryData>(true);

            yield return BuildAddDictionaryMethod();
            yield return BuildAddEtagMethod();

            yield return BuildAddMatchConditionsMethod();
            yield return BuildRequestConditionsMethod();

            yield return BuildAddDelimitedMethod();
            yield return BuildAddDelimitedMethodWithFormat();
        }

        private const string _add = "Add";
        private const string _addDelimited = "AddDelimited";
        private readonly Parameter _headersParameter = new Parameter("headers", null, Configuration.ApiTypes.RequestHeadersType, null, ValidationType.None, null);
        private readonly Parameter _nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
        private readonly Parameter _delimiterParameter = new Parameter("delimiter", null, typeof(string), null, ValidationType.None, null);

        private Method BuildAddMethod<T>(bool hasFormat)
        {
            var valueParameter = new Parameter("value", null, typeof(T), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { _headersParameter, _nameParameter, valueParameter, _formatParameter }
                : new[] { _headersParameter, _nameParameter, valueParameter };
            var signature = new MethodSignature(
                Name: _add,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: parameters,
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var format = hasFormat ? (ValueExpression)_formatParameter : null;
            var headers = new RequestHeadersExpression(_headersParameter);
            var body = headers.Add(_nameParameter, _typeFormatters.ConvertToString(valueParameter, format));

            return new(signature, body);
        }

        private Method BuildAddDictionaryMethod()
        {
            var prefixParameter = new Parameter("prefix", null, typeof(string), null, ValidationType.None, null);
            var headersToAddParameter = new Parameter("headersToAdd", null, typeof(IDictionary<string, string>), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _add,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, prefixParameter, headersToAddParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var headersToAdd = new DictionaryExpression(typeof(string), typeof(string), headersToAddParameter);
            var headers = new RequestHeadersExpression(_headersParameter);
            var body = new ForeachStatement("header", headersToAdd, out var header)
            {
                headers.Add(new BinaryOperatorExpression("+", prefixParameter, header.Key), header.Value)
            };

            return new(signature, body);
        }

        private Method BuildAddEtagMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(ETag), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _add,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, _nameParameter, valueParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var headers = new RequestHeadersExpression(_headersParameter);
            var value = new ETagExpression(valueParameter);
            var body = headers.Add(_nameParameter, value.InvokeToString(Literal("H")));

            return new(signature, body);
        }

        private Method BuildAddMatchConditionsMethod()
        {
            var conditionsParameter = new Parameter("conditions", null, typeof(MatchConditions), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _add,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, conditionsParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var headers = new RequestHeadersExpression(_headersParameter);
            var conditions = new MatchConditionsExpression(conditionsParameter);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(conditions.IfMatch, Null))
                {
                    headers.Add(Literal("If-Match"), conditions.IfMatch.NullableStructValue())
                },
                EmptyLine,
                new IfStatement(NotEqual(conditions.IfNoneMatch, Null))
                {
                    headers.Add(Literal("If-None-Match"), conditions.IfNoneMatch.NullableStructValue())
                }
            };

            return new(signature, body);
        }

        private Method BuildRequestConditionsMethod()
        {
            var conditionsParameter = new Parameter("conditions", null, typeof(RequestConditions), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _add,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, conditionsParameter, _formatParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var headers = new RequestHeadersExpression(_headersParameter);
            var conditions = new RequestConditionsExpression(conditionsParameter);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(conditions.IfMatch, Null))
                {
                    headers.Add(Literal("If-Match"), conditions.IfMatch.NullableStructValue())
                },
                EmptyLine,
                new IfStatement(NotEqual(conditions.IfNoneMatch, Null))
                {
                    headers.Add(Literal("If-None-Match"), conditions.IfNoneMatch.NullableStructValue())
                },
                EmptyLine,
                new IfStatement(NotEqual(conditions.IfModifiedSince, Null))
                {
                    headers.Add(Literal("If-Modified-Since"), conditions.IfModifiedSince.NullableStructValue(), _formatParameter)
                },
                EmptyLine,
                new IfStatement(NotEqual(conditions.IfUnmodifiedSince, Null))
                {
                    headers.Add(Literal("If-Unmodified-Since"), conditions.IfUnmodifiedSince.NullableStructValue(), _formatParameter)
                }
            };

            return new(signature, body);
        }

        private Method BuildAddDelimitedMethod()
        {
            CSharpType valueType = typeof(IEnumerable<>);
            var t = valueType.Arguments[0];
            var valueParameter = new Parameter("value", null, valueType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _addDelimited,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, _nameParameter, valueParameter, _delimiterParameter },
                ReturnType: null,
                GenericArguments: new[] { t },
                Summary: null, Description: null, ReturnDescription: null);

            var headers = new RequestHeadersExpression(_headersParameter);
            var body = headers.Add(_nameParameter, StringExpression.Join(_delimiterParameter, valueParameter));
            return new(signature, body);
        }

        private Method BuildAddDelimitedMethodWithFormat()
        {
            CSharpType valueType = typeof(IEnumerable<>);
            var t = valueType.Arguments[0];
            var valueParameter = new Parameter("value", null, valueType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _addDelimited,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                Parameters: new[] { _headersParameter, _nameParameter, valueParameter, _delimiterParameter, _formatParameter },
                ReturnType: null,
                GenericArguments: new[] { t },
                Summary: null, Description: null, ReturnDescription: null);

            var headers = new RequestHeadersExpression(_headersParameter);
            var value = new EnumerableExpression(t, valueParameter);
            var v = new CodeWriterDeclaration("v");
            var body = new MethodBodyStatement[]
            {
                Declare("stringValues", value.Select(new TypedFuncExpression(new[] {v}, _typeFormatters.ConvertToString(new VariableReference(t, v), _formatParameter))), out var stringValues),
                headers.Add(_nameParameter, StringExpression.Join(_delimiterParameter, stringValues))
            };
            return new(signature, body);
        }

        public MethodBodyStatement Add(ValueExpression headers, ValueExpression name, ValueExpression value, ValueExpression format)
            => new InvokeStaticMethodStatement(Type, _add, new[] { headers, name, value, format }, CallAsExtension: true);

        public MethodBodyStatement Add(ValueExpression headers, ValueExpression conditions)
            => new InvokeStaticMethodStatement(Type, _add, new[] { headers, conditions });
        public MethodBodyStatement Add(ValueExpression headers, ValueExpression conditions, ValueExpression format)
            => new InvokeStaticMethodStatement(Type, _add, new[] { headers, conditions, format });

        public MethodBodyStatement AddDelimited(ValueExpression headers, ValueExpression name, ValueExpression value, ValueExpression delimiter)
            => new InvokeStaticMethodStatement(Type, _addDelimited, new[] { headers, name, value, delimiter }, CallAsExtension: true);

        public MethodBodyStatement AddDelimited(ValueExpression headers, ValueExpression name, ValueExpression value, ValueExpression delimiter, ValueExpression format)
            => new InvokeStaticMethodStatement(Type, _addDelimited, new[] { headers, name, value, delimiter, format }, CallAsExtension: true);
    }
}
