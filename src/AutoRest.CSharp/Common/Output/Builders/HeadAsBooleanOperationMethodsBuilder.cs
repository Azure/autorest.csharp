// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class HeadAsBooleanOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        public HeadAsBooleanOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, ClientMethodParameters clientMethodParameters)
            : base(args, clientMethodParameters)
        {

        }

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
        {
            return WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(), out var message),
                Return(PipelineField.ProcessHeadAsBoolMessage(message, ClientDiagnosticsProperty, CreateMessageRequestContext, async))
            );
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            throw new System.NotImplementedException();
        }
    }
}
