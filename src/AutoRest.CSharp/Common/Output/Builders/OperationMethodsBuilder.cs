// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class OperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        private readonly bool _headAsBoolean;
        private readonly RequestContextExpression? _requestContext;

        public OperationMethodsBuilder(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, GetReturnTypes(operation, typeFactory), clientMethodParameters)
        {
            _headAsBoolean = operation.HttpMethod == RequestMethod.Head && Input.Configuration.HeadAsBoolean;
            _requestContext = CreateMessageMethodParameters.Contains(KnownParameters.RequestContext)
                ? new RequestContextExpression(KnownParameters.RequestContext)
                : null;
        }

        private static ClientMethodReturnTypes GetReturnTypes(InputOperation operation, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory);
            var protocol = operation.HttpMethod == RequestMethod.Head && Input.Configuration.HeadAsBoolean ? typeof(Response<bool>) : typeof(Response);
            var convenience = responseType is not null ? new CSharpType(typeof(Response<>), responseType) : protocol;
            return new ClientMethodReturnTypes(responseType, protocol, convenience);
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            var pipeline = new HttpPipelineExpression(PipelineField);

            return WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(), out var message),
                _headAsBoolean
                    ? Return(pipeline.ProcessHeadAsBoolMessage(message, ClientDiagnosticsDeclaration, _requestContext, async))
                    : Return(pipeline.ProcessMessage(message, _requestContext, null, async))
            );
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            return methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(async).AsStatement())
                : CreateConvenienceMethodLogic(async).AsStatement();
        }

        protected override MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async)
        {
            var arguments = ConvenienceMethodParameters.Select(p => new ParameterReference(p)).ToList();
            var invokeRestClientMethod = InvokeProtocolMethod(RestClient, arguments, async);
            return WrapInDiagnosticScopeLegacy(ProtocolMethodName, Return(invokeRestClientMethod));
        }

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();

            yield return AddProtocolMethodArguments(protocolMethodArguments).ToArray();
            yield return Declare(ProtocolMethodReturnType, "response", InvokeProtocolMethod(null, protocolMethodArguments, async), out var response);

            if (ResponseType is null)
            {
                yield return Return(response);
            }
            else if (ResponseType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } serializableObjectType})
            {
                yield return Return(ResponseExpression.FromValue(SerializableObjectTypeExpression.FromResponse(serializableObjectType, response), response));
            }
            else if (TypeFactory.IsReadOnlyList(ResponseType))
            {
                var firstResponseBodyType = Operation.Responses.Where(r => r is { IsErrorResponse: false, BodyType: {} }).Select(r => r.BodyType).Distinct().First();
                var serialization = SerializationBuilder.BuildJsonSerialization(firstResponseBodyType!, ResponseType, false);

                yield return Declare(ResponseType, "value", new FrameworkTypeExpression(ResponseType, Default), out var value);
                yield return JsonSerializationMethodsBuilder.BuildDeserializationForMethods(serialization, async, value, response, false);
                yield return Return(ResponseExpression.FromValue(value, response));
            }
            else if (ResponseType is { IsFrameworkType: true })
            {
                yield return Return(ResponseExpression.FromValue(response.Content.ToObjectFromJson(ResponseType), response));
            }
        }
    }
}
