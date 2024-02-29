// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class RequestBodyHelperProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<RequestBodyHelperProvider> _instance = new Lazy<RequestBodyHelperProvider>(() => new RequestBodyHelperProvider(Configuration.Namespace));
        public static RequestBodyHelperProvider Instance => _instance.Value;

        private readonly MethodSignatureModifiers _methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static;
        private RequestBodyHelperProvider(string defaultNamespace) : base(defaultNamespace, null)
        {
            DefaultName = Configuration.IsBranded ? "RequestContentHelper" : "RequestBodyHelper";
            IsStatic = true;
        }

        private readonly CSharpType _requestBodyType = Configuration.IsBranded ? typeof(RequestContent) : typeof(RequestBody);
        private readonly CSharpType _utf8JsonRequestBodyType = Configuration.IsBranded ? typeof(Utf8JsonRequestContent) : typeof(Utf8JsonRequestBody);

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "internal";

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildFromEnumerableTMethod();
            yield return BuildFromEnumerableBinaryDataMethod();

            yield return BuildFromDictionaryTMethod();
            yield return BuildFromDictionaryBinaryDataMethod();

            yield return BuildFromObjectMethod();
            yield return BuildFromBinaryDataMethod();
        }

        private static readonly string JsonWriter = Configuration.IsBranded ? nameof(Utf8JsonRequestContent.JsonWriter) : nameof(Utf8JsonRequestBody.JsonWriter);

        private Method BuildFromEnumerableTMethod()
        {
            var enumerableTType = typeof(IEnumerable<>);
            CSharpType tType = enumerableTType.GetGenericArguments()[0];
            var enumerableParameter = new Parameter("enumerable", null, enumerableTType, null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: FromEnumerable,
                Modifiers: _methodModifiers,
                Parameters: new[] { enumerableParameter },
                ReturnType: _requestBodyType,
                GenericArguments: new[] { tType },
                GenericParameterConstraints: new[]
                {
                    new WhereExpression(tType, new KeywordExpression("notnull", null))
                },
                Summary: null, Description: null, ReturnDescription: null);

            var enumerable = new EnumerableExpression(tType, enumerableParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartArray(),
                new ForeachStatement("item", enumerable, out var item)
                {
                    writer.WriteObjectValue(item)
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
                Name: FromEnumerable,
                Modifiers: _methodModifiers,
                Parameters: new[] { enumerableParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var enumerable = new EnumerableExpression(typeof(BinaryData), enumerableParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
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

        private Method BuildFromDictionaryTMethod()
        {
            var dictionaryTType = typeof(IDictionary<,>);
            CSharpType valueType = dictionaryTType.GetGenericArguments()[1];
            var dictionaryParameter = new Parameter("dictionary", null, new CSharpType(dictionaryTType, typeof(string), valueType), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: FromDictionary,
                Modifiers: _methodModifiers,
                Parameters: new[] { dictionaryParameter },
                ReturnType: _requestBodyType,
                GenericArguments: new[] { valueType },
                GenericParameterConstraints: new[]
                {
                    new WhereExpression(valueType, new KeywordExpression("notnull", null))
                },
                Summary: null, Description: null, ReturnDescription: null);

            var dictionary = new DictionaryExpression(typeof(string), valueType, dictionaryParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteStartObject(),
                new ForeachStatement("item", dictionary, out var item)
                {
                    writer.WritePropertyName(item.Key),
                    writer.WriteObjectValue(item.Value)
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
                Name: FromDictionary,
                Modifiers: _methodModifiers,
                Parameters: new[] { dictionaryParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var dictionary = new DictionaryExpression(typeof(string), typeof(BinaryData), dictionaryParameter);
            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
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

        private Method BuildFromObjectMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(object), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: FromObject,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
            var value = (ValueExpression)valueParameter;
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteObjectValue(value),
                Return(content)
            });

            return new Method(signature, body);
        }

        private Method BuildFromBinaryDataMethod()
        {
            var valueParameter = new Parameter("value", null, typeof(BinaryData), null, ValidationType.None, null);
            var signature = new MethodSignature(
                Name: FromObject,
                Modifiers: _methodModifiers,
                Parameters: new[] { valueParameter },
                ReturnType: _requestBodyType,
                Summary: null, Description: null, ReturnDescription: null);

            var body = new List<MethodBodyStatement>
            {
                Declare(_utf8JsonRequestBodyType, "content", New.Instance(_utf8JsonRequestBodyType), out var content)
            };
            var writer = new Utf8JsonWriterExpression(content.Property(JsonWriter));
            var value = new BinaryDataExpression(valueParameter);
            body.Add(new MethodBodyStatement[]
            {
                writer.WriteBinaryData(value),
                Return(content)
            });

            return new Method(signature, body);
        }

        public const string FromEnumerable = "FromEnumerable";
        public const string FromDictionary = "FromDictionary";
        public const string FromObject = "FromObject";
    }
}
