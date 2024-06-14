// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types.System
{
    internal class ClientUriBuilderProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ClientUriBuilderProvider> _instance = new(() => new ClientUriBuilderProvider());

        public static ClientUriBuilderProvider Instance => _instance.Value;

        private ClientUriBuilderProvider() : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal;
        }

        protected override string DefaultName => "ClientUriBuilder";

        private readonly FieldDeclaration _uriBuilderField = new(FieldModifiers.Private, typeof(UriBuilder), "_uriBuilder");
        private readonly FieldDeclaration _pathBuilderField = new(FieldModifiers.Private, typeof(StringBuilder), "_pathBuilder");
        private readonly FieldDeclaration _queryBuilderField = new(FieldModifiers.Private, typeof(StringBuilder), "_queryBuilder");

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _uriBuilderField;
            yield return _pathBuilderField;
            yield return _queryBuilderField;
        }

        private PropertyDeclaration? _uriBuilderProperty;
        private PropertyDeclaration UriBuilderProperty => _uriBuilderProperty ??= new(
                modifiers: MethodSignatureModifiers.Private,
                name: "UriBuilder",
                propertyType: typeof(UriBuilder),
                propertyBody: new ExpressionPropertyBody(new BinaryOperatorExpression(" ??= ", _uriBuilderField, New.Instance(typeof(UriBuilder)))),
                description: null);

        internal ValueExpression UriBuilderPath => new MemberExpression(UriBuilderProperty, "Path");
        internal ValueExpression UriBuilderQuery => new MemberExpression(UriBuilderProperty, "Query");

        private PropertyDeclaration? _pathBuilderProperty;
        private PropertyDeclaration PathBuilderProperty => _pathBuilderProperty ??= new(
                modifiers: MethodSignatureModifiers.Private,
                name: "PathBuilder",
                propertyType: typeof(StringBuilder),
                propertyBody: new ExpressionPropertyBody(new BinaryOperatorExpression(" ??= ", _pathBuilderField, New.Instance(typeof(StringBuilder), UriBuilderPath))),
                description: null);

        private PropertyDeclaration? _queryBuilderProperty;
        private PropertyDeclaration QueryBuilderProperty => _queryBuilderProperty ??= new(
                modifiers: MethodSignatureModifiers.Private,
                name: "QueryBuilder",
                propertyType: typeof(StringBuilder),
                propertyBody: new ExpressionPropertyBody(new BinaryOperatorExpression(" ??= ", _queryBuilderField, New.Instance(typeof(StringBuilder), UriBuilderQuery))),
                description: null);

        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return UriBuilderProperty;
            yield return PathBuilderProperty;
            yield return QueryBuilderProperty;
        }

        protected override IEnumerable<Method> BuildConstructors()
        {
            var signature = new ConstructorSignature(
                Type: Type,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: Array.Empty<Parameter>(),
                Summary: null, Description: null);
            yield return new(signature, EmptyStatement);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildResetMethod();

            foreach (var method in BuildAppendPathMethods())
            {
                yield return method;
            }

            foreach (var method in BuildAppendQueryMethods())
            {
                yield return method;
            }

            foreach (var method in BuildAppendQueryDelimitedMethods())
            {
                yield return method;
            }

            yield return BuildToUriMethod();
        }

        private const string _resetMethodName = "Reset";
        private Method BuildResetMethod()
        {
            var uriParameter = new Parameter("uri", null, typeof(Uri), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _resetMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: new[]
                {
                    uriParameter
                },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var body = new MethodBodyStatement[]
            {
                Assign(_uriBuilderField, New.Instance(_uriBuilderField.Type, uriParameter)),
                Assign(_pathBuilderField, New.Instance(_pathBuilderField.Type, UriBuilderPath)),
                Assign(_queryBuilderField, New.Instance(_queryBuilderField.Type, UriBuilderQuery))
            };

            return new(signature, body);
        }

        private const string _appendPathMethodName = "AppendPath";
        private IEnumerable<Method> BuildAppendPathMethods()
        {
            var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var escapeParameter = new Parameter("escape", null, typeof(bool), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _appendPathMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: new[] { valueParameter, escapeParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var value = new StringExpression(valueParameter);
            var escape = new BoolExpression(escapeParameter);
            var pathBuilder = new StringBuilderExpression(PathBuilderProperty);
            MethodBodyStatement body = new MethodBodyStatement[]
            {
                Argument.AssertNotNullOrWhiteSpace(value),
                EmptyLine,
                new IfStatement(escape)
                {
                    Assign(value, new InvokeStaticMethodExpression(typeof(Uri), nameof(Uri.EscapeDataString), new[]{ value }))
                },
                EmptyLine,
                new IfStatement(And(And(GreaterThan(pathBuilder.Length, Int(0)), Equal(new IndexerExpression(pathBuilder, pathBuilder.Length - Int(1)), Literal('/'))), Equal(new IndexerExpression(value, Int(0)), Literal('/'))))
                {
                    pathBuilder.Remove(pathBuilder.Length - Int(1), Int(1))
                },
                EmptyLine,
                pathBuilder.Append(value),
                Assign(UriBuilderPath, pathBuilder.InvokeToString())
            };

            yield return new(signature, body);

            yield return BuildAppendPathMethod(typeof(bool), false, false);
            yield return BuildAppendPathMethod(typeof(float), true, false);
            yield return BuildAppendPathMethod(typeof(double), true, false);
            yield return BuildAppendPathMethod(typeof(int), true, false);
            yield return BuildAppendPathMethod(typeof(byte[]), true, true);
            yield return BuildAppendPathMethod(typeof(IEnumerable<string>), true, false);
            yield return BuildAppendPathMethod(typeof(DateTimeOffset), true, true);
            yield return BuildAppendPathMethod(typeof(TimeSpan), true, true);
            yield return BuildAppendPathMethod(typeof(Guid), true, false);
            yield return BuildAppendPathMethod(typeof(long), true, false);
        }

        private Method BuildAppendPathMethod(CSharpType valueType, bool escapeDefaultValue, bool hasFormat)
        {
            var valueParameter = new Parameter("value", null, valueType, null, ValidationType.None, null);
            var escapeParameter = new Parameter("escape", null, typeof(bool), new Constant(escapeDefaultValue, typeof(bool)), ValidationType.None, null);
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { valueParameter, formatParameter, escapeParameter }
                : new[] { valueParameter, escapeParameter };

            var signature = new MethodSignature(
                Name: _appendPathMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: parameters,
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);
            // TODO -- this is temporary, in the future, TypeFormatters will be a standalone static class, but now it is a nested type inside ModelSerializationExtensions
            var typeFormattersProvider = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
            var convertToStringExpression = typeFormattersProvider.ConvertToString(valueParameter, hasFormat ? (ValueExpression)formatParameter : null);
            var body = new InvokeInstanceMethodStatement(null, _appendPathMethodName, convertToStringExpression, escapeParameter);

            return new(signature, body);
        }

        private const string _appendQueryMethodName = "AppendQuery";
        private IEnumerable<Method> BuildAppendQueryMethods()
        {
            var nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null);
            var escapeParameter = new Parameter("escape", null, typeof(bool), null, ValidationType.None, null);

            var signature = new MethodSignature(
                Name: _appendQueryMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: new[] { nameParameter, valueParameter, escapeParameter },
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);

            var name = new StringExpression(nameParameter);
            var value = new StringExpression(valueParameter);
            var escape = new BoolExpression(escapeParameter);
            var queryBuilder = new StringBuilderExpression(QueryBuilderProperty);
            var body = new MethodBodyStatement[]
            {
                Argument.AssertNotNullOrWhiteSpace(name),
                Argument.AssertNotNullOrWhiteSpace(value),
                EmptyLine,
                new IfStatement(GreaterThan(queryBuilder.Length, Int(0)))
                {
                    queryBuilder.Append(Literal('&'))
                },
                EmptyLine,
                new IfStatement(escape)
                {
                    Assign(value, new InvokeStaticMethodExpression(typeof(Uri), nameof(Uri.EscapeDataString), new[] { value }))
                },
                EmptyLine,
                queryBuilder.Append(name),
                queryBuilder.Append(Literal('=')),
                queryBuilder.Append(value)
            };

            yield return new(signature, body);

            yield return BuildAppendQueryMethod(typeof(bool), false, false);
            yield return BuildAppendQueryMethod(typeof(float), true, false);
            yield return BuildAppendQueryMethod(typeof(DateTimeOffset), true, true);
            yield return BuildAppendQueryMethod(typeof(TimeSpan), true, true);
            yield return BuildAppendQueryMethod(typeof(double), true, false);
            yield return BuildAppendQueryMethod(typeof(decimal), true, false);
            yield return BuildAppendQueryMethod(typeof(int), true, false);
            yield return BuildAppendQueryMethod(typeof(long), true, false);
            yield return BuildAppendQueryMethod(typeof(TimeSpan), true, false);
            yield return BuildAppendQueryMethod(typeof(byte[]), true, true);
            yield return BuildAppendQueryMethod(typeof(Guid), true, false);
        }

        private Method BuildAppendQueryMethod(CSharpType valueType, bool escapeDefaultValue, bool hasFormat)
        {
            var nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var valueParameter = new Parameter("value", null, valueType, null, ValidationType.None, null);
            var escapeParameter = new Parameter("escape", null, typeof(bool), new Constant(escapeDefaultValue, typeof(bool)), ValidationType.None, null);
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var parameters = hasFormat
                ? new[] { nameParameter, valueParameter, formatParameter, escapeParameter }
                : new[] { nameParameter, valueParameter, escapeParameter };

            var signature = new MethodSignature(
                Name: _appendQueryMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: parameters,
                ReturnType: null,
                Summary: null, Description: null, ReturnDescription: null);
            // TODO -- this is temporary, in the future, TypeFormatters will be a standalone static class, but now it is a nested type inside ModelSerializationExtensions
            var typeFormattersProvider = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
            var convertToStringExpression = typeFormattersProvider.ConvertToString(valueParameter, hasFormat ? (ValueExpression)formatParameter : null);
            var body = new InvokeInstanceMethodStatement(null, _appendQueryMethodName, nameParameter, convertToStringExpression, escapeParameter);

            return new(signature, body);
        }

        private IEnumerable<Method> BuildAppendQueryDelimitedMethods()
        {
            yield return BuildAppendQueryDelimitedMethod(false);
            yield return BuildAppendQueryDelimitedMethod(true);
        }

        private readonly CSharpType _t = typeof(IEnumerable<>).GetGenericArguments()[0];

        private const string _appendQueryDelimitedMethodName = "AppendQueryDelimited";
        private Method BuildAppendQueryDelimitedMethod(bool hasFormat)
        {
            var nameParameter = new Parameter("name", null, typeof(string), null, ValidationType.None, null);
            var valueParameter = new Parameter("value", null, new CSharpType(typeof(IEnumerable<>), _t), null, ValidationType.None, null);
            var delimiterParameter = new Parameter("delimiter", null, typeof(string), null, ValidationType.None, null);
            var formatParameter = new Parameter("format", null, typeof(string), null, ValidationType.None, null);
            var escapeParameter = new Parameter("escape", null, typeof(bool), new Constant(true, typeof(bool)), ValidationType.None, null);

            var parameters = hasFormat
                ? new[] { nameParameter, valueParameter, delimiterParameter, formatParameter, escapeParameter }
                : new[] { nameParameter, valueParameter, delimiterParameter, escapeParameter };
            var signature = new MethodSignature(
                Name: _appendQueryDelimitedMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: parameters,
                ReturnType: null,
                GenericArguments: new[] { _t },
                Summary: null, Description: null, ReturnDescription: null);

            var name = new StringExpression(nameParameter);
            var value = new EnumerableExpression(_t, valueParameter);
            var delimiter = new StringExpression(delimiterParameter);
            var format = hasFormat ? new StringExpression(formatParameter) : null;
            var escape = new BoolExpression(escapeParameter);

            var typeFormattersProvider = (TypeFormattersProvider)ModelSerializationExtensionsProvider.Instance.NestedTypes[0];
            var v = new VariableReference(_t, "v");
            var body = new[]
            {
                Var("stringValues", value.Select(new TypedFuncExpression(new[] {v.Declaration}, typeFormattersProvider.ConvertToString(v, format))), out var stringValues),
                new InvokeInstanceMethodStatement(null, _appendQueryMethodName, name, StringExpression.Join(delimiter, stringValues), escape)
            };

            return new(signature, body);
        }

        private const string _toUriMethodName = "ToUri";
        private Method BuildToUriMethod()
        {
            var signature = new MethodSignature(
                Name: _toUriMethodName,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: Array.Empty<Parameter>(),
                ReturnType: typeof(Uri),
                Summary: null, Description: null, ReturnDescription: null);

            var pathBuilder = (ValueExpression)_pathBuilderField;
            var queryBuilder = (ValueExpression)_queryBuilderField;
            var body = new MethodBodyStatement[]
            {
                new IfStatement(NotEqual(pathBuilder, Null))
                {
                    Assign(UriBuilderPath, pathBuilder.InvokeToString())
                },
                EmptyLine,
                new IfStatement(NotEqual(queryBuilder, Null))
                {
                    Assign(UriBuilderQuery, queryBuilder.InvokeToString())
                },
                EmptyLine,
                Return(new MemberExpression(UriBuilderProperty, nameof(UriBuilder.Uri)))
            };

            return new(signature, body);
        }
    }
}
