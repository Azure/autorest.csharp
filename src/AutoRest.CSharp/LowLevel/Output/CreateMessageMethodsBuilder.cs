// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal class CreateMessageMethodsBuilder
    {
        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private readonly TypeFactory _typeFactory;
        private readonly InputOperation _operation;
        private readonly ClientFields _fields;
        private readonly List<(Parameter OutputParameter, InputParameter? InputParameter)> _orderedParameters;
        private readonly List<RequestPartSource> _requestParts;

        private RequestConditionHeaders ConditionHeaderFlag { get; set; } = RequestConditionHeaders.None;
        private Parameter? BodyParameter { get; set; }
        private RestClientMethod? Method { get; set; }
        private IReadOnlyDictionary<Parameter, InputParameter?>? OutputToInputParameterMap { get; set; }

        public static IEnumerable<OperationMethodChainBuilder> BuildMethods(TypeFactory typeFactory, IEnumerable<InputOperation> operations, ClientFields fields, string clientName)
        {
            var createMessageMethod = new Dictionary<InputOperation, CreateMessageMethodsBuilder>();
            foreach (var inputOperation in operations)
            {
                var builder = new CreateMessageMethodsBuilder(typeFactory, inputOperation, fields);
                builder.BuildParameters();
                builder.BuildMethod();
                createMessageMethod[inputOperation] = builder;
            }

            foreach (var (operation, builder) in createMessageMethod)
            {
                RestClientMethod? nextPageMethod = default;
                if (operation.Paging is { NextLinkOperation: var nextLinkOperation, NextLinkName: var nextLinkName })
                {
                    nextPageMethod = nextLinkOperation != null
                        ? createMessageMethod[nextLinkOperation].Method
                        : nextLinkName != null
                            ? RestClientBuilder.BuildNextPageMethod(builder.Method!)
                            : null;

                }

                yield return new OperationMethodChainBuilder(operation, clientName, typeFactory, builder.Method!, nextPageMethod, builder.OutputToInputParameterMap!, builder.ConditionHeaderFlag);
            }
        }

        private CreateMessageMethodsBuilder(TypeFactory typeFactory, InputOperation operation, ClientFields fields)
        {
            _typeFactory = typeFactory;
            _operation = operation;
            _fields = fields;
            _orderedParameters = new List<(Parameter, InputParameter?)>();
            _requestParts = new List<RequestPartSource>();
        }

        private void BuildParameters()
        {
            var operationParameters = _operation.Parameters.Where(rp => !RestClientBuilder.IsIgnoredHeaderParameter(rp));

            var requiredPathParameters = new Dictionary<string, InputParameter>();
            var optionalPathParameters = new Dictionary<string, InputParameter>();
            var requiredRequestParameters = new List<InputParameter>();
            var optionalRequestParameters = new List<InputParameter>();

            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            InputParameter? bodyParameter = null;
            InputParameter? contentTypeRequestParameter = null;
            InputParameter? requestConditionRequestParameter = null;

            foreach (var operationParameter in operationParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body }:
                        bodyParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true }
                        when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header }
                        when ConditionRequestHeader.TryGetValue(operationParameter.NameInRequest, out var header):
                        if (operationParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= operationParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                                ? SerializationBuilder.GetSerializationFormat(operationParameter.Type)
                                : requestConditionSerializationFormat;
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: null }:
                        requiredPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: not null }:
                        optionalPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                }
            }

            AddUriOrPathParameters(_operation.Uri, requiredPathParameters);
            AddUriOrPathParameters(_operation.Path, requiredPathParameters);
            AddQueryOrHeaderParameters(requiredRequestParameters);
            AddBody(bodyParameter, contentTypeRequestParameter, _operation.RequestMediaTypes);
            AddUriOrPathParameters(_operation.Uri, optionalPathParameters);
            AddUriOrPathParameters(_operation.Path, optionalPathParameters);
            AddQueryOrHeaderParameters(optionalRequestParameters);
            AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter, requestConditionSerializationFormat);
            AddRequestContext();

            OutputToInputParameterMap = _orderedParameters.ToDictionary(p => p.OutputParameter, p => p.InputParameter);
        }

        private void BuildMethod()
        {
            Method = RestClientBuilder.BuildRequestMethod(_operation, _orderedParameters.Select(p => p.OutputParameter).ToArray(), _requestParts, BodyParameter, _typeFactory);
        }

        private void AddUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, InputParameter> requestParameters)
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
                    AddParameter(text, requestParameter);
                }
            }
        }

        private void AddQueryOrHeaderParameters(List<InputParameter> inputParameters)
        {
            foreach (var inputParameter in inputParameters)
            {
                AddParameter(inputParameter.NameInRequest, inputParameter);
            }
        }

        private void AddBody(InputParameter? inputBodyParameter, InputParameter? contentTypeRequestParameter, IReadOnlyList<string>? requestMediaTypes)
        {
            if (inputBodyParameter == null)
            {
                return;
            }

            BodyParameter = inputBodyParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable;
            _orderedParameters.Add((BodyParameter, inputBodyParameter));

            if (contentTypeRequestParameter == null)
            {
                return;
            }

            if (requestMediaTypes?.Count > 1)
            {
                AddContentTypeRequestParameter(contentTypeRequestParameter, requestMediaTypes);
            }
            else
            {
                AddParameter(contentTypeRequestParameter, typeof(ContentType));
            }
        }

        private void AddRequestConditionHeaders(RequestConditionHeaders conditionHeaderFlag, InputParameter? requestConditionRequestParameter, SerializationFormat serializationFormat)
        {
            if (conditionHeaderFlag == RequestConditionHeaders.None || requestConditionRequestParameter == null)
            {
                return;
            }

            ConditionHeaderFlag = conditionHeaderFlag;

            switch (conditionHeaderFlag)
            {
                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    _orderedParameters.Add((KnownParameters.MatchConditionsParameter, null));
                    AddReference(KnownParameters.MatchConditionsParameter.Name, null, KnownParameters.MatchConditionsParameter, serializationFormat);
                    break;
                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    AddParameter(requestConditionRequestParameter, typeof(ETag));
                    break;
                default:
                    _orderedParameters.Add((KnownParameters.RequestConditionsParameter, null));
                    AddReference(KnownParameters.RequestConditionsParameter.Name, null, KnownParameters.RequestConditionsParameter, serializationFormat);
                    break;
            }
        }

        private void AddRequestContext() => _orderedParameters.Add((KnownParameters.RequestContext, null));

        private void AddParameter(InputParameter inputParameter, CSharpType parameterTypeOverride)
            => AddParameter(inputParameter.NameInRequest, inputParameter, parameterTypeOverride.WithNullable(inputParameter.Type.IsNullable));

        private void AddParameter(string name, InputParameter inputParameter, CSharpType? parameterTypeOverride = null)
        {
            var outputParameter = BuildParameter(inputParameter, parameterTypeOverride);
            AddReference(name, inputParameter, outputParameter, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
            if (inputParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped || inputParameter.Location != RequestLocation.None)
            {
                _orderedParameters.Add((outputParameter, inputParameter));
            }
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter, IReadOnlyList<string> requestMediaTypes)
        {
            var name = inputParameter.Name.ToVariableName();
            var description = Parameter.CreateDescription(inputParameter, typeof(ContentType), requestMediaTypes);
            var parameter = new Parameter(name, description, typeof(ContentType), null, ValidationType.None, null, RequestLocation: RequestLocation.Header);
            _orderedParameters.Add((parameter, inputParameter));

            AddReference(inputParameter.NameInRequest, inputParameter, parameter, SerializationFormat.Default);
        }

        private void AddReference(string nameInRequest, InputParameter? inputParameter, Parameter parameter,
            SerializationFormat serializationFormat)
        {
            var reference = inputParameter != null ? CreateReference(inputParameter, parameter) : parameter;
            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter, reference, serializationFormat));
        }

        private Parameter BuildParameter(in InputParameter inputParameter, CSharpType? typeOverride = null)
        {
            var type = typeOverride ?? ChangeTypeForProtocolMethod(inputParameter.Type);
            return Parameter.FromInputParameter(inputParameter, type, _typeFactory);
        }

        private ReferenceOrConstant CreateReference(InputParameter operationParameter, Parameter parameter)
        {
            if (operationParameter.Kind == InputOperationParameterKind.Client)
            {
                var field = operationParameter.IsEndpoint
                    ? _fields.EndpointField
                    : _fields.GetFieldByParameter(parameter);
                if (field == null)
                {
                    throw new InvalidOperationException($"Parameter {parameter.Name} should have matching field");
                }

                return new Reference(field.Name, field.Type);
            }

            if (operationParameter.Kind == InputOperationParameterKind.Constant && parameter.DefaultValue != null)
            {
                return (ReferenceOrConstant)parameter.DefaultValue;
            }

            return parameter;
        }

        private CSharpType ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputEnumType enumType => _typeFactory.CreateType(enumType.EnumValueType).WithNullable(enumType.IsNullable),
            InputModelType modelType => new CSharpType(typeof(object), modelType.IsNullable),
            _ => _typeFactory.CreateType(type).WithNullable(type.IsNullable)
        };
    }
}
