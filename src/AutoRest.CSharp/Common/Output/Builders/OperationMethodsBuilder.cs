// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Builders;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class OperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public OperationMethodsBuilder(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, GetReturnTypes(operation, typeFactory), clientMethodParameters)
        {
        }

        private static OperationMethodReturnTypes GetReturnTypes(InputOperation operation, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory);
            var protocol = typeof(Response);
            var convenience = responseType is not null ? new CSharpType(typeof(Response<>), responseType) : protocol;
            return new OperationMethodReturnTypes(responseType, protocol, convenience);
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            return WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(null), out var message),
                Return(PipelineField.ProcessMessage(message, CreateMessageRequestContext, null, async))
            );
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            return methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(async).AsStatement())
                : CreateConvenienceMethodLogic(async).AsStatement();
        }

        protected override Method BuildLegacyConvenienceMethod(CSharpType? lroType, bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var arguments = ConvenienceMethodParameters.Select(p => new ParameterReference(p)).ToList();
            var body = WrapInDiagnosticScopeLegacy(ProtocolMethodName, Return(InvokeProtocolMethod(RestClient, arguments, async)));

            return new Method(signature.WithAsync(async), body);
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
