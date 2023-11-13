// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
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
            _keepClientDefaultValue = operation.KeepClientDefaultValue || Configuration.MethodsToKeepClientDefaultValue.Contains(operation.Name);
            _unsortedParameters = operation.Parameters
                .Where(rp => rp.Location != RequestLocation.Header || !IgnoredRequestHeader.Contains(rp.NameInRequest))
                .ToArray();

            _requestPartsBuilder = new RequestPartBuilder();
        }

        public RestClientMethodParameters BuildParameters(bool buildParametersForProtocolMethods)
        {
            var sortedForProtocolMethod = GetSortedParameters();
            if (!buildParametersForProtocolMethods)
            {
                return BuildParametersLegacy(Configuration.Generation1ConvenienceClient ? GetLegacySortedParameters() : sortedForProtocolMethod);
            }

            bool bodyIsAdded = false;
            List<(InputParameter, RequestConditionHeaders)>? requestConditionRequestParameters = null;

            AddWaitForCompletion();
            foreach (var inputParameter in sortedForProtocolMethod)
            {
                switch (inputParameter)
                {
                    case { Location: RequestLocation.Header } when ConditionRequestHeader.TryGetValue(inputParameter.NameInRequest, out var header):
                        if (inputParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionRequestParameters ??= new List<(InputParameter, RequestConditionHeaders)>();
                        requestConditionRequestParameters.Add((inputParameter, header));
                        break;
                    case { Location: RequestLocation.Body }:
                        if (!bodyIsAdded)
                        {
                            AddBodyParameter(inputParameter, sortedForProtocolMethod);
                            bodyIsAdded = true;
                        }
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true }:
                        AddContentTypeRequestParameter(inputParameter);
                        break;
                    case { Location: RequestLocation.Header } when SpecialHandledHeaders.IsNonParameterizedHeader(inputParameter.NameInRequest):
                        _requestPartsBuilder.AddNonParameterizedHeaderPart(inputParameter);
                        break;
                    case { IsApiVersion: true } when !Configuration.IsBranded:
                        // [TODO]: What provides value for api version if it is passed neither in operation nor in constructor?
                        break;
                    default:
                        AddReferenceAndParameter(inputParameter);
                        break;
                }
            }

            AddRequestConditionHeaders(requestConditionRequestParameters);
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
                    var parameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);
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
                        CreateConversionToRequestContent(inputParameter, value, parameters, false, out var content, out var conversions);
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

        private void AddRequestConditionHeaders(IReadOnlyList<(InputParameter Parameter, RequestConditionHeaders RequestCondition)>? requestConditions)
        {
            switch (requestConditions) {
                case null:
                    return;
                case [{RequestCondition: RequestConditionHeaders.IfMatch or RequestConditionHeaders.IfNoneMatch, Parameter: var inputParameter}]:
                    AddETagParameter(inputParameter);
                    return;
                case [{RequestCondition: RequestConditionHeaders.IfMatch}, {RequestCondition: RequestConditionHeaders.IfNoneMatch}]:
                    AddMatchConditionsParameter(requestConditions[0].Parameter, requestConditions[1].Parameter, false);
                    return;
                case [{RequestCondition: RequestConditionHeaders.IfNoneMatch}, {RequestCondition: RequestConditionHeaders.IfMatch}]:
                    AddMatchConditionsParameter(requestConditions[1].Parameter, requestConditions[0].Parameter, true);
                    return;
                default:
                    AddRequestConditionsParameter(requestConditions);
                    break;
            }
        }

        private void AddETagParameter(InputParameter inputParameter)
        {
            var type = new CSharpType(typeof(ETag), inputParameter.Type.IsNullable);
            var protocolParameter = Parameter.FromInputParameter(inputParameter, type, _keepClientDefaultValue, _typeFactory);
            var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);

            _requestPartsBuilder.AddHeaderPart(inputParameter, protocolParameter, serializationFormat);
            AddCreateMessageParameter(protocolParameter);
            _protocolParameters.Add(protocolParameter);

            AddETagConvenienceParameter(inputParameter, protocolParameter);
        }

        private void AddETagConvenienceParameter(InputParameter inputParameter, Parameter protocolParameter)
        {
            if (!Configuration.AzureArm && !Configuration.Generation1ConvenienceClient)
            {
                _convenienceParameters.Add(protocolParameter);
                return;
            }

            var convenienceParameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);
            _arguments[protocolParameter] = New.Instance(typeof(ETag), convenienceParameter);
            _convenienceParameters.Add(convenienceParameter);
        }

        private void AddMatchConditionsParameter(InputParameter ifMatchInputParameter, InputParameter ifNoneMatchInputParameter, bool reverseOrder)
        {
            var parameter = KnownParameters.MatchConditionsParameter;
            var serializationFormat = SerializationBuilder.GetSerializationFormat(ifMatchInputParameter.Type);
            if (serializationFormat == SerializationFormat.Default)
            {
                serializationFormat = SerializationBuilder.GetSerializationFormat(ifNoneMatchInputParameter.Type);
            }

            _requestPartsBuilder.AddMatchConditionsHeaderPart(parameter, serializationFormat);
            AddCreateMessageParameter(parameter);
            _protocolParameters.Add(parameter);

            AddMatchConditionsConvenienceParameter(ifMatchInputParameter, ifNoneMatchInputParameter, parameter, reverseOrder);
        }

        private void AddMatchConditionsConvenienceParameter(InputParameter ifMatchInputParameter, InputParameter ifNoneMatchInputParameter, Parameter protocolParameter, bool reverseOrder)
        {
            if (!Configuration.AzureArm && !Configuration.Generation1ConvenienceClient)
            {
                _convenienceParameters.Add(protocolParameter);
                return;
            }

            var ifMatchConvenienceParameter = Parameter.FromInputParameter(ifMatchInputParameter, _keepClientDefaultValue, _typeFactory);
            var ifNoneMatchConvenienceParameter = Parameter.FromInputParameter(ifNoneMatchInputParameter, _keepClientDefaultValue, _typeFactory);
            _arguments[protocolParameter] = New.Instance(typeof(MatchConditions), new Dictionary<string, ValueExpression>
            {
                [nameof(MatchConditions.IfMatch)] = New.Instance(typeof(ETag), ifMatchConvenienceParameter),
                [nameof(MatchConditions.IfNoneMatch)] = New.Instance(typeof(ETag), ifNoneMatchConvenienceParameter),
            });

            if (reverseOrder)
            {
                _convenienceParameters.Add(ifNoneMatchConvenienceParameter);
                _convenienceParameters.Add(ifMatchConvenienceParameter);
            }
            else
            {
                _convenienceParameters.Add(ifMatchConvenienceParameter);
                _convenienceParameters.Add(ifNoneMatchConvenienceParameter);
            }
        }

        private void AddRequestConditionsParameter(IReadOnlyList<(InputParameter Parameter, RequestConditionHeaders RequestCondition)> requestConditions)
        {
            var requestConditionFlag = requestConditions.Aggregate(RequestConditionHeaders.None, static (rcf, rc) => rcf | rc.RequestCondition);
            var parameter = KnownParameters.RequestConditionsParameter with
            {
                Validation = new Validation(ValidationType.AssertNull, requestConditionFlag)
            };

            var serializationFormat = requestConditions
                .Select(static rc => SerializationBuilder.GetSerializationFormat(rc.Parameter.Type))
                .FirstOrDefault(static sf => sf != SerializationFormat.Default, SerializationFormat.Default);

            _requestPartsBuilder.AddRequestConditionsHeaderPart(parameter, serializationFormat);
            AddCreateMessageParameter(parameter);
            _protocolParameters.Add(parameter);

            AddRequestConditionsConvenienceParameter(requestConditions, parameter);
        }

        private void AddRequestConditionsConvenienceParameter(IReadOnlyList<(InputParameter Parameter, RequestConditionHeaders RequestCondition)> requestConditions, Parameter protocolParameter)
        {
            if (!Configuration.AzureArm && !Configuration.Generation1ConvenienceClient)
            {
                _convenienceParameters.Add(protocolParameter);
                return;
            }

            var properties = new Dictionary<string, ValueExpression>();
            foreach (var (inputParameter, requestCondition) in requestConditions)
            {
                var convenienceParameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);
                var propertyName = requestCondition switch
                {
                    RequestConditionHeaders.IfMatch => nameof(RequestConditions.IfMatch),
                    RequestConditionHeaders.IfNoneMatch => nameof(RequestConditions.IfNoneMatch),
                    RequestConditionHeaders.IfModifiedSince => nameof(RequestConditions.IfModifiedSince),
                    RequestConditionHeaders.IfUnmodifiedSince => nameof(RequestConditions.IfUnmodifiedSince),
                    _ => throw new ArgumentOutOfRangeException()
                };

                properties[propertyName] = requestCondition switch
                {
                    RequestConditionHeaders.IfMatch or RequestConditionHeaders.IfNoneMatch => New.Instance(typeof(ETag), convenienceParameter),
                    RequestConditionHeaders.IfModifiedSince or RequestConditionHeaders.IfUnmodifiedSince => convenienceParameter,
                    _ => throw new ArgumentOutOfRangeException()
                };

                _convenienceParameters.Add(convenienceParameter);
            }

            _arguments[protocolParameter] = New.Instance(typeof(RequestConditions), properties);
        }

        private void AddRequestContext()
        {
            AddCreateMessageParameter(KnownParameters.RequestContext);
            _protocolParameters.Add(KnownParameters.RequestContext);
            _convenienceParameters.Add(KnownParameters.CancellationTokenParameter);

            var requestContext = new VariableReference(Configuration.ApiTypes.RequestContextType, KnownParameters.RequestContext.Name);
            _arguments[KnownParameters.RequestContext] = requestContext;

            if (_operation.Paging is not null || Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
            {
                _conversions[KnownParameters.RequestContext] = Declare(requestContext, IfCancellationTokenCanBeCanceled(new CancellationTokenExpression(KnownParameters.CancellationTokenParameter)));
            }
            else
            {
                _conversions[KnownParameters.RequestContext] = Declare(requestContext, new InvokeStaticMethodExpression(null, "FromCancellationToken", new ValueExpression[] { KnownParameters.CancellationTokenParameter }));
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
            var protocolMethodParameterType = ChangeTypeForProtocolMethod(inputParameter.Type);
            var protocolMethodParameter = Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(protocolMethodParameterType), _keepClientDefaultValue, _typeFactory);

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

            AddParameter(inputParameter, protocolMethodParameter);
        }

        private void AddParameter(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            if (inputParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                AddGroupedParameter(inputParameter, protocolMethodParameter);
                return;
            }

            if (inputParameter.Location == RequestLocation.None)
            {
                _convenienceParameters.Add(Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory));
                return;
            }

            var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);

            AddCreateMessageParameter(protocolMethodParameter);
            _protocolParameters.Add(protocolMethodParameter);
            _convenienceParameters.Add(convenienceMethodParameter);

            if (protocolMethodParameter.Equals(convenienceMethodParameter) || protocolMethodParameter.Type.Equals(convenienceMethodParameter.Type))
            {
                _arguments[protocolMethodParameter] = convenienceMethodParameter;
                return;
            }

            if (TryCreateConversionForEnum(convenienceMethodParameter, convenienceMethodParameter.IsOptionalInSignature, out var convertedValue))
            {
                _arguments[protocolMethodParameter] = convertedValue;
                return;
            }

            throw new InvalidOperationException($"Unexpected conversion from '{convenienceMethodParameter.Name}' parameter to '{protocolMethodParameter.Name}' parameter in '{_operation.Name}' operation.");
        }

        private void AddGroupedParameter(InputParameter inputParameter, Parameter protocolParameter)
        {
            AddCreateMessageParameter(protocolParameter);
            _protocolParameters.Add(protocolParameter);

            var value = GetValueForProtocolArgument(inputParameter, protocolParameter);
            if (TryCreateConversionForEnum(value, value.Type.IsNullable, out var convertedValue))
            {
                _arguments[protocolParameter] = convertedValue;
            }
            else
            {
                _arguments[protocolParameter] = value;
            }
        }

        private void CreateSpreadConvenienceParameters(InputParameter inputParameter, Parameter protocolMethodParameter)
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

        private void CreateMultipartConvenienceParameters(IReadOnlyList<InputParameter> sortedInputParameters, Parameter protocolBodyParameter)
        {
            var conversionStatements = new List<MethodBodyStatement>
            {
                Var("boundary", GuidExpression.NewGuid().InvokeToString(), out var boundary),
                Var("content", New.MultipartFormDataContent(boundary), out var multipartContent)
            };

            foreach (var inputParameter in sortedInputParameters.Where(p => p.Location == RequestLocation.Body))
            {
                var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);
                _convenienceParameters.Add(convenienceMethodParameter);


                MethodBodyStatement addPartStatement;
                if (TypeFactory.IsList(convenienceMethodParameter.Type))
                {
                    EnumerableExpression enumerable = new(TypeFactory.GetElementType(convenienceMethodParameter.Type), convenienceMethodParameter);
                    addPartStatement = new ForeachStatement("value", enumerable, out var item)
                    {
                        multipartContent.Add(RequestContentExpression.Create(item), inputParameter.NameInRequest, Null)
                    };
                }
                else
                {
                    RequestContentExpression value = new(GetMultipartBodyValue(convenienceMethodParameter));
                    addPartStatement = multipartContent.Add(value, inputParameter.NameInRequest, Null);
                }

                conversionStatements.Add(WrapInNullCheckIfRequired(convenienceMethodParameter, addPartStatement));
            }

            _arguments[protocolBodyParameter] = multipartContent;
            _conversions[protocolBodyParameter] = conversionStatements;

            _requestPartsBuilder.AddContentTypeHeaderPart(KnownParameters.ContentType);
            AddCreateMessageParameter(KnownParameters.ContentType);
            _protocolParameters.Add(KnownParameters.ContentType);
            _arguments[KnownParameters.ContentType] = new FormattableStringExpression("multipart/form-data; boundary={0}", new[]{boundary});
        }

        private void CreateFormUrlEncodedConvenienceParameters(IReadOnlyList<InputParameter> sortedInputParameters, Parameter protocolBodyParameter)
        {
            var conversionStatements = new List<MethodBodyStatement>
            {
                Var("content", New.FormUrlEncodedContent(), out var urlContent),
            };

            foreach (var inputParameter in sortedInputParameters.Where(p => p.Location == RequestLocation.Body))
            {
                var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, _keepClientDefaultValue, _typeFactory);
                _convenienceParameters.Add(convenienceMethodParameter);

                var addPartStatement = urlContent.Add(inputParameter.NameInRequest, ConvertToString(convenienceMethodParameter));
                conversionStatements.Add(WrapInNullCheckIfRequired(convenienceMethodParameter, addPartStatement));
            }

            _arguments[protocolBodyParameter] = urlContent;
            _conversions[protocolBodyParameter] = conversionStatements;

            static StringExpression ConvertToString(TypedValueExpression value)
            {
                if (value.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
                {
                    return new(new EnumExpression(enumType, value.NullableStructValue(value.Type)).ToSerial());
                }

                return value.Type.EqualsIgnoreNullable(typeof(string)) ? new(value) : value.NullableStructValue(value.Type).InvokeToString();
            }
        }

        private static MethodBodyStatement WrapInNullCheckIfRequired(Parameter parameter, MethodBodyStatement statement)
        {
            if (parameter.Validation.Type is ValidationType.AssertNotNull or ValidationType.AssertNotNullOrEmpty)
            {
                return statement;
            }

            return new IfStatement(NotEqual(parameter, Null)) { statement };
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

        private void AddBodyParameter(InputParameter firstInputBodyParameter, IReadOnlyList<InputParameter> sortedInputParameters)
        {
            var protocolBodyParameter = firstInputBodyParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable;
            _requestPartsBuilder.AddBodyPart(protocolBodyParameter, null, protocolBodyParameter, !Configuration.Generation1ConvenienceClient);

            if (firstInputBodyParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                // BUG: For constant bodies and bodies assigned from client, DPG still creates RequestContent parameter. Most likely, this is incorrect.
                if (Configuration.Generation1ConvenienceClient || Configuration.AzureArm)
                {
                    return;
                }
            }

            AddCreateMessageParameter(protocolBodyParameter);
            _protocolParameters.Add(protocolBodyParameter);

            if (firstInputBodyParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant or InputOperationParameterKind.Grouped)
            {
                _arguments[protocolBodyParameter] = GetValueForProtocolArgument(firstInputBodyParameter, protocolBodyParameter);
                return;
            }

            if (firstInputBodyParameter.Kind == InputOperationParameterKind.Spread)
            {
                CreateSpreadConvenienceParameters(firstInputBodyParameter, protocolBodyParameter);
                return;
            }

            // [TODO]: Remove Configuration.Generation1ConvenienceClient condition when multipart support design in DPG is finalized
            if (_operation.RequestBodyMediaType is BodyMediaType.Multipart && Configuration.Generation1ConvenienceClient)
            {
                CreateMultipartConvenienceParameters(sortedInputParameters, protocolBodyParameter);
                return;
            }

            // [TODO]: Remove Configuration.Generation1ConvenienceClient condition when multipart support design in DPG is finalized
            if (_operation.RequestBodyMediaType is BodyMediaType.Form && Configuration.Generation1ConvenienceClient)
            {
                CreateFormUrlEncodedConvenienceParameters(sortedInputParameters, protocolBodyParameter);
                return;
            }

            var convenienceMethodParameter = Parameter.FromInputParameter(firstInputBodyParameter, _keepClientDefaultValue, _typeFactory);
            _convenienceParameters.Add(convenienceMethodParameter);

            CreateConversionToRequestContent(firstInputBodyParameter, convenienceMethodParameter, null, convenienceMethodParameter.IsOptionalInSignature, out var argument, out var conversions);
            if (conversions is not null)
            {
                _arguments[protocolBodyParameter] = argument;
                _conversions[protocolBodyParameter] = conversions;
            }
            else
            {
                var requestContent = new VariableReference(Configuration.ApiTypes.RequestContentType, "content");
                // Don't dispose content for pageables
                _conversions[protocolBodyParameter] = _operation.Paging is not null ? Declare(requestContent, argument) : UsingDeclare(requestContent, argument);
                _arguments[protocolBodyParameter] = requestContent;
            }
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter)
        {
            // [TODO]: Remove Configuration.Generation1ConvenienceClient condition when multipart support design in DPG is finalized
            if (_operation.RequestBodyMediaType is BodyMediaType.Multipart && Configuration.Generation1ConvenienceClient)
            {
                // ContentType parameter has been added with body parameter
                return;
            }

            if (_operation.RequestMediaTypes?.Count > 1)
            {
                var name = inputParameter.Name.ToVariableName();
                var description = Parameter.CreateDescription(inputParameter, typeof(ContentType), _operation.RequestMediaTypes);
                var outputParameter = new Parameter(name, description, typeof(ContentType), null, Validation.None, null, RequestLocation: RequestLocation.Header);

                _requestPartsBuilder.AddHeaderPart(inputParameter, GetValueForProtocolArgument(inputParameter, outputParameter), SerializationFormat.Default);
                AddCreateMessageParameter(outputParameter);
                _protocolParameters.Add(outputParameter);
                _convenienceParameters.Add(outputParameter);
            }
            else
            {
                var outputParameter = Parameter.FromInputParameter(inputParameter, new CSharpType(typeof(ContentType), inputParameter.Type.IsNullable), _keepClientDefaultValue, _typeFactory);
                var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);

                _requestPartsBuilder.AddHeaderPart(inputParameter, GetValueForProtocolArgument(inputParameter, outputParameter), serializationFormat);
                AddParameter(inputParameter, outputParameter);
            }
        }

        private InputType ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputListType listType => listType with {ElementType = ChangeTypeForProtocolMethod(listType.ElementType)},
            InputDictionaryType dictionaryType => dictionaryType with {ValueType = ChangeTypeForProtocolMethod(dictionaryType.ValueType)},
            InputEnumType enumType => enumType.EnumValueType with {IsNullable = enumType.IsNullable},
            InputModelType modelType => InputPrimitiveType.Object with {IsNullable = modelType.IsNullable},
            _ => type
        };

        private static RequestContextExpression IfCancellationTokenCanBeCanceled(CancellationTokenExpression cancellationToken)
            => new(new TernaryConditionalOperator(cancellationToken.CanBeCanceled, New.RequestContext(cancellationToken), Null));

        private IEnumerable<InputParameter> GetLegacySortedParameters()
            => _keepClientDefaultValue
                ? _unsortedParameters.OrderByDescending(p => p is { IsRequired: true, DefaultValue: null })
                : _unsortedParameters.OrderByDescending(p => p is { IsRequired: true });

        private IReadOnlyList<InputParameter> GetSortedParameters()
        {
            var uriOrPathParameters = new Dictionary<string, InputParameter>();
            var requiredRequestParameters = new List<InputParameter>();
            var optionalRequestParameters = new List<InputParameter>();
            var bodyParameters = new List<InputParameter>();

            InputParameter? contentTypeRequestParameter = null;

            foreach (var operationParameter in _unsortedParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body }:
                        bodyParameters.Add(operationParameter);
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path }:
                        uriOrPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsApiVersion: true, DefaultValue: not null }:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    case { IsRequired: true } when !_keepClientDefaultValue:
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
            if (bodyParameters.Any())
            {
                orderedParameters.AddRange(bodyParameters.OrderByDescending(p => p is { IsRequired: true }));
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
                    var (propertyName, propertyType) = groupedByParameterType.Implementation switch
                    {
                        ModelTypeProvider modelType when modelType.Fields.GetFieldByParameterName(outputParameter.Name) is {} field => (field.Name, field.Type),
                        SchemaObjectType schemaObjectType when schemaObjectType.GetPropertyForGroupedParameter(inputParameter.Name).Declaration is {} declaration => (declaration.Name, declaration.Type),
                        _ => throw new InvalidOperationException($"Unable to find object property for grouped parameter {outputParameter.Name} in {groupedByParameterType.Name}")
                    };

                    var groupedByParameterName = groupedByInputParameter.Name.ToVariableName();
                    var groupedByParameterReference = new TypedMemberExpression(null, groupedByParameterName, groupedByParameterType);
                    return new TypedMemberExpression(groupedByParameterReference.NullConditional(), propertyName, propertyType);

                default:
                    return outputParameter;
            }
        }

        private bool TryCreateConversionForEnum(TypedValueExpression value, bool valueCanBeNull, [MaybeNullWhen(false)] out TypedValueExpression convertedValue)
        {
            if (value.Type is {IsFrameworkType: false, Implementation: EnumType enumType})
            {
                convertedValue = new EnumExpression(enumType, NullConditional(value, valueCanBeNull)).ToSerial();
                return true;
            }

            if (TypeFactory.IsList(value.Type, out var elementType) && elementType is {IsFrameworkType: false, Implementation: EnumType elementEnumType})
            {
                var element = new VariableReference(elementType, "e");
                var selector = new EnumExpression(elementEnumType, element).ToSerial();
                convertedValue = new EnumerableExpression(elementType, NullConditional(value, valueCanBeNull)).Select(new TypedFuncExpression(new[] { element.Declaration }, selector));
                return true;
            }

            convertedValue = null;
            return false;
        }

        private void CreateConversionToRequestContent(InputParameter inputParameter, TypedValueExpression value, IReadOnlyDictionary<InputParameter, Parameter>? parameters, bool valueCanBeNull, out TypedValueExpression content, out MethodBodyStatement? conversions)
        {
            conversions = null;
            if (value.Type is { IsFrameworkType: false, Implementation: ModelTypeProvider { HasToRequestBodyMethod: true }})
            {
                content = Extensible.Model.InvokeToRequestBodyMethod(NullConditional(value, valueCanBeNull));
                return;
            }

            switch (_operation.RequestBodyMediaType)
            {
                case BodyMediaType.Binary:
                    content = NullTernary(value, RequestContentExpression.Create(value), valueCanBeNull);
                    break;

                case BodyMediaType.Text:
                    content = NullTernary(value, New.StringRequestContent(value), valueCanBeNull);
                    break;

                case var _ when inputParameter.Kind == InputOperationParameterKind.Flattened:
                    GetConversionsForFlattenedParameter(parameters ?? throw new InvalidOperationException("Protocol parameters must be resolved"), out content, out conversions);
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
                    content = BinaryDataExpression.FromObjectAsJson(new EnumExpression(enumType, NullConditional(value, valueCanBeNull)).ToSerial());
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected body media type: {_operation.RequestBodyMediaType}");
            }
        }

        private static RequestContentExpression CreateRequestContentFromFrameworkType(TypedValueExpression value)
        {
            if (value.Type.FrameworkType == typeof(BinaryData))
            {
                return new BinaryDataExpression(value);
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

        private static TypedValueExpression NullTernary(TypedValueExpression value, TypedValueExpression content, bool valueCanBeNull)
            => valueCanBeNull ? new TypedTernaryConditionalOperator(NotEqual(value, Null), content, Null) : content;

        private static TypedValueExpression NullConditional(TypedValueExpression value, bool addNullConditional)
            => addNullConditional ? value.NullConditional() : value;

        private static void CreateConversionToUtf8JsonRequestContent(InputParameter inputParameter, TypedValueExpression value, out TypedValueExpression content, out MethodBodyStatement conversions)
        {
            var jsonSerialization = SerializationBuilder.BuildJsonSerialization(inputParameter.Type, value.Type);
            conversions = new[]
            {
                Var("content", New.Utf8JsonRequestContent(), out Utf8JsonRequestContentExpression utf8JsonContent),
                JsonSerializationMethodsBuilder.SerializeExpression(utf8JsonContent.JsonWriter, jsonSerialization, value),
            };
            content = utf8JsonContent;
        }

        private static void CreateConversionToXmlWriterRequestContent(InputParameter inputParameter, TypedValueExpression value, out TypedValueExpression content, out MethodBodyStatement conversions)
        {
            var xmlSerialization = SerializationBuilder.BuildXmlSerialization(inputParameter.Type, value.Type);
            conversions = new[]
            {
                Var("content", New.XmlWriterContent(), out XmlWriterContentExpression xmlWriterContent),
                XmlSerializationMethodsBuilder.SerializeExpression(xmlWriterContent.XmlWriter, xmlSerialization, value),
            };
            content = xmlWriterContent;
        }

        private void GetConversionsForFlattenedParameter(IReadOnlyDictionary<InputParameter, Parameter> parameters, out TypedValueExpression content, out MethodBodyStatement conversion)
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
