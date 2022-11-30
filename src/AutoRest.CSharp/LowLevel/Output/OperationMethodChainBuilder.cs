// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Configuration = AutoRest.CSharp.Input.Configuration;

namespace AutoRest.CSharp.Output.Models
{
    internal class OperationMethodChainBuilder
    {
        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private readonly string _clientName;
        private readonly ClientFields _fields;
        private readonly TypeFactory _typeFactory;
        private readonly List<ParameterChain> _orderedParameters;
        private readonly List<RequestPartSource> _requestParts;
        private readonly RestClientMethod _restClientMethod;

        private Parameter? _protocolBodyParameter;
        private ProtocolMethodPaging? _protocolMethodPaging;
        private RequestConditionHeaders _conditionHeaderFlag = RequestConditionHeaders.None;

        public InputOperation Operation { get; }

        public OperationMethodChainBuilder(InputOperation operation, string clientName, ClientFields fields, TypeFactory typeFactory)
        {
            _clientName = clientName;
            _fields = fields;
            _typeFactory = typeFactory;
            _orderedParameters = new List<ParameterChain>();
            _requestParts = new List<RequestPartSource>();

            Operation = operation;
            BuildParameters();
            _restClientMethod = RestClientBuilder.BuildRequestMethod(Operation, _orderedParameters.Select(p => p.CreateMessage).WhereNotNull().ToArray(), _requestParts, _protocolBodyParameter, _typeFactory);
        }

        public void BuildNextPageMethod(IReadOnlyDictionary<InputOperation, OperationMethodChainBuilder> builders)
        {
            var paging = Operation.Paging;
            if (paging == null)
            {
                return;
            }

            var nextLinkOperation = paging.NextLinkOperation;
            var nextLinkName = paging.NextLinkName;

            RestClientMethod? nextPageMethod = nextLinkOperation != null
                ? builders[nextLinkOperation]._restClientMethod
                : nextLinkName != null
                    ? RestClientBuilder.BuildNextPageMethod(_restClientMethod)
                    : null;

            _protocolMethodPaging = new ProtocolMethodPaging(nextPageMethod, nextLinkName, paging.ItemName ?? "value");
        }

        public LowLevelClientMethod BuildOperationMethodChain()
        {
            var returnTypeChain = BuildReturnTypes();
            var protocolMethodParameters = _orderedParameters.Select(p => p.Protocol).WhereNotNull().ToArray();
            var protocolMethodSignature = new MethodSignature(_restClientMethod.Name, _restClientMethod.Summary, _restClientMethod.Description, _restClientMethod.Accessibility | Virtual, returnTypeChain.Protocol, null, protocolMethodParameters);
            var convenienceMethod = ShouldConvenienceMethodGenerated(returnTypeChain) ? BuildConvenienceMethod(returnTypeChain) : null;

            var diagnostic = new Diagnostic($"{_clientName}.{_restClientMethod.Name}");

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            return new LowLevelClientMethod(protocolMethodSignature, convenienceMethod, _restClientMethod, requestBodyType, responseBodyType, diagnostic, _protocolMethodPaging, Operation.LongRunning, _conditionHeaderFlag);
        }

        private bool ShouldConvenienceMethodGenerated(ReturnTypeChain returnTypeChain)
        {
            return Operation.GenerateConvenienceMethod
                && (_orderedParameters.Where(parameter => parameter.Convenience != KnownParameters.CancellationTokenParameter).Any(parameter => !IsParameterTypeSame(parameter.Convenience, parameter.Protocol))
                || !returnTypeChain.Convenience.Equals(returnTypeChain.Protocol));
        }

        private static bool IsParameterTypeSame(Parameter? first, Parameter? second) => first == null || second == null || first.Type.Equals(second.Type);

        private ReturnTypeChain BuildReturnTypes()
        {
            var operationBodyTypes = Operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().ToArray();
            CSharpType? responseType = null;
            if (operationBodyTypes.Length != 0)
            {
                var firstBodyType = operationBodyTypes[0];
                if (firstBodyType != null)
                {
                    responseType = _typeFactory.CreateType(firstBodyType);
                }
            }

            if (Operation.Paging != null)
            {
                if (responseType == null)
                {
                    throw new InvalidOperationException($"Method {Operation.Name} has to have a return value");
                }

                if (Operation.LongRunning != null)
                {
                    var convenienceMethodReturnType = new CSharpType(typeof(Operation<>), new CSharpType(typeof(Pageable<>), responseType));
                    return new ReturnTypeChain(convenienceMethodReturnType, typeof(Operation<Pageable<BinaryData>>), responseType);
                }

                return new ReturnTypeChain(new CSharpType(typeof(Pageable<>), responseType), typeof(Pageable<BinaryData>), responseType);
            }

            if (Operation.LongRunning != null)
            {
                if (responseType != null)
                {
                    return new ReturnTypeChain(new CSharpType(typeof(Operation<>), responseType), typeof(Operation<BinaryData>), responseType);
                }

                return new ReturnTypeChain(typeof(Operation), typeof(Operation), null);
            }

            var headAsBoolean = Operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            if (headAsBoolean)
            {
                return new ReturnTypeChain(typeof(Response<bool>), typeof(Response<bool>), null);
            }

            if (responseType != null)
            {
                return new ReturnTypeChain(new CSharpType(typeof(Response<>), responseType), typeof(Response), responseType);
            }

            return new ReturnTypeChain(typeof(Response), typeof(Response), null);
        }

