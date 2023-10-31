// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
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
                Extensible.RestOperations.DeclareHttpMessage(createMessageSignature, out var message),
                EnableHttpRedirectIfSupported(message),
                Return(Extensible.RestOperations.InvokeServiceOperationCall(PipelineField, message, async))
            );

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(parameters, async).AsStatement())
                : CreateConvenienceMethodLogic(parameters, async).AsStatement();

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(RestClientMethodParameters parameters, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            yield return AddProtocolMethodArguments(parameters, protocolMethodArguments).ToArray();

            var response = new VariableReference(ProtocolMethodReturnType, Configuration.ApiTypes.ResponseParameterName);
            yield return Declare(response, InvokeProtocolMethod(null, protocolMethodArguments, async));

            if (ResponseType is null)
            {
                yield return Return(response);
            }
            else if (ResponseType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } serializableObjectType})
            {
                yield return Return(Extensible.RestOperations.GetTypedResponseFromModel(serializableObjectType, response));
            }
            else if (ResponseType is { IsFrameworkType: false, Implementation: EnumType enumType})
            {
                yield return Return(Extensible.RestOperations.GetTypedResponseFromEnum(enumType, response));
            }
            else if (TypeFactory.IsCollectionType(ResponseType))
            {
                var firstResponseBodyType = Operation.Responses.Where(r => r is { IsErrorResponse: false, BodyType: {} }).Select(r => r.BodyType).Distinct().First();
                var serialization = SerializationBuilder.BuildJsonSerialization(firstResponseBodyType!, ResponseType, false);
                var value = new VariableReference(ResponseType, "value");

                yield return new DeclareVariableStatement(value.Type, value.Declaration, Default);
                yield return JsonSerializationMethodsBuilder.BuildDeserializationForMethods(serialization, async, value, new ResponseExpression(response).ContentStream, false);
                yield return Return(Extensible.RestOperations.GetTypedResponseFromValue(value, response));
            }
            else if (ResponseType is { IsFrameworkType: true })
            {
                yield return Return(Extensible.RestOperations.GetTypedResponseFromBinaryDate(ResponseType.FrameworkType, response));
            }
        }
    }
}
