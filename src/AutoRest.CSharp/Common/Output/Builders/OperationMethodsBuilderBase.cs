// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using ConstantExpression = AutoRest.CSharp.Common.Output.Models.ValueExpressions.ConstantExpression;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using Response = AutoRest.CSharp.Output.Models.Responses.Response;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class OperationMethodsBuilderBase
    {
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<RequestPartSource> _requestParts;

        private readonly string? _summary;
        private readonly string? _description;
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly MethodSignatureModifiers _convenienceAccessibility;

        public InputOperation Operation { get; }

        protected CodeWriterDeclaration ClientDiagnosticsDeclaration { get; }
        protected HttpPipelineExpression PipelineField { get; }
        protected ValueExpression? RestClient { get; }

        protected string CreateMessageMethodName { get; }
        protected string ProtocolMethodName { get; }

        protected CSharpType ProtocolMethodReturnType { get; }
        protected CSharpType ConvenienceMethodReturnType { get; }

        protected IReadOnlyList<Parameter> CreateMessageMethodParameters { get; }
        protected IReadOnlyList<Parameter> ProtocolMethodParameters { get; }
        protected IReadOnlyList<Parameter> ConvenienceMethodParameters { get; }
        protected IReadOnlyDictionary<Parameter, ValueExpression> ArgumentsMap { get; }
        protected IReadOnlyDictionary<Parameter, MethodBodyStatement> ConversionsMap { get; }
        protected RequestContextExpression? CreateMessageRequestContext { get; }

        protected OperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientMethodParameters clientMethodParameters)
        {
            Operation = operation;
            ClientDiagnosticsDeclaration = fields.ClientDiagnosticsProperty.Declaration;
            PipelineField = new HttpPipelineExpression(fields.PipelineField.Declaration);
            RestClient = restClient;

            ProtocolMethodName = operation.Name.ToCleanName();
            CreateMessageMethodName = $"Create{ProtocolMethodName}Request";

            ProtocolMethodReturnType = returnTypes.ProtocolMethodReturnType;
            ConvenienceMethodReturnType = returnTypes.ConvenienceMethodReturnType;

            CreateMessageMethodParameters = clientMethodParameters.CreateMessage;
            ProtocolMethodParameters = clientMethodParameters.Protocol;
            ConvenienceMethodParameters = clientMethodParameters.Convenience;
            CreateMessageRequestContext = clientMethodParameters.HasRequestContextInCreateMessage
                    ? new RequestContextExpression(KnownParameters.RequestContext)
                    : null;

            _fields = fields;
            _clientName = clientName;
            _typeFactory = typeFactory;
            _requestParts = clientMethodParameters.RequestParts;
            ArgumentsMap = clientMethodParameters.Arguments;
            ConversionsMap = clientMethodParameters.Conversions;
            _summary = operation.Summary != null ? BuilderHelpers.EscapeXmlDescription(operation.Summary) : null;
            _description = BuilderHelpers.EscapeXmlDescription(operation.Description);
            _protocolAccessibility = operation.GenerateProtocolMethod ? GetAccessibility(operation.Accessibility) : MethodSignatureModifiers.Internal;
            _convenienceAccessibility = GetAccessibility(operation.Accessibility);
        }

        public LowLevelClientMethod BuildDpg()
        {
            var responseClassifier = RestClientBuilder.BuildRequestMethod(Operation, CreateMessageMethodParameters, _requestParts, null, null, _fields, _typeFactory).ResponseClassifierType;
            var createRequestMethods = BuildCreateRequestMethods(responseClassifier).ToArray();
            var protocolMethods = new[]{ BuildProtocolMethod(true), BuildProtocolMethod(false) };
            var convenienceMethods = Array.Empty<Method>();
            if (Operation.GenerateConvenienceMethod && ShouldConvenienceMethodGenerated())
            {
                var needNameChange = ProtocolMethodParameters.Where(p => !p.IsOptionalInSignature).SequenceEqual(ConvenienceMethodParameters.Where(p => !p.IsOptionalInSignature));
                var convenienceMethodName = needNameChange
                    ? ProtocolMethodName.IsLastWordSingular() ? $"{ProtocolMethodName}Value" : $"{ProtocolMethodName.LastWordToSingular()}Values"
                    : ProtocolMethodName;

                convenienceMethods = new[]{ BuildConvenienceMethod(convenienceMethodName, true), BuildConvenienceMethod(convenienceMethodName, false) };
            }

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var isPaging = Operation.Paging is not null;
            var isLongRunning = Operation.LongRunning is not null;
            return new LowLevelClientMethod(convenienceMethods, protocolMethods, createRequestMethods, responseClassifier, Operation.ExternalDocsUrl, requestBodyType, responseBodyType, isPaging, isLongRunning, Operation.Paging?.ItemName ?? "value");
        }

        public LegacyMethods BuildLegacy(DataPlaneResponseHeaderGroupType? headerModel, CSharpType? resourceDataType)
        {
            var restClientMethod = RestClientBuilder.BuildRequestMethod(Operation, CreateMessageMethodParameters, _requestParts, headerModel, resourceDataType, _fields, _typeFactory);
            var createRequestMethods = BuildCreateRequestMethods(restClientMethod.ResponseClassifierType).ToArray();

            var restClientMethods = new[]
            {
                BuildRestClientConvenienceMethod(ProtocolMethodName, ConvenienceMethodParameters, InvokeCreateRequestMethod(), restClientMethod.Responses, restClientMethod.ReturnType, headerModel?.Type, resourceDataType, true),
                BuildRestClientConvenienceMethod(ProtocolMethodName, ConvenienceMethodParameters, InvokeCreateRequestMethod(), restClientMethod.Responses, restClientMethod.ReturnType, headerModel?.Type, resourceDataType, false)
            };

            RestClientMethod? nextPage;
            Method? createNextPageRequest;
            IReadOnlyList<Method> restClientNextPageMethods;

            if (createRequestMethods.Length == 2)
            {
                nextPage = BuildNextPageMethod(restClientMethod);
                createNextPageRequest = createRequestMethods[1];

                var methodName = ProtocolMethodName + "NextPage";
                var parameters = ConvenienceMethodParameters.Prepend(nextPage.Parameters.First()).ToList();
                var invokeCreateRequestMethod = InvokeCreateRequestMethod(createNextPageRequest.Signature.Name, createNextPageRequest.Signature.Parameters);

                restClientNextPageMethods = new[]
                {
                    BuildRestClientConvenienceMethod(methodName, parameters, invokeCreateRequestMethod, nextPage.Responses, nextPage.ReturnType, headerModel?.Type, resourceDataType, true),
                    BuildRestClientConvenienceMethod(methodName, parameters, invokeCreateRequestMethod, nextPage.Responses, nextPage.ReturnType, headerModel?.Type, resourceDataType, false)
                };
            }
            else
            {
                nextPage = null;
                createNextPageRequest = null;
                restClientNextPageMethods = Array.Empty<Method>();
            }

            var convenienceMethods = new[]
            {
                BuildLegacyConvenienceMethod(true),
                BuildLegacyConvenienceMethod(false)
            };

            return new LegacyMethods
            (
                createRequestMethods[0],
                createNextPageRequest,
                restClientMethods,
                restClientNextPageMethods,
                convenienceMethods,

                this is LroOperationMethodsBuilder ? 2 : this is PagingOperationMethodsBuilderBase ? 1 : 0,
                Operation,
                null,
                restClientMethod,
                nextPage
            );
        }

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);

            var pathSegments = method.Request.PathSegments
                .Where(ps => ps.IsRaw)
                .Append(new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default, isRaw: true))
                .ToArray();

            var request = new Request(RequestMethod.Get, pathSegments, Array.Empty<QueryParameter>(), method.Request.Headers, null);
            var parameters = method.Parameters.Where(p => p.Name != nextPageUrlParameter.Name).Prepend(nextPageUrlParameter).ToArray();
            var responses = method.Responses;

            // We hardcode 200 as expected response code for paged LRO results
            if (method.Operation.LongRunning != null)
            {
                responses = new[]
                {
                    new Response(null, new[] { new StatusCodes(200, null) })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Summary,
                method.Description,
                method.ReturnType,
                request,
                parameters,
                responses,
                method.HeaderModel,
                bufferResponse: true,
                accessibility: "internal",
                method.Operation);
        }

        protected virtual IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType)
        {
            var signature = new MethodSignature(CreateMessageMethodName, _summary, _description, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, CreateMessageMethodParameters);
            yield return new Method(signature, BuildCreateRequestMethodBody(responseClassifierType).AsStatement());
        }

        private IEnumerable<MethodBodyStatement> BuildCreateRequestMethodBody(ResponseClassifierType responseClassifierType)
        {
            yield return CreateHttpMessage(responseClassifierType, out var message, out var request, out var uriBuilder);
            yield return AddUri(uriBuilder, Operation.Uri);
            yield return AddPath(uriBuilder, Operation.Path);
            yield return AddQuery(uriBuilder).AsStatement();

            yield return Assign(request.Uri, uriBuilder);

            yield return AddHeaders(request, false).AsStatement();
            yield return AddBody(request);
            yield return Return(message);
        }

        protected List<MethodBodyStatement> CreateHttpMessage(ResponseClassifierType? responseClassifierType, out HttpMessageExpression message, out RequestExpression request, out RawRequestUriBuilderExpression uriBuilder)
        {
            var callPipelineCreateMessage = CreateMessageRequestContext is not null
                ? responseClassifierType is not null
                    ? PipelineField.CreateMessage(CreateMessageRequestContext, new FormattableStringToExpression($"{responseClassifierType.Name}"))
                    : PipelineField.CreateMessage(CreateMessageRequestContext)
                : PipelineField.CreateMessage();

            var statements = new List<MethodBodyStatement>
            {
                Var("message", callPipelineCreateMessage, out message),
                Var("request", message.Request, out request)
            };

            if (!Operation.BufferResponse)
            {
                statements.Add(Assign(message.BufferResponse, False));
            }

            statements.Add(Assign(request.Method, new MemberReference(typeof(RequestMethod), Operation.HttpMethod.ToRequestMethodName())));
            statements.Add(Var("uri", RawRequestUriBuilderExpression.New(), out uriBuilder));

            return statements;
        }

        protected List<MethodBodyStatement> AddUri(RawRequestUriBuilderExpression uriBuilder, string uri)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uri))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendRaw(span.ToString(), false));
                }
                else if (TryGetRequestPart(span, RequestLocation.Uri, out var inputParameter, out var outputParameter, out _))
                {
                    if (inputParameter.IsEndpoint)
                    {
                        lines.Add(uriBuilder.Reset(_fields.EndpointField ?? throw new InvalidOperationException("Endpoint field is missing!")));
                    }
                    else
                    {
                        var value = GetValueForRequestPart(inputParameter, outputParameter);

                        lines.Add(outputParameter.Type.Equals(typeof(Uri))
                            ? uriBuilder.Reset(value)
                            : uriBuilder.AppendRaw(ConvertToRequestPartType(value, outputParameter.Type, true), !inputParameter.SkipUrlEncoding));
                    }
                }
                else
                {
                    ErrorHelpers.ThrowError($"\n\nError while processing request '{uri}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                }
            }
            return lines;
        }

        private List<MethodBodyStatement> AddPath(RawRequestUriBuilderExpression uriBuilder, string path)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(path))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendPath(span.ToString(), false));
                }
                else if (TryGetRequestPart(span, RequestLocation.Path, out var inputParameter, out var outputParameter, out var format))
                {
                    var value = GetValueForRequestPart(inputParameter, outputParameter);
                    lines.Add(value is not ConstantExpression && outputParameter.Name == "nextLink"
                        ? uriBuilder.AppendRawNextLink(outputParameter, !inputParameter.SkipUrlEncoding)
                        : uriBuilder.AppendPath(ConvertToRequestPartType(value, outputParameter.Type), format, !inputParameter.SkipUrlEncoding));
                }
                else
                {
                    ErrorHelpers.ThrowError($"\n\nError while processing request '{path}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                }
            }
            return lines;
        }

        private IEnumerable<MethodBodyStatement> AddQuery(RawRequestUriBuilderExpression uriBuilder)
        {
            foreach (var (nameInRequest, inputParameter, outputParameter, format) in _requestParts)
            {
                if (inputParameter is not null && inputParameter.Location == RequestLocation.Query)
                {
                    yield return AddToQuery(uriBuilder, inputParameter, outputParameter, nameInRequest, format);
                }
            }
        }

        private MethodBodyStatement AddToQuery(RawRequestUriBuilderExpression uriBuilder, InputParameter inputParameter, Parameter outputParameter, string nameInRequest, SerializationFormat format)
        {
            var value = GetValueForRequestPart(inputParameter, outputParameter);
            var convertedValue = ConvertToRequestPartType(value, outputParameter.Type);
            var escape = !inputParameter.SkipUrlEncoding;

            MethodBodyStatement addToQuery;
            if (inputParameter.Explode)
            {
                addToQuery = new ForeachStatement("param", convertedValue, out var paramVariable)
                {
                    uriBuilder.AppendQuery(nameInRequest, paramVariable, format, escape)
                };
            }
            else
            {
                addToQuery = inputParameter.ArraySerializationDelimiter is { } delimiter
                    ? uriBuilder.AppendQueryDelimited(nameInRequest, convertedValue, delimiter, escape)
                    : uriBuilder.AppendQuery(nameInRequest, convertedValue, format, escape);
            }

            if (outputParameter is { IsApiVersionParameter: true, IsOptionalInSignature: true, Initializer: { } })
            {
                return addToQuery;
            }

            return NullCheckRequestPartValue(value, outputParameter.Type, addToQuery);
        }

        protected IEnumerable<MethodBodyStatement> AddHeaders(RequestExpression request, bool addContentHeaders)
        {
            foreach (var (nameInRequest, inputParameter, outputParameter, format) in _requestParts)
            {
                if (inputParameter is null)
                {
                    if (!addContentHeaders)
                    {
                        yield return AddRequestConditionsHeaders(request, outputParameter, format);
                    }
                }
                else if (inputParameter.Location == RequestLocation.Header && addContentHeaders == ContentHeaders.Contains(nameInRequest))
                {
                    yield return AddHeader(request, nameInRequest, inputParameter, outputParameter, format);
                }
            }
        }

        private MethodBodyStatement AddRequestConditionsHeaders(RequestExpression request, Parameter outputParameter, SerializationFormat format)
        {
            if (outputParameter.Type.EqualsIgnoreNullable(KnownParameters.MatchConditionsParameter.Type) && outputParameter.Name == KnownParameters.MatchConditionsParameter.Name)
            {
                return NullCheckRequestPartValue(outputParameter, outputParameter.Type, request.Headers.Add(outputParameter));
            }

            if (outputParameter.Type.EqualsIgnoreNullable(KnownParameters.RequestConditionsParameter.Type) && outputParameter.Name == KnownParameters.RequestConditionsParameter.Name)
            {
                return NullCheckRequestPartValue(outputParameter, outputParameter.Type, request.Headers.Add(outputParameter, format));
            }

            throw new InvalidOperationException();
        }

        protected MethodBodyStatement AddHeader(RequestExpression request, string nameInRequest, InputParameter inputParameter, Parameter outputParameter, SerializationFormat format)
        {
            var headerName = inputParameter.HeaderCollectionPrefix ?? nameInRequest;
            var value = GetValueForRequestPart(inputParameter, outputParameter);
            var convertedValue = ConvertToRequestPartType(value, outputParameter.Type);

            var addToHeader = inputParameter.ArraySerializationDelimiter is {} delimiter
                ? request.Headers.AddDelimited(headerName, convertedValue, delimiter)
                : request.Headers.Add(headerName, convertedValue, format);

            return NullCheckRequestPartValue(value, outputParameter.Type, addToHeader);
        }

        protected MethodBodyStatement AddBody(RequestExpression request)
        {
            var bodyParameters = new Dictionary<InputParameter, Parameter>();
            foreach (var (_, inputParameter, outputParameter, _) in _requestParts)
            {
                if (inputParameter is null || inputParameter.Location != RequestLocation.Body)
                {
                    continue;
                }

                if (outputParameter == KnownParameters.RequestContent || outputParameter == KnownParameters.RequestContentNullable)
                {
                    return new[]
                    {
                        AddHeaders(request, true).AsStatement(),
                        Assign(request.Content, new RequestContentExpression(outputParameter))
                    };
                }

                switch (Operation.RequestBodyMediaType)
                {
                    case BodyMediaType.Multipart or BodyMediaType.Form:
                        bodyParameters.Add(inputParameter, outputParameter);
                        break;

                    case BodyMediaType.Binary:
                        return NullCheckRequestPartValue(outputParameter, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            Assign(request.Content, RequestContentExpression.Create(outputParameter))
                        });

                    case BodyMediaType.Text:
                        return NullCheckRequestPartValue(outputParameter, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            Assign(request.Content, New(typeof(StringRequestContent), outputParameter))
                        });

                    case var _ when inputParameter.Kind == InputOperationParameterKind.Flattened:
                        return AddFlattenedBody(request, outputParameter);

                    default:
                        var serialization = SerializationBuilder.Build(Operation.RequestBodyMediaType, inputParameter.Type, outputParameter.Type);
                        return NullCheckRequestPartValue(outputParameter, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            SerializeContentIntoRequest(request, serialization, outputParameter)
                        });
                }
            }

            if (bodyParameters.Any())
            {
                return Operation.RequestBodyMediaType == BodyMediaType.Multipart
                    ? AddMultipartBody(request, bodyParameters)
                    : AddFormBody(request, bodyParameters);
            }

            return new MethodBodyStatement();
        }

        private MethodBodyStatement AddMultipartBody(RequestExpression request, IReadOnlyDictionary<InputParameter, Parameter> bodyParameters)
        {
            throw new NotImplementedException();
        }

        private MethodBodyStatement AddFormBody(RequestExpression request, IReadOnlyDictionary<InputParameter, Parameter> bodyParameters)
        {
            throw new NotImplementedException();
        }

        private MethodBodyStatement AddFlattenedBody(RequestExpression request, Parameter parameter)
        {
            var content = ArgumentsMap[parameter];
            var conversion = ConversionsMap[parameter];

            return new[]
            {
                AddHeaders(request, true).AsStatement(),
                conversion,
                Assign(request.Content, content)
            };
        }

        private MethodBodyStatement SerializeContentIntoRequest(RequestExpression request, ObjectSerialization serialization, ValueExpression expression)
        {
            return serialization switch
            {
                JsonSerialization jsonSerialization => new[]
                {
                    Var("content", Utf8JsonRequestContentExpression.New(), out var content),
                    JsonSerializationMethodsBuilder.SerializeExpression(content.JsonWriter, jsonSerialization, expression),
                    Assign(request.Content, content)
                },
                XmlElementSerialization xmlSerialization => new[]
                {
                    Var("content", XmlWriterContentExpression.New(), out var content),
                    XmlSerializationMethodsBuilder.SerializeExpression(content.XmlWriter, xmlSerialization, expression),
                    Assign(request.Content, content)
                },
                _ => throw new NotImplementedException()
            };
        }

        private bool TryGetRequestPart(in ReadOnlySpan<char> key, in RequestLocation location, [MaybeNullWhen(false)] out InputParameter inputParameter, [MaybeNullWhen(false)] out Parameter outputParameter, out SerializationFormat serializationFormat)
        {
            foreach (var part in _requestParts)
            {
                if (part.InputParameter?.Location == location && part.NameInRequest.AsSpan().Equals(key, StringComparison.InvariantCulture))
                {
                    inputParameter = part.InputParameter;
                    outputParameter = part.OutputParameter;
                    serializationFormat = part.SerializationFormat;
                    return true;
                }
            }

            inputParameter = null;
            outputParameter = null;
            serializationFormat = SerializationFormat.Default;
            return false;
        }

        private ValueExpression GetValueForRequestPart(InputParameter inputParameter, Parameter outputParameter)
        {
            switch (inputParameter.Kind)
            {
                case InputOperationParameterKind.Client:
                    return _fields.GetFieldByParameter(outputParameter) ?? throw new InvalidOperationException($"Parameter {outputParameter.Name} should have matching field");

                case InputOperationParameterKind.Constant when outputParameter.DefaultValue is {} defaultValue:
                    return new ConstantExpression(defaultValue);

                case var _ when inputParameter.GroupedBy is {} groupedByParameter:
                    var groupedByParameterName = groupedByParameter.Name.ToVariableName();
                    var groupParameter = CreateMessageMethodParameters.Single(p => p.Name == groupedByParameterName);
                    var property = ((SchemaObjectType)groupParameter.Type.Implementation).GetPropertyForGroupedParameter(inputParameter.Name);

                    return new MemberReference(NullConditional(groupParameter), property.Declaration.Name);

                default:
                    return outputParameter;
            }
        }

        private static ValueExpression ConvertToRequestPartType(ValueExpression value, CSharpType fromType, bool convertOnlyExtendableEnumToString = false)
        {
            if (value is ConstantExpression)
            {
                return value;
            }

            if (fromType is { IsFrameworkType: false, Implementation: EnumType enumType } && (!convertOnlyExtendableEnumToString || enumType.IsExtensible))
            {
                return new EnumExpression(enumType, value.NullConditional(fromType)).ToSerial();
            }

            if (fromType.EqualsIgnoreNullable(typeof(ContentType)))
            {
                return new InvokeInstanceMethodExpression(value.NullableStructValue(fromType), nameof(ToString));
            }

            return value.NullableStructValue(fromType);
        }

        private static MethodBodyStatement NullCheckRequestPartValue(ValueExpression value, CSharpType type, MethodBodyStatement inner)
        {
            if (value is ConstantExpression || !type.IsNullable)
            {
                return inner;
            }

            return new IfElseStatement(IsNotNull(value), inner, null);
        }

        protected virtual bool ShouldConvenienceMethodGenerated()
        {
            return !Operation.GenerateProtocolMethod
                || !ConvenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter).SequenceEqual(ProtocolMethodParameters.Where(p => p != KnownParameters.RequestContext));
        }

        protected string CreateScopeName(string methodName) => $"{_clientName}.{methodName}";

        private Method BuildProtocolMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, _protocolAccessibility, ProtocolMethodParameters, ProtocolMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateProtocolMethodBody(async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildConvenienceMethod(string methodName, bool async)
        {
            var signature = CreateMethodSignature(methodName, _convenienceAccessibility, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateConvenienceMethodBody(methodName, async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildRestClientConvenienceMethod(string methodName, IReadOnlyList<Parameter> parameters, HttpMessageExpression invokeCreateRequestMethod, Response[] responses, CSharpType? responseType, CSharpType? headerModelType, CSharpType? resourceDataType, bool async)
        {
            var returnType = (responseType, headerModelType) switch
            {
                (not null, not null) => new CSharpType(typeof(ResponseWithHeaders<>), responseType, headerModelType),
                (not null, null) => new CSharpType(typeof(Response<>), responseType),
                (null, not null) => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                _ => new CSharpType(typeof(Response)),
            };

            var signature = new MethodSignature(methodName, _summary, _description, _convenienceAccessibility, returnType, null, parameters);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters, IsLegacy: true),
                UsingVar("message", invokeCreateRequestMethod, out var message),
                PipelineField.Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                BuildStatusCodeSwitch(message, responses, responseType, headerModelType, resourceDataType, new ClientDiagnosticsExpression(ClientDiagnosticsDeclaration), async)
            };

            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildLegacyConvenienceMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, _convenienceAccessibility, ConvenienceMethodParameters, ConvenienceMethodReturnType);

            var body = CreateLegacyConvenienceMethodBody(async);
            return new Method(signature.WithAsync(async), body);
        }

        private MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility | MethodSignatureModifiers.Virtual, returnType, null, parameters, attributes);
        }

        protected abstract MethodBodyStatement CreateProtocolMethodBody(bool async);

        protected abstract MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async);

        protected abstract MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async);

        protected MethodBodyStatement WrapInDiagnosticScope(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), _fields.ClientDiagnosticsProperty, statements);

        protected MethodBodyStatement WrapInDiagnosticScopeLegacy(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), new Reference($"_{KnownParameters.ClientDiagnostics.Name}", KnownParameters.ClientDiagnostics.Type), statements);

        protected HttpMessageExpression InvokeCreateRequestMethod()
            => InvokeCreateRequestMethod(CreateMessageMethodName, CreateMessageMethodParameters);

        protected HttpMessageExpression InvokeCreateRequestMethod(string methodName, IReadOnlyList<Parameter> parameters)
            => new(new InvokeInstanceMethodExpression(null, methodName, parameters.Select(p => new ParameterReference(p)).ToList(), null, false));

        protected ResponseExpression InvokeProtocolMethod(ValueExpression? instance, IReadOnlyList<ValueExpression> arguments, bool async)
            => new(new InvokeInstanceMethodExpression(instance, async ? $"{ProtocolMethodName}Async" : ProtocolMethodName, arguments, null, async));

        protected ValueExpression InvokeProtocolOperationHelpersConvertMethod(SerializableObjectType responseType, ResponseExpression response, string scopeName)
        {
            var arguments = new[] { response, SerializableObjectTypeExpression.FromResponseDelegate(responseType), _fields.ClientDiagnosticsProperty, Snippets.Literal(scopeName) };
            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), nameof(ProtocolOperationHelpers.Convert), arguments);
        }

        private static MethodBodyStatement BuildStatusCodeSwitch(HttpMessageExpression httpMessage, Response[] responses, CSharpType? responseType, CSharpType? headerModelType, CSharpType? resourceDataType, ClientDiagnosticsExpression? clientDiagnostics, bool async)
        {
            ValueExpression? headers = null;

            var declareHeaders = headerModelType is not null
                ? new DeclareVariableStatement(null, "headers", New(headerModelType, httpMessage.Response), out headers)
                : null;

            var requestFailedException = clientDiagnostics is not null
                ? clientDiagnostics.CreateRequestFailedException(httpMessage.Response, async)
                : New(typeof(RequestFailedException), httpMessage.Response);

            var cases = responses
                .Select(r => BuildStatusCodeSwitchCases(r.StatusCodes, responseType, r.ResponseBody, httpMessage, headers, headerModelType, async))
                .Append(new SwitchCase(null, Throw(requestFailedException)))
                .ToArray();

            var switchStatement = new SwitchStatement(httpMessage.Response.Status, cases);
            return declareHeaders is not null ? new MethodBodyStatement[] { declareHeaders, switchStatement } : switchStatement;
        }

        private static SwitchCase BuildStatusCodeSwitchCases(IReadOnlyList<StatusCodes> statusCodes, CSharpType? responseType, ResponseBody? responseBody, HttpMessageExpression httpMessage, ValueExpression? headers, CSharpType? headerModelType, bool async)
        {
            var statusCode = statusCodes[0];
            var match = statusCode.Code is {} code
                ? Int(code)
                : new FormattableStringToExpression($"int s when s >= {statusCode.Family * 100:L} && s < {statusCode.Family * 100 + 100:L}");

            var statement = BuildStatusCodeSwitchCaseStatement(responseType, responseBody, httpMessage, headers, headerModelType, async);
            return new SwitchCase(match, statement, AddScope: responseBody is not null);
        }

        private static MethodBodyStatement BuildStatusCodeSwitchCaseStatement(CSharpType? commonResponseType, ResponseBody? responseBody, HttpMessageExpression httpMessage, ValueExpression? headers, CSharpType? headerModelType, bool async)
        {
            if (responseBody is null)
            {
                return (commonResponseType, headers) switch
                {
                    (not null, not null) => Return(ResponseWithHeadersExpression.FromValue(new CastExpression(Null, commonResponseType), headers, httpMessage.Response)),
                    (not null, null) => Return(ResponseExpression.FromValue(new CastExpression(Null, commonResponseType), httpMessage.Response)),
                    (null, not null) => Return(ResponseWithHeadersExpression.FromValue(headers, httpMessage.Response)),
                    _ => Return(httpMessage.Response)
                };
            }

            ValueExpression value;
            MethodBodyStatement valueStatement = responseBody switch
            {
                ObjectResponseBody objectResponseBody => new[]
                {
                    new DeclareVariableStatement(responseBody.Type, "value", Default, out value),
                    objectResponseBody.Serialization switch
                    {
                        JsonSerialization jsonSerialization => JsonSerializationMethodsBuilder.BuildDeserializationForMethods(jsonSerialization, async, value, httpMessage.Response, responseBody.Type.Equals(typeof(BinaryData))),
                        XmlElementSerialization xmlSerialization => throw new Exception(),
                        _ => throw new NotImplementedException(objectResponseBody.Serialization.ToString())
                    }
                },
                StreamResponseBody _ => new DeclareVariableStatement(null, "value", httpMessage.ExtractResponseContent(), out value),
                ConstantResponseBody body => new DeclareVariableStatement(responseBody.Type, "value", new ConstantExpression(body.Value), out value),
                StringResponseBody _ => new[]
                {
                    Declare("streamReader", StreamReaderExpression.New(httpMessage.Response.ContentStream), out StreamReaderExpression streamReader),
                    new DeclareVariableStatement(responseBody.Type, "value", streamReader.ReadToEnd(async), out value)
                },
                _ => throw new InvalidOperationException()
            };

            var returnStatement = headers is not null
                ? Return(ResponseWithHeadersExpression.FromValue(value, headers, httpMessage.Response))
                : Return(ResponseExpression.FromValue(value, httpMessage.Response));

            return new[] { valueStatement, returnStatement };
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

        private static HashSet<string> ContentHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Allow",
            "Content-Disposition",
            "Content-Encoding",
            "Content-Language",
            "Content-Length",
            "Content-Location",
            "Content-MD5",
            "Content-Range",
            "Content-Type",
            "Expires",
            "Last-Modified",
        };
    }
}
