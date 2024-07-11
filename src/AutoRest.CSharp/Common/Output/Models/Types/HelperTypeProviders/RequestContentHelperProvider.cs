// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class RequestContentHelperProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<RequestContentHelperProvider> _instance = new Lazy<RequestContentHelperProvider>(() => new RequestContentHelperProvider());
        public static RequestContentHelperProvider Instance => _instance.Value;

        private readonly CSharpType _requestBodyType;
        private readonly CSharpType _utf8JsonRequestBodyType;

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static;
        private RequestContentHelperProvider() : base(Configuration.HelperNamespace, null)
        {
            DefaultName = $"{Configuration.ApiTypes.RequestContentType.Name}Helper";
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _requestBodyType = Configuration.ApiTypes.RequestContentType;
            _utf8JsonRequestBodyType = Utf8JsonRequestContentProvider.Instance.Type;
        }

        protected override string DefaultName { get; }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildFromEnumerableTMethod();
            yield return BuildFromEnumerableBinaryDataMethod();
            yield return BuildFromReadOnlySpanMethod();

            yield return BuildFromDictionaryTMethod();
            yield return BuildFromDictionaryBinaryDataMethod();

            yield return BuildFromObjectMethod();
            yield return BuildFromBinaryDataMethod();
        }

        private const string _fromEnumerableName = "FromEnumerable";

        public ValueExpression FromEnumerable(ValueExpression enumerable)
            => new InvokeStaticMethodExpression(Type, _fromEnumerableName, new[] { enumerable });

        private Method BuildFromEnumerableTMethod()
        {
            var enumerableTType = typeof(IEnumerable<>);
            CSharpType tType = enumerableTType.GetGenericArguments()[0];
            var enumerableParameter = new Parameter("enumerable", null, enumerableTType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromEnumerableName,
                Modifiers: _methodModifiers,
                Parameters: new[] { enumerableParameter },
                ReturnType: _requestBodyType,
                GenericArguments: new[] { tType },
                GenericParameterConstraints: new[]
                {
                    Where.NotNull(tType)
                },
                Summary: null, Description: null, ReturnDescription: null);

            var enumerable = new EnumerableExpression(tType, enumerableParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartArray(),
                new ForeachStatement("item", enumerable, out var item)
                {
                    writer.WriteObjectValue(item, ModelReaderWriterOptionsExpression.Wire)
                },
                writer.WriteEndArray(),
                EmptyLine,
                Return(content)
            });

            return new Method(signature, body);
        }

        private Method BuildFromEnumerableBinaryDataMethod()
        {
            var enumerableParameter = new Parameter("enumerable", null, typeof(IEnumerable<BinaryData>), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromEnumerableName,
                Modifiers: _methodModifiers,
                Parameters: new[] { enumerableParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var enumerable = new EnumerableExpression(typeof(BinaryData), enumerableParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartArray(),
                new ForeachStatement("item", enumerable, out var item)
                {
                    new IfElseStatement(
                        Equal(item, Null),
                        writer.WriteNullValue(),
                        writer.WriteBinaryData(item))
                },
                writer.WriteEndArray(),
                EmptyLine,
                Return(content)
            });

            return new Method(signature, body);
        }

        private Method BuildFromReadOnlySpanMethod()
        {
            var spanType = typeof(ReadOnlySpan<>);
            CSharpType tType = spanType.GetGenericArguments()[0];
            var spanParameter = new Parameter("span", null, spanType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromEnumerableName,
                Modifiers: _methodModifiers,
                Parameters: new[] { spanParameter },
                ReturnType: _requestBodyType,
                GenericArguments: new[] { tType },
                GenericParameterConstraints: new[]
                {
                    Where.NotNull(tType)
                },
                Summary: null, Description: null, ReturnDescription: null);

            var span = (ValueExpression)spanParameter;
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            var i = new VariableReference(typeof(int), "i");
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartArray(),
                new ForStatement(new AssignmentExpression(i, Int(0)), LessThan(i, span.Property(nameof(ReadOnlySpan<byte>.Length))), new UnaryOperatorExpression("++", i, true))
                {
                    writer.WriteObjectValue(new TypedValueExpression(tType, new IndexerExpression(span, i)), ModelReaderWriterOptionsExpression.Wire)
                },
                writer.WriteEndArray(),
                EmptyLine,
                Return(content)
            });

            return new Method(signature, body);
        }

        private const string _fromDictionaryName = "FromDictionary";

        public ValueExpression FromDictionary(ValueExpression dictionary)
            => new InvokeStaticMethodExpression(Type, _fromDictionaryName, new[] { dictionary });

        private Method BuildFromDictionaryTMethod()
        {
            var dictionaryTType = typeof(IDictionary<,>);
            CSharpType valueType = dictionaryTType.GetGenericArguments()[1];
            var dictionaryParameter = new Parameter("dictionary", null, new CSharpType(dictionaryTType, typeof(string), valueType), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromDictionaryName,
                Modifiers: _methodModifiers,
                Parameters: new[] { dictionaryParameter },
                ReturnType: _requestBodyType,
                GenericArguments: new[] { valueType },
                GenericParameterConstraints: new[]
                {
                    Where.NotNull(valueType)
                },
                Summary: null, Description: null, ReturnDescription: null);

            var dictionary = new DictionaryExpression(typeof(string), valueType, dictionaryParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartObject(),
                new ForeachStatement("item", dictionary, out var item)
                {
                    writer.WritePropertyName(item.Key),
                    writer.WriteObjectValue(item.Value, ModelReaderWriterOptionsExpression.Wire)
                },
                writer.WriteEndObject(),
                EmptyLine,
                Return(content)
            });

            return new Method(signature, body);
        }

        private Method BuildFromDictionaryBinaryDataMethod()
        {
            var dictionaryParameter = new Parameter("dictionary", null, typeof(IDictionary<string, BinaryData>), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromDictionaryName,
                Modifiers: _methodModifiers,
                Parameters: new[] { dictionaryParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var dictionary = new DictionaryExpression(typeof(string), typeof(BinaryData), dictionaryParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartObject(),
                new ForeachStatement("item", dictionary, out var item)
                {
                    writer.WritePropertyName(item.Key),
                    new IfElseStatement(
                        Equal(item.Value, Null),
                        writer.WriteNullValue(),
                        writer.WriteBinaryData(item.Value))
                },
                writer.WriteEndObject(),
                EmptyLine,
                Return(content)
            });

            return new Method(signature, body);
        }

        private const string _fromObjectName = "FromObject";

        public ValueExpression FromObject(ValueExpression value)
            => new InvokeStaticMethodExpression(Type, _fromObjectName, new[] { value });

        private Method BuildFromObjectMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(object), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromObjectName,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var body = new MethodBodyStatement[]
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content),
                Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content).WriteObjectValue(valueParameter, ModelReaderWriterOptionsExpression.Wire),
                Return(content)
            };

            return new Method(signature, body);
        }

        private Method BuildFromBinaryDataMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(BinaryData), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: _fromObjectName,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = Utf8JsonRequestContentProvider.Instance.JsonWriterProperty(content);
            var value = new BinaryDataExpression(valueParameter);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteBinaryData(value),
                Return(content)
            });

            return new Method(signature, body);
        }
    }
}
