// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal static class InlineableExpressions
    {
        private static InlineableExpression Null { get; } = new ExpressionAsFormattableString($"null");

        private static InlineableExpression CheckNull(this Parameter parameter)
            => parameter.Type.IsNullable
                ? new NullConditionalExpression(new ParameterReference(parameter))
                : new ParameterReference(parameter);

        public static class Instantiate
        {
            public static InlineableExpression IfCancellationTokenCanBeCanceled()
            {
                var cancellationToken = new ParameterReference(KnownParameters.CancellationTokenParameter);
                return new TernaryConditionalOperator(
                    new MemberReference(cancellationToken, nameof(CancellationToken.CanBeCanceled)),
                    new NewInstanceExpression(typeof(RequestContext), new Dictionary<string, InlineableExpression>{ [nameof(RequestContext.CancellationToken)] = cancellationToken }),
                    Null);
            }
        }

        public static class Call
        {
            public static InlineableExpression FromCancellationToken() => new StaticMethodCallExpression(null, "FromCancellationToken", new[]{ new ParameterReference(KnownParameters.CancellationTokenParameter) }, false, false);

            public static InlineableExpression ToString(Parameter parameter) => ToString(parameter.CheckNull());
            public static InlineableExpression ToRequestContent(Parameter parameter) => ToRequestContent(parameter.CheckNull());
            public static InlineableExpression ToSerialString(Parameter parameter) => ToSerialString(parameter.Type, parameter.CheckNull());

            public static InlineableExpression ToString(InlineableExpression reference) => new InstanceMethodCallExpression(reference , "ToString", Array.Empty<InlineableExpression>(), false);
            public static InlineableExpression ToRequestContent(InlineableExpression reference) => new InstanceMethodCallExpression(reference, "ToRequestContent", Array.Empty<InlineableExpression>(), false);
            public static InlineableExpression ToSerialString(CSharpType type, InlineableExpression reference) => new StaticMethodCallExpression(type, "ToSerialString", new[] { reference }, true, false);

            public static InlineableExpression CreateRequestMethod(string methodName, IEnumerable<Parameter> parameters)
            {
                var createRequestMethodName = RequestWriterHelpers.CreateRequestMethodName(methodName);
                return new InstanceMethodCallExpression(null, createRequestMethodName, parameters.Select(p => new ParameterReference(p)).ToList(), false);
            }

            public static InlineableExpression ProtocolMethod(string methodName, IReadOnlyList<InlineableExpression> arguments, bool async)
            {
                var protocolMethodName = async ? methodName + "Async" : methodName;
                return new InstanceMethodCallExpression(null, protocolMethodName, arguments, async);
            }

            public static class HttpPipelineExtensions
            {
                private static readonly CSharpType HttpPipelineExtensionsType = typeof(Azure.Core.HttpPipelineExtensions);

                public static InlineableExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, Parameter? requestContext, Parameter? cancellationToken, bool async)
                {
                    var arguments = new List<InlineableExpression>
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
                    return new StaticMethodCallExpression(HttpPipelineExtensionsType, methodName, arguments, true, async);
                }

                public static InlineableExpression ProcessHeadAsBoolMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, Parameter? requestContext, bool async)
                {
                    var arguments = new List<InlineableExpression>
                    {
                        new VariableReference(pipeline),
                        new VariableReference(message),
                        new VariableReference(clientDiagnostics),
                        requestContext != null ? new ParameterReference(requestContext) : Null
                    };

                    var methodName = async ? nameof(Azure.Core.HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(Azure.Core.HttpPipelineExtensions.ProcessHeadAsBoolMessage);
                    return new StaticMethodCallExpression(HttpPipelineExtensionsType, methodName, arguments, true, async);
                }
            }

            public static class PageableHelpers
            {
                private static readonly CSharpType PageableHelpersType = typeof(Azure.Core.PageableHelpers);

                public static InlineableExpression CreatePageable(
                    CodeWriterDeclaration createFirstPageRequest,
                    CodeWriterDeclaration? createNextPageRequest,
                    CodeWriterDeclaration clientDiagnostics,
                    CodeWriterDeclaration pipeline,
                    CSharpType? pageItemType,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    InlineableExpression? requestContextVariable,
                    bool async)
                {
                    var arguments = new List<InlineableExpression>
                    {
                        new VariableReference(createFirstPageRequest),
                        createNextPageRequest != null ? new VariableReference(createNextPageRequest) : Null,
                        new ExpressionAsFormattableString(PageableMethodsWriterExtensions.GetValueFactory(pageItemType)),
                        new VariableReference(clientDiagnostics),
                        new VariableReference(pipeline),
                        new ExpressionAsFormattableString($"{scopeName:L}"),
                        new ExpressionAsFormattableString($"{itemPropertyName:L}"),
                        new ExpressionAsFormattableString($"{nextLinkPropertyName:L}")
                    };

                    if (requestContextVariable is not null)
                    {
                        arguments.Add(requestContextVariable);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new StaticMethodCallExpression(PageableHelpersType, methodName, arguments, false, false);
                }

                public static InlineableExpression CreatePageable(
                    CodeWriterDeclaration message,
                    CodeWriterDeclaration? createNextPageRequest,
                    CodeWriterDeclaration clientDiagnostics,
                    CodeWriterDeclaration pipeline,
                    CSharpType? pageItemType,
                    OperationFinalStateVia finalStateVia,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    InlineableExpression? requestContext,
                    bool async)
                {
                    var arguments = new List<InlineableExpression>
                    {
                        new ParameterReference(KnownParameters.WaitForCompletion),
                        new VariableReference(message),
                        createNextPageRequest is not null ? new VariableReference(createNextPageRequest) : Null,
                        new ExpressionAsFormattableString(PageableMethodsWriterExtensions.GetValueFactory(pageItemType)),
                        new VariableReference(clientDiagnostics),
                        new VariableReference(pipeline),
                        new ExpressionAsFormattableString($"{typeof(OperationFinalStateVia)}.{finalStateVia}"),
                        new ExpressionAsFormattableString($"{scopeName:L}"),
                        new ExpressionAsFormattableString($"{itemPropertyName:L}"),
                        new ExpressionAsFormattableString($"{nextLinkPropertyName:L}")
                    };

                    if (requestContext is not null)
                    {
                        arguments.Add(requestContext);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new StaticMethodCallExpression(PageableHelpersType, methodName, arguments, false, async);
                }
            }

            public static class ProtocolOperationHelpers
            {
                public static InlineableExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessage);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                public static InlineableExpression ProcessMessageWithoutResponseValue(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async)
                {
                    var methodName = async ? nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync) : nameof(Azure.Core.ProtocolOperationHelpers.ProcessMessageWithoutResponseValue);
                    return ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, async, methodName);
                }

                private static InlineableExpression ProcessMessage(CodeWriterDeclaration pipeline, CodeWriterDeclaration message, CodeWriterDeclaration clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, bool async, string methodName)
                {
                    var arguments = new List<InlineableExpression> {
                        new VariableReference(pipeline),
                        new VariableReference(message),
                        new VariableReference(clientDiagnostics),
                        new ExpressionAsFormattableString($"{scopeName:L}"),
                        new ExpressionAsFormattableString($"{typeof(OperationFinalStateVia)}.{finalStateVia}"),
                        new ParameterReference(KnownParameters.RequestContext),
                        new ParameterReference(KnownParameters.WaitForCompletion)
                    };

                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), methodName, arguments, false, async);
                }

                public static InlineableExpression Convert(CSharpType responseType, CodeWriterDeclaration response, CodeWriterDeclaration clientDiagnostics, string scopeName)
                {
                    var responseVariable = new VariableReference(response);
                    var fromResponseReference = new MemberReference(new TypeReference(responseType), "FromResponse");
                    var diagnosticsReference = new VariableReference(clientDiagnostics);
                    var arguments = new InlineableExpression[] { responseVariable, fromResponseReference, diagnosticsReference, new ExpressionAsFormattableString($"{scopeName:L}") };
                    return new StaticMethodCallExpression(typeof(Azure.Core.ProtocolOperationHelpers), nameof(Azure.Core.ProtocolOperationHelpers.Convert), arguments, false, false);
                }
            }

            public static class Response
            {
                public static InlineableExpression FromValue(CSharpType responseType, CodeWriterDeclaration response)
                {
                    var responseVariable = new VariableReference(response);
                    var fromResponseCall = new StaticMethodCallExpression(responseType, "FromResponse", new[]{responseVariable}, false, false);
                    return new StaticMethodCallExpression(typeof(Azure.Response), nameof(Azure.Response.FromValue), new InlineableExpression[]{fromResponseCall, responseVariable}, false, false);
                }
            }
        }
    }
}
