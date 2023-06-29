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
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class OperationMethodsBuilderBase
    {
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly IReadOnlyList<RequestPartSource> _requestParts;

        private readonly string? _summary;
        private readonly string? _description;
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly StatusCodeSwitchBuilder _statusCodeSwitchBuilder;

        public InputOperation Operation { get; }

        protected ValueExpression ClientDiagnosticsProperty { get; }
        protected HttpPipelineExpression PipelineField { get; }
        protected ValueExpression? RestClient { get; }

        protected MethodSignatureModifiers ConvenienceModifiers { get; }

        protected string CreateMessageMethodName { get; }
        protected string ProtocolMethodName { get; }

        protected CSharpType? ResponseType { get; }
        protected CSharpType ProtocolMethodReturnType { get; }
        protected CSharpType RestConvenienceMethodReturnType { get; }
        protected CSharpType ConvenienceMethodReturnType { get; }

        protected IReadOnlyList<Parameter> CreateMessageMethodParameters { get; }
        protected IReadOnlyList<Parameter> ProtocolMethodParameters { get; }
        protected IReadOnlyList<Parameter> ConvenienceMethodParameters { get; }
        protected IReadOnlyDictionary<Parameter, ValueExpression> ArgumentsMap { get; }
        protected IReadOnlyDictionary<Parameter, MethodBodyStatement> ConversionsMap { get; }
        protected RequestContextExpression? CreateMessageRequestContext { get; }

        protected OperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args, ClientMethodParameters clientMethodParameters)
        {
            _fields = args.Fields;
            _clientName = args.ClientName;
            _statusCodeSwitchBuilder = args.StatusCodeSwitchBuilder;

            Operation = args.Operation;
            ClientDiagnosticsProperty = _fields.ClientDiagnosticsProperty;
            PipelineField = new HttpPipelineExpression(_fields.PipelineField.Declaration);
            RestClient = args.RestClientReference;

            ProtocolMethodName = Operation.Name.ToCleanName();
            CreateMessageMethodName = $"Create{ProtocolMethodName}Request";

            ResponseType = _statusCodeSwitchBuilder.ResponseType;
            ProtocolMethodReturnType = _statusCodeSwitchBuilder.ProtocolReturnType;
            RestConvenienceMethodReturnType = _statusCodeSwitchBuilder.RestClientConvenienceReturnType;
            ConvenienceMethodReturnType = _statusCodeSwitchBuilder.ClientConvenienceReturnType;

            CreateMessageMethodParameters = clientMethodParameters.CreateMessage;
            ProtocolMethodParameters = clientMethodParameters.Protocol;
            ConvenienceMethodParameters = clientMethodParameters.Convenience;
            CreateMessageRequestContext = clientMethodParameters.HasRequestContextInCreateMessage
                    ? new RequestContextExpression(KnownParameters.RequestContext)
                    : null;

            _requestParts = clientMethodParameters.RequestParts;
            ArgumentsMap = clientMethodParameters.Arguments;
            ConversionsMap = clientMethodParameters.Conversions;
            _summary = Operation.Summary != null ? BuilderHelpers.EscapeXmlDocDescription(Operation.Summary) : null;
            _description = BuilderHelpers.EscapeXmlDocDescription(Operation.Description);
            _protocolAccessibility = Operation.GenerateProtocolMethod ? GetAccessibility(Operation.Accessibility) : MethodSignatureModifiers.Internal;
            ConvenienceModifiers = GetAccessibility(Operation.Accessibility) | MethodSignatureModifiers.Virtual;
        }

        public LowLevelClientMethod BuildDpg()
        {
            var responseClassifier = _statusCodeSwitchBuilder.ResponseClassifier;
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

            var order = Operation.LongRunning is not null ? 2 : Operation.Paging is not null ? 1 : 0;
            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;

            return new LowLevelClientMethod(createRequestMethods, protocolMethods, convenienceMethods, responseClassifier, order, Operation, Operation.ExternalDocsUrl, requestBodyType, responseBodyType);
        }

        public virtual LegacyMethods BuildLegacy()
        {
            var createRequestMethod = BuildCreateRequestMethod(_statusCodeSwitchBuilder.ResponseClassifier);

            var restClientMethods = new[]
            {
                BuildRestClientConvenienceMethod(ProtocolMethodName, ConvenienceMethodParameters, InvokeCreateRequestMethod(null), _statusCodeSwitchBuilder, true),
                BuildRestClientConvenienceMethod(ProtocolMethodName, ConvenienceMethodParameters, InvokeCreateRequestMethod(null), _statusCodeSwitchBuilder, false)
            };

            var convenienceMethods = Configuration.PublicClients && !Configuration.AzureArm ? new[]
            {
                BuildLegacyConvenienceMethod(true),
                BuildLegacyConvenienceMethod(false)
            } : Array.Empty<Method>();

            return new LegacyMethods
            (
                createRequestMethod,
                null,
                restClientMethods,
                Array.Empty<Method>(),
                convenienceMethods,

                this is LroOperationMethodsBuilder ? 2 : 0,
                Operation,
                ResponseType
            );
        }

        protected abstract IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType);

        protected Method BuildCreateRequestMethod(ResponseClassifierType responseClassifierType)
        {
            var signature = new MethodSignature(CreateMessageMethodName, _summary, _description, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, CreateMessageMethodParameters);
            return new Method(signature, BuildCreateRequestMethodBody(responseClassifierType).AsStatement());
        }

        private IEnumerable<MethodBodyStatement> BuildCreateRequestMethodBody(ResponseClassifierType responseClassifierType)
        {
            yield return CreateHttpMessage(responseClassifierType, Operation.HttpMethod, out var message, out var request, out var uriBuilder);
            yield return AddUri(uriBuilder, Operation.Uri);
            yield return AddPath(uriBuilder, Operation.Path);
            yield return AddQuery(uriBuilder).AsStatement();

            yield return Assign(request.Uri, uriBuilder);

            yield return AddHeaders(request, false).AsStatement();
            yield return AddBody(request);
            yield return AddUserAgent(message);
            yield return Return(message);
        }

        protected List<MethodBodyStatement> CreateHttpMessage(ResponseClassifierType? responseClassifierType, RequestMethod requestMethod, out HttpMessageExpression message, out RequestExpression request, out RawRequestUriBuilderExpression uriBuilder)
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

            statements.Add(Assign(request.Method, new MemberReference(typeof(RequestMethod), requestMethod.ToRequestMethodName())));
            statements.Add(Var("uri", New.RawRequestUriBuilder(), out uriBuilder));

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
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(value), outputParameter.Type);
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

        protected MethodBodyStatement AddUserAgent(HttpMessageExpression message)
            => _fields.UserAgentField is { } userAgent
                ? new InvokeInstanceMethodStatement(userAgent, nameof(TelemetryDetails.Apply), message)
                : new MethodBodyStatement();

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
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(value), outputParameter.Type);

            var addToHeader = inputParameter.ArraySerializationDelimiter is {} delimiter
                ? request.Headers.AddDelimited(headerName, convertedValue, delimiter)
                : request.Headers.Add(headerName, convertedValue, format);

            return NullCheckRequestPartValue(value, outputParameter.Type, addToHeader);
        }

        protected MethodBodyStatement AddBody(RequestExpression request)
        {
            var bodyParameters = new Dictionary<string, Parameter>();
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
                        bodyParameters.Add(inputParameter.NameInRequest, outputParameter);
                        break;

                    case BodyMediaType.Binary:
                        var binaryValue = GetValueForRequestPart(inputParameter, outputParameter);
                        return NullCheckRequestPartValue(binaryValue, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            Assign(request.Content, RequestContentExpression.Create(RemoveAllNullConditional(binaryValue)))
                        });

                    case BodyMediaType.Text:
                        var stringValue = GetValueForRequestPart(inputParameter, outputParameter);
                        return NullCheckRequestPartValue(stringValue, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            Assign(request.Content, New.StringRequestContent(RemoveAllNullConditional(stringValue)))
                        });

                    case var _ when inputParameter.Kind == InputOperationParameterKind.Flattened:
                        return AddFlattenedBody(request);

                    default:
                        var value = GetValueForRequestPart(inputParameter, outputParameter);
                        var serialization = SerializationBuilder.Build(Operation.RequestBodyMediaType, inputParameter.Type, outputParameter.Type);
                        return NullCheckRequestPartValue(value, outputParameter.Type, new[]
                        {
                            AddHeaders(request, true).AsStatement(),
                            SerializeContentIntoRequest(request, serialization, RemoveAllNullConditional(value))
                        });
                }
            }

            if (bodyParameters.Any())
            {
                return Operation.RequestBodyMediaType == BodyMediaType.Multipart
                    ? AddMultipartBody(request, bodyParameters.Values).AsStatement()
                    : AddFormBody(request, bodyParameters).AsStatement();
            }

            return new MethodBodyStatement();
        }

        private IEnumerable<MethodBodyStatement> AddMultipartBody(RequestExpression request, IEnumerable<Parameter> bodyParameters)
        {
            yield return AddHeaders(request, true).AsStatement();
            yield return Var("content", New.MultipartFormDataContent(), out var multipartContent);

            foreach (var parameter in bodyParameters)
            {
                var bodyPartName = parameter.Name;
                var bodyPartType = parameter.Type;

                if (bodyPartType.Equals(typeof(string)))
                {
                    yield return NullCheckRequestPartValue(parameter, bodyPartType, multipartContent.Add(New.StringRequestContent(parameter), bodyPartName, Null));
                }
                else if (bodyPartType.IsFrameworkType && bodyPartType.FrameworkType == typeof(Stream))
                {
                    yield return NullCheckRequestPartValue(parameter, bodyPartType, multipartContent.Add(RequestContentExpression.Create(parameter), bodyPartName, Null));
                }
                else if (TypeFactory.IsList(bodyPartType))
                {
                    yield return new ForeachStatement("value", parameter, out var item)
                    {
                        multipartContent.Add(RequestContentExpression.Create(item), bodyPartName, Null)
                    };
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            yield return multipartContent.ApplyToRequest(request);
        }

        private IEnumerable<MethodBodyStatement> AddFormBody(RequestExpression request, IReadOnlyDictionary<string, Parameter> bodyParameters)
        {
            yield return AddHeaders(request, true).AsStatement();
            yield return Var("content", New.FormUrlEncodedContent(), out var urlContent);

            foreach (var (nameInRequest, parameter) in bodyParameters)
            {
                var type = parameter.Type;
                var value = new ParameterReference(parameter);

                yield return NullCheckRequestPartValue(value, type, urlContent.Add(nameInRequest, ConvertToString(value, type)));
            }

            yield return Assign(request.Content, urlContent);
        }

        private MethodBodyStatement AddFlattenedBody(RequestExpression request)
        {
            var conversion = new List<MethodBodyStatement>
            {
                Var("content", New.Utf8JsonRequestContent(), out var content),
                content.JsonWriter.WriteStartObject()
            };

            foreach (var (_, inputParameter, outputParameter, _) in _requestParts)
            {
                if (inputParameter is { FlattenedBodyProperty: { } property })
                {
                    conversion.Add(CreatePropertySerializationStatement(property, content.JsonWriter, inputParameter, outputParameter));
                }
            }

            conversion.Add(content.JsonWriter.WriteEndObject());

            return new[]
            {
                AddHeaders(request, true).AsStatement(),
                conversion,
                Assign(request.Content, content)
            };
        }

        private MethodBodyStatement CreatePropertySerializationStatement(InputModelProperty property, Utf8JsonWriterExpression jsonWriter, InputParameter inputParameter, Parameter outputParameter)
        {
            var value = GetValueForRequestPart(inputParameter, outputParameter);
            var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, outputParameter.Type, false);

            var propertyName = property.SerializedName ?? property.Name;
            var writePropertyStatement = new[]
            {
                jsonWriter.WritePropertyName(propertyName),
                JsonSerializationMethodsBuilder.SerializeExpression(jsonWriter, valueSerialization, value)
            };

            var writeNullStatement = property.IsRequired ? jsonWriter.WriteNull(propertyName) : null;
            if (outputParameter.Type.IsNullable)
            {
                return new IfElseStatement(NotEqual(value, Null), writePropertyStatement, writeNullStatement);
            }

            return writePropertyStatement;
        }

        private static MethodBodyStatement SerializeContentIntoRequest(RequestExpression request, ObjectSerialization serialization, ValueExpression expression)
            => serialization switch
            {
                JsonSerialization jsonSerialization => new[]
                {
                    Var("content", New.Utf8JsonRequestContent(), out var content),
                    JsonSerializationMethodsBuilder.SerializeExpression(content.JsonWriter, jsonSerialization, expression),
                    Assign(request.Content, content)
                },
                XmlElementSerialization xmlSerialization => new[]
                {
                    Var("content", New.XmlWriterContent(), out var content),
                    XmlSerializationMethodsBuilder.SerializeExpression(content.XmlWriter, xmlSerialization, expression),
                    Assign(request.Content, content)
                },
                _ => throw new NotImplementedException()
            };

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
                return new EnumExpression(enumType, value.NullableStructValue(fromType)).ToSerial();
            }

            if (fromType.EqualsIgnoreNullable(typeof(ContentType)))
            {
                return value.NullableStructValue(fromType).InvokeToString();
            }

            return value.NullableStructValue(fromType);
        }

        private static StringExpression ConvertToString(ValueExpression value, CSharpType fromType)
        {
            if (fromType is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                return new EnumExpression(enumType, value.NullableStructValue(fromType)).ToSerial();
            }

            return fromType.EqualsIgnoreNullable(typeof(string))
                ? new(value)
                : value.NullableStructValue(fromType).InvokeToString();
        }

        private static MethodBodyStatement NullCheckRequestPartValue(ValueExpression value, CSharpType type, MethodBodyStatement inner)
        {
            if (value is ConstantExpression || !type.IsNullable)
            {
                return inner;
            }

            return type.IsCollectionType()
                ? new IfElseStatement(And(NotEqual(value, Null), InvokeOptional.IsCollectionDefined(value)), inner, null)
                : new IfElseStatement(NotEqual(value, Null), inner, null);
        }

        protected virtual bool ShouldConvenienceMethodGenerated()
        {
            return !Operation.GenerateProtocolMethod
                || !ConvenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter).SequenceEqual(ProtocolMethodParameters.Where(p => p != KnownParameters.RequestContext));
        }

        protected string CreateScopeName(string methodName) => $"{_clientName}.{methodName}";

        private Method BuildProtocolMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, _protocolAccessibility | MethodSignatureModifiers.Virtual, ProtocolMethodParameters, ProtocolMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateProtocolMethodBody(async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildConvenienceMethod(string methodName, bool async)
        {
            var signature = CreateMethodSignature(methodName, ConvenienceModifiers, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateConvenienceMethodBody(methodName, async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        protected Method BuildRestClientConvenienceMethod(string methodName, IReadOnlyList<Parameter> parameters, HttpMessageExpression invokeCreateRequestMethod, StatusCodeSwitchBuilder statusCodeSwitchBuilder, bool async)
        {
            var signature = CreateMethodSignature(methodName, MethodSignatureModifiers.Public, parameters, statusCodeSwitchBuilder.RestClientConvenienceReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters, IsLegacy: !Configuration.AzureArm),
                UsingVar("message", invokeCreateRequestMethod, out var message),
                PipelineField.Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                statusCodeSwitchBuilder.Build(message, async)
            };

            return new Method(signature.WithAsync(async), body);
        }

        protected abstract Method BuildLegacyConvenienceMethod(bool async);

        protected MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility, returnType, null, parameters, attributes);
        }

        protected abstract MethodBodyStatement CreateProtocolMethodBody(bool async);

        protected abstract MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async);

        protected MethodBodyStatement WrapInDiagnosticScope(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), _fields.ClientDiagnosticsProperty, statements);

        protected MethodBodyStatement WrapInDiagnosticScopeLegacy(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), new Reference($"_{KnownParameters.ClientDiagnostics.Name}", KnownParameters.ClientDiagnostics.Type), statements);

        protected HttpMessageExpression InvokeCreateRequestMethod(ValueExpression? instance)
            => InvokeCreateRequestMethod(instance, CreateMessageMethodName, CreateMessageMethodParameters);

        protected HttpMessageExpression InvokeCreateRequestMethod(ValueExpression? instance, string methodName, IReadOnlyList<Parameter> parameters)
            => new(new InvokeInstanceMethodExpression(instance, methodName, parameters.Select(p => new ParameterReference(p)).ToList(), null, false));

        protected ResponseExpression InvokeProtocolMethod(ValueExpression? instance, IReadOnlyList<ValueExpression> arguments, bool async)
            => new(new InvokeInstanceMethodExpression(instance, async ? $"{ProtocolMethodName}Async" : ProtocolMethodName, arguments, null, async));

        protected ValueExpression InvokeProtocolOperationHelpersConvertMethod(SerializableObjectType responseType, ResponseExpression response, string scopeName)
        {
            var arguments = new[] { response, SerializableObjectTypeExpression.FromResponseDelegate(responseType), _fields.ClientDiagnosticsProperty, Literal(scopeName) };
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
