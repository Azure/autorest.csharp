// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class New
        {
            public static ValueExpression ArgumentOutOfRangeException(EnumType enumType, Parameter valueParameter)
                => Instance(typeof(ArgumentOutOfRangeException), Nameof(valueParameter), valueParameter, Literal($"Unknown {enumType.Declaration.Name} value."));

            public static DictionaryExpression Dictionary(CSharpType dictionaryType) => new(Instance(dictionaryType));

            public static ValueExpression JsonSerializerOptions()
                => Instance(typeof(JsonSerializerOptions), new Dictionary<string, ValueExpression>{ [nameof(System.Text.Json.JsonSerializerOptions.Converters)] = new CollectionInitializerExpression(Instance(typeof(ManagedServiceIdentityTypeV3Converter))) });

            public static ListExpression List(CSharpType listType) => new(Instance(listType));

            public static FormUrlEncodedContentExpression FormUrlEncodedContent() => new(Instance(typeof(FormUrlEncodedContent)));
            public static MultipartFormDataContentExpression MultipartFormDataContent() => new(Instance(typeof(MultipartFormDataContent)));

            public static RawRequestUriBuilderExpression RawRequestUriBuilder() => new(Instance(typeof(RawRequestUriBuilder)));

            public static RequestContextExpression RequestContext(CancellationTokenExpression cancellationToken)
                => new(Instance(typeof(RequestContext), new Dictionary<string, ValueExpression>{ [nameof(Azure.RequestContext.CancellationToken)] = cancellationToken }));

            public static ValueExpression RequestFailedException(ResponseExpression response) => Instance(typeof(RequestFailedException), response);

            public static ResourceIdentifierExpression ResourceIdentifier(ValueExpression resourceData) => new(Instance(typeof(ResourceIdentifier), new MemberReference(resourceData, "Id")));

            public static StreamReaderExpression StreamReader(ValueExpression stream) => new(Instance(typeof(StreamReader), stream));

            public static StringRequestContentExpression StringRequestContent(ValueExpression value) => new(Instance(typeof(StringRequestContent), value));

            public static Utf8JsonRequestContentExpression Utf8JsonRequestContent() => new(Instance(typeof(Utf8JsonRequestContent)));
            public static XmlWriterContentExpression XmlWriterContent() => new(Instance(typeof(XmlWriterContent)));

            public static ValueExpression Instance(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
            public static ValueExpression Instance(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, Array.Empty<ValueExpression>()) { Properties = properties };
        }
    }
}
