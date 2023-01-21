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
        private readonly string _clientName;
        private readonly TypeFactory _typeFactory;
        private readonly RestClientMethod _createMessageMethod;
        private readonly RestClientMethod? _createNextPageMessageMethod;
        private readonly IReadOnlyDictionary<Parameter, InputParameter?> _outputToInputParameterMap;
        private readonly RequestConditionHeaders _conditionHeaderFlag;

        private InputOperation Operation { get; }

        public OperationMethodChainBuilder(InputOperation operation, string clientName, TypeFactory typeFactory, RestClientMethod createMessageMethod, RestClientMethod? createNextPageMessageMethod, IReadOnlyDictionary<Parameter, InputParameter?> outputToInputParameterMap, RequestConditionHeaders conditionHeaderFlag)
        {
            _clientName = clientName;
            _typeFactory = typeFactory;

            Operation = operation;
            _createMessageMethod = createMessageMethod;
            _createNextPageMessageMethod = createNextPageMessageMethod;
            _outputToInputParameterMap = outputToInputParameterMap;
            _conditionHeaderFlag = conditionHeaderFlag;
        }

        public LowLevelClientMethod BuildOperationMethodChain()
        {
            var returnTypeChain = BuildReturnTypes();
            var protocolMethodAttributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : Array.Empty<CSharpAttribute>();

            var protocolMethodParameters = _createMessageMethod.Parameters.ToList();
            AddWaitForCompletion(protocolMethodParameters);
            var protocolMethodSignature = new MethodSignature(_createMessageMethod.Name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, returnTypeChain.Protocol, null, protocolMethodParameters, protocolMethodAttributes);
            var convenienceMethod = ShouldConvenienceMethodGenerated(returnTypeChain) ? BuildConvenienceMethod(returnTypeChain) : null;

            var diagnostic = new Diagnostic($"{_clientName}.{_createMessageMethod.Name}");

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var protocolMethodPaging = Operation.Paging is { } paging && _createNextPageMessageMethod is not null
                ? new ProtocolMethodPaging(_createNextPageMessageMethod, paging.NextLinkName, paging.ItemName ?? "value")
                : null;

            return new LowLevelClientMethod(protocolMethodSignature, convenienceMethod, _createMessageMethod, requestBodyType, responseBodyType, diagnostic, protocolMethodPaging, Operation.LongRunning, _conditionHeaderFlag);
        }

        private bool ShouldConvenienceMethodGenerated(ReturnTypeChain returnTypeChain)
            => Operation.GenerateConvenienceMethod && (Operation.Parameters.Any(p => p.Type is InputEnumType or InputModelType) || !returnTypeChain.Convenience.Equals(returnTypeChain.Protocol));

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
            bool needNameChange = !Operation.Parameters.Any(p => p.Type is InputModelType or InputEnumType);
            string name = _createMessageMethod.Name;
            if (needNameChange)
            {
                name = _createMessageMethod.Name.IsLastWordSingular() ? $"{_createMessageMethod.Name}Value" : $"{_createMessageMethod.Name.LastWordToSingular()}Values";
            }
            var orderedParameters = _createMessageMethod.Parameters
                .Select(CreateConvenienceParameter)
                .ToList();

            var parameterList = new List<Parameter>();
            foreach (var parameterChain in orderedParameters)
            {
                if (parameterChain.Input?.Kind == InputOperationParameterKind.Spread)
                {
                    InputType type = parameterChain.Input.Type;
                    if (type is InputModelType modelType)
                    {
                        foreach (var prop in modelType.Properties)
                        {
                            var parameter = Parameter.FromModelProperty(prop, prop.Name.ToVariableName(), _typeFactory.CreateType(prop.Type));
                            parameterList.Add(parameter);
                        }
                    }

                } else if (parameterChain.Convenience != null)
                {
                    parameterList.Add(parameterChain.Convenience);
                }
            }
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;
            var protocolToConvenience = orderedParameters
                .Where(p => p.Protocol != null)
                .Select(p => (p.Protocol!, p.Convenience, p.Input))
                .ToArray();
            var convenienceSignature = new MethodSignature(name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, returnTypeChain.Convenience, null, parameterList, attributes);
            var diagnostic = name != _createMessageMethod.Name ? new Diagnostic($"{_clientName}.{convenienceSignature.Name}") : null;
            return new ConvenienceMethod(convenienceSignature, protocolToConvenience, returnTypeChain.ConvenienceResponseType, diagnostic);
        }

        private void AddWaitForCompletion(IList<Parameter> parameters)
        {
            if (Operation.LongRunning != null)
            {
                parameters.Insert(0, KnownParameters.WaitForCompletion);
            }
        }

        private ParameterChain CreateConvenienceParameter(Parameter protocolMethodParameter)
        {
            if (!_outputToInputParameterMap.TryGetValue(protocolMethodParameter, out var inputParameter))
            {
                return new ParameterChain(null, null, protocolMethodParameter, protocolMethodParameter);
            }

            if (inputParameter is null)
            {
                var convenienceParameter = protocolMethodParameter == KnownParameters.RequestContext
                    ? KnownParameters.CancellationTokenParameter
                    : null;

                return new ParameterChain(null, convenienceParameter, protocolMethodParameter, protocolMethodParameter);
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                return new ParameterChain(inputParameter, null, protocolMethodParameter, protocolMethodParameter);
            }

            var convenienceMethodParameter = BuildParameter(inputParameter);
            return inputParameter.Location == RequestLocation.None
                ? new ParameterChain(inputParameter, convenienceMethodParameter, null, null)
                : new ParameterChain(inputParameter, convenienceMethodParameter, protocolMethodParameter, protocolMethodParameter);
        }

        private Parameter BuildParameter(InputParameter operationParameter)
            => Parameter.FromInputParameter(operationParameter, _typeFactory.CreateType(operationParameter.Type), _typeFactory);

        private record ReturnTypeChain(CSharpType Convenience, CSharpType Protocol, CSharpType? ConvenienceResponseType);

        private record ParameterChain(InputParameter? Input, Parameter? Convenience, Parameter? Protocol, Parameter? CreateMessage);
    }
}