        private ConvenienceMethod BuildConvenienceMethod(ReturnTypeChain returnTypeChain)
        {
            bool needNameChange = _orderedParameters.Where(parameter => parameter.Convenience != KnownParameters.CancellationTokenParameter).All(parameter => IsParameterTypeSame(parameter.Convenience, parameter.Protocol));
            string name = _restClientMethod.Name;
            if (needNameChange)
            {
                name = _restClientMethod.Name.IsLastWordSingular() ? $"{_restClientMethod.Name}Value" : $"{_restClientMethod.Name.LastWordToSingular()}Values";
            }

            var parameters = _orderedParameters.Select(p => p.Convenience).WhereNotNull().ToArray();
            var protocolToConvenience = _orderedParameters
                .Where(p => p.Protocol != null)
                .Select(p => (p.Protocol!, p.Convenience))
                .ToArray();

            var convenienceSignature = new MethodSignature(name, _restClientMethod.Summary, _restClientMethod.Description, _restClientMethod.Accessibility | Virtual, returnTypeChain.Convenience, null, parameters);
            var diagnostic = name != _restClientMethod.Name ? new Diagnostic($"{_clientName}.{convenienceSignature.Name}") : null;
            return new ConvenienceMethod(convenienceSignature, protocolToConvenience, returnTypeChain.ConvenienceResponseType, diagnostic);
        }

        private void BuildParameters()
        {
            var operationParameters = Operation.Parameters.Where(rp => !RestClientBuilder.IsIgnoredHeaderParameter(rp));

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
                    case { Location: RequestLocation.Header, IsContentType: true } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header } when ConditionRequestHeader.TryGetValue(operationParameter.NameInRequest, out var header):
                        if (operationParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        if (operationParameter.Kind != InputOperationParameterKind.Method)
                        {
                            throw new NotSupportedException("Conditional request headers should be specified only as method parameters.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= operationParameter;
                        if (header is RequestConditionHeaders.IfModifiedSince or RequestConditionHeaders.IfUnmodifiedSince)
                        {
                            requestConditionSerializationFormat = SerializationBuilder.GetSerializationFormat(operationParameter.Type);
                        }
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

            AddWaitForCompletion();
            AddUriOrPathParameters(Operation.Uri, requiredPathParameters);
            AddUriOrPathParameters(Operation.Path, requiredPathParameters);
            AddQueryOrHeaderParameters(requiredRequestParameters);
            AddBody(bodyParameter, contentTypeRequestParameter);
            AddUriOrPathParameters(Operation.Uri, optionalPathParameters);
            AddUriOrPathParameters(Operation.Path, optionalPathParameters);
            AddQueryOrHeaderParameters(optionalRequestParameters);
            AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter, requestConditionSerializationFormat);
            AddRequestContext();
        }

        private void AddWaitForCompletion()
        {
            if (Operation.LongRunning != null)
            {
                _orderedParameters.Add(new ParameterChain(KnownParameters.WaitForCompletion, KnownParameters.WaitForCompletion, null));
            }
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

        private void AddQueryOrHeaderParameters(IEnumerable<InputParameter> inputParameters)
        {
            foreach (var inputParameter in inputParameters)
            {
                AddParameter(inputParameter.NameInRequest, inputParameter);
            }
        }

        private void AddBody(InputParameter? bodyParameter, InputParameter? contentTypeRequestParameter)
        {
            if (bodyParameter == null)
            {
                return;
            }

            _protocolBodyParameter = bodyParameter.IsRequired
                ? KnownParameters.RequestContent
                : KnownParameters.RequestContentNullable;

            var convenienceBodyParameter = Parameter.FromInputParameter(bodyParameter, _typeFactory.CreateType(bodyParameter.Type), _typeFactory);
            _orderedParameters.Add(new ParameterChain(convenienceBodyParameter, _protocolBodyParameter, _protocolBodyParameter));

            if (contentTypeRequestParameter != null && Operation.RequestMediaTypes?.Count > 0)
            {
                AddContentTypeParameter(contentTypeRequestParameter, Operation.RequestMediaTypes);
            }
        }

        public void AddRequestConditionHeaders(RequestConditionHeaders conditionHeaderFlag, InputParameter? requestConditionRequestParameter, SerializationFormat serializationFormat)
        {
            if (conditionHeaderFlag == RequestConditionHeaders.None || requestConditionRequestParameter == null)
            {
                return;
            }

            _conditionHeaderFlag = conditionHeaderFlag;

            string nameInRequest;
            InputParameter? inputParameter;
            Parameter parameter;
            switch (conditionHeaderFlag)
            {
                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    inputParameter = null;
                    parameter = KnownParameters.MatchConditionsParameter;
                    nameInRequest = parameter.Name;
                    break;
                case RequestConditionHeaders.IfMatch or RequestConditionHeaders.IfNoneMatch:
                    inputParameter = requestConditionRequestParameter;
                    parameter = Parameter.FromInputParameter(inputParameter, new CSharpType(typeof(ETag), true), _typeFactory);
                    nameInRequest = inputParameter.NameInRequest;
                    break;
                default:
                    inputParameter = null;
                    parameter = KnownParameters.RequestConditionsParameter;
                    nameInRequest = parameter.Name;
                    break;
            }

            _orderedParameters.Add(new ParameterChain(parameter, parameter, parameter));
            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter, parameter, serializationFormat));
        }

