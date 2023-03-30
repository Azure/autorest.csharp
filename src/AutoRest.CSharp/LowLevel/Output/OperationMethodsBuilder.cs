// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using static AutoRest.CSharp.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Configuration = AutoRest.CSharp.Input.Configuration;
using Response = Azure.Response;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

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
        private readonly bool _isLongRunning;
        private readonly bool _isPageable;
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
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly MethodSignatureModifiers _convenienceAccessibility;

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
            _headAsBoolean = operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            _isLongRunning = operation.LongRunning is not null;
            _isPageable = operation.Paging is not null;

            _protocolMethodName = operation.Name.ToCleanName();
            _protocolAccessibility = operation.GenerateProtocolMethod ? GetAccessibility(operation.Accessibility) : Internal;
            _convenienceAccessibility = GetAccessibility(operation.Accessibility);
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
            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var createRequestMethods = CreateRequestMethods(null).ToArray();
            var protocolMethods = new[]{ BuildProtocolMethod(true), BuildProtocolMethod(false) };

            var convenienceMethods = ShouldConvenienceMethodGenerated(out var needNameChange)
                ? new[]{ BuildConvenienceMethod(needNameChange, true), BuildConvenienceMethod(needNameChange, false) }
                : Array.Empty<Method>();

            return new LowLevelClientMethod(convenienceMethods, protocolMethods, createRequestMethods, requestBodyType, responseBodyType, _isPageable, _isLongRunning, Operation.Paging?.ItemName ?? "value");
        }

        public HlcMethods BuildHlc(DataPlaneResponseHeaderGroupType? headerModel)
        {
            var createRequestMethods = CreateRequestMethods(headerModel).ToArray();
            var convenienceMethods = _isPageable && !_isLongRunning
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
            if (_isPageable && _isLongRunning)
            {
                return false;
            }

            if (Operation.GenerateProtocolMethod && _responseType is null && _convenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter)
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
            var signature = CreateMethodSignature(_protocolMethodName, _protocolAccessibility, _protocolMethodParameters, _protocolMethodReturnType);
            var body = CreateMethodBody(CreateProtocolMethodBody(async).AsStatement(), signature, !_isPageable || _isLongRunning);
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

            var signature = CreateMethodSignature(methodName, _convenienceAccessibility, _convenienceMethodParameters, _convenienceMethodReturnType);
            var body = CreateMethodBody(CreateConvenienceMethodLogic(methodName, async), signature, !_isPageable && needNameChange);
            return new Method(signature.WithAsync(async), body);
        }

        private MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility | Virtual, returnType, null, parameters, attributes);
        }

        private MethodBody CreateMethodBody(MethodBodyStatement methodBodyLogic, MethodSignature signature, bool addDiagnosticScope)
        {
            if (addDiagnosticScope)
            {
                methodBodyLogic = new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{signature.Name}"), _fields.ClientDiagnosticsProperty, methodBodyLogic);
            }
            return new MethodBody(new[] { new ParameterValidationBlock(signature.Parameters), methodBodyLogic });
        }

        private IEnumerable<MethodBodyStatement> CreateProtocolMethodBody(bool async)
            => (Operation.Paging, Operation.LongRunning) switch
            {
                { Paging: { } paging, LongRunning: { } longRunning } => CreatePagingLroProtocolMethodLogic(paging, longRunning, async),
                { Paging: { } paging, LongRunning: null }            => CreatePagingProtocolMethodLogic(paging, async),
                { Paging: null, LongRunning: { } longRunning }       => CreateLroProtocolMethodLogic(longRunning, async),
                _                                                    => CreateProtocolMethodLogic(async)
            };

        private IEnumerable<MethodBodyStatement> CreateProtocolMethodLogic(bool async)
        {
            var pipeline = new HttpPipelineExpression(_fields.PipelineField.Declaration);
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var requestContext = _createMessageMethodParameters.Contains(KnownParameters.RequestContext)
                ? new RequestContextExpression(KnownParameters.RequestContext)
                : null;

            yield return Declare("message", InvokeCreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return _headAsBoolean
                ? Return(pipeline.ProcessHeadAsBoolMessage(message, clientDiagnostics, requestContext, async))
                : Return(pipeline.ProcessMessage(message, requestContext, null, async));
        }

        private IEnumerable<MethodBodyStatement> CreateLroProtocolMethodLogic(OperationLongRunning longRunning, bool async)
        {
            var pipeline = new HttpPipelineExpression(_fields.PipelineField.Declaration);
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var scopeName = $"{_clientName}.{_protocolMethodName}";

            yield return Declare("message", InvokeCreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return _responseType is not null
                ? Return(Call.ProtocolOperationHelpers.ProcessMessage(pipeline, message, clientDiagnostics, scopeName, longRunning.FinalStateVia, async))
                : Return(Call.ProtocolOperationHelpers.ProcessMessageWithoutResponseValue(pipeline, message, clientDiagnostics, scopeName, longRunning.FinalStateVia, async));
        }

        private IEnumerable<MethodBodyStatement> CreatePagingProtocolMethodLogic(OperationPaging paging, bool async)
        {
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{_protocolMethodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;
            var requestContext = _protocolMethodParameters.Contains(KnownParameters.RequestContext) ? (ParameterReference)KnownParameters.RequestContext : null;

            var createRequestArguments = _createMessageMethodParameters.Select(p => new ParameterReference(p));
            yield return MethodBodyLines.Declare.FirstPageRequest(null, _createMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            if (_createNextPageMessageMethodName is not null)
            {
                var nextPageArguments = _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                yield return MethodBodyLines.Declare.NextPageRequest(null, _createNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            yield return Return(Call.PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, typeof(BinaryData), scopeName, itemPropertyName, nextLinkName, requestContext, async));
        }

        private IEnumerable<MethodBodyStatement> CreatePagingLroProtocolMethodLogic(OperationPaging paging, OperationLongRunning longRunning, bool async)
        {
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var pipeline = new HttpPipelineExpression(_fields.PipelineField.Declaration);
            var scopeName = $"{_clientName}.{_protocolMethodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;
            var requestContext = _protocolMethodParameters.Contains(KnownParameters.RequestContext) ? (ParameterReference)KnownParameters.RequestContext : null;

            CodeWriterDeclaration? createNextPageRequest = null;
            if (_createNextPageMessageMethodName is not null)
            {
                var nextPageArguments = _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p));
                yield return MethodBodyLines.Declare.NextPageRequest(null, _createNextPageMessageMethodName, nextPageArguments, out createNextPageRequest);
            }

            yield return Declare("message", InvokeCreateRequestMethod(_createMessageMethodName, _createMessageMethodParameters), out var message);
            yield return Return(Call.PageableHelpers.CreatePageable(message, createNextPageRequest, clientDiagnostics, pipeline, typeof(BinaryData), longRunning.FinalStateVia, scopeName, itemPropertyName, nextLinkName, requestContext, async));
        }

        private MethodBodyStatement CreateConvenienceMethodLogic(string methodName, bool async)
            => (Operation.Paging, Operation.LongRunning) switch
            {
                { Paging: { } paging, LongRunning: null } => CreatePagingConvenienceMethodLines(methodName, paging, async),
                { Paging: null, LongRunning: not null }   => CreateLroConvenienceMethodLogic(methodName, async).AsStatement(),
                _                                         => CreateConvenienceMethodLogic(async).AsStatement()
            };

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            var parameterConversions = AddProtocolMethodArguments(_parameterLinks, protocolMethodArguments).AsStatement();

            yield return parameterConversions;
            yield return Declare(_protocolMethodReturnType, "response", new ResponseExpression(Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async)), out var response);

            if (_responseType is null)
            {
                yield return Return(response);
            }
            else if (_responseType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true }})
            {
                yield return Return(ResponseExpression.FromValue(new TypedValueExpression(_responseType, Call.Static(_responseType, "FromResponse", response)), response));
            }
            else
            {
                var firstResponseBodyType = Operation.Responses.Where(r => r is { IsErrorResponse: false, BodyType: {} }).Select(r => r.BodyType).Distinct().First();
                var serialization = SerializationBuilder.BuildJsonSerialization(firstResponseBodyType!, _responseType, false);

                yield return Declare(_responseType, "value", new ResponseExpression(Default), out var value);
                yield return JsonSerializationMethodsBuilder.BuildDeserializationForMethods(serialization, async, value, response);
                yield return Return(ResponseExpression.FromValue(value, response));
            }
        }

        private IEnumerable<MethodBodyStatement> CreateLroConvenienceMethodLogic(string methodName, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            var parameterConversions = AddProtocolMethodArguments(_parameterLinks, protocolMethodArguments).AsStatement();
            yield return parameterConversions;

            if (_responseType == null)
            {
                yield return Return(Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async));
            }
            else
            {
                yield return Declare(_protocolMethodReturnType, "response", new ResponseExpression(Call.ProtocolMethod(_protocolMethodName, protocolMethodArguments, async)), out var response);
                yield return Return(Call.ProtocolOperationHelpers.Convert(_responseType, response, _fields.ClientDiagnosticsProperty.Declaration, $"{_clientName}.{methodName}"));
            }
        }

        private MethodBodyStatement CreatePagingConvenienceMethodLines(string methodName, OperationPaging paging, bool async)
        {
            ValueExpression clientDiagnostics = _restClient != null
                ? new FormattableStringToExpression($"_{KnownParameters.ClientDiagnostics.Name}")
                : new VariableReference(_fields.ClientDiagnosticsProperty.Declaration);

            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{methodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;

            var createRequestArguments = new List<ValueExpression>();
            var parameterConversions = AddPageableMethodArguments(_parameterLinks, createRequestArguments, out var requestContextVariable).AsStatement();
            var firstPageRequestLine = MethodBodyLines.Declare.FirstPageRequest(_restClient, _createMessageMethodName, createRequestArguments, out var createFirstPageRequest);

            CodeWriterDeclaration? createNextPageRequest = null;
            DeclarationStatement? nextPageRequestLine = null;
            if (_createNextPageMessageMethodName is not null)
            {
                var arguments = _restClient != null ? _createNextPageMessageMethodParameters.Select(p => new ParameterReference(p)) : createRequestArguments.Prepend(KnownParameters.NextLink);
                nextPageRequestLine = MethodBodyLines.Declare.NextPageRequest(_restClient, _createNextPageMessageMethodName, arguments, out createNextPageRequest);
            }

            var returnLine = Return(Call.PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, _responseType, scopeName, itemPropertyName, nextLinkName, requestContextVariable, async));

            return nextPageRequestLine is not null
                ? new MethodBodyStatements(parameterConversions, firstPageRequestLine, nextPageRequestLine, returnLine)
                : new MethodBodyStatements(parameterConversions, firstPageRequestLine, returnLine);
        }

        public static IEnumerable<MethodBodyStatement> AddPageableMethodArguments(IReadOnlyList<MethodParametersBuilder.ParameterLink> parameters, List<ValueExpression> createRequestArguments, out ValueExpression? requestContextVariable)
        {
            var statements = new List<MethodBodyStatement>();
            requestContextVariable = null;
            foreach (var parameterLink in parameters)
            {
                switch (parameterLink)
                {
                    case { ProtocolParameters.Count: 0, ConvenienceParameters: var convenienceParameters }:
                        if (convenienceParameters.Count == 1 && convenienceParameters[0] == KnownParameters.CancellationTokenParameter)
                        {
                            requestContextVariable = KnownParameters.CancellationTokenParameter;
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters: [var convenienceParameter], IntermediateSerialization: null }:
                        if (protocolParameter == KnownParameters.RequestContext && convenienceParameter == KnownParameters.CancellationTokenParameter)
                        {
                            statements.Add(Declare(IfCancellationTokenCanBeCanceled(CancellationTokenExpression.KnownParameter), out var requestContext));
                            requestContextVariable = requestContext;
                            createRequestArguments.Add(requestContext);
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            var conversion = CreateConversion(convenienceParameter, protocolParameter.Type);
                            var argument = new CodeWriterDeclaration(protocolParameter.Name);
                            statements.Add(new DeclareVariable(protocolParameter.Type, argument, conversion));
                            createRequestArguments.Add(new VariableReference(argument));
                        }
                        else if (protocolParameter == KnownParameters.RequestContext)
                        {
                            requestContextVariable = new ParameterReference(protocolParameter);
                            createRequestArguments.Add(requestContextVariable);
                        }
                        else
                        {
                            createRequestArguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateSerialization: {} serializations }:
                        statements.Add(Var(protocolParameter.Name, Utf8JsonRequestContentExpression.New(), out var requestContent));
                        statements.Add(Var("writer", requestContent.JsonWriter, out var utf8JsonWriter));
                        statements.Add(utf8JsonWriter.WriteStartObject());
                        statements.Add(JsonSerializationMethodsBuilder.WritProperties(utf8JsonWriter, serializations).AsStatement());
                        statements.Add(utf8JsonWriter.WriteEndObject());

                        createRequestArguments.Add(requestContent);
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateSerialization: {} serializations }:
                        // Grouping is not supported yet
                        break;
                }
            }

            return statements;
        }

        public static IEnumerable<MethodBodyStatement> AddProtocolMethodArguments(IReadOnlyList<MethodParametersBuilder.ParameterLink> parameters, List<ValueExpression> protocolMethodArguments)
        {
            foreach (var parameterLink in parameters)
            {
                switch (parameterLink)
                {
                    case { ProtocolParameters.Count: 0 }:
                        // Skip the convenience-only parameters
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters: [var convenienceParameter], IntermediateSerialization: null }:
                        if (protocolParameter == KnownParameters.RequestContext && convenienceParameter == KnownParameters.CancellationTokenParameter)
                        {
                            yield return Declare(RequestContextExpression.FromCancellationToken(), out var requestContext);
                            protocolMethodArguments.Add(requestContext);
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            protocolMethodArguments.Add(CreateConversion(convenienceParameter, protocolParameter.Type));
                        }
                        else
                        {
                            protocolMethodArguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateSerialization: {} serializations }:
                        yield return Var(protocolParameter.Name, Utf8JsonRequestContentExpression.New(), out var requestContent);
                        yield return Var("writer", requestContent.JsonWriter, out var utf8JsonWriter);
                        yield return utf8JsonWriter.WriteStartObject();
                        yield return JsonSerializationMethodsBuilder.WritProperties(utf8JsonWriter, serializations).AsStatement();
                        yield return utf8JsonWriter.WriteEndObject();

                        protocolMethodArguments.Add(requestContent);
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateSerialization: {} model }:
                        // Grouping is not supported yet
                        break;
                }
            }
        }

        public static HttpMessageExpression InvokeCreateRequestMethod(string methodName, IEnumerable<Parameter> parameters)
        {
            return new(new InstanceMethodCallExpression(null, methodName, parameters.Select(p => new ParameterReference(p)).ToList(), false));
        }

        private static RequestContextExpression IfCancellationTokenCanBeCanceled(CancellationTokenExpression cancellationToken)
            => new(new TernaryConditionalOperator(cancellationToken.CanBeCanceled, RequestContextExpression.New(cancellationToken), Null));

        private static ValueExpression CreateConversion(Parameter fromParameter, CSharpType toType)
        {
            return fromParameter.Type.IsFrameworkType
                ? CreateConversion(fromParameter.CheckNull(), fromParameter.Type.FrameworkType, toType)
                : CreateConversion(fromParameter.CheckNull(), fromParameter.Type.Implementation, toType);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.IsNullable && toType.IsNullable)
            {
                fromExpression = new NullConditionalExpression(fromExpression);
            }

            return fromType.IsFrameworkType
                ? CreateConversion(fromExpression, fromType.FrameworkType, toType)
                : CreateConversion(fromExpression, fromType.Implementation, toType);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, Type fromFrameworkType, CSharpType toType)
        {
            if ((fromFrameworkType == typeof(BinaryData) || fromFrameworkType == typeof(string)) && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                return fromExpression;
            }

            return Call.RequestContent.Create(fromExpression);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, TypeProvider fromTypeImplementation, CSharpType toType)
        {
            return fromTypeImplementation switch
            {
                EnumType enumType when toType.EqualsIgnoreNullable(typeof(string)) => Call.Enum.ToString(fromExpression, enumType),
                ModelTypeProvider when toType.EqualsIgnoreNullable(typeof(RequestContent)) => Call.ToRequestContent(fromExpression),
                _ => fromExpression
            };
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
