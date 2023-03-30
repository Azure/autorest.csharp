// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal static class ValueExpressions
    {
        public static FuncExpression Func(CodeWriterDeclaration arg, ValueExpression expression) => new(new[]{ arg }, expression);

        public static ValueExpression GetResponseValue(CodeWriterDeclaration response) =>
            new MemberReference(new VariableReference(response), nameof(Response<object>.Value));

        public static ValueExpression CheckNull(this Parameter parameter)
            => parameter.Type.IsNullable
                ? new NullConditionalExpression(parameter)
                : new ParameterReference(parameter);

        public static class Call
        {
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName) => new InstanceMethodCallExpression(instanceReference, methodName, Array.Empty<ValueExpression>(), false);
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName, ValueExpression arg) => new InstanceMethodCallExpression(instanceReference, methodName, new[]{ arg }, false);
            public static ValueExpression Static(CSharpType? methodType, string methodName) => new StaticMethodCallExpression(methodType, methodName, Array.Empty<ValueExpression>());
            public static ValueExpression Static(CSharpType? methodType, string methodName, ValueExpression arg) => new StaticMethodCallExpression(methodType, methodName, new[]{ arg });
            public static ValueExpression Extension(CSharpType? methodType, string methodName, ValueExpression instanceReference) => new StaticMethodCallExpression(methodType, methodName, new[]{ instanceReference }, CallAsExtension: true);
            public static ValueExpression Extension(CSharpType? methodType, string methodName, ValueExpression instanceReference, ValueExpression arg) => new StaticMethodCallExpression(methodType, methodName, new[]{ instanceReference, arg }, CallAsExtension: true);

            public static ValueExpression ToString(ValueExpression reference) => Instance(reference , "ToString");
            public static ValueExpression ToRequestContent(ValueExpression reference) => new InstanceMethodCallExpression(reference, "ToRequestContent", Array.Empty<ValueExpression>(), false);
            public static ValueExpression ToEnum(CSharpType enumType, ValueExpression stringValue) => new StaticMethodCallExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{ stringValue }, null, true);

            public static ValueExpression ProtocolMethod(string methodName, IReadOnlyList<ValueExpression> arguments, bool async)
            {
                var protocolMethodName = async ? methodName + "Async" : methodName;
                return new InstanceMethodCallExpression(null, protocolMethodName, arguments, async);
            }

            public static class BinaryData
            {
                public static ValueExpression FromStream(ValueExpression response, bool async)
                {
                    var methodName = async ? nameof(System.BinaryData.FromStreamAsync) : nameof(System.BinaryData.FromStream);
                    var contentStream = new MemberReference(response, nameof(Azure.Response.ContentStream));
                    return Static(typeof(System.BinaryData), methodName, contentStream);
                }

                public static ValueExpression FromString(ValueExpression data) => Static(typeof(System.BinaryData), nameof(System.BinaryData.FromString), data);
            }

            public static class Enum
            {
                public static ValueExpression ToString(ValueExpression enumValue, EnumType enumType)
                    => enumType.IsExtensible ? Call.ToString(enumValue) : new StaticMethodCallExpression(enumType.Type, $"ToSerial{enumType.ValueType.Name.FirstCharToUpperCase()}", new[] { enumValue }, null, true);
            }

            public static class JsonSerializer
            {
                public static ValueExpression Deserialize(JsonElementExpression element, CSharpType serializationType, ValueExpression? options = null)
                {
                    var arguments = options is null
                        ? new[]{ element.GetRawText() }
                        : new[]{ element.GetRawText(), options };
                    return new StaticMethodCallExpression(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Deserialize), arguments, new[] { serializationType });
                }
            }

            public static class Optional
            {
                public static ValueExpression IsCollectionDefined(ValueExpression collection) => Static(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.IsCollectionDefined), collection);
                public static ValueExpression IsDefined(ValueExpression value) => Static(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.IsDefined), value);
                public static ValueExpression ToDictionary(ValueExpression dictionary) => Static(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToDictionary), dictionary);
                public static ValueExpression ToList(ValueExpression collection) => Static(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToList), collection);
                public static ValueExpression ToNullable(ValueExpression optional) => Static(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToNullable), optional);
            }

            public static class PageableHelpers
            {
                private static readonly CSharpType BinaryDataType = typeof(System.BinaryData);
                private static readonly CSharpType PageableHelpersType = typeof(Azure.Core.PageableHelpers);

                public static ValueExpression CreatePageable(
                    CodeWriterDeclaration createFirstPageRequest,
                    CodeWriterDeclaration? createNextPageRequest,
                    ValueExpression clientDiagnostics,
                    ValueExpression pipeline,
                    CSharpType? pageItemType,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    ValueExpression? requestContextOrCancellationToken,
                    bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        new VariableReference(createFirstPageRequest),
                        createNextPageRequest != null ? new VariableReference(createNextPageRequest) : Null,
                        GetValueFactory(pageItemType),
                        clientDiagnostics,
                        pipeline,
                        Literal(scopeName),
                        Literal(itemPropertyName),
                        Literal(nextLinkPropertyName)
                    };

                    if (requestContextOrCancellationToken is not null)
                    {
                        arguments.Add(requestContextOrCancellationToken);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new StaticMethodCallExpression(PageableHelpersType, methodName, arguments);
                }

                public static ValueExpression CreatePageable(
                    HttpMessageExpression message,
                    CodeWriterDeclaration? createNextPageRequest,
                    CodeWriterDeclaration clientDiagnostics,
                    HttpPipelineExpression pipeline,
                    CSharpType? pageItemType,
                    OperationFinalStateVia finalStateVia,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    ValueExpression? requestContext,
                    bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        new ParameterReference(KnownParameters.WaitForCompletion),
                        message,
                        createNextPageRequest is not null ? new VariableReference(createNextPageRequest) : Null,
                        GetValueFactory(pageItemType),
                        clientDiagnostics,
                        pipeline,
                        new FormattableStringToExpression($"{typeof(OperationFinalStateVia)}.{finalStateVia}"),
                        Literal(scopeName),
                        Literal(itemPropertyName),
                        Literal(nextLinkPropertyName)
                    };

                    if (requestContext is not null)
                    {
                        arguments.Add(requestContext);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new StaticMethodCallExpression(PageableHelpersType, methodName, arguments, null, false, async);
                }

                public static ValueExpression GetValueFactory(CSharpType? pageItemType)
                {
                    if (pageItemType is null)
                    {
                        throw new NotSupportedException("Type of the element of the page must be specified");
                    }

                    if (pageItemType.Equals(BinaryDataType))
                    {
                        // When `JsonElement` provides access to its UTF8 buffer, change this code to create `BinaryData` from it.
                        // See also PageableHelpers.ParseResponseForBinaryData
                        var e = new CodeWriterDeclaration("e");
                        return Func(e, BinaryData.FromString(new JsonElementExpression(e).GetRawText()));
                    }

                    if (pageItemType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type })
                    {
                        return new MemberReference(new TypeReference(type.Type), $"Deserialize{type.Declaration.Name}");
                    }

                    var variable = new CodeWriterDeclaration("e");
                    var deserializeImplementation = JsonSerializationMethodsBuilder.GetDeserializeValueExpression(new JsonElementExpression(variable), pageItemType);
                    return Func(variable, deserializeImplementation);
                }
            }

            public static class ProtocolOperationHelpers
            {
                public static ValueExpression ProcessMessage(HttpPipelineExpression pipeline, HttpMessageExpression message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessage);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                public static ValueExpression ProcessMessageWithoutResponseValue(HttpPipelineExpression pipeline, HttpMessageExpression message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValue);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                private static ValueExpression ProcessMessage(HttpPipelineExpression pipeline, HttpMessageExpression message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async, string methodName)
                {
                    var arguments = new List<ValueExpression> {
                        pipeline,
                        message,
                        clientDiagnostics,
                        Literal(scopeName),
                        new FormattableStringToExpression($"{typeof(OperationFinalStateVia)}.{finalStateVia}"),
                        KnownParameters.RequestContext,
                        KnownParameters.WaitForCompletion
                    };

                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), methodName, arguments, null, false, async);
                }

                public static ValueExpression Convert(CSharpType responseType, ResponseExpression response, CodeWriterDeclaration clientDiagnostics, string scopeName)
                {
                    var fromResponseReference = new MemberReference(new TypeReference(responseType), "FromResponse");
                    var diagnosticsReference = new VariableReference(clientDiagnostics);
                    var arguments = new[] { response, fromResponseReference, diagnosticsReference, Literal(scopeName) };
                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), nameof(Azure.Core.ProtocolOperationHelpers.Convert), arguments);
                }
            }

            public static class RequestContent
            {
                public static ValueExpression Create(ValueExpression serializable) => Static(typeof(Azure.Core.RequestContent), nameof(Azure.Core.RequestContent.Create), serializable);
            }
        }
    }

    internal record TypedValueExpression(CSharpType Type, ValueExpression Untyped) : ValueExpression
    {
    }

    internal record DeclareExpression(CSharpType? Type, string Name) : ValueExpression;
    internal record CastExpression(ValueExpression Inner, CSharpType Type) : ValueExpression;
    internal record DefaultValueExpression(CSharpType Type) : ValueExpression;
    internal record CollectionInitializerExpression(params ValueExpression[] Items) : ValueExpression;
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<ValueExpression> Arguments) : ValueExpression
    {
        public IReadOnlyDictionary<string, ValueExpression> Properties { get; init; } = new Dictionary<string, ValueExpression>();
    }

    internal record TernaryConditionalOperator(ValueExpression Condition, ValueExpression Consequent, ValueExpression Alternative) : ValueExpression;
    internal record TypeReference(CSharpType Type) : ValueExpression;
    internal record MemberReference(ValueExpression Inner, string MemberName) : ValueExpression;
    internal record FormattableStringToExpression(FormattableString Value) : ValueExpression; // Shim between formattable strings and expressions
    internal record NullConditionalExpression(ValueExpression Inner) : ValueExpression;
    internal record BinaryOperatorExpression(string Operator, ValueExpression Left, ValueExpression Right) : ValueExpression;
    internal record StaticMethodCallExpression(CSharpType? MethodType, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments = null, bool CallAsExtension = false, bool CallAsAsync = false) : ValueExpression;
    internal record InstanceMethodCallExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : ValueExpression;
    internal record FuncExpression(IReadOnlyList<CodeWriterDeclaration> Parameters, ValueExpression Inner) : ValueExpression;
}
