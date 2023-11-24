// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class Method
    {
        public MethodSignatureBase Signature { get; }
        public MethodBodyStatement? Body { get; protected init; }
        public ValueExpression? BodyExpression { get; protected init; }

        public Method(MethodSignatureBase signature, MethodBodyStatement body)
        {
            Signature = signature;
            Body = body;
        }

        public Method(MethodSignatureBase signature, ValueExpression bodyExpression)
        {
            Signature = signature;
            BodyExpression = bodyExpression;
        }
    }
}
