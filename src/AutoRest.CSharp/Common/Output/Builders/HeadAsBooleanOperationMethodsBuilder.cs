// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class HeadAsBooleanOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public HeadAsBooleanOperationMethodsBuilder(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, new StatusCodeSwitchBuilder(fields), clientMethodParameters)
        {

        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
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
    }
}