        public void AddRequestContext()
        {
            _orderedParameters.Add(new ParameterChain(KnownParameters.CancellationTokenParameter, KnownParameters.RequestContext, KnownParameters.RequestContext));
        }

        private void AddContentTypeParameter(InputParameter inputParameter, IReadOnlyList<string> mediaTypes)
        {
            CSharpType parameterType = typeof(ContentType);
            if (mediaTypes.Count > 1) // ContentType parameter is added to protocol method only if there is more than one supported media type
            {
                var name = inputParameter.Name.ToVariableName();
                var description = Parameter.CreateDescription(inputParameter, parameterType, Operation.RequestMediaTypes);
                var parameter = new Parameter(name, description, parameterType, null, ValidationType.None, null, RequestLocation: RequestLocation.Header);

                _orderedParameters.Add(new ParameterChain(null, parameter, parameter));
                _requestParts.Add(new RequestPartSource(inputParameter.NameInRequest, inputParameter, parameter, SerializationFormat.Default));
            }
            else
            {
                var defaultValue = BuilderHelpers.StringConstant(mediaTypes[0]);
                _requestParts.Add(new RequestPartSource(inputParameter.NameInRequest, inputParameter, defaultValue, SerializationFormat.Default));
            }
        }

        private void AddParameter(string nameInRequest, InputParameter inputParameter)
        {
            var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);

            if (inputParameter.Kind == InputOperationParameterKind.Client)
            {
                AddRequestPartFromClient(nameInRequest, inputParameter, serializationFormat);
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Constant)
            {
                AddRequestPartFromConstant(nameInRequest, inputParameter, serializationFormat);
                return;
            }

            var parameterType = _typeFactory.CreateType(inputParameter.Type);
            var reference = new Reference(inputParameter.Name.ToVariableName(), parameterType);
            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter, reference, serializationFormat));

            var protocolMethodParameter = Parameter.FromInputParameter(inputParameter, ChangeTypeForProtocolMethod(inputParameter.Type) ?? parameterType, _typeFactory);
            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                _orderedParameters.Add(new ParameterChain(null, protocolMethodParameter, protocolMethodParameter));
                return;
            }

            var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, parameterType, _typeFactory);
            var parameterChain = inputParameter.Location == RequestLocation.None
                ? new ParameterChain(convenienceMethodParameter, null, null)
                : new ParameterChain(convenienceMethodParameter, protocolMethodParameter, protocolMethodParameter);

            _orderedParameters.Add(parameterChain);
        }

        private void AddRequestPartFromClient(string nameInRequest, InputParameter inputParameter, SerializationFormat serializationFormat)
        {
            var parameterName = inputParameter.Name.ToVariableName();
            var field = inputParameter.IsEndpoint
                ? _fields.EndpointField
                : _fields.GetFieldByParameter(parameterName, _typeFactory.CreateType(inputParameter.Type));
            if (field == null)
            {
                throw new InvalidOperationException($"Parameter {parameterName} should have matching field");
            }

            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter, new Reference(field.Name, field.Type), serializationFormat));
        }

        private void AddRequestPartFromConstant(string nameInRequest, InputParameter inputParameter, SerializationFormat serializationFormat)
        {
            var defaultValue = inputParameter.DefaultValue;
            if (defaultValue == null)
            {
                throw new InvalidOperationException($"Input parameter {inputParameter.Name} is defined as constant, but doesn't have a default value.");
            }

            var constant = BuilderHelpers.ParseConstant(defaultValue.Value, _typeFactory.CreateType(defaultValue.Type));
            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter, constant, serializationFormat));
        }

        private CSharpType? ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputEnumType enumType => _typeFactory.CreateType(enumType.EnumValueType).WithNullable(enumType.IsNullable),
            InputModelType modelType => new CSharpType(typeof(object), modelType.IsNullable),
            _ => null
        };

        private record ReturnTypeChain(CSharpType Convenience, CSharpType Protocol, CSharpType? ConvenienceResponseType);

        private record ParameterChain(Parameter? Convenience, Parameter? Protocol, Parameter? CreateMessage);
    }
}
