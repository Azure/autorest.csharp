// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ClientMethodBodyLines;
using static AutoRest.CSharp.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Configuration = AutoRest.CSharp.Input.Configuration;
using Response = Azure.Response;

namespace AutoRest.CSharp.Output.Models
{
    internal class OperationMethodsBuilder
    {
        private readonly ValueExpression? _restClient;
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<RequestPartSource> _requestParts;
        private readonly bool _headAsBoolean;
        private readonly IReadOnlyList<MethodParametersBuilder.ParameterLink> _parameterLinks;
        private readonly IReadOnlyList<Parameter> _protocolMethodParameters;
        private readonly IReadOnlyList<Parameter> _convenienceMethodParameters;
        private readonly IReadOnlyList<Parameter> _createMessageMethodParameters;
        private readonly IReadOnlyList<Parameter> _createNextPageMessageMethodParameters;
        private readonly CSharpType? _responseType;
        private readonly CSharpType _protocolMethodReturnType;
        private readonly CSharpType _convenienceMethodReturnType;
        private readonly string _createMessageMethodName;
        private readonly string? _createNextPageMessageMethodName;
        private readonly string _protocolMethodName;
        private readonly string? _summary;
        private readonly string? _description;
        private readonly MethodSignatureModifiers _accessibility;

        public InputOperation Operation { get; }

        public OperationMethodsBuilder(
            InputOperation operation,
            ValueExpression? restClient,
            ClientFields fields,
            string clientName,
            TypeFactory typeFactory,
            IReadOnlyList<RequestPartSource> requestParts,
            IReadOnlyList<Parameter> createMessageMethodParameters,
            IReadOnlyList<Parameter> createNextPageMessageMethodParameters,
            IReadOnlyList<MethodParametersBuilder.ParameterLink> parameterLinks)
        {
            Operation = operation;

            _restClient = restClient;
            _fields = fields;
            _clientName = clientName;
            _typeFactory = typeFactory;
            _requestParts = requestParts;
            _summary = operation.Summary != null ? BuilderHelpers.EscapeXmlDescription(operation.Summary) : null;
            _description = BuilderHelpers.EscapeXmlDescription(operation.Description);
            _accessibility = GetAccessibility(operation.Accessibility);
            _headAsBoolean = operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;

            _protocolMethodName = operation.Name.ToCleanName();
            _createMessageMethodName = $"Create{_protocolMethodName}Request";
            _createNextPageMessageMethodName = operation.Paging is { NextLinkOperation: { } nextLinkOperation }
                ? $"Create{nextLinkOperation.Name.ToCleanName()}Request"
                : operation.Paging is { NextLinkName: { }} ? $"Create{_protocolMethodName}NextPageRequest" : null;

            _parameterLinks = parameterLinks;
            _createMessageMethodParameters = createMessageMethodParameters;
            _createNextPageMessageMethodParameters = createNextPageMessageMethodParameters;
            _protocolMethodParameters = parameterLinks.SelectMany(p => p.ProtocolParameters).ToList();
            _convenienceMethodParameters = parameterLinks.SelectMany(p => p.ConvenienceParameters).ToList();
            _responseType = _headAsBoolean ? null : GetResponseType(operation, typeFactory);
            _protocolMethodReturnType = _headAsBoolean ? typeof(Response<bool>) : GetProtocolMethodReturnType(operation, _responseType);
            _convenienceMethodReturnType = _responseType is not null ? GetConvenienceMethodReturnType(operation, _responseType) : _protocolMethodReturnType;
        }

        public LowLevelClientMethod BuildDpg()
        {
            var createRequestMethods = CreateRequestMethods(null).ToArray();
            var protocolMethods = new[]{ BuildProtocolMethod(true), BuildProtocolMethod(false) };

            var convenienceMethods = ShouldConvenienceMethodGenerated(out var needNameChange)
                ? new[]{ BuildConvenienceMethod(needNameChange, true), BuildConvenienceMethod(needNameChange, false) }
                : Array.Empty<Method>();

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var protocolMethodPaging = Operation.Paging is { } paging
                ? new ProtocolMethodPaging(paging.NextLinkName, paging.ItemName ?? "value")
                : null;

            return new LowLevelClientMethod(convenienceMethods, protocolMethods, createRequestMethods, requestBodyType, responseBodyType, protocolMethodPaging, Operation.LongRunning);
        }

