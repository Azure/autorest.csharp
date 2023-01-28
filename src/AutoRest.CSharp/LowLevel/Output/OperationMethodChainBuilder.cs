// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
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
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly TypeFactory _typeFactory;
        private readonly RestClientMethod _createMessageMethod;
        private readonly RestClientMethod? _createNextPageMessageMethod;
        private readonly IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> _parameterLinks;
        private readonly RequestConditionHeaders _conditionHeaderFlag;
        private readonly IReadOnlyList<Parameter> _protocolMethodParameters;
        private readonly IReadOnlyList<Parameter> _convenienceMethodParameters;

        private InputOperation Operation { get; }

        public OperationMethodChainBuilder(InputOperation operation, ClientFields fields, string clientName, TypeFactory typeFactory, RestClientMethod createMessageMethod, RestClientMethod? createNextPageMessageMethod, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameterLinks, RequestConditionHeaders conditionHeaderFlag)
        {
            _fields = fields;
            _clientName = clientName;
            _typeFactory = typeFactory;

            Operation = operation;
            _createMessageMethod = createMessageMethod;
            _createNextPageMessageMethod = createNextPageMessageMethod;
            _parameterLinks = parameterLinks;
            _protocolMethodParameters = parameterLinks.SelectMany(p => p.ProtocolParameters).ToList();
            _convenienceMethodParameters = parameterLinks.SelectMany(p => p.ConvenienceParameters).ToList();
            _conditionHeaderFlag = conditionHeaderFlag;
        }

        public LowLevelClientMethod BuildOperationMethodChain()
        {
            var returnTypeChain = BuildReturnTypes();

            var protocolMethodSignature = BuildProtocolMethod(returnTypeChain, false).Signature;
            var methods = ShouldConvenienceMethodGenerated(returnTypeChain)
                ? new[]{ BuildConvenienceMethod(returnTypeChain, true), BuildConvenienceMethod(returnTypeChain, false) }
                : Array.Empty<Method>();

            var diagnostic = new Diagnostic($"{_clientName}.{_createMessageMethod.Name}");

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var protocolMethodPaging = Operation.Paging is { } paging ? new ProtocolMethodPaging(_createNextPageMessageMethod, paging.NextLinkName, paging.ItemName ?? "value") : null;
            return new LowLevelClientMethod(methods, protocolMethodSignature, _createMessageMethod, requestBodyType, responseBodyType, diagnostic, protocolMethodPaging, Operation.LongRunning, _conditionHeaderFlag);
        }

        private bool ShouldConvenienceMethodGenerated(ReturnTypeChain returnTypeChain)
        {
            if (!Operation.GenerateConvenienceMethod)
            {
                return false;
            }

            // Pageable LRO's aren't supported yet
            if (Operation.Paging != null && Operation.LongRunning != null)
            {
                return false;
            }

            if (!returnTypeChain.Convenience.Equals(returnTypeChain.Protocol))
            {
                return true;
            }

            return !_convenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter)
                .SequenceEqual(_protocolMethodParameters.Where(p => p != KnownParameters.RequestContext));
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

        private Method BuildProtocolMethod(ReturnTypeChain returnTypeChain, bool async)
        {
            var methodName = _createMessageMethod.Name;
            var signature = CreateProtocolMethodSignature(methodName, returnTypeChain, async);
            var body = new MethodBody(Array.Empty<MethodBodyBlock>());
            return new Method(signature, body);
        }

        private Method BuildConvenienceMethod(ReturnTypeChain returnTypeChain, bool async)
        {
            var needNameChange = _protocolMethodParameters.Where(p => !p.IsOptionalInSignature)
                .SequenceEqual(_convenienceMethodParameters.Where(p => !p.IsOptionalInSignature));

            string methodName = _createMessageMethod.Name;
            if (needNameChange)
            {
                methodName = methodName.IsLastWordSingular()
                    ? $"{methodName}Value"
                    : $"{methodName.LastWordToSingular()}Values";
            }

            var signature = CreateConvenienceMethodSignature(methodName, returnTypeChain, async);
            var body = CreateConvenienceMethodBody(methodName, returnTypeChain, async);
            return new Method(signature, body);
        }

        private MethodSignature CreateProtocolMethodSignature(string name, ReturnTypeChain returnTypeChain, bool async)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(_createMessageMethod.Name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, returnTypeChain.Protocol, null, _protocolMethodParameters, attributes).WithAsync(async);
        }

        private MethodSignature CreateConvenienceMethodSignature(string name, ReturnTypeChain returnTypeChain, bool async)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, returnTypeChain.Convenience, null, _convenienceMethodParameters, attributes).WithAsync(async);
        }

        private MethodBody CreateConvenienceMethodBody(string methodName, ReturnTypeChain returnTypeChain, bool async)
        {
            var lines = new List<MethodBodySingleLine>();
            var scopeName = $"{_clientName}.{methodName}";
            if (Operation.Paging is {} paging)
            {
                CodeWriterDeclaration? createNextPageRequest = null;

                lines.CreatePageableMethodArguments(_parameterLinks, out var createRequestArguments, out var requestContextVariable);
                lines.DeclareCreateFirstPageRequestLocalFunction(null, _createMessageMethod.Name, createRequestArguments, out var createFirstPageRequest);
                if (_createNextPageMessageMethod is not null)
                {
                    lines.DeclareCreateNextPageRequestLocalFunction(null, _createNextPageMessageMethod!.Name, createRequestArguments, out createNextPageRequest);
                }

                var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
                var pipeline = _fields.PipelineField.Declaration;
                lines.CallPageableHelpersCreatePageableAndReturn(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, returnTypeChain.ConvenienceResponseType, scopeName, paging.ItemName ?? "value", paging.NextLinkName, requestContextVariable, async);
                return new MethodBody(new MethodBodyBlock[] { new ParameterValidationBlock(_convenienceMethodParameters), new MethodBodyLines(lines) });
            }

            if (Operation.LongRunning != null)
            {
                lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
                if (returnTypeChain.ConvenienceResponseType != null)
                {
                    lines.CallProtocolMethod(_createMessageMethod.Name, protocolMethodArguments, returnTypeChain.Protocol, async, out var response);
                    lines.CallProtocolOperationHelpersConvertAndReturn(returnTypeChain.ConvenienceResponseType, response, _fields.ClientDiagnosticsProperty.Declaration, scopeName);
                }
                else
                {
                    lines.CallProtocolMethodAndReturn(_createMessageMethod.Name, protocolMethodArguments, async);
                }
            }
            else
            {
                lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
                if (returnTypeChain.ConvenienceResponseType != null)
                {
                    lines.CallProtocolMethod(_createMessageMethod.Name, protocolMethodArguments, returnTypeChain.Protocol, async, out var response);
                    lines.CallResponseFromValueAndReturn(returnTypeChain.ConvenienceResponseType, response);
                }
                else
                {
                    lines.CallProtocolMethod(_createMessageMethod.Name, protocolMethodArguments, returnTypeChain.Protocol, async, out var response);
                    lines.Add(new ReturnValueLine(new VariableReference(response)));
                }
            }

            MethodBodyBlock mainBodyBlock = new MethodBodyLines(lines);
            if (methodName != _createMessageMethod.Name)
            {
                mainBodyBlock = new DiagnosticScopeMethodBodyBlock(new Diagnostic(scopeName), _fields.ClientDiagnosticsProperty, mainBodyBlock);
            }

            return new MethodBody(new[] { new ParameterValidationBlock(_convenienceMethodParameters), mainBodyBlock });
        }

        private record ReturnTypeChain(CSharpType Convenience, CSharpType Protocol, CSharpType? ConvenienceResponseType);
    }
}
