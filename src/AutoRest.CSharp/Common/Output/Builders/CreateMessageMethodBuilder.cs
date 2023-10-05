// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class CreateMessageMethodBuilder
    {
        private static readonly HashSet<string> ContentHeaders = new(StringComparer.OrdinalIgnoreCase)
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

        private readonly ClientFields _fields;
        private readonly IReadOnlyList<RequestPartSource> _requestParts;
        private readonly IReadOnlyList<Parameter> _parameters;
        private readonly HttpPipelineExpression _pipeline;
        private readonly RequestContextExpression? _requestContext;
        private readonly BodyMediaType _bodyMediaType;
        private readonly IReadOnlyList<RequestPart> _uriRequestParts;
        private readonly IReadOnlyList<RequestPart> _pathRequestParts;
        private readonly IReadOnlyList<RequestPart> _queryRequestParts;
        private readonly IReadOnlyList<RequestPart> _headerRequestParts;
        private readonly IReadOnlyList<RequestPart> _contentHeaderRequestParts;
        private readonly IReadOnlyList<RequestPart> _bodyRequestParts;

        public CreateMessageMethodBuilder(ClientFields fields, IReadOnlyList<RequestPartSource> requestParts, IReadOnlyList<Parameter> parameters, RequestContextExpression? requestContext, BodyMediaType bodyMediaType)
        {
            _fields = fields;
            _requestParts = requestParts;
            _parameters = parameters;
            _requestContext = requestContext;
            _bodyMediaType = bodyMediaType;
            _pipeline  = new HttpPipelineExpression(_fields.PipelineField);

            _uriRequestParts = requestParts
                .Where(p => p.InputParameter?.Location == RequestLocation.Uri)
                .Select(p => new RequestPart(p.NameInRequest, GetValueForRequestPart(p.InputParameter!, p.OutputParameter!), null, p.SerializationFormat, Escape: !p.InputParameter!.SkipUrlEncoding))
                .ToList();

            _pathRequestParts = requestParts
                .Where(p => p.InputParameter?.Location == RequestLocation.Path)
                .Select(p => new RequestPart(p.NameInRequest, GetValueForRequestPart(p.InputParameter!, p.OutputParameter!), null, p.SerializationFormat, Escape: !p.InputParameter!.SkipUrlEncoding))
                .ToList();

            _queryRequestParts = requestParts
                .Where(p => p.InputParameter?.Location == RequestLocation.Query)
                .Select(p => new RequestPart(p.NameInRequest, GetValueForRequestPart(p.InputParameter!, p.OutputParameter!), null, p.SerializationFormat, p.InputParameter!.ArraySerializationDelimiter,
                    Explode: p.InputParameter.Explode,
                    Escape: !p.InputParameter.SkipUrlEncoding,
                    SkipNullCheck: p.OutputParameter is {IsApiVersionParameter: true, IsOptionalInSignature: true, Initializer: not null}
                ))
                .ToList();

            _headerRequestParts = GetRequestPartsForHeaders(requestParts);

            _contentHeaderRequestParts = requestParts
                .Where(p => p.InputParameter?.Location == RequestLocation.Header && ContentHeaders.Contains(p.NameInRequest))
                .Select(p => new RequestPart(p.InputParameter!.HeaderCollectionPrefix ?? p.NameInRequest, GetValueForRequestPart(p.InputParameter!, p.OutputParameter!), null, p.SerializationFormat, p.InputParameter!.ArraySerializationDelimiter))
                .ToList();

            var bodyParameters = _requestParts
                .Where(p => p.InputParameter is {Location: RequestLocation.Body})
                .ToList();

            _bodyRequestParts = _bodyMediaType switch
            {
                BodyMediaType.Multipart => CreateMultipartBodyRequestParts(bodyParameters),
                BodyMediaType.Form => CreateFormBodyRequestParts(bodyParameters),
                _ when bodyParameters.Count == 1 => new[]{GetBodyRequestPart(bodyMediaType, bodyParameters[0].InputParameter!, bodyParameters[0].OutputParameter!)},
                _ => Array.Empty<BodyRequestPart>()
            };
        }

        public MethodBodyStatement CreateHttpMessage(RequestMethod requestMethod, bool bufferResponse, ResponseClassifierType? responseClassifierType, out HttpMessageExpression message, out RequestExpression request, out RawRequestUriBuilderExpression uriBuilder)
        {
            var callPipelineCreateMessage = _requestContext is not null
                ? responseClassifierType is not null
                    ? _pipeline.CreateMessage(_requestContext, new MemberExpression(null, responseClassifierType.Name))
                    : _pipeline.CreateMessage(_requestContext)
                : _pipeline.CreateMessage();

            var statements = new List<MethodBodyStatement>
            {
                Var("message", callPipelineCreateMessage, out message),
                Var("request", message.Request, out request)
            };

            if (!bufferResponse)
            {
                statements.Add(Assign(message.BufferResponse, False));
            }

            statements.Add(Assign(request.Method, new MemberExpression(typeof(RequestMethod), requestMethod.ToRequestMethodName())));
            statements.Add(Var("uri", New.RawRequestUriBuilder(), out uriBuilder));

            return statements;
        }

        public MethodBodyStatement AddUri(RawRequestUriBuilderExpression uriBuilder, string uri)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uri))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendRaw(span.ToString(), false));
                }
                else
                {
                    RequestPart? requestPart = null;
                    foreach (var part in _uriRequestParts)
                    {
                        if (part.NameInRequest.AsSpan().Equals(span, StringComparison.InvariantCulture))
                        {
                            requestPart = part;
                            break;
                        }
                    }

                    if (requestPart is not null)
                    {
                        lines.Add(requestPart.Value.Type.Equals(typeof(Uri))
                            ? uriBuilder.Reset(requestPart.Value)
                            : uriBuilder.AppendRaw(ConvertToRequestPartType(requestPart.Value, requestPart.Value.Type, convertOnlyExtendableEnumToString: true), requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{uri}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }

                }
            }
            return lines;
        }

        public MethodBodyStatement AddPath(RawRequestUriBuilderExpression uriBuilder, string path)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(path))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendPath(span.ToString(), false));
                }
                else
                {
                    RequestPart? requestPart = null;
                    foreach (var part in _pathRequestParts)
                    {
                        if (part.NameInRequest.AsSpan().Equals(span, StringComparison.InvariantCulture))
                        {
                            requestPart = part;
                            break;
                        }
                    }

                    if (requestPart is not null)
                    {
                        lines.Add(requestPart.Value is not ConstantExpression && requestPart.NameInRequest == "nextLink"
                            ? uriBuilder.AppendRawNextLink(requestPart.Value, requestPart.Escape)
                            : uriBuilder.AppendPath(ConvertToRequestPartType(requestPart.Value, requestPart.Value.Type, requestPart.SerializationFormat), requestPart.SerializationFormat, requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{path}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                }
            }
            return lines;
        }

        public MethodBodyStatement AddQuery(RawRequestUriBuilderExpression uriBuilder)
            => _queryRequestParts.Select(rp => NullCheckRequestPartValue(rp, GetAddToQueryStatement(uriBuilder, rp))).AsStatement();

        public MethodBodyStatement AddHeaders(RequestExpression request)
            => _headerRequestParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(request, rp))).AsStatement();

        public MethodBodyStatement AddContentHeaders(RequestExpression request)
            => _contentHeaderRequestParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(request, rp))).AsStatement();

        private IReadOnlyList<RequestPart> GetRequestPartsForHeaders(IEnumerable<RequestPartSource> requestPartSources)
        {
            var requestParts = new List<RequestPart>();
            foreach (var (nameInRequest, inputParameter, outputParameter, format) in requestPartSources)
            {
                if (outputParameter is null)
                {
                    if (inputParameter is {Location: RequestLocation.Header})
                    {
                        var value = GetNonParameterizedHeaderValue(nameInRequest);
                        requestParts.Add(new RequestPart(nameInRequest, value, null, format));
                    }
                }
                else if (inputParameter is null)
                {
                    if (outputParameter.Type.EqualsIgnoreNullable(KnownParameters.MatchConditionsParameter.Type) && outputParameter.Name == KnownParameters.MatchConditionsParameter.Name)
                    {
                        requestParts.Add(new RequestPart(null, outputParameter, null, SerializationFormat.Default));
                    }
                    else if (outputParameter.Type.EqualsIgnoreNullable(KnownParameters.RequestConditionsParameter.Type) && outputParameter.Name == KnownParameters.RequestConditionsParameter.Name)
                    {
                        requestParts.Add(new RequestPart(null, outputParameter, null, format));
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else if (inputParameter.Location == RequestLocation.Header && !ContentHeaders.Contains(nameInRequest))
                {
                    var value = GetValueForRequestPart(inputParameter, outputParameter);
                    requestParts.Add(new RequestPart(inputParameter.HeaderCollectionPrefix ?? nameInRequest, value, null, format, inputParameter.ArraySerializationDelimiter));
                }
            }

            return requestParts;
        }

        private static TypedValueExpression GetNonParameterizedHeaderValue(string nameInRequest)
        {
            if (nameInRequest.Equals(SpecialHandledHeaders.ClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return Literal(null);
            }
            if (nameInRequest.Equals(SpecialHandledHeaders.ReturnClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return Literal("true");
            }
            if (nameInRequest.Equals(SpecialHandledHeaders.RepeatabilityRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return GuidExpression.NewGuid();
            }
            if (nameInRequest.Equals(SpecialHandledHeaders.RepeatabilityFirstSent, StringComparison.OrdinalIgnoreCase))
            {
                return DateTimeOffsetExpression.Now;
            }

            throw new InvalidOperationException($"Unknown non-parameterized header {nameInRequest}.");
        }

        public MethodBodyStatement AddBody(RequestExpression request)
            => _bodyMediaType switch
            {
                BodyMediaType.Multipart => new[]
                {
                    AddContentHeaders(request),
                    Var("content", New.MultipartFormDataContent(), out var multipartContent),
                    _bodyRequestParts.Select(rp => NullCheckRequestPartValue(rp, GetAddMultipartBodyPartStatement(multipartContent, rp))).AsStatement(),
                    multipartContent.ApplyToRequest(request)
                },
                BodyMediaType.Form => new[]
                {
                    AddContentHeaders(request), Var("content", New.FormUrlEncodedContent(), out var urlContent),
                    _bodyRequestParts.Select(rp => NullCheckRequestPartValue(rp, urlContent.Add(rp.NameInRequest!, ConvertToString(rp.Value)))).AsStatement(),
                    Assign(request.Content, urlContent)
                },
                _ when _bodyRequestParts is [BodyRequestPart bodyRequestPart] =>
                    NullCheckRequestPartValue(bodyRequestPart, new[]
                    {
                        AddContentHeaders(request), bodyRequestPart.Conversion ?? new MethodBodyStatement(),
                        Assign(request.Content, bodyRequestPart.Content)
                    }),
                _ => new MethodBodyStatement()
            };

        private static IReadOnlyList<RequestPart> CreateMultipartBodyRequestParts(IEnumerable<RequestPartSource> bodyParameters)
        {
            var requestParts = new List<RequestPart>();
            foreach (var (_, _, parameter, _) in bodyParameters)
            {
                var bodyPartName = parameter!.Name;
                var bodyPartType = parameter.Type;

                if (bodyPartType.Equals(typeof(string)))
                {
                    requestParts.Add(new RequestPart(bodyPartName, New.StringRequestContent(parameter), null, SerializationFormat.Default));
                }
                else if (bodyPartType.IsFrameworkType && bodyPartType.FrameworkType == typeof(Stream))
                {
                    requestParts.Add(new RequestPart(bodyPartName, RequestContentExpression.Create(parameter), null, SerializationFormat.Default));
                }
                else if (TypeFactory.IsList(bodyPartType))
                {
                    requestParts.Add(new RequestPart(bodyPartName, parameter, null, SerializationFormat.Default));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return requestParts;
        }

        private IReadOnlyList<RequestPart> CreateFormBodyRequestParts(IEnumerable<RequestPartSource> bodyParameters)
        {
            var requestParts = new List<RequestPart>();
            foreach (var (nameInRequest, inputParameter, outputParameter, _) in bodyParameters)
            {
                var value = GetValueForRequestPart(inputParameter!, outputParameter!);
                requestParts.Add(new RequestPart(nameInRequest, value, null, SerializationFormat.Default));
            }

            return requestParts;
        }

        private BodyRequestPart GetBodyRequestPart(BodyMediaType bodyMediaType, InputParameter inputParameter, Parameter outputParameter)
        {
            if (outputParameter == KnownParameters.RequestContent || outputParameter == KnownParameters.RequestContentNullable)
            {
                return new BodyRequestPart(outputParameter, new RequestContentExpression(outputParameter), null, SkipNullCheck: true);
            }

            var value = GetValueForRequestPart(inputParameter, outputParameter);
            switch (bodyMediaType)
            {
                case BodyMediaType.Binary:
                    return new BodyRequestPart(value, RequestContentExpression.Create(RemoveAllNullConditional(value)), null);

                case BodyMediaType.Text:
                    return new BodyRequestPart(value, New.StringRequestContent(RemoveAllNullConditional(value)), null);

                case var _ when inputParameter.Kind == InputOperationParameterKind.Flattened:
                    return GetFlattenedBodyRequestPart(value);

                default:
                    var serialization = SerializationBuilder.Build(bodyMediaType, inputParameter.Type, outputParameter.Type);
                    var content = GetRequestContentForSerialization(serialization, RemoveAllNullConditional(value), out var conversion);

                    return new BodyRequestPart(value, content, conversion);
            }
        }

        public MethodBodyStatement AddUserAgent(HttpMessageExpression message)
            => _fields.UserAgentField is not null
                ? new InvokeInstanceMethodStatement(_fields.UserAgentField, nameof(TelemetryDetails.Apply), message)
                : new MethodBodyStatement();

        private static MethodBodyStatement GetAddToQueryStatement(RawRequestUriBuilderExpression uriBuilder, RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.Value.Type, requestPart.SerializationFormat);
            if (requestPart.NameInRequest is not {} nameInRequest)
            {
                throw new InvalidOperationException($" must have ");
            }

            if (requestPart.Explode)
            {
                return new ForeachStatement("param", new EnumerableExpression(TypeFactory.GetElementType(requestPart.Value.Type), convertedValue), out var paramVariable)
                {
                    uriBuilder.AppendQuery(requestPart.NameInRequest, paramVariable, requestPart.SerializationFormat, requestPart.Escape)
                };
            }

            return requestPart.ArraySerializationDelimiter is { } delimiter
                ? uriBuilder.AppendQueryDelimited(nameInRequest, convertedValue, delimiter, requestPart.SerializationFormat, requestPart.Escape)
                : uriBuilder.AppendQuery(nameInRequest, convertedValue, requestPart.SerializationFormat, requestPart.Escape);
        }

        private static MethodBodyStatement GetAddHeaderStatement(RequestExpression request, RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.Value.Type, requestPart.SerializationFormat);
            if (requestPart.NameInRequest is null)
            {
                return requestPart.SerializationFormat == SerializationFormat.Default
                    ? request.Headers.Add(convertedValue)
                    : request.Headers.Add(convertedValue, requestPart.SerializationFormat);
            }

            if (requestPart.NameInRequest.Equals(SpecialHandledHeaders.ClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return request.Headers.Add(SpecialHandledHeaders.ClientRequestId, request.ClientRequestId);
            }

            return requestPart.ArraySerializationDelimiter is {} delimiter
                ? request.Headers.AddDelimited(requestPart.NameInRequest, convertedValue, delimiter, requestPart.SerializationFormat)
                : request.Headers.Add(requestPart.NameInRequest, convertedValue, requestPart.SerializationFormat);
        }

        private TypedValueExpression GetValueForRequestPart(InputParameter inputParameter, Parameter outputParameter)
        {
            if (inputParameter.IsEndpoint)
            {
                return _fields.EndpointField ?? throw new InvalidOperationException("Endpoint field is missing!");
            }

            switch (inputParameter.Kind)
            {
                case InputOperationParameterKind.Client:
                    return _fields.GetFieldByParameter(outputParameter) ?? throw new InvalidOperationException($"Parameter {outputParameter.Name} should have matching field");

                case InputOperationParameterKind.Constant when outputParameter.DefaultValue is {} defaultValue:
                    return new ConstantExpression(defaultValue);

                case var _ when inputParameter.GroupedBy is {} groupedByInputParameter:
                    var groupedByParameterName = groupedByInputParameter.Name.ToVariableName();
                    var groupedByParameter = _parameters.Single(p => p.Name == groupedByParameterName);
                    var propertyName = groupedByParameter.Type.Implementation switch
                    {
                        ModelTypeProvider modelType => modelType.Fields.GetFieldByParameterName(outputParameter.Name)?.Name,
                        SchemaObjectType schemaObjectType => schemaObjectType.GetPropertyForGroupedParameter(inputParameter.Name).Declaration.Name,
                        _ => throw new InvalidOperationException($"Unexpected object type {groupedByParameter.Type.GetType()} for grouped parameter {outputParameter.Name}")
                    };

                    if (propertyName is null)
                    {
                        throw new InvalidOperationException($"Unable to find object property for grouped parameter {outputParameter.Name} in {groupedByParameter.Type.Name}");
                    }

                    return new TypedMemberExpression(NullConditional(groupedByParameter), propertyName, outputParameter.Type);

                default:
                    return outputParameter;
            }
        }

        private static MethodBodyStatement GetAddMultipartBodyPartStatement(MultipartFormDataContentExpression multipartContent, RequestPart requestPart)
        {
            var nameInRequest = requestPart.NameInRequest!;
            var value = requestPart.Value;
            if (!TypeFactory.IsList(value.Type))
            {
                return multipartContent.Add(new RequestContentExpression(value), nameInRequest, Null);
            }

            return new ForeachStatement("value", new EnumerableExpression(TypeFactory.GetElementType(value.Type), requestPart.Value), out var item)
            {
                multipartContent.Add(RequestContentExpression.Create(item), nameInRequest, Null)
            };
        }

        private BodyRequestPart GetFlattenedBodyRequestPart(TypedValueExpression value)
        {
            var properties = new Dictionary<InputModelProperty, TypedValueExpression>();
            var conversions = new List<MethodBodyStatement>();
            foreach (var (_, inputParameter, outputParameter, _) in _requestParts)
            {
                if (inputParameter is not { FlattenedBodyProperty: {} property } || outputParameter is null)
                {
                    continue;
                }

                // Special case to match behaviour of the new ChangeTrackingList<> which would be considered uninitialized when empty
                // It is not clear if that is expected behavior or just coincidence
                if (property is { IsRequired: false, Type.IsNullable: false } && TypeFactory.IsCollectionType(outputParameter.Type))
                {
                    var changeTrackingListType = TypeFactory.IsDictionary(outputParameter.Type)
                        ? new CSharpType(typeof(ChangeTrackingDictionary<,>), outputParameter.Type.Arguments)
                        : new CSharpType(typeof(ChangeTrackingList<>), outputParameter.Type.Arguments);

                    var enumerable = new EnumerableExpression(TypeFactory.GetElementType(outputParameter.Type), outputParameter);
                    conversions.Add(new IfStatement(Or(Equal(enumerable, Null), Not(enumerable.Any())))
                    {
                        new AssignValueStatement(enumerable, New.Instance(changeTrackingListType))
                    });
                }

                properties[property] = GetValueForRequestPart(inputParameter, outputParameter);
            }

            var serializations = SerializationBuilder.GetPropertiesForSerializationOnly(properties);
            conversions.Add(new[]
            {
                Var("content", New.Utf8JsonRequestContent(), out var content),
                content.JsonWriter.WriteStartObject(),
                JsonSerializationMethodsBuilder.WriteProperties(content.JsonWriter, serializations).AsStatement(),
                content.JsonWriter.WriteEndObject()
            });

            return new BodyRequestPart(value, content, conversions, SkipNullCheck: true);
        }

        private static RequestContentExpression GetRequestContentForSerialization(ObjectSerialization serialization, TypedValueExpression expression, out MethodBodyStatement conversion)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    conversion = new[]
                    {
                        Var("content", New.Utf8JsonRequestContent(), out var utf8JsonContent),
                        JsonSerializationMethodsBuilder.SerializeExpression(utf8JsonContent.JsonWriter, jsonSerialization, expression),
                    };
                    return utf8JsonContent;

                case XmlElementSerialization xmlSerialization:
                    conversion = new[]
                    {
                        Var("content", New.XmlWriterContent(), out var xmlWriterContent),
                        XmlSerializationMethodsBuilder.SerializeExpression(xmlWriterContent.XmlWriter, xmlSerialization, expression),
                    };
                    return xmlWriterContent;

                default:
                    throw new NotImplementedException();
            }
        }

        private static StringExpression ConvertToString(TypedValueExpression value)
        {
            if (value.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                return new EnumExpression(enumType, value.NullableStructValue(value.Type)).ToSerial();
            }

            return value.Type.EqualsIgnoreNullable(typeof(string)) ? new(value) : value.NullableStructValue(value.Type).InvokeToString();
        }

        private static MethodBodyStatement NullCheckRequestPartValue(RequestPart requestPart, MethodBodyStatement addRequestPartStatement)
        {
            if (requestPart.SkipNullCheck)
            {
                return addRequestPartStatement;
            }

            var value = requestPart.Value;
            var type = requestPart.Value.Type;
            if (value is ConstantExpression || !type.IsNullable)
            {
                return addRequestPartStatement;
            }

            return TypeFactory.IsCollectionType(type)
                ? new IfElseStatement(And(NotEqual(value, Null), InvokeOptional.IsCollectionDefined(value)), addRequestPartStatement, null)
                : new IfElseStatement(NotEqual(value, Null), addRequestPartStatement, null);
        }

        private static ValueExpression ConvertToRequestPartType(ValueExpression value, CSharpType fromType, SerializationFormat format = SerializationFormat.Default, bool convertOnlyExtendableEnumToString = false)
        {
            if (fromType is { IsFrameworkType: false, Implementation: EnumType enumType } && (!convertOnlyExtendableEnumToString || enumType.IsExtensible))
            {
                return new EnumExpression(enumType, value.NullableStructValue(fromType)).ToSerial();
            }

            if (value is ConstantExpression)
            {
                return value;
            }

            if (fromType.EqualsIgnoreNullable(typeof(ContentType)))
            {
                return value.NullableStructValue(fromType).InvokeToString();
            }

            if (fromType.EqualsIgnoreNullable(typeof(BinaryData)) && format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
            {
                return new BinaryDataExpression(value).ToArray();
            }

            return value.NullableStructValue(fromType);
        }
    }
}