        public HlcMethods BuildHlc(DataPlaneResponseHeaderGroupType? headerModel)
        {
            var createRequestMethods = CreateRequestMethods(headerModel).ToArray();
            var convenienceMethods = Operation.Paging is not null && Operation.LongRunning is null
                ? new[]{ BuildConvenienceMethod(false, true), BuildConvenienceMethod(false, false) }
                : Array.Empty<Method>();

            return new HlcMethods(Operation, createRequestMethods, convenienceMethods);
        }

        private IEnumerable<RestClientMethod> CreateRequestMethods(DataPlaneResponseHeaderGroupType? headerModel)
        {
            var createMessageMethod = RestClientBuilder.BuildRequestMethod(Operation, _createMessageMethodParameters, _requestParts, headerModel, _fields, _typeFactory);
            yield return createMessageMethod;
            if (_createNextPageMessageMethodName is not null && Operation.Paging is { NextLinkOperation: null })
            {
                yield return RestClientBuilder.BuildNextPageMethod(createMessageMethod);
            }
        }

        private bool ShouldConvenienceMethodGenerated(out bool needNameChange)
        {
            needNameChange = false;

            if (!Operation.GenerateConvenienceMethod)
            {
                return false;
            }

            // Pageable LRO's aren't supported yet
            if (Operation.Paging != null && Operation.LongRunning != null)
            {
                return false;
            }

            if (_responseType is null && _convenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter)
                    .SequenceEqual(_protocolMethodParameters.Where(p => p != KnownParameters.RequestContext)))
            {
                return false;
            }

            needNameChange = _protocolMethodParameters.Where(p => !p.IsOptionalInSignature)
                .SequenceEqual(_convenienceMethodParameters.Where(p => !p.IsOptionalInSignature));
            return true;
        }

        private static CSharpType? GetResponseType(InputOperation operation, TypeFactory typeFactory)
        {
            var firstResponseBodyType = operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().FirstOrDefault();
            var responseType = firstResponseBodyType is not null ? typeFactory.CreateType(firstResponseBodyType) : null;
            if (operation.Paging is not { } paging)
            {
                return responseType is null ? null : TypeFactory.GetOutputType(responseType);
            }

            if (responseType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            if (responseType.IsFrameworkType || responseType.Implementation is not SerializableObjectType modelType)
            {
                return TypeFactory.IsList(responseType) ? TypeFactory.GetElementType(responseType) : responseType;
            }

            var property = modelType.GetPropertyBySerializedName(paging.ItemName ?? "value");
            var propertyType = property.ValueType.WithNullable(false);
            if (!TypeFactory.IsList(propertyType))
            {
                throw new InvalidOperationException($"'{modelType.Declaration.Name}.{property.Declaration.Name}' property must be a collection of items");
            }

            return TypeFactory.GetElementType(property.ValueType);
        }

        private static CSharpType GetProtocolMethodReturnType(InputOperation operation, CSharpType? responseType)
            => (operation.Paging, operation.LongRunning, responseType) switch
            {
                { Paging: not null, LongRunning: not null }       => typeof(Operation<Pageable<BinaryData>>),
                { Paging: not null, LongRunning: null }           => typeof(Pageable<BinaryData>),
                { LongRunning: not null, responseType: not null } => typeof(Operation<BinaryData>),
                { LongRunning: not null, responseType: null }     => typeof(Operation),
                _                                                 => typeof(Response)
            };

        private static CSharpType GetConvenienceMethodReturnType(InputOperation operation, CSharpType responseType)
            => (operation.Paging, operation.LongRunning) switch
            {
                { Paging: not null, LongRunning: not null } => new CSharpType(typeof(Operation<>), new CSharpType(typeof(Pageable<>), responseType)),
                { Paging: not null, LongRunning: null }     => new CSharpType(typeof(Pageable<>), responseType),
                { LongRunning: not null }                   => new CSharpType(typeof(Operation<>), responseType),
                _                                           => new CSharpType(typeof(Response<>), responseType)
            };

        private Method BuildProtocolMethod(bool async)
        {
            var isPageable = Operation.Paging is not null && Operation.LongRunning is null;
            var signature = CreateMethodSignature(_protocolMethodName, _protocolMethodParameters, _protocolMethodReturnType);
            var body = CreateMethodBody(CreateProtocolMethodBody(async), signature, !isPageable);
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildConvenienceMethod(bool needNameChange, bool async)
        {
            var methodName = _protocolMethodName;
            if (needNameChange)
            {
                methodName = methodName.IsLastWordSingular()
                    ? $"{methodName}Value"
                    : $"{methodName.LastWordToSingular()}Values";
            }

            var isPageable = Operation.Paging is not null;

            var signature = CreateMethodSignature(methodName, _convenienceMethodParameters, _convenienceMethodReturnType);
            var body = CreateMethodBody(CreateConvenienceMethodMainBodyBlock(methodName, async), signature, !isPageable && needNameChange);
            return new Method(signature.WithAsync(async), body);
        }

        private MethodSignature CreateMethodSignature(string name, IReadOnlyList<Parameter> parameters, CSharpType returnType)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, _accessibility | Virtual, returnType, null, parameters, attributes);
        }

