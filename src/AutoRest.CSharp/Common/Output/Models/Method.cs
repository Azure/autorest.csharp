// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class Method
    {
        public MethodSignature Signature { get; }
        public IReadOnlyList<MethodBodyStatement>? Body { get; }
        public ValueExpression? BodyExpression { get; }

        public Method(MethodSignature signature, IReadOnlyList<MethodBodyStatement> body)
        {
            Signature = signature;
            Body = body;
        }

        public Method(MethodSignature signature, ValueExpression bodyExpression)
        {
            Signature = signature;
            BodyExpression = bodyExpression;
        }
    }
}
