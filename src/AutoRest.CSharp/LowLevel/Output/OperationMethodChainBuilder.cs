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
using AutoRest.CSharp.Output.Models.Types;
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

        private InputOperation Operation { get; }

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
            var protocolMethodAttributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : Array.Empty<CSharpAttribute>();
            var protocolMethodParameters = _orderedParameters.Select(p => p.Protocol).WhereNotNull().ToArray();
            var protocolMethodSignature = new MethodSignature(_restClientMethod.Name, _restClientMethod.Summary, _restClientMethod.Description, _restClientMethod.Accessibility | Virtual, returnTypeChain.Protocol, null, protocolMethodParameters, protocolMethodAttributes);
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

        private bool IsParameterTypeSame(Parameter? first, Parameter? second)
        {
            if ((first == null && second != null)
                || (first != null && second == null))
            {
                return true;
            }

            if (first == null && second == null)
            {
                return true;
            }

            return first!.Type.Equals(second!.Type);
        }

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
            };

            if (Operation.Paging != null)
            {
                if (responseType == null)
                {
                    throw new InvalidOperationException($"Method {Operation.Name} has to have a return value");
                }

                if (!responseType.IsFrameworkType && responseType.Implementation is ModelTypeProvider modelType)
                {
                    var property = modelType.GetPropertyBySerializedName(Operation.Paging.ItemName ?? "value");
                    var propertyType = property.ValueType.WithNullable(false);
                    if (!TypeFactory.IsList(propertyType))
                    {
                        throw new InvalidOperationException($"'{modelType.Declaration.Name}.{property.Declaration.Name}' property must be a collection of items");
                    }

                    responseType = TypeFactory.GetElementType(property.ValueType);
                }
                else if (TypeFactory.IsList(responseType))
                {
                    responseType = TypeFactory.GetElementType(responseType);
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
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            var protocolToConvenience = new List<ProtocolToConvenienceParameterConverter>();
            var parameterList = new List<Parameter>();
            foreach (var parameterChain in _orderedParameters)
            {
                var protocolParameter = parameterChain.Protocol;
                var convenienceParameter = parameterChain.Convenience;
                if (convenienceParameter != null)
                {
                    if (parameterChain.IsSpreadParameter)
                    {
                        if (convenienceParameter.Type.TryCast<ModelTypeProvider>(out var model))
                        {
                            parameterList.AddRange(model.Fields.SerializationParameters);
                            protocolToConvenience.Add(new ProtocolToConvenienceParameterConverter(protocolParameter!, convenienceParameter, new ConvenienceParameterSpread(model, model.Fields.SerializationParameters)));
                        }
                        else
                        {
                            throw new InvalidOperationException($"The parameter {convenienceParameter.Name} is marked as Spread but its type is not ModelTypeProvider (got {convenienceParameter.Type})");
                        }
                    }
                    else
                    {
                        parameterList.Add(convenienceParameter);
                        if (protocolParameter != null)
                            protocolToConvenience.Add(new ProtocolToConvenienceParameterConverter(protocolParameter, convenienceParameter, null));
                    }
                }
            }
            var convenienceSignature = new MethodSignature(name, _restClientMethod.Summary, _restClientMethod.Description, _restClientMethod.Accessibility | Virtual, returnTypeChain.Convenience, null, parameterList, attributes);
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
                _orderedParameters.Add(new ParameterChain(KnownParameters.WaitForCompletion, KnownParameters.WaitForCompletion, null, false));
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
            _orderedParameters.Add(new ParameterChain(BuildParameter(bodyParameter), _protocolBodyParameter, _protocolBodyParameter, bodyParameter.Kind == InputOperationParameterKind.Spread));

            if (contentTypeRequestParameter != null)
            {
                if (Operation.RequestMediaTypes?.Count > 1)
                {
                    AddContentTypeRequestParameter(contentTypeRequestParameter, Operation.RequestMediaTypes);
                }
                else
                {
                    AddParameter(contentTypeRequestParameter, typeof(ContentType));
                }
            }
        }

        public void AddRequestConditionHeaders(RequestConditionHeaders conditionHeaderFlag, InputParameter? requestConditionRequestParameter, SerializationFormat serializationFormat)
        {
            if (conditionHeaderFlag == RequestConditionHeaders.None || requestConditionRequestParameter == null)
            {
                return;
            }

            _conditionHeaderFlag = conditionHeaderFlag;

            switch (conditionHeaderFlag)
            {
                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    _orderedParameters.Add(new ParameterChain(KnownParameters.MatchConditionsParameter, KnownParameters.MatchConditionsParameter, KnownParameters.MatchConditionsParameter));
                    AddReference(KnownParameters.MatchConditionsParameter.Name, null, KnownParameters.MatchConditionsParameter, serializationFormat);
                    break;
                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    AddParameter(requestConditionRequestParameter, typeof(ETag));
                    break;
                default:
                    _orderedParameters.Add(new ParameterChain(KnownParameters.RequestConditionsParameter, KnownParameters.RequestConditionsParameter, KnownParameters.RequestConditionsParameter));
                    AddReference(KnownParameters.RequestConditionsParameter.Name, null, KnownParameters.RequestConditionsParameter, serializationFormat);
                    break;
            }
        }

        public void AddRequestContext()
        {
            _orderedParameters.Add(new ParameterChain(KnownParameters.CancellationTokenParameter, KnownParameters.RequestContext, KnownParameters.RequestContext));
        }

        private void AddContentTypeRequestParameter(InputParameter operationParameter, IReadOnlyList<string> requestMediaTypes)
        {
            var name = operationParameter.Name.ToVariableName();
            var description = Parameter.CreateDescription(operationParameter, typeof(ContentType), requestMediaTypes);
            var parameter = new Parameter(name, description, typeof(ContentType), null, ValidationType.None, null, RequestLocation: RequestLocation.Header);
            _orderedParameters.Add(new ParameterChain(null, parameter, parameter));

            AddReference(operationParameter.NameInRequest, operationParameter, parameter, SerializationFormat.Default);
        }

        private void AddParameter(InputParameter operationParameter, CSharpType? frameworkParameterType = null)
            => AddParameter(operationParameter.NameInRequest, operationParameter, frameworkParameterType);

        private void AddParameter(string name, InputParameter inputParameter, CSharpType? frameworkParameterType = null)
        {
            var protocolMethodParameter = BuildParameter(inputParameter, frameworkParameterType ?? ChangeTypeForProtocolMethod(inputParameter.Type));

            AddReference(name, inputParameter, protocolMethodParameter, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
            if (inputParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                _orderedParameters.Add(new ParameterChain(null, protocolMethodParameter, protocolMethodParameter));
                return;
            }

            var convenienceMethodParameter = BuildParameter(inputParameter);
            var parameterChain = inputParameter.Location == RequestLocation.None
                ? new ParameterChain(convenienceMethodParameter, null, null)
                : new ParameterChain(convenienceMethodParameter, protocolMethodParameter, protocolMethodParameter);

            _orderedParameters.Add(parameterChain);
        }

        private Parameter BuildParameter(in InputParameter operationParameter, CSharpType? typeOverride = null)
        {
            var type = typeOverride != null
                ? typeOverride.WithNullable(operationParameter.Type.IsNullable)
                : _typeFactory.CreateType(operationParameter.Type);

            return Parameter.FromInputParameter(operationParameter, type, _typeFactory);
        }

        private void AddReference(string nameInRequest, InputParameter? operationParameter, Parameter parameter, SerializationFormat serializationFormat)
        {
            var reference = operationParameter != null ? CreateReference(operationParameter, parameter) : parameter;
            _requestParts.Add(new RequestPartSource(nameInRequest, operationParameter, reference, serializationFormat));
        }

        private ReferenceOrConstant CreateReference(InputParameter? operationParameter, Parameter parameter)
        {
            if (operationParameter?.Kind == InputOperationParameterKind.Client)
            {
                var field = operationParameter.IsEndpoint ? _fields.EndpointField : _fields.GetFieldByParameter(parameter);
                if (field == null)
                {
                    throw new InvalidOperationException($"Parameter {parameter.Name} should have matching field");
                }

                return new Reference(field.Name, field.Type);
            }

            if (operationParameter?.Kind == InputOperationParameterKind.Constant && parameter.DefaultValue != null)
            {
                return (ReferenceOrConstant)parameter.DefaultValue;
            }

            return parameter;
        }

        private CSharpType? ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputEnumType enumType => _typeFactory.CreateType(enumType.EnumValueType).WithNullable(enumType.IsNullable),
            InputModelType modelType => new CSharpType(typeof(object), modelType.IsNullable),
            _ => null
        };

        private record ReturnTypeChain(CSharpType Convenience, CSharpType Protocol, CSharpType? ConvenienceResponseType);

        private record ParameterChain(Parameter? Convenience, Parameter? Protocol, Parameter? CreateMessage, bool IsSpreadParameter = false);
    }
}