        private MethodBody CreateMethodBody(IEnumerable<MethodBodyLine> mainBlockLines, MethodSignature signature, bool addDiagnosticScope)
        {
            MethodBodyBlock mainBodyBlock = new MethodBodyLines(mainBlockLines.ToList());
            if (addDiagnosticScope)
            {
                mainBodyBlock = new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{signature.Name}"), _fields.ClientDiagnosticsProperty, mainBodyBlock);
            }
            return new MethodBody(new[] { new ParameterValidationBlock(signature.Parameters), mainBodyBlock });
        }

        private IEnumerable<MethodBodyLine> CreateProtocolMethodBody(bool async)
            => (Operation.Paging, Operation.LongRunning) switch
            {
                { Paging: { } paging, LongRunning: { } longRunning } => CreatePagingLroProtocolMethodLines(paging, longRunning, async),
                { Paging: { } paging, LongRunning: null }            => CreatePagingProtocolMethodLines(paging, async),
                { Paging: null, LongRunning: { } longRunning }       => CreateLroProtocolMethodLines(longRunning, async),
                _                                                    => CreateProtocolMethodLines(async)
            };

        private IEnumerable<MethodBodyLine> CreateProtocolMethodLines(bool async)
        {
            var pipeline = _fields.PipelineField.Declaration;
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var requestContext = _createMessageMethodParameters.Contains(KnownParameters.RequestContext) ? KnownParameters.RequestContext : null;

            yield return Declare.Message(Call.CreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return _headAsBoolean
                ? Return(Call.HttpPipelineExtensions.ProcessHeadAsBoolMessage(pipeline, message, clientDiagnostics, requestContext, async))
                : Return(Call.HttpPipelineExtensions.ProcessMessage(pipeline, message, requestContext, null, async));
        }

        private IEnumerable<MethodBodyLine> CreateLroProtocolMethodLines(OperationLongRunning longRunning, bool async)
        {
            var pipeline = _fields.PipelineField.Declaration;
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var scopeName = $"{_clientName}.{_protocolMethodName}";

            yield return Declare.Message(Call.CreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return _responseType is not null
                ? Return(Call.ProtocolOperationHelpers.ProcessMessage(pipeline, message, clientDiagnostics, scopeName, longRunning.FinalStateVia, async))
                : Return(Call.ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(pipeline, message, clientDiagnostics, scopeName, longRunning.FinalStateVia, async));
        }

        private IEnumerable<MethodBodyLine> CreatePagingProtocolMethodLines(OperationPaging paging, bool async)
        {
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{_protocolMethodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;
            var requestContext = _protocolMethodParameters.Contains(KnownParameters.RequestContext) ? (ParameterReference)KnownParameters.RequestContext : null;

            var createRequestArguments = _createMessageMethodParameters.Select(p => new ParameterReference(p));
            yield return Declare.FirstPageRequest(null, _createMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            if (_createNextPageMessageMethodName is not null)
            {
                var nextPageArguments = _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                yield return Declare.NextPageRequest(null, _createNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            yield return Return(Call.PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, typeof(BinaryData), scopeName, itemPropertyName, nextLinkName, requestContext, async));
        }

        private IEnumerable<MethodBodyLine> CreatePagingLroProtocolMethodLines(OperationPaging paging, OperationLongRunning longRunning, bool async)
        {
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{_protocolMethodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;
            var requestContext = _protocolMethodParameters.Contains(KnownParameters.RequestContext) ? (ParameterReference)KnownParameters.RequestContext : null;

            CodeWriterDeclaration? createNextPageRequest = null;
            if (_createNextPageMessageMethodName is not null)
            {
                var nextPageArguments = _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                yield return Declare.NextPageRequest(null, _createNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            yield return Declare.Message(Call.CreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return Return(Call.PageableHelpers.CreatePageable(message, createNextPageRequest, clientDiagnostics, pipeline, typeof(BinaryData), longRunning.FinalStateVia, scopeName, itemPropertyName, nextLinkName, requestContext, async));
        }

        private IEnumerable<MethodBodyLine> CreateConvenienceMethodMainBodyBlock(string methodName, bool async)
            => (Operation.Paging, Operation.LongRunning) switch
            {
                { Paging: { } paging, LongRunning: null } => CreatePagingConvenienceMethodLines(methodName, paging, async),
                { Paging: null, LongRunning: not null }   => CreateLroConvenienceMethodLines(methodName, async),
                _                                         => CreateConvenienceMethodLines(async)
            };

        private IEnumerable<MethodBodyLine> CreateConvenienceMethodLines(bool async)
        {
            var lines = new List<MethodBodyLine>();

            lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
            lines.Add(Declare.Response(_protocolMethodReturnType, Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async), out var response));
            if (_responseType is null)
            {
                lines.Add(Return(response));
            }
            else if (TypeFactory.IsList(_responseType))
            {
                lines.Add(Declare.Default(_responseType, "value", out var value));
                lines.Add(Declare.JsonDocument(Call.JsonDocument.Parse(response, async), out var document));
                lines.Add(Return(Call.Response.FromValue(value, response)));
            }
            else
            {
                lines.Add(Return(Call.Response.FromValue(_responseType, response)));
            }

            return lines;
        }

        private IEnumerable<MethodBodyLine> CreateLroConvenienceMethodLines(string methodName, bool async)
        {
            var lines = new List<MethodBodyLine>();

            lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
            if (_responseType != null)
            {
                lines.Add(Declare.Response(_protocolMethodReturnType, Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async), out var response));
                lines.Add(Return(Call.ProtocolOperationHelpers.Convert(_responseType, response, _fields.ClientDiagnosticsProperty.Declaration, $"{_clientName}.{methodName}")));
            }
            else
            {
                lines.Add(Return(Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async)));
            }

            return lines;
        }

        private IEnumerable<MethodBodyLine> CreatePagingConvenienceMethodLines(string methodName, OperationPaging paging, bool async)
        {
            ValueExpression clientDiagnostics = _restClient != null
                ? new FormattableStringToExpression($"_{KnownParameters.ClientDiagnostics.Name}")
                : new VariableReference(_fields.ClientDiagnosticsProperty.Declaration);

            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{methodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;

            var lines = new List<MethodBodyLine>();
            CodeWriterDeclaration? createNextPageRequest = null;

            lines.CreatePageableMethodArguments(_parameterLinks, out var createRequestArguments, out var requestContextVariable);

            lines.Add(Declare.FirstPageRequest(_restClient, _createMessageMethodName, createRequestArguments, out var createFirstPageRequest));
            if (_createNextPageMessageMethodName is not null)
            {
                var arguments = _restClient != null ? _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p)) : createRequestArguments.Prepend(KnownParameters.NextLink);
                lines.Add(Declare.NextPageRequest(_restClient, _createNextPageMessageMethodName, arguments, out createNextPageRequest));
            }

            lines.Add(Return(Call.PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, _responseType, scopeName, itemPropertyName, nextLinkName, requestContextVariable, async)));

            return lines;
        }

        private static MethodSignatureModifiers GetAccessibility(string? accessibility) => accessibility switch
        {
            "public" => Public,
            "internal" => Internal,
            "protected" => Protected,
            "private" => Private,
            null => Public,
            _ => throw new NotSupportedException()
        };
    }
}
