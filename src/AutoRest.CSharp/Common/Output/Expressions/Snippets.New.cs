﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class New
        {
            public static ValueExpression ArgumentOutOfRangeException(EnumType enumType, Parameter valueParameter)
                => Instance(typeof(ArgumentOutOfRangeException), Nameof(valueParameter), valueParameter, Literal($"Unknown {enumType.Declaration.Name} value."));
            public static ValueExpression NotImplementedException(string name)
                => Instance(typeof(NotImplementedException), Literal($"Method {name} is implemented in customized code."));

            public static EnumerableExpression Array(CSharpType? elementType) => new(elementType ?? typeof(object), new NewArrayExpression(elementType));
            public static EnumerableExpression Array(CSharpType? elementType, params ValueExpression[] items) => new(elementType ?? typeof(object), new NewArrayExpression(elementType, new ArrayInitializerExpression(items)));
            public static EnumerableExpression Array(CSharpType? elementType, bool isInline, params ValueExpression[] items) => new(elementType ?? typeof(object), new NewArrayExpression(elementType, new ArrayInitializerExpression(items, isInline)));

            public static DictionaryExpression Dictionary(CSharpType dictionaryType) => new(TypeFactory.GetElementType(dictionaryType), new NewDictionaryExpression(dictionaryType));
            public static DictionaryExpression Dictionary(CSharpType keyType, CSharpType valueType) => Dictionary(new CSharpType(typeof(Dictionary<,>), keyType, valueType));
            public static DictionaryExpression Dictionary(CSharpType keyType, CSharpType valueType, params (ValueExpression Key, ValueExpression Value)[] values)
                => new(valueType, new NewDictionaryExpression(new CSharpType(typeof(Dictionary<,>), keyType, valueType), new DictionaryInitializerExpression(values)));

            public static TypedValueExpression JsonSerializerOptions() => new FrameworkTypeExpression(typeof(JsonSerializerOptions), new NewJsonSerializerOptionsExpression());

            public static ListExpression List(CSharpType listType) => new(Instance(listType));

            public static FormUrlEncodedContentExpression FormUrlEncodedContent() => new(Instance(typeof(FormUrlEncodedContent)));
            public static MultipartFormDataContentExpression MultipartFormDataContent() => new(Instance(typeof(MultipartFormDataContent)));

            public static RawRequestUriBuilderExpression RawRequestUriBuilder() => new(Instance(typeof(RawRequestUriBuilder)));

            public static RequestContextExpression RequestContext(CancellationTokenExpression cancellationToken)
                => new(Instance(typeof(RequestContext), new Dictionary<string, ValueExpression>{ [nameof(Azure.RequestContext.CancellationToken)] = cancellationToken }));

            public static ValueExpression RequestFailedException(ResponseExpression response) => Instance(typeof(RequestFailedException), response);

            public static ResourceIdentifierExpression ResourceIdentifier(ValueExpression resourceData) => new(Instance(typeof(ResourceIdentifier), new MemberExpression(resourceData, "Id")));

            public static StreamReaderExpression StreamReader(ValueExpression stream) => new(Instance(typeof(StreamReader), stream));

            public static StringRequestContentExpression StringRequestContent(ValueExpression value) => new(Instance(typeof(StringRequestContent), value));

            public static TimeSpanExpression TimeSpan(int hours, int minutes, int seconds) => new(Instance(typeof(TimeSpan), Int(hours), Int(minutes), Int(seconds)));
            public static TypedValueExpression Uri(string uri) => Instance(typeof(Uri), Literal(uri));
            public static Utf8JsonRequestContentExpression Utf8JsonRequestContent() => new(Instance(typeof(Utf8JsonRequestContent)));
            public static XmlWriterContentExpression XmlWriterContent() => new(Instance(typeof(XmlWriterContent)));

            public static ValueExpression Anonymous(string key, ValueExpression value) => Anonymous(new Dictionary<string, ValueExpression>{[key] = value});
            public static ValueExpression Anonymous(IReadOnlyDictionary<string, ValueExpression>? properties) => new KeywordExpression("new", new ObjectInitializerExpression(properties, IsInline: false));
            public static ValueExpression Instance(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
            public static ValueExpression Instance(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, System.Array.Empty<ValueExpression>(), new ObjectInitializerExpression(properties));
            public static TypedValueExpression Instance(Type type, params ValueExpression[] arguments) => new FrameworkTypeExpression(type, new NewInstanceExpression(type, arguments));
            public static TypedValueExpression Instance(Type type, IReadOnlyDictionary<string, ValueExpression> properties) => new FrameworkTypeExpression(type, new NewInstanceExpression(type, System.Array.Empty<ValueExpression>(), new ObjectInitializerExpression(properties)));
        }
    }
}
