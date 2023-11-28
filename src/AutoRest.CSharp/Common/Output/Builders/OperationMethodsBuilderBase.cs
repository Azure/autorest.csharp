// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.Core.Pipeline;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal abstract class OperationMethodsBuilderBase
    {
        private const string ConvenienceMethodNotConfident = "The convenience method of this operation is made internal because this operation directly or indirectly uses a low confident type, for instance, unions, literal types with number values, etc.";
        private const string ConvenienceMethodIsMeaningless = "The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method";
        private const string ConvenienceMethodIsUsingAnonymousModel = "The convenience method of this operation is omitted because it is using at least one anonymous model";

        private static readonly int[] RedirectResponseCodes = { 300, 301, 302, 303, 307, 308 };

        private readonly string _clientName;
        private readonly string _clientNamespace;

        private readonly FormattableString? _summary;
        private readonly FormattableString? _description;
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly MethodParametersBuilder _parametersBuilder;
        private readonly DpgOperationSampleBuilder _operationSampleBuilder;
        private readonly TypeFactory _typeFactory;
        private readonly SourceInputModel? _sourceInputModel;

        protected InputOperation Operation { get; }

        protected ClientFields Fields { get; }
        protected TypedValueExpression ClientDiagnosticsProperty { get; }
        protected TypedValueExpression PipelineField { get; }
        protected StatusCodeSwitchBuilder StatusCodeSwitchBuilder { get; }
        protected MethodSignatureModifiers ConvenienceModifiers { get; }

        protected string CreateMessageMethodName { get; }
        protected string ProtocolMethodName { get; }
        protected bool GenerateProtocolMethods { get; }

        protected CSharpType? ResponseType { get; }
        protected CSharpType ProtocolMethodReturnType { get; }
        protected CSharpType RestClientConvenienceMethodReturnType { get; }
        protected CSharpType ConvenienceMethodReturnType { get; }
        protected ResponseClassifierType ResponseClassifier { get; }

        protected OperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args)
        {
            _clientName = args.ClientName;
            _clientNamespace = args.ClientNamespace;
            _operationSampleBuilder = args.OperationSampleBuilder;
            _parametersBuilder = new MethodParametersBuilder(args.Operation, args.Fields, args.TypeFactory);
            _typeFactory = args.TypeFactory;
            _sourceInputModel = args.SourceInputModel;

            Operation = args.Operation;
            GenerateProtocolMethods = args.GenerateProtocolMethods;
            StatusCodeSwitchBuilder = args.StatusCodeSwitchBuilder;
            Fields = args.Fields;
            ClientDiagnosticsProperty = args.Fields.ClientDiagnosticsProperty;
            PipelineField = args.Fields.PipelineField;

            ProtocolMethodName = Operation.Name.ToCleanName();
            CreateMessageMethodName = $"Create{ProtocolMethodName}Request";

            ResponseType = StatusCodeSwitchBuilder.ResponseType;
            ProtocolMethodReturnType = StatusCodeSwitchBuilder.ProtocolReturnType;
            RestClientConvenienceMethodReturnType = StatusCodeSwitchBuilder.RestClientConvenienceReturnType;
            ConvenienceMethodReturnType = StatusCodeSwitchBuilder.ClientConvenienceReturnType;
            ResponseClassifier = StatusCodeSwitchBuilder.ResponseClassifier;

            _summary = FormattableStringHelpers.FromString(Operation.Summary != null ? BuilderHelpers.EscapeXmlDocDescription(Operation.Summary) : null);
            _description = FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(Operation.Description));
            _protocolAccessibility = Operation.GenerateProtocolMethod ? GetAccessibility(Operation.Accessibility) : MethodSignatureModifiers.Internal;
            ConvenienceModifiers = GetAccessibility(Operation.Accessibility);
        }

        public RestClientOperationMethods Build(IReadOnlyDictionary<object, string>? renamingMap)
        {
            if (!GenerateProtocolMethods && (Configuration.Generation1ConvenienceClient || Configuration.AzureArm))
            {
                return BuildLegacy(renamingMap);
            }

            var parameters = _parametersBuilder.BuildParameters(true, renamingMap);

            var convenienceMethodIsMeaningless = IsConvenienceMethodMeaningless(parameters);
            if (MakeAllProtocolParametersRequired(parameters, convenienceMethodIsMeaningless))
            {
                parameters = parameters.MakeAllProtocolParametersRequired();
            }

            var createMessageMethod = BuildCreateRequestMethod(parameters.CreateMessage, parameters.RequestParts);
            var createNextPageMessageMethodSignature = BuildCreateNextPageMessageSignature(parameters.CreateMessage, renamingMap);
            var createNextPageMessageMethod = BuildCreateNextPageMessageMethod(createNextPageMessageMethodSignature, parameters);

            string? protocolMethodNonDocumentComment = null;
            MethodSignature? convenienceMethodSignature = null;
            Method? convenience = null;
            Method? convenienceAsync = null;

            if (Operation.GenerateConvenienceMethod)
            {
                var confidenceLevel = OperationConfidenceChecker.GetConfidenceLevel(Operation, _typeFactory);
                if (confidenceLevel == ConvenienceMethodConfidenceLevel.Removal)
                {
                    protocolMethodNonDocumentComment = ConvenienceMethodIsUsingAnonymousModel;
                }
                else if (!Operation.GenerateProtocolMethod || !convenienceMethodIsMeaningless)
                {
                    var convenienceMethodName = ProtocolMethodName;
                    if (parameters.HasAmbiguityBetweenProtocolAndConvenience)
                    {
                        convenienceMethodName = ProtocolMethodName.IsLastWordSingular()
                            ? $"{ProtocolMethodName}Value"
                            : $"{ProtocolMethodName.LastWordToSingular()}Values";
                    }

                    var methodNamingIsConfident = confidenceLevel == ConvenienceMethodConfidenceLevel.Confident;
                    protocolMethodNonDocumentComment = methodNamingIsConfident ? null : ConvenienceMethodNotConfident;
                    var modifiers = ConvenienceModifiers | MethodSignatureModifiers.Virtual;
                    if (!methodNamingIsConfident)
                    {
                        modifiers = modifiers & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal;
                    }

                    convenienceMethodSignature = CreateMethodSignature(convenienceMethodName, modifiers, parameters.Convenience, ConvenienceMethodReturnType, null);

                    var convenienceBody = CreateConvenienceMethodBody(convenienceMethodSignature.Name, parameters, createNextPageMessageMethodSignature, false);
                    convenience = BuildConvenienceMethod(convenienceMethodSignature, convenienceBody, false);
                    var convenienceBodyAsync = CreateConvenienceMethodBody(convenienceMethodSignature.Name, parameters, createNextPageMessageMethodSignature, true);
                    convenienceAsync = BuildConvenienceMethod(convenienceMethodSignature, convenienceBodyAsync, true);
                }
                else if (Operation.GenerateProtocolMethod)
                {
                    protocolMethodNonDocumentComment = ConvenienceMethodIsMeaningless;
                }
            }
            else if (Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
            {
                convenienceMethodSignature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, parameters.Convenience, RestClientConvenienceMethodReturnType, null);

                convenience = BuildConvenienceMethod(convenienceMethodSignature, CreateConvenienceMethodBodyForLegacyRestClient(parameters, createMessageMethod.Signature, StatusCodeSwitchBuilder, false), false);
                convenienceAsync = BuildConvenienceMethod(convenienceMethodSignature, CreateConvenienceMethodBodyForLegacyRestClient(parameters, createMessageMethod.Signature, StatusCodeSwitchBuilder, true), true);
            }

            var protocolMethodSignature = CreateMethodSignature(ProtocolMethodName, _protocolAccessibility | MethodSignatureModifiers.Virtual, parameters.Protocol, ProtocolMethodReturnType, protocolMethodNonDocumentComment);
            var order = Operation.LongRunning is not null ? 2 : Operation.Paging is not null ? 1 : 0;
            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var samples = _operationSampleBuilder.BuildSamples(Operation, protocolMethodSignature, convenienceMethodSignature, requestBodyType, StatusCodeSwitchBuilder);

            return new RestClientOperationMethods
            (
                createMessageMethod,
                createNextPageMessageMethod,
                BuildProtocolMethod(protocolMethodSignature, createMessageMethod.Signature, createNextPageMessageMethodSignature, false),
                BuildProtocolMethod(protocolMethodSignature, createMessageMethod.Signature, createNextPageMessageMethodSignature, true),
                convenience,
                convenienceAsync,
                null,
                null,
                BuildResultConversionMethod(),
                ResponseClassifier,

                order,
                Operation,
                ResponseType,
                StatusCodeSwitchBuilder.PageItemType,
                samples,
                createNextPageMessageMethodSignature
            );
        }

        private bool IsConvenienceMethodMeaningless(RestClientMethodParameters parameters)
        {
            if (Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
            {
                return false;
            }

            return parameters.Convenience
                .Where(p => p != KnownParameters.CancellationTokenParameter)
                .SequenceEqual(parameters.Protocol.Where(p => p != KnownParameters.RequestContext)) && ConvenienceMethodReturnType.Equals(ProtocolMethodReturnType);
        }

        private bool MakeAllProtocolParametersRequired(RestClientMethodParameters parameters, bool convenienceMethodIsMeaningless)
        {
            return !Configuration.KeepNonOverloadableProtocolSignature &&
                   Configuration.UseOverloadsBetweenProtocolAndConvenience &&
                   !ExistingProtocolMethodHasOptionalParameters(_clientNamespace, _clientName, parameters.Protocol) &&
                   !convenienceMethodIsMeaningless &&
                   parameters.HasAmbiguityBetweenProtocolAndConvenience;
        }

        private RestClientOperationMethods BuildLegacy(IReadOnlyDictionary<object, string>? renamingMap)
        {
            var parameters = _parametersBuilder.BuildParameters(false, renamingMap);
            var createRequestMessageMethod = BuildCreateRequestMethod(parameters.CreateMessage, parameters.RequestParts);
            var createNextPageMessageMethodSignature = BuildCreateNextPageMessageSignature(parameters.CreateMessage, renamingMap);
            var createNextPageMessageMethod = BuildCreateNextPageMessageMethod(createNextPageMessageMethodSignature, parameters);

            var order = Operation.LongRunning is not null ? 2 : Operation.Paging is not null ? 1 : 0;
            var convenienceMethodSignature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, parameters.Convenience, RestClientConvenienceMethodReturnType, null);

            return new RestClientOperationMethods
            (
                createRequestMessageMethod,
                createNextPageMessageMethod,
                null,
                null,
                BuildConvenienceMethod(convenienceMethodSignature, CreateLegacyConvenienceMethodBody(createRequestMessageMethod.Signature, StatusCodeSwitchBuilder, false), false),
                BuildConvenienceMethod(convenienceMethodSignature, CreateLegacyConvenienceMethodBody(createRequestMessageMethod.Signature, StatusCodeSwitchBuilder, true), true),
                BuildLegacyNextPageConvenienceMethod(parameters.Convenience, createNextPageMessageMethod, false),
                BuildLegacyNextPageConvenienceMethod(parameters.Convenience, createNextPageMessageMethod, true),
                null,
                ResponseClassifier,

                order,
                Operation,
                ResponseType,
                StatusCodeSwitchBuilder.PageItemType,
                Array.Empty<DpgOperationSample>(),
                createNextPageMessageMethodSignature
            );
        }

        protected Method BuildCreateRequestMethod(IReadOnlyList<Parameter> parameters, RequestParts requestParts)
        {
            var signature = new MethodSignature(CreateMessageMethodName, _summary, _description, MethodSignatureModifiers.Internal, Configuration.ApiTypes.HttpMessageType, null, parameters);
            var requestContext = signature.Parameters.FirstOrDefault(p => p.Type.Equals(Configuration.ApiTypes.RequestContextType)) is {} requestContextParameter ? (TypedValueExpression)requestContextParameter : null;
            return new Method(signature, new[]
            {
                CreateMessageMethodBuilder.CreateHttpMessage(Fields, requestParts, Operation.HttpMethod, requestContext, Operation.BufferResponse, ResponseClassifier, out var builder),
                builder.AddUri(Operation.Uri),
                builder.AddPath(Operation.Path),
                builder.AddQuery(),

                builder.SetUriToRequest(),

                builder.AddHeaders(),
                builder.AddBody(Operation.RequestBodyMediaType),
                builder.AddUserAgent(),
                Return(builder.Message)
            });
        }

        private bool ExistingProtocolMethodHasOptionalParameters(string clientNamespace, string clientName, IEnumerable<Parameter> parameters)
        {
            var existingProtocolMethod = _sourceInputModel?.FindMethod(clientNamespace, clientName, Operation.CleanName, parameters.Select(p => p.Type));
            return existingProtocolMethod is { Parameters: [.., {IsOptional: true}]};
        }

        private Method? BuildCreateNextPageMessageMethod(MethodSignature? signature, RestClientMethodParameters parameters)
        {
            if (signature is null)
            {
                return null;
            }

            var body = BuildCreateNextPageMessageMethodBody(parameters.RequestParts, signature);
            return body is not null ? new Method(signature, body) : null;
        }

        protected abstract MethodSignature? BuildCreateNextPageMessageSignature(IReadOnlyList<Parameter> createMessageParameters, IReadOnlyDictionary<object, string>? renamingMap);

        protected abstract MethodBodyStatement? BuildCreateNextPageMessageMethodBody(RequestParts requestParts, MethodSignature signature);

        protected string CreateScopeName(string methodName) => $"{_clientName}.{methodName}";

        private Method BuildProtocolMethod(MethodSignature signature, MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
        {
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateProtocolMethodBody(createMessageSignature, createNextPageMessageSignature, async)
            };

            return new Method(signature.WithAsync(async), body);
        }

        protected Method BuildConvenienceMethod(MethodSignature signature, MethodBodyStatement body, bool async)
        {
            return new Method(signature.WithAsync(async), new[]
            {
                new ParameterValidationBlock(signature.Parameters, IsLegacy: !Configuration.AzureArm && Configuration.Generation1ConvenienceClient),
                body
            });
        }

        protected virtual Method? BuildResultConversionMethod() => null;

        private MethodBodyStatement CreateConvenienceMethodBodyForLegacyRestClient(RestClientMethodParameters parameters, MethodSignatureBase createRequestMessageMethodSignature, StatusCodeSwitchBuilder statusCodeSwitchBuilder, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            // [TODO]: Protocol method doesn't provide access to the underlying HttpMessage instance to call httpMessage.ExtractResponseContent(),
            // hence it requires convenience method to call pipeline.Send method directly
            if (statusCodeSwitchBuilder.ResponseType is {} responseType && responseType.Equals(typeof(Stream)))
            {
                return new[]
                {
                    AddProtocolMethodArguments(parameters, protocolMethodArguments).ToArray(),
                    UsingVar("message", InvokeCreateRequestMethod(createRequestMessageMethodSignature.Name, protocolMethodArguments), out var message),
                    EnableHttpRedirectIfSupported(message),
                    new HttpPipelineExpression(PipelineField).Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                    statusCodeSwitchBuilder.Build(message, async)
                };
            }

            return new[]
            {
                AddProtocolMethodArguments(parameters, protocolMethodArguments).ToArray(),
                Declare(ProtocolMethodReturnType, "response", InvokeProtocolMethod(null, protocolMethodArguments, async), out var response),
                statusCodeSwitchBuilder.Build(response, async)
            };
        }

        protected MethodBodyStatement CreateLegacyConvenienceMethodBody(MethodSignatureBase createRequestMessageMethodSignature, StatusCodeSwitchBuilder statusCodeSwitchBuilder, bool async)
        {
            var createRequestArguments = createRequestMessageMethodSignature.Parameters.Select(p => (ValueExpression)p).ToList();
            return new[]
            {
                UsingVar("message", InvokeCreateRequestMethod(createRequestMessageMethodSignature.Name, createRequestArguments), out var message),
                EnableHttpRedirectIfSupported(message),
                new HttpPipelineExpression(PipelineField).Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                statusCodeSwitchBuilder.Build(message, async)
            };
        }

        protected abstract Method? BuildLegacyNextPageConvenienceMethod(IReadOnlyList<Parameter> parameters, Method? createRequestMethod, bool async);

        protected MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType, string? nonDocumentComment)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility, returnType, null, parameters, attributes, NonDocumentComment: nonDocumentComment);
        }

        protected abstract MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async);

        protected abstract MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async);

        protected MethodBodyStatement EnableHttpRedirectIfSupported(TypedValueExpression message)
            => Operation.Responses.Any(r => RedirectResponseCodes.Any(r.StatusCodes.Contains))
                ? new InvokeStaticMethodStatement(typeof(RedirectPolicy), nameof(RedirectPolicy.SetAllowAutoRedirect), message, True)
                : new MethodBodyStatement();

        protected MethodBodyStatement WrapInDiagnosticScope(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), Fields.ClientDiagnosticsProperty, statements);

        protected static HttpMessageExpression InvokeCreateRequestMethod(string name, IReadOnlyList<ValueExpression> parameters)
            => new(new InvokeInstanceMethodExpression(null, name, parameters, null, false));

        protected ResponseExpression InvokeProtocolMethod(ValueExpression? instance, IReadOnlyList<ValueExpression> arguments, bool async)
            => new(new InvokeInstanceMethodExpression(instance, async ? $"{ProtocolMethodName}Async" : ProtocolMethodName, arguments, null, async));

        protected ValueExpression InvokeProtocolOperationHelpersConvertMethod(ValueExpression fetchResultDelegate, TypedValueExpression response, string scopeName)
        {
            var arguments = new[]{ response, fetchResultDelegate, Fields.ClientDiagnosticsProperty, Literal(scopeName) };
            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), nameof(ProtocolOperationHelpers.Convert), arguments);
        }

        protected IEnumerable<MethodBodyStatement> AddProtocolMethodArguments(RestClientMethodParameters parameters, List<ValueExpression> protocolMethodArguments)
        {
            MethodBodyStatement? requestContentConversion = null;
            foreach (var protocolParameter in parameters.Protocol)
            {
                if (parameters.Arguments.TryGetValue(protocolParameter, out var argument))
                {
                    protocolMethodArguments.Add(argument);
                    if (parameters.Conversions.TryGetValue(protocolParameter, out var conversion))
                    {
                        if (protocolParameter.Equals(KnownParameters.RequestContent) || protocolParameter.Equals(KnownParameters.RequestContentNullable))
                        {
                            requestContentConversion = conversion;
                        }
                        else
                        {
                            yield return conversion;
                        }
                    }
                }
                else
                {
                    protocolMethodArguments.Add(protocolParameter);
                }
            }

            if (requestContentConversion is not null)
            {
                yield return requestContentConversion;
            }
        }

        private static MethodSignatureModifiers GetAccessibility(string? accessibility) => accessibility switch
        {
            "public" => MethodSignatureModifiers.Public,
            "internal" => MethodSignatureModifiers.Internal,
            "protected" => MethodSignatureModifiers.Protected,
            "private" => MethodSignatureModifiers.Private,
            null => MethodSignatureModifiers.Public,
            _ => throw new NotSupportedException()
        };
    }
}
