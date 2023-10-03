// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
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

        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly string _clientNamespace;

        private readonly FormattableString? _summary;
        private readonly FormattableString? _description;
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly MethodParametersBuilder _parametersBuilder;
        private readonly StatusCodeSwitchBuilder _statusCodeSwitchBuilder;
        private readonly DpgOperationSampleBuilder _operationSampleBuilder;
        private readonly TypeFactory _typeFactory;
        private readonly SourceInputModel? _sourceInputModel;

        public InputOperation Operation { get; }

        protected ValueExpression ClientDiagnosticsProperty { get; }
        protected HttpPipelineExpression PipelineField { get; }

        protected MethodSignatureModifiers ConvenienceModifiers { get; }

        protected string CreateMessageMethodName { get; }
        protected string ProtocolMethodName { get; }

        protected CSharpType? ResponseType { get; }
        protected CSharpType ProtocolMethodReturnType { get; }
        protected CSharpType RestClientConvenienceMethodReturnType { get; }
        protected CSharpType ConvenienceMethodReturnType { get; }
        protected ResponseClassifierType ResponseClassifier { get; }

        protected OperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args)
        {
            _fields = args.Fields;
            _clientName = args.ClientName;
            _clientNamespace = args.ClientNamespace;
            _statusCodeSwitchBuilder = args.StatusCodeSwitchBuilder;
            _operationSampleBuilder = args.OperationSampleBuilder;
            _parametersBuilder = new MethodParametersBuilder(args.Operation, args.TypeFactory);
            _typeFactory = args.TypeFactory;
            _sourceInputModel = args.SourceInputModel;

            Operation = args.Operation;
            ClientDiagnosticsProperty = _fields.ClientDiagnosticsProperty;
            PipelineField = new HttpPipelineExpression(_fields.PipelineField);

            ProtocolMethodName = Operation.Name.ToCleanName();
            CreateMessageMethodName = $"Create{ProtocolMethodName}Request";

            ResponseType = _statusCodeSwitchBuilder.ResponseType;
            ProtocolMethodReturnType = _statusCodeSwitchBuilder.ProtocolReturnType;
            RestClientConvenienceMethodReturnType = _statusCodeSwitchBuilder.RestClientConvenienceReturnType;
            ConvenienceMethodReturnType = _statusCodeSwitchBuilder.ClientConvenienceReturnType;
            ResponseClassifier = _statusCodeSwitchBuilder.ResponseClassifier;

            _summary = FormattableStringHelpers.FromString(Operation.Summary != null ? BuilderHelpers.EscapeXmlDocDescription(Operation.Summary) : null);
            _description = FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(Operation.Description));
            _protocolAccessibility = Operation.GenerateProtocolMethod ? GetAccessibility(Operation.Accessibility) : MethodSignatureModifiers.Internal;
            ConvenienceModifiers = GetAccessibility(Operation.Accessibility);
        }


        public RestClientOperationMethods Build()
        {
            var parameters = _parametersBuilder.BuildParameters();

            var convenienceMethodIsMeaningless = parameters.Convenience.Where(p => p != KnownParameters.CancellationTokenParameter)
                .SequenceEqual(parameters.Protocol.Where(p => p != KnownParameters.RequestContext)) && ConvenienceMethodReturnType.Equals(ProtocolMethodReturnType);

            var makeAllProtocolParametersRequired =
                !Configuration.KeepNonOverloadableProtocolSignature &&
                Configuration.UseOverloadsBetweenProtocolAndConvenience &&
                !ExistingProtocolMethodHasOptionalParameters(_clientNamespace, _clientName, parameters.Protocol) &&
                !convenienceMethodIsMeaningless &&
                parameters.HasAmbiguityBetweenProtocolAndConvenience;

            if (makeAllProtocolParametersRequired)
            {
                parameters = parameters.MakeAllProtocolParametersRequired();
            }

            var requestContext = new RequestContextExpression(KnownParameters.RequestContext);
            var createMessageBuilder = new CreateMessageMethodBuilder(_fields, parameters.RequestParts, parameters.CreateMessage, requestContext, Operation.RequestBodyMediaType);

            var createMessageMethod = BuildCreateRequestMethod(parameters.CreateMessage, createMessageBuilder);
            var createNextPageMessageMethodSignature = BuildCreateNextPageMessageSignature(parameters.CreateMessage);
            var createNextPageMessageMethod = BuildCreateNextPageMessageMethod(createNextPageMessageMethodSignature, parameters, requestContext);

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
                    convenience = BuildConvenienceMethod(convenienceMethodSignature, parameters, createNextPageMessageMethodSignature, false);
                    convenienceAsync = BuildConvenienceMethod(convenienceMethodSignature, parameters, createNextPageMessageMethodSignature, true);
                }
                else if (Operation.GenerateProtocolMethod)
                {
                    protocolMethodNonDocumentComment = ConvenienceMethodIsMeaningless;
                }
            }

            var protocolMethodSignature = CreateMethodSignature(ProtocolMethodName, _protocolAccessibility | MethodSignatureModifiers.Virtual, parameters.Protocol, ProtocolMethodReturnType, protocolMethodNonDocumentComment);
            var order = Operation.LongRunning is not null ? 2 : Operation.Paging is not null ? 1 : 0;
            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var samples = _operationSampleBuilder.BuildSamples(Operation, protocolMethodSignature, convenienceMethodSignature, requestBodyType, ResponseType, _statusCodeSwitchBuilder.PageItemType);

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
                ResponseClassifier,

                order,
                Operation,
                requestBodyType,
                ResponseType,
                _statusCodeSwitchBuilder.PageItemType,
                samples,
                createNextPageMessageMethodSignature
            );
        }

        public RestClientOperationMethods BuildLegacy()
        {
            var parameters = _parametersBuilder.BuildParameters();
            var createMessageBuilder = new CreateMessageMethodBuilder(_fields, parameters.RequestParts, parameters.CreateMessage, null, Operation.RequestBodyMediaType);

            var createRequestMessageMethod = BuildCreateRequestMethod(parameters.CreateMessage, createMessageBuilder);
            var createNextPageMessageMethodSignature = BuildCreateNextPageMessageSignature(parameters.CreateMessage);
            var createNextPageMessageMethod = BuildCreateNextPageMessageMethod(createNextPageMessageMethodSignature, parameters, null);

            var order = Operation.LongRunning is not null ? 2 : Operation.Paging is not null ? 1 : 0;

            return new RestClientOperationMethods
            (
                createRequestMessageMethod,
                createNextPageMessageMethod,
                null,
                null,
                BuildLegacyConvenienceMethod(ProtocolMethodName, parameters.Convenience, InvokeCreateRequestMethod(createRequestMessageMethod.Signature), _statusCodeSwitchBuilder, false),
                BuildLegacyConvenienceMethod(ProtocolMethodName, parameters.Convenience, InvokeCreateRequestMethod(createRequestMessageMethod.Signature), _statusCodeSwitchBuilder, true),
                BuildLegacyNextPageConvenienceMethod(parameters.Convenience, createNextPageMessageMethod, false),
                BuildLegacyNextPageConvenienceMethod(parameters.Convenience, createNextPageMessageMethod, true),
                _statusCodeSwitchBuilder.ResponseClassifier,

                order,
                Operation,
                null,
                ResponseType,
                _statusCodeSwitchBuilder.PageItemType,
                Array.Empty<DpgOperationSample>(),
                createNextPageMessageMethodSignature
            );
        }

        protected Method BuildCreateRequestMethod(IReadOnlyList<Parameter> parameters, CreateMessageMethodBuilder builder)
        {
            var signature = new MethodSignature(CreateMessageMethodName, _summary, _description, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, parameters);
            return new Method(signature, BuildCreateRequestMethodBody(builder));
        }

        private bool ExistingProtocolMethodHasOptionalParameters(string clientNamespace, string clientName, IEnumerable<Parameter> parameters)
        {
            var existingProtocolMethod = _sourceInputModel?.FindMethod(clientNamespace, clientName, Operation.CleanName, parameters.Select(p => p.Type));
            return existingProtocolMethod is { Parameters: [.., {IsOptional: true}]};
        }

        private MethodBodyStatement BuildCreateRequestMethodBody(CreateMessageMethodBuilder builder)
        {
            return new[]
            {
                builder.CreateHttpMessage(Operation.HttpMethod, Operation.BufferResponse, ResponseClassifier, out var message, out var request, out var uriBuilder),
                builder.AddUri(uriBuilder, Operation.Uri),
                builder.AddPath(uriBuilder, Operation.Path),
                builder.AddQuery(uriBuilder),

                Assign(request.Uri, uriBuilder),

                builder.AddHeaders(request),
                builder.AddBody(request),
                builder.AddUserAgent(message),
                Return(message)
            };
        }

        private Method? BuildCreateNextPageMessageMethod(MethodSignature? signature, RestClientMethodParameters parameters, RequestContextExpression? requestContext)
        {
            if (signature is null)
            {
                return null;
            }

            var builder = new CreateMessageMethodBuilder(_fields, parameters.RequestParts, signature.Parameters, requestContext, Operation.RequestBodyMediaType);
            var body = BuildCreateNextPageMessageMethodBody(builder, signature);
            return body is not null ? new Method(signature, body) : null;
        }

        protected abstract MethodSignature? BuildCreateNextPageMessageSignature(IReadOnlyList<Parameter> createMessageParameters);

        protected abstract MethodBodyStatement? BuildCreateNextPageMessageMethodBody(CreateMessageMethodBuilder builder, MethodSignature signature);

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

        private Method BuildConvenienceMethod(MethodSignature signature, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
        {
            var body = new[]
            {
                new ParameterValidationBlock(parameters.Convenience),
                CreateConvenienceMethodBody(signature.Name, parameters, createNextPageMessageSignature, async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        protected Method BuildLegacyConvenienceMethod(string methodName, IReadOnlyList<Parameter> parameters, HttpMessageExpression invokeCreateRequestMethod, StatusCodeSwitchBuilder statusCodeSwitchBuilder, bool async)
        {
            var signature = CreateMethodSignature(methodName, ConvenienceModifiers, parameters, RestClientConvenienceMethodReturnType, null);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters, IsLegacy: !Configuration.AzureArm),
                UsingVar("message", invokeCreateRequestMethod, out var message),
                EnableHttpRedirectIfSupported(message),
                PipelineField.Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                statusCodeSwitchBuilder.Build(message, async)
            };

            return new Method(signature.WithAsync(async), body);
        }

        protected abstract Method? BuildLegacyNextPageConvenienceMethod(IReadOnlyList<Parameter> parameters, Method? createRequestMethod, bool async);

        private MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType, string? nonDocumentComment)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility, returnType, null, parameters, attributes, NonDocumentComment: nonDocumentComment);
        }

        protected abstract MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async);

        protected abstract MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async);

        protected MethodBodyStatement EnableHttpRedirectIfSupported(HttpMessageExpression message)
            => Operation.Responses.Any(r => RedirectResponseCodes.Any(r.StatusCodes.Contains))
                ? new InvokeStaticMethodStatement(typeof(RedirectPolicy), nameof(RedirectPolicy.SetAllowAutoRedirect), message, True)
                : new MethodBodyStatement();

        protected MethodBodyStatement WrapInDiagnosticScope(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), _fields.ClientDiagnosticsProperty, statements);

        protected static HttpMessageExpression InvokeCreateRequestMethod(MethodSignatureBase signature)
            => new(new InvokeInstanceMethodExpression(null, signature.Name, signature.Parameters.Select(p => (ValueExpression)p).ToList(), null, false));

        protected ResponseExpression InvokeProtocolMethod(ValueExpression? instance, IReadOnlyList<ValueExpression> arguments, bool async)
            => new(new InvokeInstanceMethodExpression(instance, async ? $"{ProtocolMethodName}Async" : ProtocolMethodName, arguments, null, async));

        protected ValueExpression InvokeProtocolOperationHelpersConvertMethod(SerializableObjectType responseType, ResponseExpression response, string scopeName)
        {
            var arguments = new ValueExpression[]{ response, SerializableObjectTypeExpression.FromResponseDelegate(responseType), _fields.ClientDiagnosticsProperty, Literal(scopeName) };
            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), nameof(ProtocolOperationHelpers.Convert), arguments);
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
