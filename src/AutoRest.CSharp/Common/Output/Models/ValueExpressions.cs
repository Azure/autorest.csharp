﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal static class ValueExpressions
    {
        public static ValueExpression Func(CodeWriterDeclaration arg, ValueExpression expression) => new FuncExpression(new[]{ arg }, expression);
        public static ValueExpression New(CSharpType type, params ValueExpression[] arguments) => new NewInstanceExpression(type, arguments);
        public static ValueExpression New(CSharpType type, IReadOnlyDictionary<string, ValueExpression> properties) => new NewInstanceExpression(type, Array.Empty<ValueExpression>()) { Properties = properties };

        public static ValueExpression Literal(string? value) => new FormattableStringToExpression($"{value:L}");

        public static ValueExpression GetResponseValue(CodeWriterDeclaration response) =>
            new MemberReference(new VariableReference(response), nameof(Response<object>.Value));

        public static ValueExpression GetResponseValueName(CodeWriterDeclaration response) =>
            new MemberReference(GetResponseValue(response), "Name");

        public static ValueExpression GetResponseValueId(CodeWriterDeclaration response) =>
            new MemberReference(GetResponseValue(response), "Id");

        public static ValueExpression Default { get; } = new FormattableStringToExpression($"default");
        public static ValueExpression Null { get; } = new FormattableStringToExpression($"null");

        private static ValueExpression CheckNull(this Parameter parameter)
            => parameter.Type.IsNullable
                ? new NullConditionalExpression(parameter)
                : new ParameterReference(parameter);

        public static class Instantiate
        {
            public static ValueExpression IfCancellationTokenCanBeCanceled()
            {
                var cancellationToken = new ParameterReference(KnownParameters.CancellationTokenParameter);
                return new TernaryConditionalOperator(
                    new MemberReference(cancellationToken, nameof(CancellationToken.CanBeCanceled)),
                    New(typeof(RequestContext), new Dictionary<string, ValueExpression>{ [nameof(RequestContext.CancellationToken)] = cancellationToken }),
                    Null);
            }
        }

        public static class Call
        {
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName) => new InstanceMethodCallExpression(instanceReference, methodName, Array.Empty<ValueExpression>(), false);
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName, ValueExpression arg) => new InstanceMethodCallExpression(instanceReference, methodName, new[]{ arg }, false);
            public static ValueExpression Static(CSharpType? methodType, string methodName) => new StaticMethodCallExpression(methodType, methodName, Array.Empty<ValueExpression>());
            public static ValueExpression Static(CSharpType? methodType, string methodName, ValueExpression arg) => new StaticMethodCallExpression(methodType, methodName, new[]{ arg });

            public static ValueExpression FromCancellationToken() => new StaticMethodCallExpression(null, "FromCancellationToken", new[]{ new ParameterReference(KnownParameters.CancellationTokenParameter) });

            public static ValueExpression ToString(Parameter parameter) => ToString(parameter.CheckNull());
            public static ValueExpression ToRequestContent(Parameter parameter) => ToRequestContent(parameter.CheckNull());
            public static ValueExpression ToSerialString(Parameter parameter) => ToSerialString(parameter.Type, parameter.CheckNull());

            public static ValueExpression ToString(ValueExpression reference) => new InstanceMethodCallExpression(reference , "ToString", Array.Empty<ValueExpression>(), false);
            public static ValueExpression ToRequestContent(ValueExpression reference) => new InstanceMethodCallExpression(reference, "ToRequestContent", Array.Empty<ValueExpression>(), false);
            public static ValueExpression ToSerialString(CSharpType type, ValueExpression reference) => new StaticMethodCallExpression(type, "ToSerialString", new[] { reference }, null, true);
            public static ValueExpression ToEnum(CSharpType enumType, ValueExpression stringValue) => new StaticMethodCallExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{ stringValue }, null, true);

            public static ValueExpression CreateRequestMethod(string methodName, IEnumerable<Parameter> parameters)
            {
                return new InstanceMethodCallExpression(null, methodName, parameters.Select(p => new ParameterReference(p)).ToList(), false);
            }

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

            public static class HttpPipelineExtensions
            {
                private static readonly CSharpType HttpPipelineExtensionsType = typeof(Azure.Core.HttpPipelineExtensions);

                public static ValueExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, Parameter? requestContext, Parameter? cancellationToken, bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        new VariableReference(pipeline),
                        new VariableReference(message),
                        requestContext != null ? new ParameterReference(requestContext) : Null,
                    };

                    if (cancellationToken != null)
                    {
                        arguments.Add(new ParameterReference(cancellationToken));
                    }

                    var methodName = async ? nameof(Azure.Core.HttpPipelineExtensions.ProcessMessageAsync) : nameof(Azure.Core.HttpPipelineExtensions.ProcessMessage);
                    return new StaticMethodCallExpression(HttpPipelineExtensionsType, methodName, arguments, null, true, async);
                }

                public static ValueExpression ProcessHeadAsBoolMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, Parameter? requestContext, bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        new VariableReference(pipeline),
                        new VariableReference(message),
                        new VariableReference(clientDiagnostics),
                        requestContext != null ? new ParameterReference(requestContext) : Null
                    };

                    var methodName = async ? nameof(Azure.Core.HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(Azure.Core.HttpPipelineExtensions.ProcessHeadAsBoolMessage);
                    return new StaticMethodCallExpression(HttpPipelineExtensionsType, methodName, arguments, null, true, async);
                }
            }

            public static class HttpMessage
            {
                public static ValueExpression FromStream(ValueExpression message) => Instance(message, nameof(Azure.Core.HttpMessage.ExtractResponseContent));
            }

            public static class JsonDocument
            {
                public static ValueExpression GetRootElement(ValueExpression response)
                    => new MemberReference(response, nameof(System.Text.Json.JsonDocument.RootElement));

                public static ValueExpression Parse(ValueExpression response, bool async)
                {
                    var contentStream = new MemberReference(response, nameof(Azure.Response.ContentStream));
                    return async
                        ? new StaticMethodCallExpression(typeof(System.Text.Json.JsonDocument), nameof(System.Text.Json.JsonDocument.ParseAsync), new[]{contentStream, Default, KnownParameters.CancellationTokenParameter}, null, false, true)
                        : new StaticMethodCallExpression(typeof(System.Text.Json.JsonDocument), nameof(System.Text.Json.JsonDocument.Parse), new[]{contentStream});
                }
            }

            public static class JsonElement
            {
                public static ValueExpression EnumerateArray(ValueExpression element) => Instance(element, nameof(System.Text.Json.JsonElement.EnumerateArray));
                public static ValueExpression EnumerateObject(ValueExpression element) => Instance(element, nameof(System.Text.Json.JsonElement.EnumerateObject));
                public static ValueExpression GetString(ValueExpression element) => Instance(element, nameof(System.Text.Json.JsonElement.GetString));
                public static ValueExpression GetRawText(ValueExpression element) => Instance(element, nameof(System.Text.Json.JsonElement.GetRawText));
            }

            public static class JsonSerializer
            {
                public static ValueExpression Deserialize(ValueExpression element, CSharpType serializationType, ValueExpression? options = null)
                {
                    var arguments = options is null
                        ? new[]{ JsonElement.GetRawText(element) }
                        : new[]{ JsonElement.GetRawText(element), options };
                    return new StaticMethodCallExpression(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Deserialize), arguments, new[] { serializationType });
                }
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
                    CodeWriterDeclaration message,
                    CodeWriterDeclaration? createNextPageRequest,
                    CodeWriterDeclaration clientDiagnostics,
                    CodeWriterDeclaration pipeline,
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
                        new VariableReference(message),
                        createNextPageRequest is not null ? new VariableReference(createNextPageRequest) : Null,
                        GetValueFactory(pageItemType),
                        new VariableReference(clientDiagnostics),
                        new VariableReference(pipeline),
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
                        return Func(e, BinaryData.FromString(JsonElement.GetRawText(e)));
                    }

                    if (pageItemType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type })
                    {
                        return new MemberReference(new TypeReference(type.Type), $"Deserialize{type.Declaration.Name}");
                    }

                    var variable = new CodeWriterDeclaration("e");
                    var deserializeImplementation = JsonSerializationMethodsBuilder.GetDeserializeValueExpression(variable, pageItemType);
                    return Func(variable, deserializeImplementation);
                }
            }

            public static class ProtocolOperationHelpers
            {
                public static ValueExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessage);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                public static ValueExpression ProcessMessageWithoutResponseValue(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValue);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                private static ValueExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async, string methodName)
                {
                    var arguments = new List<ValueExpression> {
                        new VariableReference(pipeline),
                        new VariableReference(message),
                        new VariableReference(clientDiagnostics),
                        new FormattableStringToExpression($"{scopeName:L}"),
                        new FormattableStringToExpression($"{typeof(OperationFinalStateVia)}.{finalStateVia}"),
                        new ParameterReference(KnownParameters.RequestContext),
                        new ParameterReference(KnownParameters.WaitForCompletion)
                    };

                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), methodName, arguments, null, false, async);
                }

                public static ValueExpression Convert(CSharpType responseType, CodeWriterDeclaration response, CodeWriterDeclaration clientDiagnostics, string scopeName)
                {
                    var responseVariable = new VariableReference(response);
                    var fromResponseReference = new MemberReference(new TypeReference(responseType), "FromResponse");
                    var diagnosticsReference = new VariableReference(clientDiagnostics);
                    var arguments = new ValueExpression[] { responseVariable, fromResponseReference, diagnosticsReference, new FormattableStringToExpression($"{scopeName:L}") };
                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), nameof(Azure.Core.ProtocolOperationHelpers.Convert), arguments);
                }
            }

            public static class RequestContent
            {
                public static ValueExpression Create(ValueExpression serializable) => Static(typeof(Azure.Core.RequestContent), nameof(Azure.Core.RequestContent.Create), serializable);
            }

            public static class Response
            {
                public static ValueExpression FromValue(ValueExpression value, CodeWriterDeclaration response)
                {
                    var responseVariable = new VariableReference(response);
                    return new StaticMethodCallExpression(typeof(Azure.Response), nameof(Azure.Response.FromValue), new[]{value, responseVariable});
                }

                public static ValueExpression FromValue(CSharpType responseType, CodeWriterDeclaration response)
                {
                    var fromResponseCall = new StaticMethodCallExpression(responseType, "FromResponse", new[]{new VariableReference(response)});
                    return FromValue(fromResponseCall, response);
                }
            }
        }
    }

    internal record ValueExpression
    {
        public static implicit operator ValueExpression(Parameter parameter) => new ParameterReference(parameter);
        public static implicit operator ValueExpression(CodeWriterDeclaration name) => new VariableReference(name);
    }

    internal record CastExpression(ValueExpression Inner, CSharpType Type) : ValueExpression;
    internal record DefaultValueExpression(CSharpType Type) : ValueExpression;
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<ValueExpression> Arguments) : ValueExpression
    {
        public IReadOnlyDictionary<string, ValueExpression> Properties { get; init; } = new Dictionary<string, ValueExpression>();
    }

    internal record TernaryConditionalOperator(ValueExpression Condition, ValueExpression Consequent, ValueExpression Alternative) : ValueExpression;
    internal record TypeReference(CSharpType Type) : ValueExpression;
    internal record MemberReference(ValueExpression Inner, string MemberName) : ValueExpression;
    internal record ParameterReference(Parameter Parameter) : ValueExpression;
    internal record VariableReference(CodeWriterDeclaration Name) : ValueExpression;
    internal record FormattableStringToExpression(FormattableString Value) : ValueExpression; // Shim between formattable strings and expressions
    internal record NullConditionalExpression(ValueExpression Inner) : ValueExpression;
    internal record StaticMethodCallExpression(CSharpType? MethodType, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments = null, bool CallAsExtension = false, bool CallAsAsync = false) : ValueExpression;
    internal record InstanceMethodCallExpression(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : ValueExpression;
    internal record FuncExpression(IReadOnlyList<CodeWriterDeclaration> Parameters, ValueExpression Inner) : ValueExpression;
}
