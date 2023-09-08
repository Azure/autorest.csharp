// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class OperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public OperationMethodsBuilder(OperationMethodsBuilderBaseArgs args)
            : base(args)
        {
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
            => WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(createMessageSignature), out var message),
                EnableHttpRedirectIfSupported(message),
                Return(PipelineField.ProcessMessage(message, new RequestContextExpression(KnownParameters.RequestContext), null, async))
            );

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(parameters, async).AsStatement())
                : CreateConvenienceMethodLogic(parameters, async).AsStatement();

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(RestClientMethodParameters parameters, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();

            yield return AddProtocolMethodArguments(parameters, protocolMethodArguments).ToArray();
            yield return Declare(ProtocolMethodReturnType, "response", InvokeProtocolMethod(null, protocolMethodArguments, async), out var response);

            if (ResponseType is null)
            {
                yield return Return(response);
            }
            else if (ResponseType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } serializableObjectType})
            {
                yield return Return(ResponseExpression.FromValue(SerializableObjectTypeExpression.FromResponse(serializableObjectType, response), response));
            }
            else if (ResponseType is { IsFrameworkType: false, Implementation: EnumType enumType})
            {
                yield return Return(ResponseExpression.FromValue(EnumExpression.ToEnum(enumType, response.Content.ToObjectFromJson(typeof(string))), response));
            }
            else if (TypeFactory.IsCollectionType(ResponseType))
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
