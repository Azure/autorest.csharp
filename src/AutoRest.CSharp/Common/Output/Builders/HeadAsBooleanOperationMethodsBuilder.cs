// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class HeadAsBooleanOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public HeadAsBooleanOperationMethodsBuilder(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, GetReturnTypes(), clientMethodParameters)
        {

        }

        public override LegacyMethods BuildLegacy(CSharpType? headerModelType, CSharpType? lroType, CSharpType? resourceDataType)
        {
            var responseClassifier = new ResponseClassifierType(new[]{new StatusCodes(null, 2), new StatusCodes(null, 4)}.OrderBy(sc => sc.Family));

            var createRequestMethod = BuildCreateRequestMethod(responseClassifier);

            var restClientMethods = new[]
            {
                BuildRestClientConvenienceMethod(InvokeCreateRequestMethod(null), true),
                BuildRestClientConvenienceMethod(InvokeCreateRequestMethod(null), false)
            };

            var convenienceMethods = new[]
            {
                BuildLegacyConvenienceMethod(lroType, true),
                BuildLegacyConvenienceMethod(lroType, false)
            };

            return new LegacyMethods
            (
                createRequestMethod,
                null,
                restClientMethods,
                Array.Empty<Method>(),
                convenienceMethods,

                0,
                Operation,
                null,
                ResponseType
            );
        }

        protected override Method BuildLegacyConvenienceMethod(CSharpType? lroType, bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, ConvenienceModifiers, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var arguments = ConvenienceMethodParameters.Select(p => new ParameterReference(p)).ToList();
            var body = WrapInDiagnosticScopeLegacy(ProtocolMethodName, Return(InvokeProtocolMethod(RestClient, arguments, async)));

            return new Method(signature.WithAsync(async), body);
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            return WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(null), out var message),
                Return(PipelineField.ProcessHeadAsBoolMessage(message, ClientDiagnosticsProperty, CreateMessageRequestContext, async))
            );
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            throw new System.NotImplementedException();
        }

        private Method BuildRestClientConvenienceMethod(HttpMessageExpression invokeCreateRequestMethod, bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, MethodSignatureModifiers.Public, ConvenienceMethodParameters, typeof(Response<bool>));
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters, IsLegacy: true),
                UsingVar("message", invokeCreateRequestMethod, out var message),
                PipelineField.Send(message, new CancellationTokenExpression(KnownParameters.CancellationTokenParameter), async),
                new SwitchStatement(message.Response.Status, BuildStatusCodeSwitchCases(message, async))
            };

            return new Method(signature.WithAsync(async), body);
        }

        private SwitchCase[] BuildStatusCodeSwitchCases(HttpMessageExpression httpMessage, bool async)
        {
            return new[]
            {
                new SwitchCase(new[]{new FormattableStringToExpression($"int s when s >= 200 && s < 300")}, BuildHeadAsBooleanSwitchCaseStatement(httpMessage, True), AddScope: true),
                new SwitchCase(new[]{new FormattableStringToExpression($"int s when s >= 400 && s < 500")}, BuildHeadAsBooleanSwitchCaseStatement(httpMessage, False), AddScope: true),
                BuildDefaultStatusCodeSwitchCase(httpMessage, async)
            };
        }

        private static MethodBodyStatement BuildHeadAsBooleanSwitchCaseStatement(HttpMessageExpression httpMessage, BoolExpression valueConstant)
            => new MethodBodyStatement[]
            {
                new DeclareVariableStatement(typeof(bool), "value", valueConstant, out var value),
                Return(ResponseExpression.FromValue(value, httpMessage.Response))
            };

        private static OperationMethodReturnTypes GetReturnTypes() => new(typeof(bool), typeof(Response<bool>), typeof(Response<bool>));
    }
}
