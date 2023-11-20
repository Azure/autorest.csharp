// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal abstract class MethodBase
    {
        public MethodBodyStatement? Body { get; protected init; }
        public ValueExpression? BodyExpression { get; protected init; }
    }
}
