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
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class RequestUriBuilderExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<RequestUriBuilderExtensionsProvider> _instance = new Lazy<RequestUriBuilderExtensionsProvider>(() => new RequestUriBuilderExtensionsProvider());
        public static RequestUriBuilderExtensionsProvider Instance => _instance.Value;
        private class TryGetValueMethodTemplate<T> { }

        private static readonly CSharpType _t = typeof(TryGetValueMethodTemplate<>).GetGenericArguments()[0];

        // TODO -- workaround, to be removed
        private readonly TypeFormattersProvider _typeFormatters;

        private RequestUriBuilderExtensionsProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Static;
            DefaultName = $"RequestUriBuilderExtensions";
            _typeFormatters = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
        }

        protected override string DefaultName { get; }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildAppendPathMethod<bool>(false);
            yield return BuildAppendPathMethod<float>(false);
            yield return BuildAppendPathMethod<double>(false);
            yield return BuildAppendPathMethod<int>(false);
            yield return BuildAppendPathMethod<byte[]>(true);
            yield return BuildAppendPathMethod<IEnumerable<string>>(false);
            yield return BuildAppendPathMethod<DateTimeOffset>(true);
            yield return BuildAppendPathMethod<TimeSpan>(true);
            yield return BuildAppendPathMethod<Guid>(false);
            yield return BuildAppendPathMethod<long>(false);

            yield return BuildAppendQueryMethod<bool>(false);
            yield return BuildAppendQueryMethod<float>(false);
            yield return BuildAppendQueryMethod<DateTimeOffset>(true);
            yield return BuildAppendQueryMethod<TimeSpan>(true);
            yield return BuildAppendQueryMethod<double>(false);
            yield return BuildAppendQueryMethod<decimal>(false);
            yield return BuildAppendQueryMethod<int>(false);
            yield return BuildAppendQueryMethod<long>(false);
            yield return BuildAppendQueryMethod<TimeSpan>(false);
            yield return BuildAppendQueryMethod<byte[]>(true);
            yield return BuildAppendQueryMethod<Guid>(false);

            yield return BuildAppendQueryDelimited(false);
            yield return BuildAppendQueryDelimited(true);
        }

        private const string _appendPath = "AppendPath";
        private const string _appendQuery = "AppendQuery";
        private const string _appendQueryDelimited = "AppendQueryDelimited";
        private readonly Parameter _builderParameter = new Parameter("builder", null, typeof(RequestUriBuilder), null, ValidationType.None, null);
        private readonly Parameter _formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
        private readonly Parameter _escapeParameter = new Parameter("escape", null, typeof(bool), null, ValidationType.None, null);
        private readonly Parameter _nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);

        private Method BuildAppendPathMethod<T>(bool hasFormat)
        {
            var valueParameter = new Parameter("value", null, typeof(T), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { _builderParameter, valueParameter, _formatParameter, _escapeParameter }
                : new[] { _builderParameter, valueParameter, _escapeParameter };
            var signature = new MethodSignature(
                Name: _appendPath,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: null,
                Parameters: parameters,
                Summary: null, Description: null, ReturnDescription: null);

            var builder = (ValueExpression)_builderParameter;
            var body = hasFormat
                ? new InvokeInstanceMethodStatement(builder, nameof(RequestUriBuilder.AppendPath), _typeFormatters.ConvertToString(valueParameter, _formatParameter), _escapeParameter)
                : new InvokeInstanceMethodStatement(builder, nameof(RequestUriBuilder.AppendPath), _typeFormatters.ConvertToString(valueParameter), _escapeParameter);

            return new(signature, body);
        }

        private Method BuildAppendQueryMethod<T>(bool hasFormat)
        {
            var valueParameter = new Parameter("value", null, typeof(T), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { _builderParameter, _nameParameter, valueParameter, _formatParameter, _escapeParameter }
                : new[] { _builderParameter, _nameParameter, valueParameter, _escapeParameter };
            var signature = new MethodSignature(
                Name: _appendQuery,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: null,
                Parameters: parameters,
                Summary: null, Description: null, ReturnDescription: null);
            var builder = (ValueExpression)_builderParameter;
            var body = hasFormat
                ? new InvokeInstanceMethodStatement(builder, nameof(RequestUriBuilder.AppendQuery), new ValueExpression[] { _nameParameter, _typeFormatters.ConvertToString(valueParameter, _formatParameter), _escapeParameter }, false)
                : new InvokeInstanceMethodStatement(builder, nameof(RequestUriBuilder.AppendQuery), new ValueExpression[] { _nameParameter, _typeFormatters.ConvertToString(valueParameter), _escapeParameter }, false);

            return new(signature, body);
        }

        private Method BuildAppendQueryDelimited(bool hasFormat)
        {
            CSharpType valueType = typeof(IEnumerable<>);
            var t = valueType.Arguments[0];
            var valueParameter = new Parameter("value", null, typeof(IEnumerable<>), null, ValidationType.None, null);
            var delimiterParameter = new Parameter("delimiter", null, typeof(string), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { _builderParameter, _nameParameter, valueParameter, delimiterParameter, _formatParameter, _escapeParameter }
                : new[] { _builderParameter, _nameParameter, valueParameter, delimiterParameter, _escapeParameter };
            var signature = new MethodSignature(
                Name: _appendQueryDelimited,
                Modifiers: MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension,
                ReturnType: null,
                Parameters: parameters,
                GenericArguments: new[] { t },
                Summary: null, Description: null, ReturnDescription: null);

            var builder = (ValueExpression)_builderParameter;
            var value = new EnumerableExpression(t, valueParameter);
            var v = new CodeWriterDeclaration("v");
            var format = hasFormat ? (ValueExpression)_formatParameter : null;
            var body = new MethodBodyStatement[]
            {
                Declare("stringValues", value.Select(new TypedFuncExpression(new[] { v }, _typeFormatters.ConvertToString(new VariableReference(t, v), format))), out var stringValues),
                new InvokeInstanceMethodStatement(builder, nameof(RequestUriBuilder.AppendQuery), new ValueExpression[] { _nameParameter, StringExpression.Join(delimiterParameter, stringValues), _escapeParameter }, false)
            };

            return new(signature, body);
        }

        public MethodBodyStatement AppendPath(ValueExpression builder, ValueExpression value, string format, bool escape)
            => new InvokeStaticMethodStatement(Type, _appendPath, new[] { builder, value, Literal(format), Bool(escape) }, CallAsExtension: true);

        public MethodBodyStatement AppendQuery(ValueExpression builder, ValueExpression name, ValueExpression value, ValueExpression format, ValueExpression escape)
            => new InvokeStaticMethodStatement(Type, _appendQuery, new[] { builder, name, value, format, escape }, CallAsExtension: true);
        public MethodBodyStatement AppendQuery(ValueExpression builder, ValueExpression name, ValueExpression value, ValueExpression escape)
            => new InvokeStaticMethodStatement(Type, _appendQuery, new[] { builder, name, value, escape }, CallAsExtension: true);
        public MethodBodyStatement AppendQueryDelimited(ValueExpression builder, ValueExpression name, ValueExpression value, ValueExpression delimiter, ValueExpression escape)
            => new InvokeStaticMethodStatement(Type, _appendQueryDelimited, new[] { builder, name, value, delimiter, escape }, CallAsExtension: true);
        public MethodBodyStatement AppendQueryDelimited(ValueExpression builder, ValueExpression name, ValueExpression value, ValueExpression delimiter, ValueExpression format, ValueExpression escape)
            => new InvokeStaticMethodStatement(Type, _appendQueryDelimited, new[] { builder, name, value, delimiter, format, escape }, CallAsExtension: true);
    }
}
