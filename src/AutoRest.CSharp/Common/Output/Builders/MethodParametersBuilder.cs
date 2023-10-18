// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class MethodParametersBuilder
    {
        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private static readonly HashSet<string> IgnoredRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id",
            "tracestate",
            "traceparent"
        };

        private readonly InputOperation _operation;
        private readonly ClientFields? _fields;
        private readonly TypeFactory _typeFactory;
        private readonly RequestPartBuilder _requestPartsBuilder;
        private readonly IReadOnlyList<InputParameter> _unsortedParameters;
        private readonly List<Parameter> _createMessageParameters;
        private readonly List<Parameter> _protocolParameters;
        private readonly List<Parameter> _convenienceParameters;
        private readonly Dictionary<Parameter, ValueExpression> _arguments;
        private readonly Dictionary<Parameter, MethodBodyStatement> _conversions;
        private readonly bool _keepClientDefaultValue;

        public MethodParametersBuilder(InputOperation operation, ClientFields? fields, TypeFactory typeFactory)
        {
            _operation = operation;
            _fields = fields;
            _typeFactory = typeFactory;
            _createMessageParameters = new List<Parameter>();
            _protocolParameters = new List<Parameter>();
            _convenienceParameters = new List<Parameter>();
            _arguments = new Dictionary<Parameter, ValueExpression>();
            _conversions = new Dictionary<Parameter, MethodBodyStatement>();
            _keepClientDefaultValue = Configuration.MethodsToKeepClientDefaultValue.Contains(operation.Name);
            _unsortedParameters = operation.Parameters
                .Where(rp => rp.Location != RequestLocation.Header || !IgnoredRequestHeader.Contains(rp.NameInRequest))
                .ToArray();

            _requestPartsBuilder = new RequestPartBuilder();
        }

        public RestClientMethodParameters BuildParameters(bool buildParametersForProtocolMethods)
        {
            if (!buildParametersForProtocolMethods)
            {
                return BuildParametersLegacy(Configuration.AzureArm ? GetSortedParameters() : GetLegacySortedParameters());
            }

            var sortedParameters = GetSortedParameters();

            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            InputParameter? requestConditionRequestParameter = null;

            AddWaitForCompletion();
            foreach (var inputParameter in sortedParameters)
            {
                switch (inputParameter)
                {
                    case { Location: RequestLocation.Header } when !Configuration.AzureArm && !Configuration.Generation1ConvenienceClient && ConditionRequestHeader.TryGetValue(inputParameter.NameInRequest, out var header):
                        if (inputParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= inputParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                                ? SerializationBuilder.GetSerializationFormat(inputParameter.Type)
                                : requestConditionSerializationFormat;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true }:
                        AddContentTypeRequestParameter(inputParameter);
                        break;
                    case { Location: RequestLocation.Header } when SpecialHandledHeaders.IsNonParameterizedHeader(inputParameter.NameInRequest):
                        _requestPartsBuilder.AddNonParameterizedHeaderPart(inputParameter);
                        break;
                    default:
                        AddReferenceAndParameter(inputParameter);
                        break;
                }
            }

            AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter, requestConditionSerializationFormat);
            AddRequestContext();

            return new RestClientMethodParameters
            (
                _requestPartsBuilder.BuildParts(),
                _createMessageParameters,
                _protocolParameters,
                _convenienceParameters.OrderByDescending(p => p is { IsOptionalInSignature: false }).ToList(),
                _arguments,
                _conversions,
                HasAmbiguityBetweenProtocolAndConvenience()
            );
        }

        private RestClientMethodParameters BuildParametersLegacy(IEnumerable<InputParameter> sortedParameters)
        {
            var parameters = new Dictionary<InputParameter, Parameter>();
            foreach (var inputParameter in sortedParameters)
            {
                if (SpecialHandledHeaders.IsNonParameterizedHeader(inputParameter.NameInRequest))
                {
                    _requestPartsBuilder.AddNonParameterizedHeaderPart(inputParameter);
                }
                else
                {
                    var parameter = Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(inputParameter.Type), _keepClientDefaultValue, _typeFactory);
                    // Grouped and flattened parameters shouldn't be added to methods
                    if (inputParameter.Kind == InputOperationParameterKind.Method)
                    {
                        AddCreateMessageParameter(parameter);
                        _protocolParameters.Add(parameter);
                    }

                    parameters.Add(inputParameter, parameter);
                }
            }

            _convenienceParameters.AddRange(_protocolParameters);
            _convenienceParameters.Add(KnownParameters.CancellationTokenParameter);

            // for legacy logic, adding request parts unsorted
            foreach (var inputParameter in _unsortedParameters)
            {
                if (!parameters.TryGetValue(inputParameter, out var outputParameter))
                {
                    continue;
                }

                var value = GetValueForProtocolArgument(inputParameter, outputParameter);
                switch (inputParameter.Location)
                {
                    case RequestLocation.Uri:
                        _requestPartsBuilder.AddUriPart(inputParameter, value);
                        break;
                    case RequestLocation.Path:
                        _requestPartsBuilder.AddPathPart(inputParameter, value);
                        break;
                    case RequestLocation.Query:
                        var skipNullCheck = outputParameter is { IsApiVersionParameter: true, IsOptionalInSignature: true, Initializer: not null };
                        _requestPartsBuilder.AddQueryPart(inputParameter, value, skipNullCheck);
                        break;
                    case RequestLocation.Header:
                        _requestPartsBuilder.AddHeaderPart(inputParameter, value, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
                        break;
                    case RequestLocation.Body when _operation.RequestBodyMediaType is BodyMediaType.Multipart:
                        _requestPartsBuilder.AddBodyPart(inputParameter, GetMultipartBodyValue(value));
                        break;
                    case RequestLocation.Body when _operation.RequestBodyMediaType is BodyMediaType.Form:
                        _requestPartsBuilder.AddBodyPart(inputParameter, value);
                        break;
                    case RequestLocation.Body:
                        CreateConversionToRequestContent(inputParameter, value, parameters, out var content, out var conversions);
                        _requestPartsBuilder.AddBodyPart(value, conversions, content, inputParameter.Kind != InputOperationParameterKind.Method);
                        break;
                }
            }

            return new RestClientMethodParameters
            (
                _requestPartsBuilder.BuildParts(),
                _createMessageParameters,
                _protocolParameters,
                _convenienceParameters,
                _arguments,
                _conversions,
                false
            );
        }

        private void AddWaitForCompletion()
        {
            if (_operation.LongRunning != null)
            {
                _convenienceParameters.Add(KnownParameters.WaitForCompletion);
                _protocolParameters.Add(KnownParameters.WaitForCompletion);
            }
        }

        private void AddRequestConditionHeaders(RequestConditionHeaders conditionHeaderFlag, InputParameter? requestConditionRequestParameter, SerializationFormat serializationFormat)
        {
            if (conditionHeaderFlag == RequestConditionHeaders.None || requestConditionRequestParameter == null)
            {
                return;
            }

            Parameter parameter;
            switch (conditionHeaderFlag)
            {
                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    parameter = KnownParameters.MatchConditionsParameter;
                    _requestPartsBuilder.AddMatchConditionsHeaderPart(parameter, serializationFormat);
                    break;

                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    var type = new CSharpType(typeof(ETag), requestConditionRequestParameter.Type.IsNullable);
                    parameter = Parameter.FromInputParameter(requestConditionRequestParameter, type, _keepClientDefaultValue, _typeFactory);
                    serializationFormat = SerializationBuilder.GetSerializationFormat(requestConditionRequestParameter.Type);
                    _requestPartsBuilder.AddHeaderPart(requestConditionRequestParameter, parameter, serializationFormat);
                    break;

                default:
                    parameter = KnownParameters.RequestConditionsParameter with { Validation = new Validation(ValidationType.AssertNull, conditionHeaderFlag) };
                    _requestPartsBuilder.AddRequestConditionsHeaderPart(parameter, serializationFormat);
                    break;
            }

            AddCreateMessageParameter(parameter);
            _protocolParameters.Add(parameter);
            _convenienceParameters.Add(parameter);
        }

        private void AddRequestContext()
        {
            AddCreateMessageParameter(KnownParameters.RequestContext);
            _protocolParameters.Add(KnownParameters.RequestContext);
            _convenienceParameters.Add(KnownParameters.CancellationTokenParameter);

            if (_operation.Paging is not null || Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
            {
                _conversions[KnownParameters.RequestContext] = Declare(IfCancellationTokenCanBeCanceled(new CancellationTokenExpression(KnownParameters.CancellationTokenParameter)), out var requestContext);
                _arguments[KnownParameters.RequestContext] = requestContext;
            }
            else
            {
                _conversions[KnownParameters.RequestContext] = Declare(RequestContextExpression.FromCancellationToken(), out var requestContext);
                _arguments[KnownParameters.RequestContext] = requestContext;
            }
        }

        private bool HasAmbiguityBetweenProtocolAndConvenience()
        {
            for (int i = 0; i < Math.Min(_protocolParameters.Count, _convenienceParameters.Count); i++)
            {
                var protocol = _protocolParameters[i];
                var convenience = _convenienceParameters[i];

                if (protocol.IsOptionalInSignature && convenience.IsOptionalInSignature)
                {
                    // If we reached this point, it means that all previous parameters were ambiguous,
                    // which is enough to call method with minimal possible signature
                    return true;
                }

                // Identical types are obviously ambiguous
                if (protocol.Type.Equals(convenience.Type))
                {
                    continue;
                }

                if (protocol == KnownParameters.RequestContent || protocol == KnownParameters.RequestContentNullable)
                {
                    return false;
                }

                // Value types have clear resolution between them with exception of numbers and enums
                if (protocol.Type.IsValueType && convenience.Type.IsValueType)
                {
                    // Implicit numeric conversions: int -> long -> float -> double
                    // Call can be ambiguous when nullable numeric type can be implicitly cast to non-nullable numeric type,
                    // e.g.: M1(int? i) vs M1(long j) is ambiguous for call M1(0);
                    // Call can also be ambiguous when one the parameter types is Enum
                    // e.g.: M1(EnumType? e) vs M1(long j) is ambiguous for call M1(0);
                    // For simplicity, we assume that if one parameter type is nullable, and the other one isn't, parameters are ambiguous
                    if (!(protocol.Type.IsNullable ^ convenience.Type.IsNullable))
                    {
                        return false;
                    }
                }
                else if (protocol.Type.IsValueType ^ convenience.Type.IsValueType)
                {
                    var valueType = protocol.Type.IsValueType ? protocol.Type : convenience.Type;
                    var referenceType = protocol.Type.IsValueType ? convenience.Type : protocol.Type;
                    if (!valueType.IsNullable || !referenceType.EqualsIgnoreNullable(typeof(object)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void AddReferenceAndParameter(InputParameter inputParameter)
        {
            Parameter protocolMethodParameter;
            if (inputParameter.Location == RequestLocation.Body)
            {
                protocolMethodParameter = inputParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable;
                _requestPartsBuilder.AddBodyPart(protocolMethodParameter, null, new RequestContentExpression(protocolMethodParameter), !Configuration.Generation1ConvenienceClient);
            }
            else
            {
                protocolMethodParameter = Parameter.FromInputParameter(inputParameter, ChangeTypeForProtocolMethod(inputParameter.Type), _keepClientDefaultValue, _typeFactory);

                var value = GetValueForProtocolArgument(inputParameter with {GroupedBy = null}, protocolMethodParameter);
                switch (inputParameter.Location)
                {
                    case RequestLocation.Uri:
                        _requestPartsBuilder.AddUriPart(inputParameter, value);
                        break;
                    case RequestLocation.Path:
                        _requestPartsBuilder.AddPathPart(inputParameter, value);
                        break;
                    case RequestLocation.Query:
                        var skipNullCheck = protocolMethodParameter is { IsApiVersionParameter: true, IsOptionalInSignature: true, Initializer: not null };
                        _requestPartsBuilder.AddQueryPart(inputParameter, value, skipNullCheck);
                        break;
                    case RequestLocation.Header:
                        _requestPartsBuilder.AddHeaderPart(inputParameter, value, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
                        break;
                }
            }

            AddParameter(inputParameter, protocolMethodParameter);
        }

        private void AddParameter(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            if (inputParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                // BUG: For constant bodies and bodies assigned from client, DPG still creates RequestContent parameter. Most likely, this is incorrect.
                if (inputParameter.Location != RequestLocation.Body || Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
                {
                    return;
                }
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                AddCreateMessageParameter(protocolMethodParameter);
                _protocolParameters.Add(protocolMethodParameter);
                _arguments[protocolMethodParameter] = GetValueForProtocolArgument(inputParameter, protocolMethodParameter);
                return;
            }

            if (inputParameter.Location == RequestLocation.None)
            {
                _convenienceParameters.Add(Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(inputParameter.Type), _keepClientDefaultValue, _typeFactory));
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Spread)
            {
                CreateSpreadParameters(inputParameter, protocolMethodParameter);
                return;
            }

            var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(inputParameter.Type), _keepClientDefaultValue, _typeFactory);

            AddCreateMessageParameter(protocolMethodParameter);
            _protocolParameters.Add(protocolMethodParameter);
            _convenienceParameters.Add(convenienceMethodParameter);

            if (protocolMethodParameter.Equals(convenienceMethodParameter) || protocolMethodParameter.Type.Equals(convenienceMethodParameter.Type))
            {
                _arguments[protocolMethodParameter] = convenienceMethodParameter;
                return;
            }

            if (protocolMethodParameter.Type.EqualsIgnoreNullable(typeof(string)) && convenienceMethodParameter.Type is {IsFrameworkType: false, Implementation: EnumType enumType})
            {
                _arguments[protocolMethodParameter] = new EnumExpression(enumType, NullConditional(convenienceMethodParameter)).ToSerial();
                return;
            }

            if (protocolMethodParameter.Type.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                CreateConversionToRequestContent(inputParameter, NullConditional(convenienceMethodParameter), new Dictionary<InputParameter, Parameter>(), out var argument, out var conversions);
                if (conversions is not null)
                {
                    _arguments[protocolMethodParameter] = argument;
                    _conversions[protocolMethodParameter] = conversions;
                }
                else
                {
                    RequestContentExpression content;
                    // Don't dispose content for pageables
                    _conversions[protocolMethodParameter] = _operation.Paging is not null ? Declare("content", argument, out content) : UsingDeclare("content", argument, out content);
                    _arguments[protocolMethodParameter] = content;
                }

                return;
            }

            throw new InvalidOperationException($"Unexpected conversion from '{convenienceMethodParameter.Name}' parameter to '{protocolMethodParameter.Name}' parameter in '{_operation.Name}' operation.");
        }

        private void CreateSpreadParameters(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            var model = inputParameter.Type as InputModelType;
            var requiredConvenienceMethodParameters = new List<Parameter>();
            var optionalConvenienceMethodParameters = new List<Parameter>();
            var conversion = new List<MethodBodyStatement>
            {
                Var(protocolMethodParameter.Name, New.Utf8JsonRequestContent(), out var requestContent),
                Var("writer", requestContent.JsonWriter, out var utf8JsonWriter),
                utf8JsonWriter.WriteStartObject()
            };

            while (model is not null)
            {
                foreach (var property in model.Properties)
                {
                    if (property is { IsReadOnly: true, IsDiscriminator: false, ConstantValue: null })
                    {
                        continue;
                    }

                    Parameter parameter = CreateSpreadParameter(inputParameter, property);

                    if (parameter.IsOptionalInSignature)
                    {
                        optionalConvenienceMethodParameters.Add(parameter);
                    }
                    else
                    {
                        requiredConvenienceMethodParameters.Add(parameter);
                    }

                    conversion.Add(CreatePropertySerializationStatement(property, utf8JsonWriter, parameter));
                }

                model = model.BaseModel;
            }

            conversion.Add(utf8JsonWriter.WriteEndObject());
            _conversions[protocolMethodParameter] = conversion;

            AddCreateMessageParameter(protocolMethodParameter);
            _protocolParameters.Add(protocolMethodParameter);
            _convenienceParameters.AddRange(requiredConvenienceMethodParameters.Concat(optionalConvenienceMethodParameters));
            _arguments[protocolMethodParameter] = requestContent;
        }

        private Parameter CreateSpreadParameter(InputParameter inputParameter, InputModelProperty property)
        {
            var parameterType = TypeFactory.GetInputType(_typeFactory.CreateType(property.Type));
            Parameter.CreateDefaultValue(ref parameterType, _typeFactory, property.ConstantValue, false, property.IsRequired, _keepClientDefaultValue, out _, out var defaultValue, out var initializer);
            var validation = property.IsRequired && initializer == null
                ? Parameter.GetValidation(parameterType, inputParameter.Location, false)
                : Validation.None;

            return new Parameter(property.Name, property.Description, parameterType, defaultValue, validation, initializer);
        }

        private void AddCreateMessageParameter(Parameter parameter) => _createMessageParameters.Add(parameter with {DefaultValue = null});

        private static MethodBodyStatement CreatePropertySerializationStatement(InputModelProperty property, Utf8JsonWriterExpression jsonWriter, Parameter parameter)
        {
            var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, parameter.Type, false);

            var propertyName = property.SerializedName;
            var writePropertyStatement = new[]
            {
                jsonWriter.WritePropertyName(propertyName),
                JsonSerializationMethodsBuilder.SerializeExpression(jsonWriter, valueSerialization, parameter)
            };

            var writeNullStatement = property.IsRequired ? jsonWriter.WriteNull(propertyName) : null;
            if (parameter.Type.IsNullable)
            {
                return new IfElseStatement(NotEqual(parameter, Null), writePropertyStatement, writeNullStatement);
            }

            return writePropertyStatement;
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter)
        {
            Parameter outputParameter;
            SerializationFormat serializationFormat;
            if (_operation.RequestMediaTypes?.Count > 1)
            {
                var name = inputParameter.Name.ToVariableName();
                var description = Parameter.CreateDescription(inputParameter, typeof(ContentType), _operation.RequestMediaTypes);
                outputParameter = new Parameter(name, description, typeof(ContentType), null, Validation.None, null, RequestLocation: RequestLocation.Header);
                serializationFormat = SerializationFormat.Default;

                AddCreateMessageParameter(outputParameter);
                _protocolParameters.Add(outputParameter);
                _convenienceParameters.Add(outputParameter);
            }
            else
            {
                outputParameter = Parameter.FromInputParameter(inputParameter, new CSharpType(typeof(ContentType), inputParameter.Type.IsNullable), _keepClientDefaultValue, _typeFactory);
                serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);

                AddParameter(inputParameter, outputParameter);
            }

            _requestPartsBuilder.AddHeaderPart(inputParameter, GetValueForProtocolArgument(inputParameter, outputParameter), serializationFormat);
        }

        private CSharpType ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputEnumType enumType => _typeFactory.CreateType(enumType.EnumValueType).WithNullable(enumType.IsNullable),
            InputModelType modelType => new CSharpType(typeof(object), modelType.IsNullable),
            _ => _typeFactory.CreateType(type).WithNullable(type.IsNullable)
        };

        private static RequestContextExpression IfCancellationTokenCanBeCanceled(CancellationTokenExpression cancellationToken)
            => new(new TernaryConditionalOperator(cancellationToken.CanBeCanceled, New.RequestContext(cancellationToken), Null));

        private IEnumerable<InputParameter> GetLegacySortedParameters()
            => _unsortedParameters.OrderByDescending(p => p is { IsRequired: true, DefaultValue: null });

        private IEnumerable<InputParameter> GetSortedParameters()
        {
            var keepCurrentDefaultValue = Configuration.MethodsToKeepClientDefaultValue.Contains(_operation.Name);
            var uriOrPathParameters = new Dictionary<string, InputParameter>();
            var requiredRequestParameters = new List<InputParameter>();
            var optionalRequestParameters = new List<InputParameter>();

            InputParameter? bodyParameter = null;
            InputParameter? contentTypeRequestParameter = null;

            foreach (var operationParameter in _unsortedParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body }:
                        bodyParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path }:
                        uriOrPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    case { IsRequired: true } when !keepCurrentDefaultValue:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                }
            }

            var orderedParameters = new List<InputParameter>();

            SortUriOrPathParameters(_operation.Uri, uriOrPathParameters, orderedParameters);
            SortUriOrPathParameters(_operation.Path, uriOrPathParameters, orderedParameters);
            orderedParameters.AddRange(requiredRequestParameters);
            if (bodyParameter is not null)
            {
                orderedParameters.Add(bodyParameter);
                if (contentTypeRequestParameter is not null)
                {
                    orderedParameters.Add(contentTypeRequestParameter);
                }
            }
            orderedParameters.AddRange(optionalRequestParameters);

            return orderedParameters;
        }

        private static void SortUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, InputParameter> requestParameters, ICollection<InputParameter> orderedParameters)
        {
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uriPart))
            {
                if (isLiteral)
                {
                    continue;
                }

                var text = span.ToString();
                if (requestParameters.TryGetValue(text, out var requestParameter))
                {
                    orderedParameters.Add(requestParameter);
                }
            }
        }

        private TypedValueExpression GetValueForProtocolArgument(InputParameter inputParameter, Parameter outputParameter)
        {
            if (_fields is null)
            {
                return outputParameter;
            }

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
                    var groupedByParameterType = _typeFactory.CreateType(groupedByInputParameter.Type);
                    var propertyName = groupedByParameterType.Implementation switch
                    {
                        ModelTypeProvider modelType => modelType.Fields.GetFieldByParameterName(outputParameter.Name)?.Name,
                        SchemaObjectType schemaObjectType => schemaObjectType.GetPropertyForGroupedParameter(inputParameter.Name).Declaration.Name,
                        _ => throw new InvalidOperationException($"Unexpected object type {groupedByParameterType.GetType()} for grouped parameter {outputParameter.Name}")
                    };

                    if (propertyName is null)
                    {
                        throw new InvalidOperationException($"Unable to find object property for grouped parameter {outputParameter.Name} in {groupedByParameterType.Name}");
                    }

                    var groupedByParameterName = groupedByInputParameter.Name.ToVariableName();
                    var groupedByParameterReference = new TypedMemberExpression(null, groupedByParameterName, groupedByParameterType);
                    return new TypedMemberExpression(groupedByParameterReference.NullConditional(), propertyName, outputParameter.Type);

                default:
                    return outputParameter;
            }
        }

        private void CreateConversionToRequestContent(InputParameter inputParameter, TypedValueExpression value, IReadOnlyDictionary<InputParameter, Parameter> parameters, out RequestContentExpression content, out MethodBodyStatement? conversions)
        {
            conversions = null;
            if (value.Type is { IsFrameworkType: false, Implementation: ModelTypeProvider { HasToRequestContentMethod: true } model })
            {
                content = new SerializableObjectTypeExpression(model, value).ToRequestContent();
                return;
            }

            switch (_operation.RequestBodyMediaType)
            {
                case BodyMediaType.Binary:
                    content = RequestContentExpression.Create(RemoveAllNullConditional(value));
                    break;

                case BodyMediaType.Text:
                    content = New.StringRequestContent(RemoveAllNullConditional(value));
                    break;

                case var _ when inputParameter.Kind == InputOperationParameterKind.Flattened:
                    GetConversionsForFlattenedParameter(parameters, out content, out conversions);
                    break;

                // [TODO] This case is added to minimize amount of changes
                case var _ when value.Type is { IsFrameworkType: true } && !Configuration.Generation1ConvenienceClient && !Configuration.AzureArm:
                    content = CreateRequestContentFromFrameworkType(value);
                    break;

                case BodyMediaType.Json:
                    CreateConversionToUtf8JsonRequestContent(inputParameter, value, out content, out conversions);
                    break;

                case BodyMediaType.Xml:
                    CreateConversionToXmlWriterRequestContent(inputParameter, value, out content, out conversions);
                    break;

                case var _ when value.Type is { IsFrameworkType: true }:
                    content = CreateRequestContentFromFrameworkType(value);
                    break;

                case var _ when value.Type is { Implementation: EnumType enumType }:
                    content = BinaryDataExpression.FromObjectAsJson(new EnumExpression(enumType, value).ToSerial());
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected body media type: {_operation.RequestBodyMediaType}");
            }
        }

        private static RequestContentExpression CreateRequestContentFromFrameworkType(TypedValueExpression value)
        {
            if (value.Type.FrameworkType == typeof(BinaryData))
            {
                return new RequestContentExpression(value);
            }

            if (TypeFactory.IsList(value.Type))
            {
                return RequestContentExpression.FromEnumerable(value);
            }

            if (TypeFactory.IsDictionary(value.Type))
            {
                return RequestContentExpression.FromDictionary(value);
            }

            return RequestContentExpression.FromObject(value);
        }

        private static void CreateConversionToUtf8JsonRequestContent(InputParameter inputParameter, TypedValueExpression value, out RequestContentExpression content, out MethodBodyStatement conversions)
        {
            var jsonSerialization = SerializationBuilder.BuildJsonSerialization(inputParameter.Type, value.Type);
            conversions = new[]
            {
                Var("content", New.Utf8JsonRequestContent(), out Utf8JsonRequestContentExpression utf8JsonContent),
                JsonSerializationMethodsBuilder.SerializeExpression(utf8JsonContent.JsonWriter, jsonSerialization, RemoveAllNullConditional(value)),
            };
            content = utf8JsonContent;
        }

        private static void CreateConversionToXmlWriterRequestContent(InputParameter inputParameter, TypedValueExpression value, out RequestContentExpression content, out MethodBodyStatement conversions)
        {
            var xmlSerialization = SerializationBuilder.BuildXmlSerialization(inputParameter.Type, value.Type);
            conversions = new[]
            {
                Var("content", New.XmlWriterContent(), out XmlWriterContentExpression xmlWriterContent),
                XmlSerializationMethodsBuilder.SerializeExpression(xmlWriterContent.XmlWriter, xmlSerialization, RemoveAllNullConditional(value)),
            };
            content = xmlWriterContent;
        }

        private void GetConversionsForFlattenedParameter(IReadOnlyDictionary<InputParameter, Parameter> parameters, out RequestContentExpression content, out MethodBodyStatement conversion)
        {
            var properties = new Dictionary<InputModelProperty, TypedValueExpression>();
            var conversions = new List<MethodBodyStatement>();
            foreach (var (inputParameter, outputParameter) in parameters)
            {
                if (inputParameter is not { FlattenedBodyProperty: {} property })
                {
                    continue;
                }

                CSharpType type = outputParameter.Type;
                // Special case to match behaviour of the new ChangeTrackingList<> which would be considered uninitialized when empty
                // It is not clear if that is expected behavior or just coincidence
                if (property is { IsRequired: false, Type.IsNullable: false } && TypeFactory.IsCollectionType(type))
                {
                    var changeTrackingListType = TypeFactory.IsDictionary(type)
                        ? new CSharpType(typeof(ChangeTrackingDictionary<,>), type.Arguments)
                        : new CSharpType(typeof(ChangeTrackingList<>), type.Arguments);

                    var enumerable = new EnumerableExpression(TypeFactory.GetElementType(outputParameter.Type), outputParameter);
                    conversions.Add(new IfStatement(Or(Equal(enumerable, Null), Not(enumerable.Any())))
                    {
                        new AssignValueStatement(enumerable, New.Instance(changeTrackingListType))
                    });
                }

                properties[property] = GetValueForProtocolArgument(inputParameter, outputParameter);
            }

            var serializations = SerializationBuilder.GetPropertiesForSerializationOnly(properties);
            conversion = new[]
            {
                conversions,
                Var("content", New.Utf8JsonRequestContent(), out var utf8JsonRequestContent),
                utf8JsonRequestContent.JsonWriter.WriteStartObject(),
                JsonSerializationMethodsBuilder.WriteProperties(utf8JsonRequestContent.JsonWriter, serializations).AsStatement(),
                utf8JsonRequestContent.JsonWriter.WriteEndObject()
            };
            content = utf8JsonRequestContent;
        }

        private static TypedValueExpression GetMultipartBodyValue(TypedValueExpression value)
        {
            var bodyPartType = value.Type;
            if (bodyPartType.Equals(typeof(string)))
            {
                return New.StringRequestContent(value);
            }

            if (bodyPartType.Equals(typeof(Stream)))
            {
                return RequestContentExpression.Create(value);
            }

            if (TypeFactory.IsList(bodyPartType))
            {
                return value;
            }

            throw new NotSupportedException();
        }
    }
}
